using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Converts a RocketList into a Dictionary for ease of access of rocket data from launch data
public class RocketListToDict : MonoBehaviour
{
    Dictionary<string, RocketData> rocketDict;

    // Convert rocket list to dict
    public Dictionary<string, RocketData> ConvertToDict(RocketDataList rocketsList)
    {
        // Make a new dictionary to store
        Dictionary<string, RocketData> dict = new Dictionary<string, RocketData>();

        // Add each rocket from the list into the dict stored by id
        foreach (var rocket in rocketsList.rockets)
        {
            if (rocket != null) {
                dict.Add(rocket.id, rocket);
            }
        }
        // Return the dictionary
        return dict;
    }
}
