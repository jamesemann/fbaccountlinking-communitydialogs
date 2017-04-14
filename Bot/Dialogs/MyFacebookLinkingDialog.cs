using CommunityDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace Bot.Dialogs
{
    [Serializable]
    public class MyFacebookLinkingDialog :
        FacebookAccountLinkingDialog
    {
        public MyFacebookLinkingDialog() : 
            base(@"https://pizzalogin.azurewebsites.net/login")
        {
        }

        public override async Task Linked(IDialogContext context, IMessageActivity argument, string authorizationCode)
        {
            var reply = context.MakeMessage();
            reply.Text = $"BOT: Linked AUTH ID {authorizationCode}";
            await context.PostAsync(reply);
        }

        public override async Task Unlinked(IDialogContext context, IMessageActivity argument)
        {
            var reply = context.MakeMessage();
            reply.Text = $"BOT: Unlinked";
            await context.PostAsync(reply);
        }
    }
}