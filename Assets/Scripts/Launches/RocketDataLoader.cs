using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Collections.Generic;

public class RocketDataLoader : MonoBehaviour
{
    public RocketDataList loadedRocketData; // To store rocket data and access it to be displayed by DataDisplayer


    // Loads rocket data : executes Get Request and invokes parsing method
    public IEnumerator LoadRocketData(String url)
    {
        UnityWebRequest rocketDataJson = UnityWebRequest.Get(url);
        yield return rocketDataJson.SendWebRequest();
        
        // If request is successful
        if (rocketDataJson.result == UnityWebRequest.Result.Success){

            // Save as json in resources folder (in case needed)
            string jsonData = rocketDataJson.downloadHandler.text;
            string filePath = Path.Combine(Application.dataPath, "Resources/RocketData.json");
            File.WriteAllText(filePath, jsonData);
            
            // Parse json data into RocketDataList object
            ParseRocketData(jsonData);
           
        }
        // Else display error message
        else {
            Debug.LogError("Unable to access Rocket data.");
        }

    }

    // Parses json accessed into RocketDataList object
    void ParseRocketData(string json)
    {
            // Wrap the JSON array into a JSON object
            string wrappedJson = $"{{\"rockets\": {json}}}";
            
            // Parse the wrapped JSON
            RocketDataList rocketDataList = JsonUtility.FromJson<RocketDataList>(wrappedJson);
            
            //Assign it to public variable
            this.loadedRocketData = rocketDataList;

            // Check if is null
            if (this.loadedRocketData.rockets != null){
                foreach (var rocket in this.loadedRocketData.rockets)
                {
                    String name = rocket.name;
                    Debug.Log(name); // --> for debugging
                }   
            }
            else {
                Debug.LogError("Rocket Data not loaded.");
            }
             
            //Debug.Log("Rocket Data loaded"); //--> for debugging
    }

    // Returns the Rocket data if it is not null
    public RocketDataList getRocketData(){

        // make sure it is loaded already
        if (this.loadedRocketData == null || this.loadedRocketData.rockets == null)
        {
            Debug.Log("Not loaded yet, please wait...");
            return null;
        }

        Debug.Log("Rocket data accessed.");
        return this.loadedRocketData;
    }

    // Get the dictionary version of the rocket list
    public Dictionary<string, RocketData> getRocketDictionary(){
        // make a converter object
        RocketListToDict converter = new RocketListToDict();
        Dictionary<string, RocketData> dict = converter.ConvertToDict(this.getRocketData());
        return dict;
    }
}
