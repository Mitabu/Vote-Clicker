using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public Image mask;
    private int voteNum;

    void Start()
    {
        
    }

  
    void Update()
    {
        GetCurrentFill();
        voteNum = PlayerPrefs.GetInt("voteNum");
    }

    void GetCurrentFill()
    {

        float fillAmount = (float)voteNum / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
