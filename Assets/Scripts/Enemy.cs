using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected SpriteRenderer mySpriteRenderer;
    protected bool right = true;

    public virtual void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.flipX = true;
        InvokeRepeating("Flip", 2.0f, 5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (right)
        {
            transform.position += new Vector3(0.05f, 0f, 0f);
        }
        else
        {
            transform.position -= new Vector3(0.05f, 0f, 0f);
        }
    }

    private void Flip()
    {
        mySpriteRenderer.flipX = !(mySpriteRenderer.flipX);
        right = !(right);
    }
}
