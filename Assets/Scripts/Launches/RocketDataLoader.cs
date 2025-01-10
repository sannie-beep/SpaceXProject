using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Collections.Generic;

public class RocketDataLoader : MonoBehaviour
{
    public RocketDataList loadedRocketData; // To store rocket data and access it to be displayed by DataDisplayer
    public ShipDataList loadedShipData; // To store ship data and access it to be displayed by DataDisplayer


    // Loads rocket data : executes Get Request and invokes parsing method
    public IEnumerator LoadData(String url, String tag)
    {
        UnityWebRequest apiRequest = UnityWebRequest.Get(url);
        yield return apiRequest.SendWebRequest();
        
        // If request is successful
        if (apiRequest.result == UnityWebRequest.Result.Success){

            // Get the json data in a string
            string jsonData = apiRequest.downloadHandler.text;
            
            // Parse json data into specific data list
            if (tag == "Rocket"){
                ParseRocketData(jsonData);
            }
            else if (tag == "Ship"){
                ParseShipData(jsonData);
            }     
           
        }
        // Else display error message
        else {
            Debug.LogError("Unable to access data.");
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

        void ParseShipData(string json)
    {
            // Wrap the JSON array into a JSON object
            string wrappedJson = $"{{\"ships\": {json}}}";
            
            // Parse the wrapped JSON
            ShipDataList shipDataList = JsonUtility.FromJson<ShipDataList>(wrappedJson);
            
            //Assign it to public variable
            this.loadedShipData = shipDataList;

            // Check if is null
            if (this.loadedShipData.ships != null){
                foreach (var rocket in this.loadedShipData.ships)
                {
                    String name = rocket.name;
                    Debug.Log(name); // --> for debugging
                }   
            }
            else {
                Debug.LogError("Ship Data not loaded.");
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

        // Returns the Ship data if it is not null
    public ShipDataList getShipData(){

        // make sure it is loaded already
        if (this.loadedShipData == null || this.loadedShipData.ships == null)
        {
            Debug.Log("Not loaded yet, please wait...");
            return null;
        }

        Debug.Log("Ship data accessed.");
        return this.loadedShipData;
    }

    // Get the dictionary version of the rocket list
    public Dictionary<string, RocketData> getRocketDictionary(){
        // make a converter object
        ListToDict converter = new ListToDict();
        Dictionary<string, RocketData> dict = converter.ConvertToRocketDict(this.getRocketData());
        return dict;
    }

    // Get the dictionary version of the ship list
    public Dictionary<string, ShipData> getShipDictionary(){
        // make a converter object
        ListToDict converter = new ListToDict();
        Dictionary<string, ShipData> dict = converter.ConvertToShipDict(this.getShipData());
        return dict;
    }
}
