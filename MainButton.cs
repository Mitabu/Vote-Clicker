using UnityEngine;

public class MainButton : MonoBehaviour
{
	public void ClickMainButton() 
	{
		GlobalVotes.VoteCount += (ulong)Storage.VotesPerClick;
	}
}
