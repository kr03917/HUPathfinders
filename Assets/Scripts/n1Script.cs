using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n1Script : MonoBehaviour
{
    private GameObject Cso;
    public AudioSource source;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public AudioClip audio;
    void Start()
    {
        Cso = GameObject.Find("CSO");
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
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
            Cso.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
