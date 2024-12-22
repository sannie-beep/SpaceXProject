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
    public LaunchDataLoader launchLoader; // loads launch data using API
    public RocketDataLoader rocketLoader; // loads rocket data using API
    public Transform contentPanel; // Panel to instantiate launch data display objects in list form
    public Dictionary<string, RocketData> rocketDict;


    // Begin to wait for the data to be accessed and parsed
    void Start()
    {
        StartCoroutine(WaitForLaunchData());
    }


    IEnumerator WaitForLaunchData()
    {
        // Wait till the get request has finished
        yield return launchLoader.LoadLaunchData("https://api.spacexdata.com/v5/launches");

        // Get the launch data
        launchesData = launchLoader.getLaunchData();

        if (launchesData.launches == null || launchesData.launches.Count == 0)
        {
            Debug.LogError("No launches found in the data!");
        }
        
        StartCoroutine(WaitForRocketData());
        // Display the launch information
        //displayLaunchInfo();
    }

    IEnumerator WaitForRocketData()
    {
        // Wait till the get request has finished
        //yield return WaitForLaunchData();
        yield return rocketLoader.LoadRocketData("https://api.spacexdata.com/v4/rockets");

        // Get the rocket data into a dict
        rocketDict = rocketLoader.getRocketDictionary();
        Debug.Log("Success! :)");
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

            // Find Rocket TextMeshProUGUI element in that entry
            TextMeshProUGUI rocketTMP = newEntry.transform.Find("RocketsPanel/Rocket")?.GetComponent<TextMeshProUGUI>();

            // Find Country TextMeshProUGUI element in that entry
            TextMeshProUGUI countryTMP = newEntry.transform.Find("CountryPanel/Country")?.GetComponent<TextMeshProUGUI>();

            // Set data
            setName(nameTMP, launch.name);
            setPayloads(payloadsTMP, launch.payloads);
            setRocketAndCountry(rocketTMP, countryTMP, launch.rocket);
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

    // Access and display name of rocket
    void setRocketAndCountry(TextMeshProUGUI rocketTMP, TextMeshProUGUI countryTMP, String rocketID)
    {
        RocketData thisRocket = this.rocketDict[rocketID];
        rocketTMP.text = thisRocket.name;
        countryTMP.text = thisRocket.country;
    }
}
