using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardButtonScript : MonoBehaviour
{
    public GameObject PowerControl;

    public void OnMouseDown()
    {
        PowerControl.GetComponent<PowerControlScript>().ClickButton();
        if (gameObject.name != "enter" && gameObject.name != "delete")
        {
            if(PowerControl.GetComponent<PowerControlScript>().powerText.text.Length < 19)
            {
                PowerControl.GetComponent<PowerControlScript>().powerT += gameObject.name;
            }
        }
        else if (gameObject.name == "enter")
        {
            PowerControl.GetComponent<PowerControlScript>().ClickEnter();
        }
        else if (gameObject.name == "delete")
        {
            var powerControl = PowerControl.GetComponent<PowerControlScript>();

            if (powerControl.powerT.Length > 0)
            {
                powerControl.powerT = powerControl.powerT.Substring(0, powerControl.powerT.Length - 1);
            }

        }
    }
}
