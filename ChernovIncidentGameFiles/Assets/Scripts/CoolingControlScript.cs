using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolingControlScript : MonoBehaviour
{
    public GameObject Lever1, Lever2, Lever3;
    public GameObject CoolingOver;

    public void OnMouseDown()
    {
        CoolingOver.GetComponent<CoolingOverallScript>().PlaySound();

        if (gameObject.name == "1st0")
        {
            Lever1.transform.localPosition = new Vector3(Lever1.transform.localPosition.x, -0.000359f, Lever1.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever1Str = "0";
        }
        if (gameObject.name == "1st30")
        {
            Lever1.transform.localPosition = new Vector3(Lever1.transform.localPosition.x, -0.00023f, Lever1.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever1Str = "30";
        }
        if (gameObject.name == "1st60")
        {
            Lever1.transform.localPosition = new Vector3(Lever1.transform.localPosition.x, -9.4e-05f, Lever1.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever1Str = "60";
        }
        if (gameObject.name == "1st100")
        {
            Lever1.transform.localPosition = new Vector3(Lever1.transform.localPosition.x, 5.5e-05f, Lever1.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever1Str = "100";
        }
        //---------
        if (gameObject.name == "2st0")
        {
            Lever2.transform.localPosition = new Vector3(Lever2.transform.localPosition.x, -0.000359f, Lever2.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever2Str = "0";
        }
        if (gameObject.name == "2st30")
        {
            Lever2.transform.localPosition = new Vector3(Lever2.transform.localPosition.x, -0.00023f, Lever2.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever2Str = "30";
        }
        if (gameObject.name == "2st60")
        {
            Lever2.transform.localPosition = new Vector3(Lever2.transform.localPosition.x, -9.4e-05f, Lever2.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever2Str = "60";
        }
        if (gameObject.name == "2st100")
        {
            Lever2.transform.localPosition = new Vector3(Lever2.transform.localPosition.x, 5.5e-05f, Lever2.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever2Str = "100";
        }
        //----------
        if (gameObject.name == "3st0")
        {
            Lever3.transform.localPosition = new Vector3(Lever3.transform.localPosition.x, -0.000359f, Lever3.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever3Str = "0";
        }
        if (gameObject.name == "3st30")
        {
            Lever3.transform.localPosition = new Vector3(Lever3.transform.localPosition.x, -0.00023f, Lever3.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever3Str = "30";
        }
        if (gameObject.name == "3st60")
        {
            Lever3.transform.localPosition = new Vector3(Lever3.transform.localPosition.x, -9.4e-05f, Lever3.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever3Str = "60";
        }
        if (gameObject.name == "3st100")
        {
            Lever3.transform.localPosition = new Vector3(Lever3.transform.localPosition.x, 5.5e-05f, Lever3.transform.localPosition.z);
            CoolingOver.GetComponent<CoolingOverallScript>().Lever3Str = "100";
        }
        //-----------
        if (gameObject.name == "cooling1")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "1";
        }
        if (gameObject.name == "cooling2")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "2";
        }
        if (gameObject.name == "cooling3")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "3";
        }
        if (gameObject.name == "cooling4")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "4";
        }
        if (gameObject.name == "cooling5")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "5";
        }
        if (gameObject.name == "cooling6")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "6";
        }
        if (gameObject.name == "cooling7")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "7";
        }
        if (gameObject.name == "cooling8")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "8";
        }
        if (gameObject.name == "cooling9")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "9";
        }

        if (gameObject.name == "cooling0")
        {
            CoolingOver.GetComponent<CoolingOverallScript>().coolingNum += "0";
        }
    }
}
