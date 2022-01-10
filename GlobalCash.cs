using UnityEngine;
using UnityEngine.UI;

public class GlobalCash : MonoBehaviour
{
	public static int CashCount;
	public GameObject CashCountDisplay;
	private int InternalCashCount;

    private void Update()
    {
		InternalCashCount = CashCount;
        CashCountDisplay.GetComponent<Text>().text = InternalCashCount.ToString();
    }
}