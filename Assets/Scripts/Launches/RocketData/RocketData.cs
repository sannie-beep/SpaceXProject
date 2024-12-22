

using System.Collections.Generic;

[System.Serializable]

public class RocketData{
     public Height height;
    public Diameter diameter;
    public Mass mass;
    public FirstStage first_stage;
    public SecondStage second_stage;
    public Engines engines;
    public LandingLegs landing_legs;
    public List<PayloadWeight> payload_weights;
    public List<string> flickr_images;
    public string name;
    public string type;
    public bool active;
    public int stages;
    public int boosters;
    public int cost_per_launch;
    public int success_rate_pct;
    public string first_flight;
    public string country;
    public string company;
    public string wikipedia;
    public string description;
    public string id;
}