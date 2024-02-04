using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit;

public class IG_AddressBookService : MonoBehaviour
{
    // Static instance for singleton pattern
    public static IG_AddressBookService instance;

    // Variable to store the access status of the address book contacts
    AddressBookContactsAccessStatus status;

    // Array to store all address book contacts
    public IAddressBookContact[] allContacts; //IG_AddressBookService.instance.allContacts[index];

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the instance to this object
        instance = this;
    }

    //IG_AddressBookService.instance.ReadContacts();
    public void ReadContacts()
    {
        // Get the access status of the address book contacts
        status = AddressBook.GetContactsAccessStatus();

        // If access status is not determined, request contacts access
        if (status == AddressBookContactsAccessStatus.NotDetermined)
        {
            AddressBook.RequestContactsAccess(callback: OnRequestContactsAccessFinish);
        }

        // If access status is authorized, read the contacts
        if (status == AddressBookContactsAccessStatus.Authorized)
        {
            AddressBook.ReadContacts(OnReadContactsFinish);
        }
    }

    // Callback method when the request for contacts access is finished
    private void OnRequestContactsAccessFinish(AddressBookRequestContactsAccessResult result, Error error)
    {
        Debug.Log("Request for contacts access finished.");
        Debug.Log("Address book contacts access status: " + result.AccessStatus);

        // If access status is authorized after request, read the contacts
        if (result.AccessStatus == AddressBookContactsAccessStatus.Authorized)
        {
            AddressBook.ReadContacts(OnReadContactsFinish);
        }
    }

    // Callback method when reading contacts is finished
    private void OnReadContactsFinish(AddressBookReadContactsResult result, Error error)
    {
        // If there is no error, store the contacts in the array
        if (error == null)
        {
            allContacts = result.Contacts;

            var contacts = result.Contacts;
            Debug.Log("Request to read contacts finished successfully.");
            Debug.Log("Total contacts fetched: " + contacts.Length);
            Debug.Log("Below are the contact details (capped to first 10 results only):");

            // Log details of the first 10 contacts
            for (int iter = 0; iter < contacts.Length && iter < 10; iter++)
            {
                Debug.Log(string.Format("[{0}]: {1}", iter, contacts[iter]));
            }
        }
        else
        {
            // Log an error if reading contacts fails
            Debug.Log("Request to read contacts failed with error. Error: " + error);
        }
    }
}
