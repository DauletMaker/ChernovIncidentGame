using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public string numSequence;
    public Transform Phone;

    public bool isVibrating = false;
    private Vector3 originalPhonePos;
    public bool firstDialogue = false;
    public string CallStage = "";
    public bool numberPressed;

    public AudioSource source, dialingSource;
    public AudioClip MainMenu1, Cooling1, calling, Cooling2, Cooling3, reset1, reset2, reset3, power1, power2, power3, power4, emergency1, emergency2, emergency3, emergency4;


    void Start()
    {
        callingIntro();
    }

    void Update()
    {
        //-------Main-Menu:---------
        if(CallStage == "MainMenu")
        {
            if(numSequence == "1")
            {
                CallStage = "CoolingOverview";
                numberPressed = false;

                CoolingDialogue();
                numSequence = "";
            }
            if (numSequence == "2")
            {
                CallStage = "Power";
                numberPressed = false;

                PowerDialogue();
                numSequence = "";
            }
            if (numSequence == "3")
            {
                CallStage = "Emergency";
                numberPressed = false;

                EmergencyDialogue();
                numSequence = "";
            }
            if (numSequence == "4")
            {
                CallStage = "Code";
                numberPressed = false;

                CodeDialogue();
                numSequence = "";
            }
        }
        //-------Cooling:-----------
        if (CallStage == "CoolingOverview")
        {
            if (numSequence == "3")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";
            }
            if (numSequence == "2")
            {
                CallStage = "CoolingNo";
                numberPressed = false;

                CoolingNoDialogue();
                numSequence = "";
            }
            if (numSequence == "1")
            {
                CallStage = "CoolingYes";
                numberPressed = false;

                CoolingYesDialogue();
                numSequence = "";
            }
        }
        if(CallStage == "CoolingNo")
        {
            if(numSequence == "1")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";

            }
        }
        if (CallStage == "CoolingYes")
        {
            if (numSequence == "1")
            {
                CallStage = "CoolingOverview";
                numberPressed = false;

                CoolingDialogue();
                numSequence = "";

            }
        }
        //----------Reset-code:---------
        if (CallStage == "Code")
        {
            if (numSequence == "9")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";

            }
            else if(numSequence == "231#")
            {
                CallStage = "CodeCorrect";
                numberPressed = false;

                CodeCorrectDialogue();
                numSequence = "";
            }
            else if (numSequence.Contains("#"))
            {
                CallStage = "CodeIncorrect";
                numberPressed = false;

                CodeIncorrectDialogue();
                numSequence = "";
            }
        }
        if (CallStage == "CodeIncorrect")
        {
            if (numSequence == "9")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";

            }
            if (numSequence == "1")
            {
                CallStage = "Code";
                numberPressed = false;

                CodeDialogue();
                numSequence = "";
            }
        }
        if (CallStage == "CodeCorrect")
        {
            if (numSequence == "9")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";

            }
            if (numSequence == "1")
            {
                CallStage = "Code";
                numberPressed = false;

                CodeDialogue();
                numSequence = "";
            }

        }
        //----------Power-adjustment:---------
        if (CallStage == "Power")
        {
            if (numSequence == "1")
            {
                CallStage = "PowerHigh";
                numberPressed = false;

                PowerHighDialogue();
                numSequence = "";

            }
            if (numSequence == "2")
            {
                CallStage = "PowerLow";
                numberPressed = false;

                PowerLowDialogue();
                numSequence = "";

            }

        }
        if (CallStage == "PowerHigh")
        {
            if (numSequence == "1")
            {
                CallStage = "PowerLow";
                numberPressed = false;

                PowerLowDialogue();
                numSequence = "";

            }
            if (numSequence == "2")
            {
                CallStage = "PowerHighSudo";
                numberPressed = false;

                PowerHighSudoDialogue();
                numSequence = "";
            }
        }
        if (CallStage == "PowerLow")
        {
            if (numSequence == "1")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";

            }
        }
        if (CallStage == "PowerHighSudo")
        {
            if (numSequence == "1")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";

            }
        }
        //----------Emergency:---------
        if (CallStage == "Emergency")
        {
            if (numSequence == "1")
            {
                CallStage = "EmergencyMost";
                numberPressed = false;

                MostDialogue();
                numSequence = "";

            }
            if (numSequence == "2")
            {
                CallStage = "SomeDialogue";
                numberPressed = false;

                SomeDialogue();
                numSequence = "";

            }
            if (numSequence == "3")
            {
                CallStage = "NoneDialogue";
                numberPressed = false;

                NoneDialogue();
                numSequence = "";

            }
            if (numSequence == "4")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";

            }
        }
        if (CallStage == "EmergencyMost")
        {
            if (numSequence == "1")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";
            }
        }
        if (CallStage == "SomeDialogue")
        {
            if (numSequence == "1")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";
            }
        }
        if (CallStage == "NoneDialogue")
        {
            if (numSequence == "1")
            {
                CallStage = "MainMenu";
                numberPressed = false;

                introDialogue();
                numSequence = "";
            }
        }
    }

    private IEnumerator VibratePhone(float talkingTime, AudioClip clip, string CallStageTalking)
    {

        source.PlayOneShot(clip);
        isVibrating = true;
        originalPhonePos = Phone.localPosition;

        float loudness = GetLoudness();
        float strength = 0.02f;
        float speed = 40f;

        // Vibrate for talkingTime seconds
        float elapsed = 0f;
        while (elapsed < talkingTime)
        {
            loudness = GetLoudness();
            if (numberPressed && CallStageTalking != "Code")
            {
                source.Stop();
                Phone.localPosition = originalPhonePos;
                isVibrating = false;
                yield break;
            }
            else if (CallStageTalking == "Code" && numberPressed == true) 
            {
                source.Stop();
                Phone.localPosition = originalPhonePos;
                isVibrating = false;
            }
            if ((numSequence == "9" && CallStageTalking == "Code") || (numSequence == "231#" && CallStageTalking == "Code"))
            {
                print("SADJASNDJKASNDKA");
                yield break;
            }
            else if(numSequence.Contains("#") && CallStageTalking == "Code" && numSequence != "231#")
            {
                source.Stop();
                Phone.localPosition = originalPhonePos;
                isVibrating = false;
                yield break;
            }
            if ((loudness > 0.0001f && clip != calling) || (loudness > 0.01f && clip == calling))
            {
                float offsetX = Mathf.Sin(Time.time * speed) * strength;
                float offsetY = Mathf.Cos(Time.time * speed * 1.5f) * strength;
                Phone.localPosition = originalPhonePos + new Vector3(offsetX, offsetY, 0);
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        Phone.localPosition = originalPhonePos;
        isVibrating = false;


        if (numberPressed && CallStageTalking != "Code")
        {
            yield break;
        }
        if (clip == calling)
        {
            CallStage = "MainMenu";
            introDialogue();
        }
        yield return new WaitForSeconds(10f);

        if (numSequence == "" && CallStage == CallStageTalking && clip != calling)
        {
            if(CallStageTalking == "Code")
            {
                numSequence = "";
            }
            StartCoroutine(VibratePhone(talkingTime, clip, CallStageTalking));
        }
    }

    private float GetLoudness()
    {
        float[] data = new float[256];
        source.GetOutputData(data, 0);

        float sum = 0f;
        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i] * data[i];
        }

        return Mathf.Sqrt(sum / data.Length); // RMS loudness
    }

    public void callingIntro()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(calling.length, calling, CallStage));
        }


    }

    public void introDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(MainMenu1.length, MainMenu1, CallStage));
        }
            

    }
    public void CoolingDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(Cooling1.length, Cooling1, CallStage));
        }
    }
    public void CoolingNoDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(Cooling2.length, Cooling2, CallStage));
        }
    }
    public void CoolingYesDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(Cooling3.length, Cooling3, CallStage));
        }
    }
    public void CodeDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(reset1.length, reset1, CallStage));
        }
    }
    public void CodeIncorrectDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(reset2.length, reset2, CallStage));
        }
    }
    public void CodeCorrectDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(reset3.length, reset3, CallStage));
        }
    }
    public void PowerDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(power1.length, power1, CallStage));
        }
    }
    public void PowerHighDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(power2.length, power2, CallStage));
        }
    }
    public void PowerHighSudoDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(power3.length, power3, CallStage));
        }
    }
    public void PowerLowDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(power4.length, power4, CallStage));
        }
    }
    public void EmergencyDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(emergency1.length, emergency1, CallStage));
        }
    }
    public void MostDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(emergency2.length, emergency2, CallStage));
        }
    }
    public void SomeDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(emergency3.length, emergency3, CallStage));
        }
    }
    public void NoneDialogue()
    {
        if (!isVibrating)
        {
            StartCoroutine(VibratePhone(emergency4.length, emergency4, CallStage));
        }
    }

    public IEnumerator repeatDialogue()
    {
        yield return new WaitForSeconds(7f);

    }


}
