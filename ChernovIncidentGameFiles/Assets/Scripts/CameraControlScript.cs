using System.Collections;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    public Animator MainCamAnim;   // camera animator
    public Transform camTransform; // assign your Main Camera here
    public float shakeDuration = 3f;   // how long the shake lasts
    public float shakeMagnitude = 0.2f;  // how intense the shake is
    public float dampingSpeed = 1.0f;    // how quickly it fades out

    private Vector3 initialPosition;
    private bool isShaking = false;

    void Start()
    {
        if (camTransform == null)
            camTransform = transform; // fallback if not set
    }

    void Update()
    {
        // 🔹 Camera animation triggers
        if (Input.GetKeyDown(KeyCode.C))
            MainCamAnim.SetTrigger("Cooling");
        else if (Input.GetKeyDown(KeyCode.E))
            MainCamAnim.SetTrigger("Kernel");
        else if (Input.GetKeyDown(KeyCode.P))
            MainCamAnim.SetTrigger("Power");
        else if (Input.GetKeyDown(KeyCode.B))
            MainCamAnim.SetTrigger("Back");

        // 🔸 Trigger explosion shake manually (for testing)
    }

    public IEnumerator ShakeCamera()
    {
        if (isShaking) yield break;
        isShaking = true;

        float elapsed = 0.0f;
        initialPosition = camTransform.localPosition;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            camTransform.localPosition = new Vector3(
                initialPosition.x + x,
                initialPosition.y + y,
                initialPosition.z
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Smoothly return to starting position
        float t = 0f;
        while (t < 1f)
        {
            camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, initialPosition, t);
            t += Time.deltaTime * dampingSpeed;
            yield return null;
        }

        camTransform.localPosition = initialPosition;
        isShaking = false;
    }
}
