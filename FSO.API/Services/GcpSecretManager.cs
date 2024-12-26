using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.SecretManager.V1;
using Google.Protobuf;
//using Microsoft.AspNetCore.DataProtection;
//using static System.Net.Mime.MediaTypeNames;

namespace FSO.API.Services;

public class QuickstartSample
{

    public static string Quickstart()
    {
        string? projectId = "YOUR-PROJECT_ID-GOES-HERE";
        string secretId = "CONNECTION_STRING";
        string secretVersionId = "latest";

        // Create the client.
        SecretManagerServiceClient client = SecretManagerServiceClient.Create();

        // Build the parent project name.
        ProjectName projectName = new ProjectName(projectId);

       
        // Add a secret version.
        //SecretVersion createdVersion = client.AddSecretVersion(createdSecret.SecretName, payload);
        SecretVersionName secretVersionName = new SecretVersionName(projectId, secretId, secretVersionId);

        // Access the secret version.
        AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);

        // Print the results
        //
        // WARNING: Do not print secrets in production environments. This
        // snippet is for demonstration purposes only.
        string data = result.Payload.Data.ToStringUtf8();
  
        return data;

    }

}