using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGameplay : MonoBehaviour
{
    // Start is called before the first fram
    public IEnumerator<bool> TimerProto(float timeMax)
    {
        var timer = 0f;
        while ((timer += Time.deltaTime) < timeMax)
        {
            yield return false;
        }
        yield return true;
    }
}
