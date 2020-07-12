using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment : MonoBehaviour
{
    private ScoreManager theScoreManager;
    public AudioSource pickupSound;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public AudioClip audio;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    // Start is called before the first frame update
    void Start()
    {
        pickupSound = GetComponent<AudioSource>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        audio = pickupSound.clip;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.name == "Player"))
        {
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
            theScoreManager.assignmentScore += 1;
            gameObject.SetActive(false);
        }

    }
}
