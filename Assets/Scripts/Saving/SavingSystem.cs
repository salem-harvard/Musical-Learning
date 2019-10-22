using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MusicLearning.Saving
{
    public class SavingSystem : MonoBehaviour
    {
        string dataPath;
        private void Start()
        {
            dataPath = Path.Combine(Application.dataPath, "Game Data");
            print(dataPath);
        }

        public void Save(string saveFile, float[] savedArray, bool isAppending=true)
        {
            
            string path = getPathFromSaveFile(saveFile);

      
            using (StreamWriter stream = new StreamWriter(path, isAppending))
            {
                string content = "";

                for (int i = 0; i < savedArray.Length; i++)
                {
                    content += savedArray[i].ToString() + ",";
                }
                stream.WriteLine(content.TrimEnd(','));
            }

        }

       
        public void Save(string saveFile, string[] savedArray, bool isAppending = true)
        {

            string path = getPathFromSaveFile(saveFile);

            using (StreamWriter stream = new StreamWriter(path, isAppending))
            {
                string content = "";

                for (int i = 0; i < savedArray.Length; i++)
                {
                    content += savedArray[i].ToString() + ",";
                }
                stream.WriteLine(content.TrimEnd(','));
            }

        }



        static string USERNAMEFILE = "usernames";
        public void AddUsername(string name)
        {
            string namesFile = Path.Combine(dataPath, USERNAMEFILE + ".csv");

            bool isContained = false;
            foreach (string line in File.ReadLines(namesFile))
            {
                if (line.Contains(name))
                {
                    isContained = true; 
                } //TODO else ask to try a different name
            }

            if (!isContained)
            {
                File.AppendAllText(namesFile, name + Environment.NewLine);
            }
        }

        public void Load(string saveFile)
        {
            string path = getPathFromSaveFile(saveFile);

            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                float[] clickTimes = (float[])formatter.Deserialize(stream);

            }
        }


        private string getPathFromSaveFile(string saveFile)
        {

            return Path.Combine(dataPath,saveFile + ".csv");   


        }

        

    }
}

