using UnityEngine;
using UnityEngine.UI;

public class ExchangeMechanics : MonoBehaviour
{
    public GameObject ExchangeCash1;
	public GameObject ExchangeCash2;
	public GameObject ExchangeCash3;
	public GameObject ExchangeCash4;
	public GameObject ExchangeCash5;
	public GameObject ExchangeRateDisplay;
	
	private int Exchange1Amount;
	private int Exchange2Amount;
	private int Exchange3Amount;
	private int Exchange4Amount;
	private int Exchange5Amount;
	
	private void Start()
	{
		UpdatePrices();
	}

	public void UpdatePrices()
	{
		Exchange1Amount = (int)(Storage.Exchange1Amount * Storage.PrestigeLvl);
		Exchange2Amount = (int)(Storage.Exchange2Amount * Storage.PrestigeLvl);
		Exchange3Amount = (int)(Storage.Exchange3Amount * Storage.PrestigeLvl);
		Exchange4Amount = (int)(Storage.Exchange4Amount * Storage.PrestigeLvl);
		Exchange5Amount = (int)(Storage.Exchange5Amount * Storage.PrestigeLvl);
		
		ExchangeCash1.transform.Find("Text").GetComponent<Text>().text = Exchange1Amount.ToString("N0") + " votes for " + (Exchange1Amount * Storage.ExchangeRate).ToString("N0") + " " + Storage.CashCurrencyName;
		ExchangeCash2.transform.Find("Text").GetComponent<Text>().text = Exchange2Amount.ToString("N0") + " votes for " + (Exchange2Amount * (Storage.ExchangeRate + Storage.ExchangeRateBonus1)).ToString("N0") + " " + Storage.CashCurrencyName;
		ExchangeCash3.transform.Find("Text").GetComponent<Text>().text = Exchange3Amount.ToString("N0") + " votes for " + (Exchange3Amount * (Storage.ExchangeRate + Storage.ExchangeRateBonus2)).ToString("N0") + " " + Storage.CashCurrencyName;
		ExchangeCash4.transform.Find("Text").GetComponent<Text>().text = Exchange4Amount.ToString("N0") + " votes for " + (Exchange4Amount * (Storage.ExchangeRate + Storage.ExchangeRateBonus3)).ToString("N0") + " " + Storage.CashCurrencyName;
		ExchangeCash5.transform.Find("Text").GetComponent<Text>().text = Exchange5Amount.ToString("N0") + " votes for " + (Exchange5Amount * (Storage.ExchangeRate + Storage.ExchangeRateBonus4)).ToString("N0") + " " + Storage.CashCurrencyName;
		ExchangeRateDisplay.GetComponent<Text>().text = "Exchange rate is\n" + Storage.ExchangeRate.ToString() + " " + Storage.CashCurrencyName + " for 1 vote";
	}
	
	public void Exchange1() {
		if(GlobalVotes.VoteCount >= (ulong)Exchange1Amount) {
			GlobalVotes.VoteCount -= (ulong)Exchange1Amount;
			GlobalCash.CashCount += (int)(Exchange1Amount * Storage.ExchangeRate);
		}
	}
	public void Exchange2() {
		if(GlobalVotes.VoteCount >= (ulong)Exchange2Amount) {
			GlobalVotes.VoteCount -= (ulong)Exchange2Amount;
			GlobalCash.CashCount += (int)(Exchange2Amount * (Storage.ExchangeRate + Storage.ExchangeRateBonus1));
		}
	}
	public void Exchange3() {
		if(GlobalVotes.VoteCount >= (ulong)Exchange3Amount) {
			GlobalVotes.VoteCount -= (ulong)Exchange3Amount;
			GlobalCash.CashCount += (int)(Exchange3Amount * (Storage.ExchangeRate + Storage.ExchangeRateBonus2));
		}
	}
	public void Exchange4() {
		if(GlobalVotes.VoteCount >= (ulong)Exchange4Amount) {
			GlobalVotes.VoteCount -= (ulong)Exchange4Amount;
			GlobalCash.CashCount += (int)(Exchange4Amount * (Storage.ExchangeRate + Storage.ExchangeRateBonus3));
		}
	}
	public void Exchange5() {
		if(GlobalVotes.VoteCount >= (ulong)Exchange5Amount) {
			GlobalVotes.VoteCount -= (ulong)Exchange5Amount;
			GlobalCash.CashCount += (int)(Exchange5Amount * (Storage.ExchangeRate + Storage.ExchangeRateBonus4));
		}
	}
}
