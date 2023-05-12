using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private int speedNormal = 30;
    private int speedDouble = 60;
    private int speed;


    void Start()
    {
        speed = speedNormal;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void IncreaseSpeed()
    {
        speed = speedDouble;
    }

    public void DecreaseSpeed()
    {
        speed = speedNormal;
    }
}
