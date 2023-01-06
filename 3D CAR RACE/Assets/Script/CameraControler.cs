using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject NormalCamera;
    public GameObject FarCamera;
    public GameObject FPCamera;
    public int CamMode;

    void Update()
    {
        if (Input.GetButtonDown("ViewMode"))
        {
            if (CamMode == 3)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
        }
    }

    IEnumerable ModeChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            NormalCamera.SetActive(true);
            FarCamera.SetActive(false);
            FPCamera.SetActive(false);
        }
        else if (CamMode == 1)
        {
            NormalCamera.SetActive(false);
            FarCamera.SetActive(true);
            FPCamera.SetActive(false);
        }
        else if (CamMode == 2)
        {
            NormalCamera.SetActive(false);
            FarCamera.SetActive(false);
            FPCamera.SetActive(true);
        }
    }
}
