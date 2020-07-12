using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public PlayerController student;
	private Vector3 prevPlayerPosition;

	private float moveDistance;
	public Transform bg1;
	public Transform bg2;
	private float size;

    // Start is called before the first frame update
    void Start()
    {
        student = FindObjectOfType<PlayerController>();
        prevPlayerPosition = student.transform.position;
	size = bg1.GetComponent<BoxCollider2D>().size.x+9;

    }

    // Update is called once per frame
    void Update()
    {
    	moveDistance = student.transform.position.x - prevPlayerPosition.x;
    	transform.position = new Vector3(transform.position.x+moveDistance, transform.position.y, transform.position.z);
        prevPlayerPosition = student.transform.position;
	
	if(transform.position.x >= bg2.position.x){
		bg1.position = new Vector3(bg2.position.x+size, bg1.position.y,bg1.position.z);
		//Debug.Log(bg1.position);
		SwitchBg();
	}

    }

	private void SwitchBg(){
		Transform temp = bg1;
		bg1 = bg2;
		bg2 = temp;
	}
}