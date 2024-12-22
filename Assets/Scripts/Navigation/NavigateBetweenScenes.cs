using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateBetweenScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toLaunchBrowser(){
        SceneManager.LoadScene(0);
    }

    public void toMainMenu(){
        SceneManager.LoadScene(1);
    }

    public void toOrbit(){
        SceneManager.LoadScene(2);
    }
}
