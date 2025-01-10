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

}
