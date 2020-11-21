using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    public float timeToRepeat = 0.3f;
    public AudioClip clip;
    bool plays = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER && plays)
        {
            SoundManager.instance.PlayAmbient(clip);
            StartCoroutine(TimerAudio());
        }
    }

    // evito duplicados 
    private IEnumerator TimerAudio()
    {
        plays = false;
        yield return new WaitForSeconds(timeToRepeat);
        plays = true;

    }
}
