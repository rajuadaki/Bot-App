using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.FormFlow;
using CSharpGetInputFromUsers.Models;
using Microsoft.Bot.Connector;
using System.Threading;

namespace CSharpGetInputFromUsers.Dialogs
{
    [Serializable]
    public class DataToBeAddedDialog : IDialog<object>
    {
        private const string keyword = "C# Keyword";
        private const string concept = "C# Concept";
       
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result; // We've got a message!
            if (message.Text.ToLower().Contains(keyword.ToLower()))
            {
                // User said 'order', so invoke the New Order Dialog and wait for it to finish.
                // Then, call ResumeAfterNewOrderDialog.
                await context.Forward(new CSharpKeywordsDialog(), this.CSharpKeywordsDialog, message, CancellationToken.None);
            }
            else if (message.Text.ToLower().Contains(concept.ToLower()))
                {
                    // User said 'order', so invoke the New Order Dialog and wait for it to finish.
                    // Then, call ResumeAfterNewOrderDialog.
                    await context.Forward(new CSharpConceptsDialog(), this.CSharpConceptsDialog, message, CancellationToken.None);
                }
            else
            {
                this.ShowOptions(context);
            }
            // User typed something else; for simplicity, ignore this input and wait for the next message.
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task CSharpConceptsDialog(IDialogContext context, IAwaitable<object> result)
        {
            var resultFromCSharpConcept = await result;

            await context.PostAsync($"You have just told me this: {resultFromCSharpConcept}");

            // Again, wait for the next message from the user.
            context.Wait(this.MessageReceivedAsync);
        }

        private void ShowOptions(IDialogContext context)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() {keyword,concept }, "what you want to teach me?","Not a valid option",3);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                string optionSelected = await result;

                switch (optionSelected)
                {
                    case keyword:
                        context.Call(new CSharpKeywordsDialog(), this.ResumeAfterOptionDialog);
                        break;

                    case concept:
                        context.Call(new CSharpConceptsDialog(), this.ResumeAfterOptionDialog);
                        break;
                }
            }
            catch (TooManyAttemptsException ex)
            {
                await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");

                context.Wait(this.MessageReceivedAsync);
            }
        }
        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = await result;
            }
            catch (Exception ex)
            {
                await context.PostAsync($"Failed with message: {ex.Message}");
            }
            finally
            {
                context.Wait(this.MessageReceivedAsync);
            }
        }

        private async Task CSharpKeywordsDialog(IDialogContext context, IAwaitable<object> result)
        {
            var resultFromCSharpKeyword = await result;

            await context.PostAsync($"You have just told me this: {resultFromCSharpKeyword}");

            // Again, wait for the next message from the user.
            context.Wait(this.MessageReceivedAsync);
        }
    }
}