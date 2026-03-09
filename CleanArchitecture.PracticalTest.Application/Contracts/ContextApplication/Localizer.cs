using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication
{
    public class Localizer : ILocalizer
    {
        public string GetValidationMessage(string key, params object[] args) => key;
        public string GetLoggerMessage(string key, params object[] args) => key;
        public string GetExceptionMessage(string key, params object[] args) => key;
        public string GetResponseMessage(string key, params object[] args) => key;
        public string GetDomainConcept(string key, params object[] args) => key;
        public string GetEnumValue(string key, params object[] args) => key;
    }
}
