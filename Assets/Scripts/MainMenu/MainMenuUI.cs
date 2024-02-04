using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    //Buttons for play and Quit
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button quitButton;

    //Buttons and UI elements for address and mail share
    [SerializeField]
    private Button shareButton;
    [SerializeField]
    private Button backToMenuButton;
    [SerializeField]
    private ContactBase contactBase;
    [SerializeField]
    private Transform contactContainer;
    [SerializeField]
    private Transform contactContent;
    [SerializeField]
    private Button askAgainShareButton;
    [SerializeField]
    private Transform askAgainText;

    //Test email address
    private string[] mailTest = { "abc@gmail.com" };

    //Flag to track if contacts are loaded
    private bool ifGotContacts = false;

    private void Awake()
    {
        //Set up click listeners for play and quit buttons
        playButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        //ensure normal time scale
        Time.timeScale = 1f;
    }


    //Method to handle share button click
    public void OnShareClick()
    {
        //Hide play and quit button
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        //Show back to menu, ask again and contact UI elements
        backToMenuButton.gameObject.SetActive(true);
        askAgainShareButton.gameObject.SetActive(true);
        askAgainText.gameObject.SetActive(true);
        contactContainer.gameObject.SetActive(true);

        //Open share Contact UI
        OpenShareContact();

        //Hide the share button
        shareButton.gameObject.SetActive(false);

        // If contacts are already loaded, hide ask again elements
        if (ifGotContacts)
        {
            askAgainShareButton.gameObject.SetActive(false);
            askAgainText.gameObject.SetActive(false);
        }

        // Set flag to true indicating contacts are loaded
        ifGotContacts = true;
    }

    // Method to handle back to menu button click
    public void BackToTheMenu()
    {
        // Show play and quit buttons
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);

        // Hide contact UI elements and ask again elements
        contactContainer.gameObject.SetActive(false);
        backToMenuButton.gameObject.SetActive(false);
        shareButton.gameObject.SetActive(true);
        askAgainShareButton.gameObject.SetActive(false);
        askAgainText.gameObject.SetActive(false);

    }

    // Method to open the share contact UI
    private void OpenShareContact()
    {
        // Check if contacts are not already loaded
        if (!ifGotContacts)
        {
            Debug.Log("All contact length provided is " + IG_AddressBookService.instance.allContacts.Length);

            // Instantiate contact bases in the contact content
            for (int i = 0; i < IG_AddressBookService.instance.allContacts.Length + 1; i++)
            {
                Instantiate(contactBase.gameObject, contactContent);
            }

            // Get all contact bases in the content
            ContactBase[] allContactBases = contactContent.GetComponentsInChildren<ContactBase>();
            Debug.Log("Total no of contact bases is " + allContactBases.Length);

            // Set the first contact base to not have a share button 
            allContactBases[0].SetShareButtonActive(false);

            // Loop through address book contacts and set corresponding values in contact bases
            for (int i = 0; i < IG_AddressBookService.instance.allContacts.Length; i++)
            {
                allContactBases[i + 1].SetFirstName(IG_AddressBookService.instance.allContacts[i].FirstName);
                allContactBases[i + 1].SetLastName(IG_AddressBookService.instance.allContacts[i].LastName);
                allContactBases[i + 1].SetEmail(IG_AddressBookService.instance.allContacts[i].EmailAddresses);

                //To Test if mail composer is working, remove the line when building the game
                allContactBases[i + 1].SetEmail(mailTest);

            }
            // Hide ask again elements
            askAgainShareButton.gameObject.SetActive(false);
            askAgainText.gameObject.SetActive(false);

        }
        else
        {
            // Contacts are already loaded, return
            return;
        }
    }



}
