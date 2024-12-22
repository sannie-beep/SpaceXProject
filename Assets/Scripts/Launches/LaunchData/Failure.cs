[System.Serializable]
    public class Failure
    {
        public int time { get; set; }
        public int? altitude { get; set; }
        public string reason { get; set; }
    }