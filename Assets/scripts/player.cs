using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    static public int courage { get; private set; } = 20;
    static public int strength { get; private set; } = 20;
    static public int reason { get; private set; } = 20;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void courageChanger(int value)
    {
        courage += value;
    }

    public void strengthChanger(int value)
    {
        strength += value;
    }

    public void reasonChanger(int value)
    {
        reason += value;
    }


}
