using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Converts a RocketList into a Dictionary for ease of access of rocket data from launch data
public class ListToDict : MonoBehaviour
{

    // Convert rocket list to dict
    public Dictionary<string, RocketData> ConvertToRocketDict(RocketDataList rocketsList)
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

    // Convert ship list to dict
    public Dictionary<string, ShipData> ConvertToShipDict(ShipDataList shipList)
    {
        // Make a new dictionary to store
        Dictionary<string, ShipData> dict = new Dictionary<string, ShipData>();

        // Add each rocket from the list into the dict stored by id
 foreach (var ship in shipList.ships)
{
    if (ship != null && !string.IsNullOrEmpty(ship.id))
    {
        dict.Add(ship.id, ship);
    }
    else
    {
        Debug.LogWarning("Ship or Ship ID is null/empty.");
    }
}

        // Return the dictionary
        return dict;
    }
}
