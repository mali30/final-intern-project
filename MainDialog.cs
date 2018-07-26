using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Pluralsight.CustomerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Pluralsight.CustomerService.Dialogs
{
    public class MainDialog
    {                                                // Takes message we get from user and runs it through the chain
        public static readonly IDialog<string> dialog = Chain.PostToChain().
           Select(msg => msg.Text). // here we are selecting the text
           Switch( // here we are searching through the text for the word hi.
               new RegexCase<IDialog<string>>(new Regex("^hi", RegexOptions.IgnoreCase), (context, txt) =>
              {
                  // then we continue on in the chain to the greeting dialog
                  // takes in two variables, dialog we want to chain to and what gets called
                  // after the dialog is finished
                  return Chain.ContinueWith(new GreetingDialog(), AfterGreetingContinuation);
              }),
               new DefaultCase<string, IDialog<string>>((context, txt) =>
              {
                  return Chain.ContinueWith(FormDialog.FromForm(BugReport.BuildForm, FormOptions.PromptInStart), AfterGreetingContinuation);

              })).Unwrap().PostToUser();

        private async static Task<IDialog<string>> AfterGreetingContinuation(IBotContext context, IAwaitable<object> res)
        {
            var token = await res;
            var name = "User";
            context.UserData.TryGetValue<string>("Name", out name);
            return Chain.Return($"Thank you will get back to you shortly{name}");

        }
    }
}