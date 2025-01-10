using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject infoArea;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        if (button != null) {
            button.onClick.AddListener(onButtonClicked);
        }
    }

    void onButtonClicked(){
        infoArea.SetActive(true);
        GameObject infoLarge = infoArea.transform.GetChild(0).gameObject;
        GameObject infoPanel = infoLarge.transform.GetChild(0).gameObject;
        infoPanel.GetComponent<DynamicGrid>().GeneratePrefabs(gameObject.GetComponent<ShipsInLaunch>());
    }



}
