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
            context.PostAsync("hey it's time to learn new CSharp Concept");
            var keywordForm = FormDialog.FromForm(this.buildConceptForm, FormOptions.PromptInStart);

            context.Call(keywordForm, this.ResumeAfterConceptDialog);
            return Task.CompletedTask;
        }

        private async Task ResumeAfterConceptDialog(IDialogContext context, IAwaitable<CSharpConcepts> result)
        {
            context.PostAsync($"You just added this info {result}");
            context.Done(result);
        }

        private IForm<CSharpConcepts> buildConceptForm()
        {
            OnCompletionAsyncDelegate<CSharpConcepts> processCSharpConcepts = async (context, state) =>
            {
                await context.PostAsync($"Ok. you have added {state.ConceptName}  {state.Explanation}");
            };

            return new FormBuilder<CSharpConcepts>()
                .Field(nameof(CSharpConcepts.ConceptName))
                .Message("Let me know more about {KeywordName}...")
                .AddRemainingFields()
                .OnCompletion(processCSharpConcepts)
                .Build();
        }
    }
}