using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickVote : MonoBehaviour
{
	public Text displayVotes;
	public int voteNum;

	private void Update() {
		voteNum = PlayerPrefs.GetInt("voteNum");
		//if prestigeLVL= 0
		displayVotes.text = "Votes: " + voteNum + " / 100,000";
	}
	
	public void VoteOnClick() {
		voteNum += PlayerPrefs.GetInt("votesPerClick");
		PlayerPrefs.SetInt("voteNum", voteNum);
	}
}
