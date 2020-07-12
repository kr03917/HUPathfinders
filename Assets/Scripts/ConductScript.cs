using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductScript : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private movePlayer thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<movePlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thePlayer.Check();
        }
        this.gameObject.SetActive(false);
    }
}
