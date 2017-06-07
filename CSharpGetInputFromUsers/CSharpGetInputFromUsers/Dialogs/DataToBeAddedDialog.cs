using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.FormFlow;
using CSharpGetInputFromUsers.Models;

namespace CSharpGetInputFromUsers.Dialogs
{
    public class DataToBeAddedDialog
    {
        private static IForm<Data> BuildForm()
        {
            return new FormBuilder<Data>()
                    .Message(@"Thanks for your valuable time, 
                                PLease give us inputs on C# Which may help many people in 
                                future. Please Limit this BOT to C#, 
                                Please give correct inputs to the system so that it should't mislead others,
                                your inputs are re-verified before uploading, 
                                Please select which type of info you want to give to the world")
                    .Build();
        }

        public static IDialog<Data> TypeOfData()
        {
            return Chain.From(() => FormDialog.FromForm(BuildForm));
        }
    }
}