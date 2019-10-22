using UnityEngine;
using UnityEngine.SceneManagement;

namespace MusicLearning.Saving
{
    [RequireComponent(typeof(SavingSystem))]
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "play_data" ;

        RunData runData;

        private SavingSystem savingSystem;

        private SceneLoader sceneManager;
        private void Awake()
        {
            
            savingSystem = GetComponent<SavingSystem>();

            runData = FindObjectOfType<RunData>();

            sceneManager = FindObjectOfType<SceneLoader>();
    
        }
        

        public void toggleRecording()
        {
            print("toggling");
            runData.ToggleRecording();

            if (!runData.isRecording)
            {
                print("Saving data");

                runData.SaveRunData(defaultSaveFile, sceneManager.player_name);
            }
        }

        //called when a name is entered on the main menu input field
        public void get_player_name(string player_name)
        {
            print(player_name + " is playing");
            savingSystem.AddUsername(player_name);
        }


    }

}


