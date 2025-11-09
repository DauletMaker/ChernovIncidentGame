using System.Collections;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    public Animator MainCamAnim;   // camera animator



    void Update()
    {
        // Camera animation triggers
        if (Input.GetKeyDown(KeyCode.C))
            MainCamAnim.SetTrigger("Cooling");
        else if (Input.GetKeyDown(KeyCode.E))
            MainCamAnim.SetTrigger("Kernel");
        else if (Input.GetKeyDown(KeyCode.P))
            MainCamAnim.SetTrigger("Power");
        else if (Input.GetKeyDown(KeyCode.B))
            MainCamAnim.SetTrigger("Back");

        // Talking trigger

    }

    
}
