using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DataDisplayer : MonoBehaviour
{
    
    public GameObject launchPanelPrefab; // Prefab for launch data display object
    private LaunchDatabase launchesData; // Launch database to be referenced
    public LaunchDataLoader loader; // Loader which loads data using API
    public Transform contentPanel; // Panel to instantiate launch data display objects in list form


    // Begin to wait for the data to be accessed and parsed
    void Start()
    {
        StartCoroutine(WaitForDataAndDisplay());
    }


    IEnumerator WaitForDataAndDisplay()
    {
        // Wait till the get request has finished
        yield return loader.LoadLaunchData("https://api.spacexdata.com/v5/launches");

        // Get the launch data
        launchesData = loader.getLaunchData();

        if (launchesData.launches == null || launchesData.launches.Count == 0)
        {
            Debug.LogError("No launches found in the data!");
        }

        // Display the launch information
        displayLaunchInfo();
    }



    void displayLaunchInfo()
    {     
        foreach (var launch in launchesData.launches) {
            // Instantiate a new entry to list of launches
            GameObject newEntry = Instantiate(launchPanelPrefab, contentPanel.transform);

            // Find Name TextMeshProUGUI element in that entry
            TextMeshProUGUI nameTMP = newEntry.transform.Find("NamePanel/Name")?.GetComponent<TextMeshProUGUI>();

            // Find Payloads TextMeshProUGUI element in that entry
            TextMeshProUGUI payloadsTMP = newEntry.transform.Find("PayloadsPanel/Payloads")?.GetComponent<TextMeshProUGUI>();

            // Set data
            setName(nameTMP, launch.name);
            setPayloads(payloadsTMP, launch.payloads);
        }
        

    }

    // Access and display launch name
    void setName(TextMeshProUGUI nameTMP, String launchName)
    {
        nameTMP.text = launchName;
    }
    
    // Access and display number of payloads
    void setPayloads(TextMeshProUGUI payloadsTMP, String[] launchPayloads)
    {
        int numPayloads = launchPayloads.Count();
        payloadsTMP.text = Convert.ToString(numPayloads);
    }
}
