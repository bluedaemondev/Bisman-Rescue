using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    /*public UnityEngine.UI.Image imgLife;
    public float currentLifeAlpha = 0;

    public float minVelocityToGetHit = 14f;

    public Color colorLife;*/

    [Header("Medidor de estados")]
    public bool canGetKnocked = true;
    public int currentLife = 1;
    public int maxLife = 1;
    public float cameraShakeFactor = 5f;

    public bool isPlayer = false;

    [Header("Opcional para jugador")]
    public GameObject deadScreenGO;

    public UnityEvent OnDeathEvent;

    public AudioClip damagedSound;
    public AudioClip deathSound;

    public EnemyControllerBB tryEnemyA;
    public DogControllerBB tryEnemyB;
    public BossControllerBB tryBoss;

    public AlteredState radioRemate;


    private void Start()
    {
        this.TryGetComponent<EnemyControllerBB>(out tryEnemyA);
        this.TryGetComponent<DogControllerBB>(out tryEnemyB);
        this.TryGetComponent<BossControllerBB>(out tryBoss);

    }

    public void ResetLife()
    {
        this.currentLife = maxLife;

    }
    public bool GetDamage(int damage)
    {
        bool died = false;

        CamerasManager.instance.ShakeCameraNormal(cameraShakeFactor, .1f);
        this.currentLife -= damage;

        //if (isPlayer)
        //{
        //    GetComponent<PlayerControllerBB>().SetCurrentState(PlayerState.damaged);
        //}
        if (canGetKnocked && currentLife > 0)
        {
            //print("iasdhajsdhasd");

            EnemyControllerBB tryEnemyA;
            this.TryGetComponent<EnemyControllerBB>(out tryEnemyA);

            //DogControllerBB tryEnemyB;
            //this.TryGetComponent<DogControllerBB>(out tryEnemyB);

            if (tryEnemyA) { 
                tryEnemyA.SetCurrentState(EnemyState.knocked);
                radioRemate.gameObject.SetActive(true);
            }
            //else if (tryEnemyB)
            //    tryEnemyB.SetCurrentState(DogState.knocked);
            //GetComponent<EnemyControllerBB>().SetCurrentState(EnemyState.knocked);
        }

        else
        {
            died = true;
            canGetKnocked = false;

            if (isPlayer)
            {
                GetComponent<PlayerControllerBB>().SetCurrentState(PlayerState.dead);
            }
            else
            {
                if (tryEnemyA)
                    tryEnemyA.SetCurrentState(EnemyState.dead);
                else if (tryEnemyB)
                    tryEnemyB.SetCurrentState(DogState.dead);
                else if (tryBoss)
                    GameManagerActions.current.winEvent.Invoke();

            }
        }



        return died;

    }

    public void DamageSound()
    {
        SoundManager.instance.PlayEffect(damagedSound);
    }
    public void DeathSound()
    {
        SoundManager.instance.PlayEffect(damagedSound);
    }

    //void SetKnockedState()
    //{
    //    this.GetComponent<WaypointPatrol>().enabled = false;
    //    //this.GetComponent<FetchAndAttack>().isChasing = false;   // chekear esto 27-10
    //    //this.GetComponent<FetchAndAttack>().colTrigger.enabled = false;
    //    this.GetComponent<FetchAndAttack>().enabled = false;

    //    AlteredState alterState;
    //    // miro si lo tiene, sino agrego.
    //    alterState = this.TryGetComponent<AlteredState>(out alterState) ?
    //                        alterState : this.gameObject.AddComponent<AlteredState>();

    //    alterState.spriteAlter = this.sprites.Find(spr => spr.name.Contains("knocked"));
    //    alterState.startSprite = this.sprites.Find(spr => spr != alterState.spriteAlter);

    //    // checkeo de integridad para que funcione el onEnable
    //    // estan medio acopladas las clases, pero lo dejo como solucion rapida.
    //    alterState.enabled = true;
    //}
}
