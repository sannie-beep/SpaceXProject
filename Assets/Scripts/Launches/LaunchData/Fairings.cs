using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fairings
{
    public bool? reused { get; set; }
    public bool? recovery_attempt { get; set; }
    public bool? recovered { get; set; }
    public List<string> ships { get; set; }
}
