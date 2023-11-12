
using System.Reflection;


namespace CleanArchitectureReferenceTemplate.Infrastructure.Common
{
    public class InfrastructureHelper
    {
        public static string? GetInfrastructureDirectory()
        {
            string solutiondir = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
            string infrastructureProjectName = "CleanArchitectureTemplate.Infrastructure";
            var infrastructureDirectory = solutiondir + "\\" + infrastructureProjectName ;

            return infrastructureDirectory;
        }
    }
}
