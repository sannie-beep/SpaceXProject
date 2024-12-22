using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public class Core
    {
        public string core { get; set; }
        public int? flight { get; set; }
        public bool? gridfins { get; set; }
        public bool? legs { get; set; }
        public bool? reused { get; set; }
        public bool? landing_attempt { get; set; }
        public bool? landing_success { get; set; }
        public string landing_type { get; set; }
        public string landpad { get; set; }
    }
