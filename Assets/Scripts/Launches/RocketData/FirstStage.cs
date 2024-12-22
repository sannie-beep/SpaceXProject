 [System.Serializable]
  public class FirstStage
    {
        public ThrustSeaLevel thrust_sea_level { get; set; }
        public ThrustVacuum thrust_vacuum { get; set; }
        public bool reusable { get; set; }
        public int engines { get; set; }
        public int fuel_amount_tons { get; set; }
        public int burn_time_sec { get; set; }
    }