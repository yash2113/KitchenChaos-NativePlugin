using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContactBase : MonoBehaviour
{
    //UI elements
    [SerializeField]
    private TextMeshProUGUI firtName;
    [SerializeField]
    private TextMeshProUGUI lastName;
    [SerializeField]
    private Button shareButton;

    // Email addresses associated with the contact
    private string[] email;

    // Set the first name text of the contact
    public void SetFirstName(string firstName)
    {
        this.firtName.text = firstName;
    }

    // Set the last name text of the contact
    public void SetLastName(string lastName)
    {
        this.lastName.text = lastName;
    }

    // Set the visibility of the share button
    public void SetShareButtonActive(bool shareButtonActive)
    {
        shareButton.gameObject.SetActive(shareButtonActive);
    }

    // Set the email addresses associated with the contact
    public void SetEmail(string[] emails)
    {
        this.email = emails;
    }

    // Handle the button click to send an email
    public void SendEmailButtonClicked()
    {
        // Call the SendEmail function in IG_Sharing script
        // Assuming IG_Sharing is accessible through instance
        IG_Sharing.instance.SendEmail(email, "Hey " + firtName.text + ", you've got to try 'Kitchen Chaos'! It's this super fun cooking game where you race against the clock to whip up dishes on the fly. The kitchen gets crazy, but it's a blast mastering the chaos and becoming a virtual chef. Totally addictive!");
    }


}
