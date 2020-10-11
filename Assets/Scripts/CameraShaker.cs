using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker current;
    public CinemachineVirtualCamera camBrain;

    private void Awake()
    {
        if(CameraShaker.current == null)
            CameraShaker.current = this;

        camBrain = FindObjectOfType<CinemachineVirtualCamera>();
        camBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().enabled = false;
    }

    public void ScreenShake(float t)
    {
        StartCoroutine(Shake(t));
    }

    private IEnumerator Shake(float t)
    {
        var perlin_profile = camBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin_profile.enabled = true;
        yield return new WaitForSeconds(t);
        perlin_profile.enabled = false;
    }
}
