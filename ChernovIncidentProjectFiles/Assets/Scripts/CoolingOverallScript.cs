using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoolingOverallScript : MonoBehaviour
{
    public string Lever1Str = "", Lever2Str = "", Lever3Str = "";
    public string coolingNum = "";
    public bool coolingDone;
    public TMP_Text resetCodetext, redNum;
    public GameObject EmergencyControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resetCodetext.text = coolingNum;

        if (coolingNum == "674291" && Lever1Str == "60" && Lever2Str == "30" && Lever3Str == "0")
        {
            redNum.text = "4780";
            coolingDone = true;
            EmergencyControl.GetComponent<EmergencyControlScript>().coolingAdj = true;

        }
        if (coolingNum.Length >= 6)
        {
            coolingNum = "";
        }
    }
}
