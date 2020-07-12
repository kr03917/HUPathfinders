using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeText : MonoBehaviour
{

	
    // Start is called before the first frame update
    void Start()
    {
        IList<string> strList = new List<string>();
	strList.Add("Academic Warning!\n Please report to OAP for a meeting.");
	strList.Add("You have been caught with plagarism!\n Please report to Conduct Office.");
	strList.Add("Scholarship Revoked!\n Please report to Finance Office.");
	strList.Add("Graduation delayed!\n Please report to RO");
	strList.Add("You enrolled in UAK's course!\n Only a higher power can help you now.");
	Text changingText = GameObject.Find("Canvas/Text").GetComponent<Text>();
	int randomNumber = Random.Range(0,5);
	changingText.text = strList[randomNumber]; 
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
