using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class movePlayer : MonoBehaviour
{
    private int gender;
    private int joggers;
    private int watch;
    private int hoodie;
    private Rigidbody2D myRigidBody;
    private float maxSpeed = 25f;
    public LayerMask whatIsGround;
    private Collider2D myCollider;
    public bool grounded;
    public CountDownController theCountdown;
    protected Joystick theJoyStick;
    protected JoyButton theJoyButton;
	private SpriteRenderer mySpriteRenderer;
    public Animator animator;
    private Vector2 oldValue;
    public bool delirious = false;
    public RuntimeAnimatorController[] myControllers = null;
    public CapsuleCollider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        theCountdown = FindObjectOfType<CountDownController>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        theJoyButton = FindObjectOfType<JoyButton>();
        theJoyStick = FindObjectOfType<Joystick>();
	    mySpriteRenderer = GetComponent<SpriteRenderer>();
        bodyCollider = GetComponent<CapsuleCollider2D>();

        gender = PlayerPrefs.GetInt("Gender");
        joggers = PlayerPrefs.GetInt("Joggers");
        watch = PlayerPrefs.GetInt("Watch");
        hoodie = PlayerPrefs.GetInt("Hoodie");

        if (gender==0)
        {
            if (hoodie == 1)
            {
                Vector2 colliderSize;
                colliderSize = new Vector2(bodyCollider.size.x, 8.5f);
                bodyCollider.size = colliderSize;
                this.transform.localScale += new Vector3(-0.05f,-0.15f,0);
                animator.runtimeAnimatorController = myControllers[3];
                
            }
            else if (watch==1)
            {
                animator.runtimeAnimatorController = myControllers[2];
            }
            else if (joggers == 1)
            {
                animator.runtimeAnimatorController = myControllers[1];
            }
            else
            {
                animator.runtimeAnimatorController = myControllers[0];
            }
        }
        else if (gender==1)
        {
            Vector2 colliderSize;
            colliderSize = new Vector2(bodyCollider.size.x, 8.5f);
            bodyCollider.size = colliderSize;
            this.transform.localScale += new Vector3(-0.05f, -0.15f, 0);
            if (hoodie == 1)
            {
                animator.runtimeAnimatorController = myControllers[7];
            }
            else if (watch == 1)
            {
                animator.runtimeAnimatorController = myControllers[6];
            }
            else if (joggers == 1)
            {
                animator.runtimeAnimatorController = myControllers[5];
            }
            else
            {
                animator.runtimeAnimatorController = myControllers[4];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (theCountdown.start)
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal") + theJoyStick.Horizontal);
            grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
            oldValue = myRigidBody.velocity;
            if (!delirious)
            {
                if (Math.Abs(myRigidBody.velocity.x) <= maxSpeed)
                {
                    myRigidBody.velocity += new Vector2(theJoyStick.Horizontal * 0.3f + Input.GetAxisRaw("Horizontal") * 0.2f,
                0);
                }
            }
            else
            {
                if (Math.Abs(myRigidBody.velocity.x) <= maxSpeed)
                {
                    myRigidBody.velocity -= new Vector2(theJoyStick.Horizontal * 0.2f + Input.GetAxisRaw("Horizontal") * 0.2f,
                0);
                }
            }

            if (oldValue[0] < myRigidBody.velocity.x)
            {
                mySpriteRenderer.flipX = false;
            }
            if (oldValue[0] > myRigidBody.velocity.x)
            {
                mySpriteRenderer.flipX = true;
            }


            if ((grounded && theJoyButton.pressed) || (grounded && Input.GetKeyDown(KeyCode.Space)))
            {
                myRigidBody.velocity = Vector2.up * 30f;
            }
        }
	}

    public void Check()
    {
        delirious = true;
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
        delirious = false;
    }
}
