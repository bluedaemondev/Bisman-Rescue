using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkAndBring : MonoBehaviour
{
    public Vector2 positionSeen;
    public AudioClip barkClip;
    
    [Header("Tagged como bringer")]
    public Collider2D agroBringEnemies;

    // Start is called before the first frame update
    void Start()
    {
        if (agroBringEnemies == null)
            agroBringEnemies = this.GetComponent<Collider2D>();

    }

    /// <summary>
    /// llama a los enemigos en cuartos adyacentes
    /// </summary>
    public void Bark()
    {
        //positionSeen = transform.position;
        agroBringEnemies.enabled = true;
        SoundManager.instance.PlayEffect(barkClip);

    }
    public void StopBarking()
    {
        agroBringEnemies.enabled = false;
    }

}
