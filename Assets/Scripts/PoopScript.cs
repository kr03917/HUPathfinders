using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScript : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray = null;
    public SpriteRenderer mySpriteRenderer;
    public Rigidbody2D myRigidBody;
    bool collide = false;
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
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collide)
        {
            collide = true;
            myRigidBody.gravityScale = 0f;
            myRigidBody.velocity = new Vector2(0, 0);
            mySpriteRenderer.sprite = frameArray[0];
            if (collision.gameObject.tag == "Player")
            {
                AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
                GameManager.health -= 1;
            }
            StartCoroutine(PoopCoroutine());
        }
    }
    IEnumerator PoopCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
