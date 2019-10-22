using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MusicLearning.Saving;

public class StartStopButton : MonoBehaviour
{
    //changes text from start to stop and vice versa
    bool isStart = true;
   public void StartStop()
    {
        if (isStart)
        {
            GetComponent<Text>().text = "Stop";
            FindObjectOfType<Conductor>().startSphere();
            FindObjectOfType<Tapper>().startTapper();
            isStart = false;
            FindObjectOfType<SavingWrapper>().toggleRecording();
        }
        else
        {
            GetComponent<Text>().text = "Start";
            FindObjectOfType<Conductor>().stopSphere();
            FindObjectOfType<Tapper>().stopTapper();
            isStart = true;
            FindObjectOfType<SavingWrapper>().toggleRecording();
        }

        //for some reason the build is not executing these
        //isStart = !isStart;
        //FindObjectOfType<SavingWrapper>().toggleRecording();
    }
}
