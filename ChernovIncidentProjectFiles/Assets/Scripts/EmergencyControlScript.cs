using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmergencyControlScript : MonoBehaviour
{
    public GameObject RodsOff, RodsPartiallyOn, RodsMostlyOn;
    public bool powerAdj, coolingAdj, emergencyAdj;
    public string emergencyNum;
    public TMP_Text emergencyTMPtext;


    void Update()
    {
        emergencyTMPtext.text = emergencyNum;
        if(emergencyAdj == false && coolingAdj == true && powerAdj == true)
        {
            RodsMostlyOn.SetActive(false);
            RodsPartiallyOn.SetActive(true);
        }
        else if(emergencyAdj == true)
        {
            RodsPartiallyOn.SetActive(false);
            RodsOff.SetActive(true);
        }

        
    }

    public void EnterButton()
    {
        if (emergencyNum == "106")
        {
            emergencyAdj = true;
        }
        emergencyNum = "";
    }
}
