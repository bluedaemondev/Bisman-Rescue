using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker current;
    public CinemachineVirtualCamera camBrain;
    public CinemachineBasicMultiChannelPerlin perlinNoise;
    public float shakeDuration = 0.3f;
    public float max_ShakeAmplitude = 1.3f;
    public float max_ShakeFreq = 3.6f;


    private void Awake()
    {
        if(CameraShaker.current == null)
            CameraShaker.current = this;
    }
    private void Start()
    {
        camBrain = this.GetComponent<CinemachineVirtualCamera>();
        perlinNoise = camBrain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlinNoise.m_AmplitudeGain = 0;
        perlinNoise.m_FrequencyGain = 0;
    }

    public IEnumerator CinemachineShake(float duration, float magnitude)
    {
        float elapsed_t = 0f;
        perlinNoise.m_AmplitudeGain = Mathf.Clamp(magnitude, 0, max_ShakeAmplitude);
        perlinNoise.m_FrequencyGain = Mathf.Clamp(magnitude, 0, max_ShakeFreq);
        //print("starting...");
        //print("A:" + perlinNoise.m_AmplitudeGain + " ||  F: " + perlinNoise.m_FrequencyGain);
        while (elapsed_t < duration)
        {
            elapsed_t += Time.deltaTime;
            yield return null;
        }
        //print("ended.");

        perlinNoise.m_AmplitudeGain = 0;
        perlinNoise.m_FrequencyGain = 0;

    }

    public void ScreenShake(float t, float magnitude)
    {
        StartCoroutine(CinemachineShake(t, magnitude));
    }
}
