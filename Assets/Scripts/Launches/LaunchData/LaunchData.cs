using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LaunchData
{
    public Fairings fairings;
    public Links links;
    public string static_fire_date_utc;
    public int? static_fire_date_unix;
    public bool net;
    public int? window;
    public string rocket;
    public bool success;
    public Failure[] failures;
    public string details;
    public string[] crew;
    public string[] ships;
    public string[] capsules;
    public string[] payloads;
    public string launchpad;
    public int flight_number;
    public string name;
    public string date_utc;
    public int date_unix;
    public string date_local;
    public string date_precision;
    public bool upcoming;
    public Core[] cores;
    public bool auto_update;
    public bool tbd;
    public string launch_library_id;
    public string id;
}