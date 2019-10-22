using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conductor : MonoBehaviour
{
    [SerializeField] float repeatRate = 0.5f;
    [SerializeField] float startTime = 1f;
    [SerializeField] float appearDuration = 0.1f;

    [SerializeField] Material[] materials;
    

    public void startSphere()
    {
        InvokeRepeating("conductorSignal", startTime, repeatRate);
    }

    public void stopSphere()
    {
        CancelInvoke();
    }

    public void conductorSignal()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(showThenHide(levelIndex));
        
    }

    IEnumerator showThenHide(int level)
    {
        switch(level)
        {
            case 1:
               
                yield return LevelOne();
                break;
            case 2:
                
                yield return LevelTwo();
                break;
        }

        yield return new WaitForSeconds(0);
    }

    IEnumerator LevelOne()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.material = materials[0];//materials[UnityEngine.Random.Range(0,5)];

        meshRenderer.enabled = true; // make it appear

        yield return new WaitForSeconds(appearDuration); //

        meshRenderer.enabled = false; // make it disappear
    }

    bool isBlue = true;
    IEnumerator LevelTwo()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (isBlue)
        {meshRenderer.material = materials[1];}
        else {meshRenderer.material = materials[0];}

        isBlue = !isBlue;

        meshRenderer.enabled = true; // make it appear

        yield return new WaitForSeconds(appearDuration); //

        meshRenderer.enabled = false; // make it disappear
    }

}
