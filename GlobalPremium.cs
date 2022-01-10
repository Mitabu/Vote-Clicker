using UnityEngine;
using UnityEngine.UI;

public class GlobalPremium : MonoBehaviour
{
	public static int PremiumCount;
	public GameObject PremiumCountDisplay;
	private int InternalPremiumCount;

    private void Update()
    {
		InternalPremiumCount = PremiumCount;
        PremiumCountDisplay.GetComponent<Text>().text = InternalPremiumCount.ToString();
    }
}
