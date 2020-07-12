using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLetterScript : MonoBehaviour
{
    public AudioSource source;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public AudioClip audio;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        audio = source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.health -= 1;
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
        }
        this.gameObject.SetActive(false);
    }
}
