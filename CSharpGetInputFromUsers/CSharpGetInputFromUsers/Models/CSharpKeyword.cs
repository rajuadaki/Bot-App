using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpGetInputFromUsers.Models
{
    [Serializable]
    public class CSharpKeyword
    {
        public string KeywordName { get; set; }
        public string Definition { get; set; }
        public bool UsedInClassDeclaration { get; set; }
        public string ClassDeclarationFeatures { get; set; }
        public string ClassDeclarationExample { get; set; }
        public bool UsedInMethodDeclaration { get; set; }
        public string MethodDeclarationFeatures { get; set; }
        public string MethodDeclarationExample { get; set; }
        public bool  UsedInPropertyDeclaration { get; set; }
        public string PropertyDeclarationFeatures { get; set; }
        public string PropertyDeclarationExample { get; set; }
        public string OtherInformation { get; set; }
    }
}