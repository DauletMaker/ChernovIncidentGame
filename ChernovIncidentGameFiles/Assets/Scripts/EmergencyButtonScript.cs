using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyButtonScript : MonoBehaviour
{
    public GameObject EmergencyControl;

    public void OnMouseDown()
    {
        EmergencyControl.GetComponent<EmergencyControlScript>().PressButton();
        if (EmergencyControl.GetComponent<EmergencyControlScript>().emergencyNum.Length > 3 || (EmergencyControl.GetComponent<EmergencyControlScript>().emergencyNum.Length == 3 && EmergencyControl.GetComponent<EmergencyControlScript>().emergencyNum != "106"))
        {
            EmergencyControl.GetComponent<EmergencyControlScript>().emergencyNum = "";
        }
        if(gameObject.name != "emergencybutton")
        {
            EmergencyControl.GetComponent<EmergencyControlScript>().emergencyNum += gameObject.name;
        }
        if (gameObject.name == "emergencybutton")
        {
            EmergencyControl.GetComponent<EmergencyControlScript>().EnterButton();
        }
    }
}
