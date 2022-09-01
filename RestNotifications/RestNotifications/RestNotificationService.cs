using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RestNotifications
{
    public class RestNotificationService
    {
        internal static void Notify()
        {
            //Pick a random number between 0 a 3
            Random random = new Random();
            int number = random.Next(0, 4);
            var dataUri = Path.GetFullPath(@"data.json");

            var toast = JsonConvert.DeserializeObject<List<Toast>>(File.ReadAllText(dataUri));

            var imageUri = Path.GetFullPath($@"images\{toast[number].image}");
            new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("label", "restNotification")
            .AddArgument("conversationId", 9813)
            .AddText(toast[number].name)
            .AddText(toast[number].message)
            .AddAppLogoOverride(new Uri(imageUri))
            .Show();
        }
    }
}
