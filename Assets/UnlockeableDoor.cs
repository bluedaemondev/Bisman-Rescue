using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockeableDoor : MonoBehaviour
{
    public EnumPuerta idDoor;
    public Collider2D blockingCollider;
    public bool hasCard = false;

    public AudioClip clipUnlock;
    public AudioClip clipLocked;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER && hasCard)
        {
            //se desbloquea al entrar en contacto con el jugador
            this.blockingCollider.enabled = false;
            SoundManager.instance.PlayAmbient(clipUnlock);
        }
        else if(collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            SoundManager.instance.PlayAmbient(clipLocked);
        }

    }

    public void TryToUnlockDoor(EnumPuerta idComp)
    {
        if(this.idDoor == idComp)
        {
            this.hasCard = true;
            HudController.current.AddCardToUI(idComp);
        }
    }
}
