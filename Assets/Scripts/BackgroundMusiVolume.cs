using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusiVolume : MonoBehaviour
{
    // Reference to audio source component
    private AudioSource audioSrc;

    // Music volume variable that will be modified by dragging slider knob
    private float musicVolume = 1f;



    // Start is called before the first frame update
    void Start()
    {
        //Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }

    //Method that is called by slider game object 
    // The method takes vol value passed by slider and sets it as musicValue 
    
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
