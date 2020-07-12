using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructorScript : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] private Sprite[] frameArray = null;
    private int currentFrame = 0;
    private float timer;
    private float framerate = 0.5f;
    public GameObject Fail;
    public GameObject target;
    private float force = 10.0f;
    public bool fire = true;
    private bool right = true;
    // Start is called before the first frame update
    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > framerate)
        {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            mySpriteRenderer.sprite = frameArray[currentFrame];
            if (target.transform.position.x<transform.position.x)
            {
                right = false;
                mySpriteRenderer.flipX = true;
            }
            else
            {
                right = true;
                mySpriteRenderer.flipX = false;
            }
            if (currentFrame == 0)
            {
                //Debug.Log("idle");
            }
            else
            {
                if (fire)
                {
                    if (this.GetComponent<Renderer>().isVisible)
                    {
                        GameObject obj = (GameObject)Instantiate(Fail);
                        if (right)
                        {
                            obj.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y + 1.5f, transform.position.z);
                        }
                        else
                        {
                            obj.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y + 1.5f, transform.position.z);
                        }
                        obj.SetActive(true);
                        Vector3 dir = target.transform.position - obj.transform.position;
                        obj.GetComponent<Rigidbody2D>().AddForce(dir.normalized * force, ForceMode2D.Impulse);
                    }
                }
            }
        }
    }
    public IEnumerator firepause()
    {
        fire = false;
        yield return new WaitForSeconds(20f);
        fire = true;
    }
    public void begin()
    {
        StartCoroutine(firepause());
    }
}
