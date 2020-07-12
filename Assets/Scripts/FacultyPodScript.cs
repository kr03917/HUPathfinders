using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacultyPodScript : MonoBehaviour
{
    private SpriteRenderer myspriteRenderer;
    public GameObject conduct;
    public GameObject target;
    private float force = 10.0f;
    // Start is called before the first frame update
    private void Awake()
    {
         myspriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating("fire", 0.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fire()
    {
        if (myspriteRenderer.isVisible)
        {
            GameObject obj;
            obj = (GameObject)Instantiate(conduct);
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            obj.SetActive(true);
            Vector3 dir = target.transform.position - obj.transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(dir.normalized * force, ForceMode2D.Impulse);
        }
    }
}
