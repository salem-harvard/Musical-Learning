using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicLearning.Saving
{
    public class RunData : MonoBehaviour
    {
        uint playerID = 0 , runID = 0;

        System.DateTime timeOfRunStart;


        List<float> clickTimes = new List<float>();
        List<float> clickDurations = new List<float>();
        List<string> clickTypes = new List<string>();


        [NonSerialized] public bool isRecording = false;
        private float recordingTime;


        public void ToggleRecording()
        {
            isRecording = !isRecording;

            if (isRecording)
            {
                timeOfRunStart = System.DateTime.Now;
                recordingTime = Time.time;
            }
        }

        public void OnKeyDown(KeyCode keycode)
        {

            if (Input.GetMouseButtonDown(0)
                 || Input.GetMouseButtonDown(1)
                 || Input.GetMouseButtonDown(2))
                return; //Do Nothing

            
            
            if (isRecording)
            {
                clickTimes.Add(Time.time - recordingTime);
                clickTypes.Add(keycode.ToString());

                print("click times count:" + clickTimes.Count);
            }

        }

        public void OnKeyUP(KeyCode keycode)
        {

            return; // do nothing for now


            if (Input.GetMouseButtonUp(0)
                 || Input.GetMouseButtonUp(1)
                 || Input.GetMouseButtonUp(2))
            { print("returning");
                return; //Do Nothing
            }

            if (isRecording)
            {
                

                int lastEntryIndex = clickTimes.Count - 1;

                print("index of last click time:"  + lastEntryIndex);

                if (lastEntryIndex >= 0)
                {
                    
                    float lastClickTime = clickTimes[lastEntryIndex];

                    clickDurations.Add(Time.time - lastClickTime);
                    //print("duration is: " + clickDurations[lastEntryIndex]);

                    //print("click times count:" + (clickTimes.Count));
                    //print("click durations count:" + (clickDurations.Count));
                }
    
            } else
            {
                while(clickTimes.Count > clickDurations.Count)
                {
                    print("removing the last false entry");

                     clickTimes.RemoveAt(clickTimes.Count - 1);
                     clickTypes.RemoveAt(clickTypes.Count - 1);

                }
            }

        }

        public void SaveRunData(string saveFile, string playerName)
        {

            if(clickTimes.Count < 1) { return;}

            SavingSystem savingSystem = FindObjectOfType<SavingSystem>();


            /*while (clickTimes.Count > clickDurations.Count)
            {
               // print("removing the last false entry");
                clickTimes.RemoveAt(clickTimes.Count - 1);
                clickTypes.RemoveAt(clickTypes.Count - 1);
            }*/


            //save player name
            string[] runInfo = {playerName, timeOfRunStart.ToString()};
            savingSystem.Save(saveFile, runInfo);

            savingSystem.Save(saveFile, clickTimes.ToArray());
            //savingSystem.Save(saveFile, clickDurations.ToArray());
            savingSystem.Save(saveFile, clickTypes.ToArray());



            clickTimes = new List<float>();
            clickDurations = new List<float>();
            clickTypes = new List<string>();
        }


        //public void OnKey(KeyCode keycode) { }
    


    }

}



