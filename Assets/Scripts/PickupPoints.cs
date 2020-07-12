using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour
{
    private int scoreToGive = 1;
    private ScoreManager theScoreManager;
    public AudioSource pickupSound;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public AudioClip audio;
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
            //pickupSound.Play();
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }

    }
}
