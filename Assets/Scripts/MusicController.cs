using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicLearning.Saving;

public class MusicController : MonoBehaviour
{


    [SerializeField] KeyCode keyCode = KeyCode.A;

    private AudioSource audioSource;

    private RunData runData;

    //for saving data on click times.
    List<float> listOfTransforms = new List<float>();

    private Color initColor;

    [SerializeField] float flickerDuration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initColor = GetComponentInChildren<MeshRenderer>().material.GetColor("_EmissionColor");

        runData = FindObjectOfType<RunData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {

            audioSource.Play();

            // makes the box represnting the key flicker (change color quickly).
            StartCoroutine(flickerBox());

            runData.OnKeyDown(keyCode);
        }


        


        /*
            if(Input.GetMouseButton(1))
            {
                print("mouse button is held down");
                get mouse speed to be used in music.
            }
            print(Input.GetAxis("Mouse X"));
            */

    }

    IEnumerator flickerBox()
    {

        Material material = GetComponentInChildren<MeshRenderer>().material;
        initColor = material.GetColor("_EmissionColor");

        material.SetColor("_EmissionColor", Color.white);

        yield return new WaitForSeconds(flickerDuration);

        material.SetColor("_EmissionColor", initColor);
    }

    private void OnMouseDown()
    {
        //audioSource.Play();
        //Debug.Log(Time.time);
        //TODO: record time of play. 
        //RODO: store in array. 
    }
}
