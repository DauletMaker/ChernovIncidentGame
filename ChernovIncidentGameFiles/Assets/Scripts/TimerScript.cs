using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timeText;   
    public float startTime = 600f;

    private float remainingTime;
    private bool timerRunning = false;
    public GameObject EmergencyContr;
    public bool endingStarted;

    public GameObject goodLight, generalLight;
    public AudioSource tick, phone;

    public GameObject Light1, Light2, Light3;
    public GameObject CameraMain;
    public GameObject explosion, Final, tense, Siren;

    void Start()
    {
        remainingTime = startTime;
        timerRunning = true;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!timerRunning) return;

        if (EmergencyContr.GetComponent<EmergencyControlScript>().emergencyAdj == false)
        {

            remainingTime -= Time.deltaTime;
        }
        else if (endingStarted == false)
        {
            remainingTime = 147f;
            Siren.SetActive(false);
            Final.SetActive(false);
            generalLight.SetActive(false);
            StartCoroutine(GoodEndingBegDelay());
            timeText.text = "--:--:--";
            generalLight.SetActive(false);
            tick.Stop();
            tense.SetActive(false);

            endingStarted = true;
        }

        if (remainingTime <= 300f)
        {
            tense.SetActive(true);
        }
        if (remainingTime <= 60f)
        {
            Final.SetActive(true);
        }
        if (remainingTime <= 10f)
        {
            Siren.SetActive(true);
        }
        if (remainingTime <= 0f)
        {
            tick.Stop();
            tense.SetActive(false);
            Final.SetActive(false);

            remainingTime = 0f;
            timerRunning = false;
            UpdateTimerDisplay();
            Light1.GetComponent<Light>().intensity += 999f;
            Light2.GetComponent<Light>().intensity += 999f;
            Light3.GetComponent<Light>().intensity += 999f;
            StartCoroutine(CameraMain.GetComponent<CameraControlScript>().ShakeCamera());
            BadEnding();
            explosion.SetActive(true);
            phone.enabled = false;

            return;
        }

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        int hundredths = Mathf.FloorToInt((remainingTime * 100f) % 100f);

        timeText.text = $"{minutes:00}:{seconds:00}:{hundredths:00}";
    }

    public void BadEnding()
    {
        StartCoroutine(BadEndingDelay());
    }

    public IEnumerator BadEndingDelay()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("BadOutro");
    }

    public IEnumerator GoodEndingBegDelay()
    {
        yield return new WaitForSeconds(7f);
        GoodEnding();
    }
    public void GoodEnding()
    {
        generalLight.SetActive(true);
        goodLight.SetActive(true);

        StartCoroutine(GoodEndingDelay());
    }

    public IEnumerator GoodEndingDelay()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("GoodOutro");
    }
}
