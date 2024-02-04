using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit;

public class IG_Sharing : MonoBehaviour
{
    public static IG_Sharing instance;
    [SerializeField] private string subject;

    private void Start()
    {
        instance = this;
    }

    public void SendEmail(string[] recipient, string body)
    {
        if (MailComposer.CanSendMail())
        {
            // Create a new instance of MailComposer
            MailComposer composer = MailComposer.CreateInstance();

            // Set email recipients, subject, body, etc.
            composer.SetToRecipients(recipient);
            composer.SetSubject(subject);
            composer.SetBody(body, false);

            // Set a completion callback to handle the result when the composer is closed
            composer.SetCompletionCallback(OnMailComposerClosed);

            // Show the email composer interface
            composer.Show();
        }
        else
        {
            // Device doesn't support sending emails
            // Handle accordingly (e.g., show a message to the user)
            Debug.LogWarning("Device doesn't support sending emails.");
        }
    }

    private void OnMailComposerClosed(MailComposerResult result, Error error)
    {
        // Handle the result and error here
        Debug.Log("Mail composer was closed. Result code: " + result.ResultCode);
    }
}
