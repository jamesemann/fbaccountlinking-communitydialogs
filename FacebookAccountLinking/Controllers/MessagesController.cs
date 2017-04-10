using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;
using CommunityDialogs;

namespace WebViews
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            if (activity != null)
            {
                // State transition - Set Root Dialog
                await Conversation.SendAsync(activity, () => new MyFacebookAccountLinkingDialog());
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }
    }

    [Serializable]
    public class MyFacebookAccountLinkingDialog : FacebookAccountLinkingDialog
    {
        public MyFacebookAccountLinkingDialog() : base("Login to your account", @"https://pizzadeliverybot.azurewebsites.net/fakelogin")
        {
        }

        public override async Task Linked(IDialogContext context, IMessageActivity argument)
        {
            var reply = context.MakeMessage();

            reply.Text = "dialog: user just linked!";

            await context.PostAsync(reply);
        }

        public override async Task Unlinked(IDialogContext context, IMessageActivity argument)
        {
            var reply = context.MakeMessage();

            reply.Text = "dialog: user just unlinked!";

            await context.PostAsync(reply);
        }
    }
}