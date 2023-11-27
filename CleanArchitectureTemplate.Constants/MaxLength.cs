using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Constants
{
    public static class MaxLength : object
    {
        static MaxLength() { }

        public const int Url = 256;
        public const int IP = 15;

        public const int CultureName = 5;

        public const int EmailBody = 4000;
        public const int EmailSubject = 100;

        public const int UserName = 30;
        public const int Password = 30;
        public const int FullName = 100;



        


    }
}
