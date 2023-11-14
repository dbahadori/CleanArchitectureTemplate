using CleanArchitectureReferenceTemplate.Application.Common.Interfaces;
using CleanArchitectureReferenceTemplate.Application.DTO.V1.Admin;
using CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Common.Components
{
    public class ExcelFileFromHttpRequestParser : IHttpFileParser
    {
        public IEnumerable<FileContentOutput> Parse(IFormFile file)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            try
            {
                var sheet = ExtractSheetFromFile(file);
                if (!IsSheetInCorrectFormat(sheet))
                    throw new FileTemplateException($"Excel File Template is not correct. Check all rows of tables", Resources.ErrorMessages.FileTemplateError);

                return GenerateOutputFromSheet(sheet);

            }
            catch (Exception)
            {
                throw new FileTemplateException($"Excel File Template is not correct. Check all rows of tables", Resources.ErrorMessages.FileTemplateError);
            }

        }

        private Dictionary<int, List<Tuple<int, object>>> ExtractSheetFromFile(IFormFile file)
        {
            Dictionary<int, List<Tuple<int, object>>> sheet = new Dictionary<int, List<Tuple<int, object>>>();

            using (var stream = file.OpenReadStream())
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    int records = 0;
                    do
                    {
                        while (reader.Read())
                        {
                            List<Tuple<int, object>> row = new List<Tuple<int, object>>();
                            for (int column = 0; column < reader.FieldCount; column++)
                            {
                                row.Add(new Tuple<int, object>(column, reader.GetValue(column)));
                            }
                            sheet.Add(records, row);
                            records++;
                        }
                    } while (reader.NextResult());
                }
            }
            return sheet;
        }

        // Check format of sheet. 
        // in this sample we only check the headers
        private bool IsSheetInCorrectFormat(Dictionary<int, List<Tuple<int, object>>> sheet)
        {
            var Content = sheet.Values.ToList();
            var headers = Content.First();

            if (headers[0]?.Item2?.ToString() != "Header1" ||
               headers[1]?.Item2?.ToString() != "Header2" ||
               headers[3]?.Item2?.ToString() != "Header3")
                return false;
            else return true;

        }
        private IEnumerable<FileContentOutput> GenerateOutputFromSheet(Dictionary<int, List<Tuple<int, object>>> sheet) 
        {
            // remove header
            var content = sheet.Values.ToList();
            content.RemoveAt(0);

            var outputModel = content.Select(content => new FileContentOutput()
            {
                Instructions = content[0].Item2?.ToString()!

            }).AsEnumerable();
            return outputModel;
        }
    }
}
