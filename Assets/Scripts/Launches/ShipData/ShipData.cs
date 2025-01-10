using System;
using System.Collections.Generic;

[System.Serializable]
public class ShipData
{
    public string legacy_id;
    public string model;
    public string type;
    public List<string> roles;
    public int? imo;
    public int? mmsi;
    public int? abs;
    public int? classs;
    public int? mass_kg;
    public int? mass_lbs;
    public int? year_built;
    public string home_port;
    public string status;
    public float? speed_kn;
    public float? course_deg;
    public float? latitude;
    public float? longitude;
    public string last_ais_update;
    public string link;
    public string image;
    public List<string> launches;
    public string name;
    public bool active;
    public string id;
}
