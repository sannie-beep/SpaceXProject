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
        else {return null;}
        
    }


    // private String shipID;
    // private ShipData shipData;

    // private Dictionary<String, ShipData> launchDict;

    // public void setShipID(String idToSet)
    // {
    //     this.shipID = idToSet;
    // }
    
    // public String getShipID()
    // {
    //     if(this.shipID != null){
    //         return this.shipID;
    //     }
    //     else {
    //         return "No Ship ID associated with this Launch";
    //     }
    // }

    // public void setShipData(ShipData ship)
    // {
    //     this.shipData = ship;
    // }
    
    // public ShipData getShipData()
    // {
    //     if(this.shipData != null){
    //         return this.shipData;
    //     }
    //     else {
    //         return null;
    //     }
    // }
}
