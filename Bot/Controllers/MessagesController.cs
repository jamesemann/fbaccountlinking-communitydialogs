using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using Bot.Dialogs;

namespace Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
            {
                // State transition - Set Root Dialog
                await Conversation.SendAsync(activity, () => new MyFacebookLinkingDialog());
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }        
    }
}