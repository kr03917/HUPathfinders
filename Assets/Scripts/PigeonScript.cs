using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonScript : Enemy
{
    public GameObject poop;
    public override void Awake()
    {
        base.Awake();
        InvokeRepeating("Poop", 0.0f, 3f);

    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    

    private void Poop()
    {
        if (this.GetComponent<Renderer>().isVisible)
        {
            GameObject obj = (GameObject)Instantiate(poop);
            obj.SetActive(true);
            if (right)
            {
                obj.transform.position = new Vector3(transform.position.x - 1f, transform.position.y - 1f, transform.position.z);
            }
            else
            {
                obj.transform.position = new Vector3(transform.position.x + 1f, transform.position.y - 1f, transform.position.z);
            }
        }
    }

}
