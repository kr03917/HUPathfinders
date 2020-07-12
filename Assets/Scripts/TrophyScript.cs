using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyScript : MonoBehaviour
{
    public InstructorScript theInstructor;
    // Start is called before the first frame update
    void Start()
    {
        theInstructor = FindObjectOfType<InstructorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            theInstructor.begin();
            gameObject.SetActive(false);
        }
    }   
}
