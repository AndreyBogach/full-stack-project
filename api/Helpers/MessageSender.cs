using api.Models;
using System;
using Twilio;
using Twilio.Base;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace api.Helpers
{
    public class MessageSender
    {
        readonly string _accountSid = "AC18bb1d16ec111db4479d623b470e6b9e";
        readonly string _authToken = "1faf2a228750093d2217f888d2a5e7d8";

        public OperationResult SendSMS(string user_phone, string text)
        {
            TwilioClient.Init(_accountSid, _authToken);

            try
            {
                var message = MessageResource.Create(
                to: new PhoneNumber(user_phone),
                from: new PhoneNumber("+17027452483"),
                body: text);
            }
            catch(Exception ex) { return OperationResult.CreateWithError(ex.Message); }

            return OperationResult.CreateWithSuccess();
        }

        public ResourceSet<MessageResource> ReadAllSMS(string date)
        {
            DateTime timeSent;

            if (!DateTime.TryParse(date, out timeSent))
                timeSent = DateTime.Today;

            TwilioClient.Init(_accountSid, _authToken);

            try
            {
                return MessageResource.Read(dateSent: timeSent);
            }
            catch (Exception ex) { return null; }
        }
    }
}