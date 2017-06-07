using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using CSharpGetInputFromUsers.Models;
using Microsoft.Bot.Builder.FormFlow;

namespace CSharpGetInputFromUsers.Dialogs
{
    public class CSharpConceptsDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            throw new NotImplementedException();
        }
        public static IDialog<CSharpConcepts> Concept()
        {
            return Chain.From(() => FormDialog.FromForm(BuildForm));
        }
        private static IForm<CSharpConcepts> BuildForm()
        {
            return new FormBuilder<CSharpConcepts>()
                    .Build();
        }
    }
}