using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBasedOnMouse : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        TurnGunpoint();
    }

    private Vector3 TurnGunpoint()
    {
        var mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angleRot = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angleRot);

        return transform.eulerAngles;
        //Debug.Log("Gunpoimt angle = " + angleRot);
    }
}
