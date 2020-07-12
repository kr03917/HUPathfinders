using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class winningChangeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IList<string> strList = new List<string>();
	strList.Add("Deans List!\n Please go to Presidents Office.");
	strList.Add("4.0 GPA!\n ");
	strList.Add("Scholarship Raised!\n Please go to Finance Office.");
	strList.Add("You were selected as a TA!\n Please go to Career Services");
	strList.Add("Successful Enrollment!\n Please go to RO.");
	Text changingText = GameObject.Find("Canvas/Text").GetComponent<Text>();
	int randomNumber = Random.Range(0,5);
	changingText.text = strList[randomNumber]; 
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
