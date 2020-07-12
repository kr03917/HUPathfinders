using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairScript : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public Rigidbody2D myRigidBody;
    public GameObject target;
    private float force = 0.75f;
    public AudioSource source;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public AudioClip audio;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        audio = source.clip;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mySpriteRenderer.isVisible)
        {
            Vector3 dir = target.transform.position - transform.position;
            this.GetComponent<Rigidbody2D>().AddForce(dir.normalized * force, ForceMode2D.Impulse);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
            GameManager.health -= 1;
        }
    }
}
