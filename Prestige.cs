using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prestige : MonoBehaviour
{
	private float prestigeLvl;
	private float targetVoteGoalMultiplier;
	private int prestigePrice;
	private int voteNum;
	
	public Button bbb1;
	public Button bbb2;
	public Button bbb3;
	public Button bub;
	
	public void PrestigeUpgrade() {
		prestigeLvl = PlayerPrefs.GetFloat("prestigeLvl");
		targetVoteGoalMultiplier = PlayerPrefs.GetFloat("targetVoteGoalMultiplier");
		prestigePrice = PlayerPrefs.GetInt("prestigePrice");
		voteNum = PlayerPrefs.GetInt("voteNum");
		if(voteNum >= (int)(prestigePrice*targetVoteGoalMultiplier)) {
			voteNum -= (int)(prestigePrice*targetVoteGoalMultiplier);
			PlayerPrefs.SetInt("voteNum", voteNum);
			prestigeLvl += 1;
			PlayerPrefs.SetFloat("prestigeLvl", prestigeLvl);
			PlayerPrefs.SetFloat("targetVoteGoalMultiplier", PlayerPrefs.GetFloat("prestigeLvl") + PlayerPrefs.GetFloat("prestigeLvl")*(float)0.2);
			ResetProgress();
		}else {
			Debug.Log((prestigePrice*targetVoteGoalMultiplier));
		}
	}
	
	private void ResetProgress() {
		//Stop Bots
		GameObject Canvas = GameObject.Find("Canvas");
		GameObject bb1 = GameObject.Find("Button_Buy_Bot1");
		GameObject bb2 = GameObject.Find("Button_Buy_Bot2");
		GameObject bb3 = GameObject.Find("Button_Buy_Bot3");
		Canvas.SendMessage("BotStop");
		bb1.SendMessage("BotStop");
		bb2.SendMessage("BotStop");
		bb3.SendMessage("BotStop");
		
		//Turn the upgrade buttons back on
		bbb1.interactable = true;
		bbb2.interactable = true;
		bbb3.interactable = true;
		bub.interactable = true;
		
		//Reset bots' bought status
		PlayerPrefs.SetInt("bot1", 0);
		PlayerPrefs.SetInt("bot2", 0);
		PlayerPrefs.SetInt("bot3", 0);
		
		//Reset vote per click upgrade
		PlayerPrefs.SetInt("upgradeNumber", 0);
		PlayerPrefs.SetInt("votesPerClick", 5*(int)prestigeLvl);
	}
}
