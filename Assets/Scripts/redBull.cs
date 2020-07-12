using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBull : MonoBehaviour
{
    public AudioSource source;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public AudioClip audio;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
	    source = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        audio = source.clip;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameManager.health < 3)
            {
                GameManager.health += 1;
            }
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
            source.Play(0);
            this.gameObject.SetActive(false);
        }
    }

}
