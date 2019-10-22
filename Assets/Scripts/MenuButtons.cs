using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
  public void GoToMainMenu()
    {
        FindObjectOfType<SceneLoader>().LoadLevel("Main Menu");
    }

  public void GoToLevelOne()
    {
        FindObjectOfType<SceneLoader>().LoadLevel("Single Note");
    }

  public void GoToLevelTwo()
    {
        FindObjectOfType<SceneLoader>().LoadLevel("Double Note");
    }
}
