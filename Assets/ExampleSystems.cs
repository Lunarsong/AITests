using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSystems : MonoBehaviour
{
    public FloatingTextSystem TextSystem;
    public static ExampleSystems Instance { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
}
