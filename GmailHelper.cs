using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public class GmailHelper
{
    private GmailService service;

    public GmailHelper()
    {
        service = GetGmailService();
    }

    private GmailService GetGmailService()
    {
        if (!File.Exists("credentials.json"))
        {
            throw new FileNotFoundException("The 'credentials.json' file is missing. Please add it to the application directory.");
        }
        UserCredential credential;

        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            string credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                new[] { GmailService.Scope.GmailModify },
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
        }

        return new GmailService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "Gmail API Trash Script",
        });
    }

    public string TrashAllFromSender(string senderEmail)
    {
        string query = $"from:{senderEmail}";
        var allMessageIds = new List<string>();
        string pageToken = "";

        do
        {
            var request = service.Users.Messages.List("me");
            request.Q = query;
            request.PageToken = pageToken;
            request.MaxResults = 100;

            var response = request.Execute();
            if (response.Messages != null && response.Messages.Count > 0)
            {
                allMessageIds.AddRange(response.Messages.Select(m => m.Id));
            }

            pageToken = response.NextPageToken;
        }
        while (!string.IsNullOrEmpty(pageToken));

        if (allMessageIds.Count == 0)
        {
            return $"No messages found from {senderEmail}.";
        }

        const int batchSize = 1000;
        for (int i = 0; i < allMessageIds.Count; i += batchSize)
        {
            var chunk = allMessageIds.Skip(i).Take(batchSize).ToList();
            var batchModifyRequest = new BatchModifyMessagesRequest
            {
                Ids = chunk,
                AddLabelIds = new List<string> { "TRASH" }
            };

            service.Users.Messages.BatchModify(batchModifyRequest, "me").Execute();
        }

        return $"Successfully moved {allMessageIds.Count} messages from {senderEmail} to Trash.";
    }
}
