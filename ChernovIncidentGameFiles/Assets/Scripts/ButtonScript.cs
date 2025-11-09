using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public float pressDepth = -0.00045f;   // how far it moves down
    public float pressDuration = 0.1f;    // how fast it goes down/up

    private Vector3 originalPos;
    private bool isPressing = false;
    private string number;

    public GameObject Phone;
    public AudioSource dialing;
    public AudioClip dialClip;



    void Start()
    {
        originalPos = transform.localPosition;
        if(gameObject.name == "button1")
        {
            number = "1";
        }
        if (gameObject.name == "button2")
        {
            number = "2";
        }
        if (gameObject.name == "button3")
        {
            number = "3";
        }
        if (gameObject.name == "button4")
        {
            number = "4";
        }
        if (gameObject.name == "button5")
        {
            number = "5";
        }
        if (gameObject.name == "button6")
        {
            number = "6";
        }
        if (gameObject.name == "button7")
        {
            number = "7";
        }
        if (gameObject.name == "button8")
        {
            number = "8";
        }
        if (gameObject.name == "button9")
        {
            number = "9";
        }
        if (gameObject.name == "button*")
        {
            number = "*";
        }
        if (gameObject.name == "button#")
        {
            number = "#";
        }
        if (gameObject.name == "button0")
        {
            number = "0";
        }
        //-----------
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        print("TESTING");
        if (!isPressing && gameObject.name.Contains("button"))
        {
            dialing.PlayOneShot(dialClip);
            Phone.GetComponent<PhoneScript>().numberPressed = true;
            StartCoroutine(PressAnimation());

        }
    }

    private IEnumerator PressAnimation()
    {
        isPressing = true;
        Vector3 pressedPos = originalPos - new Vector3(0, pressDepth, 0);

        float elapsed = 0f;
        while (elapsed < pressDuration)
        {
            // Move down smoothly
            transform.localPosition = Vector3.Lerp(originalPos, pressedPos, elapsed / pressDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = pressedPos;

        // short delay to stay pressed for a moment
        yield return new WaitForSeconds(0.05f);

        elapsed = 0f;
        while (elapsed < pressDuration)
        {
            // Move back up smoothly
            transform.localPosition = Vector3.Lerp(pressedPos, originalPos, elapsed / pressDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        isPressing = false;
        
        StartCoroutine(PressDelay());
        
    }

    private IEnumerator PressDelay()
    {
        yield return new WaitForSeconds(2f);
        Phone.GetComponent<PhoneScript>().numSequence += number;
    }
}
