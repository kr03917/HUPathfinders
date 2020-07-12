using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpForce;
    public bool fallen;
    //Asad
    public TimerTool theTimerTool;
    public CountDownController theCountDown;
    public float speedMultiplier;
    public float speedIncreasedMilestone;
    private float speedMilestoneCount;
    private Vector2 startTouchPosition, endTouchPosition;
	private Rigidbody2D myRigidBody;
	public bool grounded;
	public LayerMask whatIsGround;
	private Collider2D myCollider;
	private Animator myAnimator;
    public GameManager theGameManager;
    public int maxSpeed = 15;
    bool start2;
    public bool collisionHold = true;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    public float SWIPE_THRESHOLD = 40f;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        theCountDown = FindObjectOfType<CountDownController>();
        theTimerTool = FindObjectOfType<TimerTool>();
        speedMilestoneCount = speedIncreasedMilestone;
    }
    
        void Update()
    {
        start2 = theCountDown.start;
        if (start2)
        {
            grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
            
            //Test Code Begin
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUp = touch.position;
                    fingerDown = touch.position;
                }

                //Detects Swipe while finger is still moving
                if (touch.phase == TouchPhase.Moved)
                {
                    if (!detectSwipeOnlyAfterRelease)
                    {
                        fingerDown = touch.position;
                        checkSwipe();
                    }
                }

                //Detects swipe after finger is released
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }
            //Test Code ends
            checkSwipe();

            if (transform.position.x > speedMilestoneCount)
            {
                speedMilestoneCount += speedIncreasedMilestone;
                speedIncreasedMilestone = speedIncreasedMilestone * speedMultiplier;
                if (moveSpeed < maxSpeed)
                    moveSpeed = moveSpeed * speedMultiplier;
            }
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            }

            //myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
            //myAnimator.SetBool("Grounded", grounded);
            if (theTimerTool.time <= 0)
            {
                theGameManager.GameOver();
            }    
        }
    }

    private void checkSwipe()
    {
        //Test Code Begins
        if (verticalMove() > SWIPE_THRESHOLD)
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }
        float verticalMove()
        {
            return Mathf.Abs(fingerDown.y - fingerUp.y);
        }
        void OnSwipeUp()
        {
            if (myRigidBody.velocity.y == 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                Debug.Log("Swipe UP");
            }
            
        }

        void OnSwipeDown()
        {
            Debug.Log("Swipe Down");
        }
        
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (collisionHold)
        {
            if (other.gameObject.tag == "killbox")
            {
                //other.gameObject.SetActive(false);
                theGameManager.GameOver();
            }
        }    
    }
}
