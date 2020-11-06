using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    public static CamerasManager instance { get; private set; }

    public CinemachineVirtualCamera currentCam;

    public CinemachineVirtualCamera lastCam;

    public CameraShake shakeVisible;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentCam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        shakeVisible = GameObject.FindObjectOfType<CameraShake>(); // ojo aca

        lastCam = currentCam;
    }

    public void SetCamera(CinemachineVirtualCamera newCam)
    {
        lastCam = currentCam;
        currentCam = newCam;

        shakeVisible = currentCam.GetComponent<CameraShake>();
    }

    public static void ShakeCameraNormal(float intensity, float time)
    {
        instance.currentCam.GetComponent<CameraShake>().ShakeCameraNormal(intensity, time);
    }

    public void DestroyCurrentCamera(float afterTime)
    {
        if (lastCam != currentCam)
        {
            print("debug");
            Destroy(currentCam.gameObject, afterTime);
            currentCam = lastCam;

            shakeVisible = currentCam.GetComponent<CameraShake>();
        }
        else
            print("No puedo eliminar la unica camara, gil de goma");
    }

}
