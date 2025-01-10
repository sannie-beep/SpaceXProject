using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipPanelDisplayer : MonoBehaviour
{
    public GameObject ShipInfo;
    // Start is called before the first frame update
    public GameObject parentPanel;
    public GameObject shipInfoDetails;

    void Start()
    {
        
    }

    void DisplayShips()
    {
        // get the ships in launch
        ShipsInLaunch ships = parentPanel.GetComponentInChildren<ShipsInLaunch>();
        if (ships != null)
        {
            if (ships.getShipsInLaunch().Count == 0){
            }
        }

    }
}
