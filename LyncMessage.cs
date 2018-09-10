using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;

namespace CustomActivity
{
    [Designer(typeof(LyncDesigner))]
    public class LyncMessage : NativeActivity
    {
        public InArgument<string> ReciepientList { get; set; }
        public InArgument<string> Message { get; set; }
        protected override void Execute(NativeActivityContext context)
        {
            try
            {
                string[] arrRecepients = ReciepientList.Get(context).Split(';'); //add your recepients here
                LyncClient lyncClient = LyncClient.GetClient();
                Conversation conversation = lyncClient.ConversationManager.AddConversation();

                foreach (string recepient in arrRecepients)
                {
                    conversation.AddParticipant(lyncClient.ContactManager.GetContactByUri(recepient));
                }
                InstantMessageModality imModality = conversation.Modalities[ModalityTypes.InstantMessage] as InstantMessageModality;
                string message = Message.Get(context);//use your existing notification logic here
                imModality.BeginSendMessage(message, null, null);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
