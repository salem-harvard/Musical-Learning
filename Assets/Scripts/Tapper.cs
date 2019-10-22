using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapper : MonoBehaviour
{
    [SerializeField] float repeatRate = 1f;
    [SerializeField] float startTime = 1f;
 


    public void startTapper()
    {
        InvokeRepeating("playTapper", startTime, repeatRate) ;
    }


    public void stopTapper()
    {
        CancelInvoke();
    }

    void playTapper()
    {
        GetComponent<AudioSource>().Play();
    }

    
}
