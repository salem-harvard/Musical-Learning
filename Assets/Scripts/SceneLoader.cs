using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using MusicLearning.Saving;

public class SceneLoader : MonoBehaviour
{
    public string player_name = "player name";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void save_player_name(string inputText)
    {
        player_name = inputText;

        FindObjectOfType<SavingWrapper>().get_player_name(player_name);

        print("name is: " + player_name);
    }
}
