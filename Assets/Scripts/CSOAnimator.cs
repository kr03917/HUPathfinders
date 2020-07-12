using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSOAnimator : Enemy
{
    public LayerMask whatIsGround;
    [SerializeField] private Sprite[] frameArray = null;
    private int currentFrame = 0;
    private float timer;
    private float framerate = 0.09f;
    public GameManager theGameManager;
    public override void Awake()
    {
        base.Awake();
        theGameManager = FindObjectOfType<GameManager>();   
    }
    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer>framerate)
        {
            timer -= framerate;
            currentFrame= (currentFrame + 1 ) % frameArray.Length;
            mySpriteRenderer.sprite = frameArray[currentFrame];
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            theGameManager.collideCSO = true;
            //collideCSO = true;
            theGameManager.GameOver();
        }
    }
}
