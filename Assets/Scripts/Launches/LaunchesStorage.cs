using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchesStorage : MonoBehaviour
{
    // Start is called before the first frame update
    public static LaunchDatabase launchesData;
    public LaunchDataLoader loader;
    void Start()
    {
        launchesData = loader.loadedLaunchData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
