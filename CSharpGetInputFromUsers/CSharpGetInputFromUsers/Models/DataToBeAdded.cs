using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpGetInputFromUsers.Models
{
    [Serializable]
    public class Data
    {
        public DataType TypeOfData;
    }

    public enum DataType
    {
        [Describe("C# Concepts")]
        CSharpConcepts = 1,
        [Describe("C# Keywords")]
        CSharpKeyword = 2
    }
}