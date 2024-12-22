using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class LaunchDataLoader : MonoBehaviour
{

    // Start is called before the first frame update
    public LaunchDatabase loadedLaunchData;
    void Start()
    {
        loadLaunchData("https://api.spacexdata.com/v4/launches");
    }


    public void loadLaunchData(String url)
    {
        StartCoroutine(GetRequest(url)); 
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/LaunchData.json", launchDataJson.toJson());
    }

    IEnumerator GetRequest(String url)
    {
        UnityWebRequest launchDataJson = UnityWebRequest.Get(url);
        yield return launchDataJson.SendWebRequest();
        
        if (launchDataJson.result == UnityWebRequest.Result.Success){
            string jsonData = launchDataJson.downloadHandler.text;
            string filePath = Path.Combine(Application.dataPath, "Resources/LaunchData.json");
            //LaunchDatabase launchData = JsonUtility.FromJson<LaunchDatabase>(jsonData);
            // Save the JSON string to the file
            File.WriteAllText(filePath, jsonData);
           // int count = launchData.launches.Count;

           ParseLaunchData(jsonData);
           
           // System.IO.File.WriteAllText(Application.persistentDataPath + "/LaunchData.json", jsonData);
        }
        else{
            Debug.LogError("Unable to access launch data.");
        }

    }

 void ParseLaunchData(string json)
{
        // Wrap the JSON array into a JSON object
        string wrappedJson = $"{{\"launches\": {json}}}";
        
        // Parse the wrapped JSON
        LaunchDatabase launchDataList = JsonUtility.FromJson<LaunchDatabase>(wrappedJson);
        
        //assign it to public variable
        this.loadedLaunchData = launchDataList;

        if (launchDataList.launches != null){
             foreach (var launch in launchDataList.launches)
            {
                String name = launch.name;
                Debug.Log(name);
            }   
        }


    //return launchDataList; 
}
}
