using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DataDisplayer : MonoBehaviour
{
    
    public GameObject launchPanel; // Prefab for launch data display object

    private LaunchDatabase launchesData; // Launch database to be referenced
    public LaunchDataLoader loader; // Loader which loads data using API


    // Begin to wait for the data to be accessed and parsed
    void Start()
    {
        StartCoroutine(WaitForDataAndDisplay());
    }


    IEnumerator WaitForDataAndDisplay()
    {
        // Wait till the get request has finished
        yield return loader.LoadLaunchData("https://api.spacexdata.com/v4/launches");

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
    // Find Name TextMeshProUGUI
    TextMeshProUGUI nameTMP = launchPanel.transform.Find("NamePanel/Name")?.GetComponent<TextMeshProUGUI>();

    // Find Payloads TextMeshProUGUI
    TextMeshProUGUI payloadsTMP = launchPanel.transform.Find("PayloadsPanel/Payloads")?.GetComponent<TextMeshProUGUI>();

    // Set data
    setName(nameTMP);
    setPayloads(payloadsTMP);

    }

    // Access and display launch name
    void setName(TextMeshProUGUI nameTMP)
    {
        nameTMP.text = launchesData.launches[5].name;
    }
    
    // Access and display number of payloads
    void setPayloads(TextMeshProUGUI payloadsTMP)
    {
        String[] payLoadsList = launchesData.launches[5].payloads;
        int numPayloads = payLoadsList.Count();
        payloadsTMP.text = Convert.ToString(numPayloads);
    }
}
