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
    [Serializable]
    public class CSharpKeywordsDialog : IDialog<object>
    {
        
        public Task StartAsync(IDialogContext context)
        {
            context.PostAsync("hey it's time to learn new CSharp Keyword");
            var keywordForm = FormDialog.FromForm(this.buildKeywordForm, FormOptions.PromptInStart);

            context.Call(keywordForm, this.ResumeAfterKeywordDialog);
            return Task.CompletedTask;
        }

        private async Task ResumeAfterKeywordDialog(IDialogContext context, IAwaitable<CSharpKeyword> result)
        {
            context.PostAsync($"You just added this info {result}");
            context.Done(result);
        }

        private IForm<CSharpKeyword> buildKeywordForm()
        {
            OnCompletionAsyncDelegate<CSharpKeyword> processHotelsSearch = async (context, state) =>
            {
                await context.PostAsync($"Ok. you have added {state.KeywordName}  {state.Definition}");
            };

            return new FormBuilder<CSharpKeyword>()
                .Field(nameof(CSharpKeyword.KeywordName))
                .Message("Let me know more about {KeywordName}...")
                .AddRemainingFields()
                .OnCompletion(processHotelsSearch)
                .Build();
        }

    }
}