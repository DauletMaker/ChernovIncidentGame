using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerControlScript : MonoBehaviour
{
    public TMP_Text powerText, IndicatorText;
    public string powerT;
    public bool powerDone;
    public GameObject incorrectLightParent, CorrectLightParent;
    public GameObject EmergencyControl;
    public Animator arrowAnim;
    public AudioSource Correct, Press;

    public void Update()
    {
        powerText.text = powerT;
    }
    public void ClickEnter()
    {
        if(powerT == "sudo /power adj z")
        {
            Correct.Play();
            incorrectLightParent.SetActive(false);
            CorrectLightParent.SetActive(true);
            powerDone = true;
            EmergencyControl.GetComponent<EmergencyControlScript>().powerAdj = true;
            powerT = "*******************";
            IndicatorText.text = "Safe";
            arrowAnim.SetTrigger("Done");
        }
        else
        {
            powerT = "";
        }
    }
    public void ClickButton()
    {
        Press.Play();
    }
}
