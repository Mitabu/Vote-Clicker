using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Timer : MonoBehaviour
{
	private string savedDateTime; //DataTime saved in PlayerPrefs
	private string currentDateTime; //A buffer for current DataTime to be taken and compared with the saved DataTime
	
	private int minAwayInterval; //Minimum amount of time (in seconds) a user needs to spend away in order to get a while away bonus
	private int maxAwayInterval; //Maximum interval of time (in seconds) user can get rewarded for after returning to the app
	
	private DateTime savedDateTimeObj; //Same as savedDateTime but as object
	private DateTime currentDateTimeObj; //Same as currentDateTime but as object
	private TimeSpan buffer; //An object that is used as a buffer to store the difference between savedDateTime and currentDateTime
	
    void Start()
    {
		minAwayInterval = PlayerPrefs.GetInt("minAwayInterval");
		maxAwayInterval = PlayerPrefs.GetInt("maxAwayInterval");
        currentDateTime = System.DateTime.Now.ToString();
		if(PlayerPrefs.GetString("savedDateTime").Length < 3) {
			PlayerPrefs.SetString("savedDateTime", currentDateTime);
		}
		savedDateTimeObj = System.DateTime.Parse(PlayerPrefs.GetString("savedDateTime"));
		currentDateTimeObj = System.DateTime.Parse(currentDateTime);
		buffer = currentDateTimeObj.Subtract(savedDateTimeObj);
		
		if((int)buffer.TotalSeconds > maxAwayInterval) 
		{
			
			int voteNum = PlayerPrefs.GetInt("voteNum");
			voteNum += maxAwayInterval * CountWhatBotsHaveProduced();
			PlayerPrefs.SetInt("voteNum", voteNum);
			Debug.Log("You were away for " + buffer.TotalSeconds + "seconds.\nYour bots have harvested " + maxAwayInterval * CountWhatBotsHaveProduced() + "while you were away");
			
		}else if(maxAwayInterval > (int)buffer.TotalSeconds && (int)buffer.TotalSeconds > minAwayInterval) 
			{
				
				int voteNum = PlayerPrefs.GetInt("voteNum");
				voteNum += (int)buffer.TotalSeconds * CountWhatBotsHaveProduced();
				PlayerPrefs.SetInt("voteNum", voteNum);
				Debug.Log("You were away for " + buffer.TotalSeconds + " seconds. || Your bots have harvested " + (int)buffer.TotalSeconds * CountWhatBotsHaveProduced());
			
			}else 
				{
					Debug.Log("Not enough time spent away");
				}
		InvokeRepeating("SaveCurrentDateTime", 0.0f, 5.0f);
    }
	
	private int CountWhatBotsHaveProduced() {
		return (PlayerPrefs.GetInt("bot1")*PlayerPrefs.GetInt("bot1Efficiency") + PlayerPrefs.GetInt("bot2")*PlayerPrefs.GetInt("bot2Efficiency") + PlayerPrefs.GetInt("bot3")*PlayerPrefs.GetInt("bot3Efficiency"));
	}
	
	private void SaveCurrentDateTime() {
		currentDateTime = System.DateTime.Now.ToString();
		PlayerPrefs.SetString("savedDateTime", currentDateTime);
		//Debug.Log("Updating saved DateTime... " + PlayerPrefs.GetString("savedDateTime"));
	}
}
