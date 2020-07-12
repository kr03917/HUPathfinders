﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    
    public int countdownTime;
    public Text countdownDisplay;
    public bool start = false;
    private void Start(){
    	StartCoroutine(CountdownToStart());
    }
    
    IEnumerator CountdownToStart(){
    	while(countdownTime>0){
    		countdownDisplay.text = countdownTime.ToString();
    		yield return new WaitForSeconds(1f);
    		countdownTime--;
    	}
    	countdownDisplay.text = "GO!";
        start = true;
        yield return new WaitForSeconds(1f);
    	countdownDisplay.gameObject.SetActive(false);

    }
}
