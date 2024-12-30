using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class LaunchDataLoader : MonoBehaviour
{
    public LaunchDatabase loadedLaunchData; // To store launch data and access it to be displayed by DataDisplayer

    // Loads launch data : executes Get Request and invokes parsing method
    public IEnumerator LoadLaunchData(String url)
    {
        UnityWebRequest launchDataJson = UnityWebRequest.Get(url);
        yield return launchDataJson.SendWebRequest();
        
        // If request is successful
        if (launchDataJson.result == UnityWebRequest.Result.Success){

            // Get the jsonData
            string jsonData = launchDataJson.downloadHandler.text;
            
            // Parse json data into LaunchDatabase object
            ParseLaunchData(jsonData);
           
        }
        // Else display error message
        else {
            Debug.LogError("Unable to access launch data.");
        }

    }

    // Parses json accessed into LaunchDatabase object
    void ParseLaunchData(string json)
    {
            // Wrap the JSON array into a JSON object
            string wrappedJson = $"{{\"launches\": {json}}}";
            
            // Parse the wrapped JSON
            LaunchDatabase launchDataList = JsonUtility.FromJson<LaunchDatabase>(wrappedJson);
            
            //Assign it to public variable
            this.loadedLaunchData = launchDataList;

            // Check if is null
            if (this.loadedLaunchData.launches != null){
                foreach (var launch in this.loadedLaunchData.launches)
                {
                    String name = launch.name;
                    //Debug.Log(name); --> for debugging
                }   
            }
            else {
                Debug.LogError("Launch Data not loaded.");
            }
             
            //Debug.Log("Launch Data loaded"); --> for debugging
    }

    // Returns the launch data if it is not null
    public LaunchDatabase getLaunchData(){

        // make sure it is loaded already
        if (this.loadedLaunchData == null || this.loadedLaunchData.launches == null)
        {
            Debug.Log("Not loaded yet, please wait...");
            return null;
        }

        Debug.Log("Launch data accessed.");
        return this.loadedLaunchData;
    }
}