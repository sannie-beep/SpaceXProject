using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipsInLaunch : MonoBehaviour
{
    private List<ShipData> shipsInLaunch;

    public void addOneShip(ShipData ship)
    {
        if (this.shipsInLaunch == null){
            this.shipsInLaunch = new List<ShipData>();
        }
        this.shipsInLaunch.Add(ship);
    }

    public List<ShipData> getShipsInLaunch()
    {
        if (this.shipsInLaunch != null){
            return this.shipsInLaunch;
        }
        else {return new List<ShipData>();}
        
    }

    public String getShipInfoToDisplay(int index)
    {
        if (index > this.shipsInLaunch.Count)
        {
            return null;
        }
        ShipData ship = this.shipsInLaunch[index];
        String name = ship.name;
        String numMissions = ship.launches.Count.ToString();
        String type = ship.type;
        String homePort = ship.home_port;

        String display = "Name: " + name + "\n" + 
                            "Missions: " + numMissions + "\n" + 
                                "Type: " + type + "\n" + 
                                    "Home Port: " + homePort;

        return display;
    }

}
