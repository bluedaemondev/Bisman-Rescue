using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCard : MonoBehaviour
{
    public EnumPuerta idDoorLinked;
    public AudioClip clipPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            var lockedDoors = FindObjectsOfType<UnlockeableDoor>();
            foreach(var door in lockedDoors)
            {
                door.TryToUnlockDoor(this.idDoorLinked);
                SoundManager.instance.PlayEffect(clipPickup);
                CamerasManager.instance.ShakeCameraNormal(0.2f, 0.1f);
                Destroy(this.gameObject);
            }
        }
    }
}
