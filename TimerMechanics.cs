using System;
using UnityEngine;
using UnityEngine.UI;


public class TimerMechanics : MonoBehaviour
{
	public GameObject AwayNotification;
	public GameObject AwayNotificationContainer;
	
	private string savedDateTime; //DataTime saved in PlayerPrefs
	private string currentDateTime; //A buffer for current DataTime to be taken and compared with the saved DataTime
	
	private DateTime savedDateTimeObj; //Same as savedDateTime but as object
	private DateTime currentDateTimeObj; //Same as currentDateTime but as object
	private TimeSpan buffer; //An object that is used as a buffer to store the difference between savedDateTime and currentDateTime
	
	private void OnApplicationFocus(bool hasFocus)
	{
		if(!hasFocus) {
			SaveCurrentDateTime();
		}
		if(hasFocus) {
			//CancelInvoke();
			ActivateTimer();
		}
	}
	
	private void ActivateTimer() {
		currentDateTime = System.DateTime.Now.ToString();
		Debug.Log(currentDateTime);
		if(PlayerPrefs.GetString("savedDateTime").Length < 3) {
			PlayerPrefs.SetString("savedDateTime", currentDateTime);
		}
		savedDateTimeObj = System.DateTime.Parse(PlayerPrefs.GetString("savedDateTime"));
		currentDateTimeObj = System.DateTime.Parse(currentDateTime);
		buffer = currentDateTimeObj.Subtract(savedDateTimeObj);

		int BotPower = CountWhatBotsHaveProduced();
		if((int)buffer.TotalSeconds > Storage.MaxAwayInterval && BotPower > 0) 
		{
			ulong a = GlobalVotes.VoteCount;
			GlobalVotes.VoteCount += (ulong)(Storage.MaxAwayInterval * BotPower);
			ulong b = GlobalVotes.VoteCount;
			AwayNotification.GetComponent<Text>().text = "You were away for more than " + Storage.MaxAwayInterval + 
			                                             " seconds\n\nYour hackers harvested " +
			                                             (Storage.MaxAwayInterval * BotPower).ToString("N0"/*, CultureInfo.CreateSpecificCulture("en-US")*/)
			                                             + " votes while you were away" + "\n\nVotes before: " + a + "\nVotes after: " + b + 
			                                             "\n\nPress anywhere to continue...";
			AwayNotificationContainer.SetActive(true);
			//Debug.Log("You were away for " + buffer.TotalSeconds);
			
		}else if(Storage.MaxAwayInterval > (int)buffer.TotalSeconds && (int)buffer.TotalSeconds > Storage.MinAwayInterval && BotPower > 0)
		{
			ulong a = GlobalVotes.VoteCount;
			GlobalVotes.VoteCount += (ulong)((int)buffer.TotalSeconds * BotPower);
			ulong b = GlobalVotes.VoteCount;
			AwayNotification.GetComponent<Text>().text = "You were away for " + buffer.TotalSeconds + 
			                                             " seconds\n\nYour hackers harvested " + 
			                                             ((int)buffer.TotalSeconds * BotPower).ToString("N0"/*, CultureInfo.CreateSpecificCulture("en-US")*/)
			                                             + " votes while you were away" + "\n\nVotes before: " + a + "\nVotes after: " + b + 
			                                             "\n\nPress anywhere to continue...";
			
			AwayNotificationContainer.SetActive(true);
			//Debug.Log("You were away for " + buffer.TotalSeconds);
				
		}else 
		{
			Debug.Log("Not Enough Time Spent Away");
		}
		//InvokeRepeating("SaveCurrentDateTime", 0.0f, 5.0f);
	}
	
	private int CountWhatBotsHaveProduced() {
		int ProductionCount = 0;
		if(Storage.Bot1 > 0) {
			ProductionCount += Storage.Bot1Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot1);
		}
		if(Storage.Bot2 > 0) {
			ProductionCount += Storage.Bot2Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot2);
		}
		if(Storage.Bot3 > 0) {
			ProductionCount += Storage.Bot3Efficiency * Storage.PrestigeLvl * (int)Math.Pow(1.5, Storage.Bot3);
		}
		return (ProductionCount);
	}
	
	private void SaveCurrentDateTime() {
		currentDateTime = System.DateTime.Now.ToString();
		PlayerPrefs.SetString("savedDateTime", currentDateTime);
		Debug.Log("Updating saved DateTime... " + PlayerPrefs.GetString("savedDateTime"));
	}
}