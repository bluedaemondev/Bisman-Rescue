using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if(Input.anyKeyDown && Time.timeSinceLevelLoad >= 1f)
            Destroy(this.gameObject);
    }
}
