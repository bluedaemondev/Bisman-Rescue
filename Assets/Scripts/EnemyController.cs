using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DamageType
{
    Knock,
    Kill
}

public class EnemyController : MonoBehaviour
{

    [Header("Previsional para mostrar estados")]
    public List<Sprite> sprites; // 0 normal , 1 en el piso
    public GameObject bloodCorpsePrefab;

    AudioSource sfxEnemy;
    [Header("Audio clips generales")]
    public AudioClip sfxDeath;
    public AudioClip sfxAttack;
    public AudioClip sfxIdle;


    private void Start()
    {
        this.sfxEnemy = GetComponentInChildren<AudioSource>();
        ExitStairs.enemiesOnFloor.Add(this);
    }

    public void Damage(DamageType type)
    {
        Debug.Log("Damaged Enemy " + this.name);
        CameraShaker.current.ScreenShake(0.3f);

        switch (type)
        {
            case DamageType.Knock:
                SetKnockedState();
                break;

            case DamageType.Kill:
                PlaySound("death");
                Instantiate(bloodCorpsePrefab, transform.position, Quaternion.identity);
                ExitStairs.enemiesOnFloor.Remove(this); // me desuscribo ya que mori
                Destroy(this.gameObject);
                break;
        }
    }

    void SetKnockedState()
    {

        AlteredState alterState;
        // miro si lo tiene, sino agrego.
        alterState = this.TryGetComponent<AlteredState>(out alterState) ?
                            alterState : this.gameObject.AddComponent<AlteredState>();

        alterState.spriteAlter = this.sprites.Find(spr => spr.name.Contains("knocked"));
        alterState.startSprite = this.sprites.Find(spr => spr != alterState.spriteAlter);

        // checkeo de integridad para que funcione el onEnable
        // estan medio acopladas las clases, pero lo dejo como solucion rapida.
        alterState.enabled = true;
    }

    public void PlaySound(string v)
    {
        switch (v)
        {
            case "idle":
                sfxEnemy.PlayOneShot(sfxIdle);
                break;
            case "attack":
                sfxEnemy.PlayOneShot(sfxAttack);
                break;
            case "death":
                sfxEnemy.PlayOneShot(sfxDeath);
                break;
        }
    }
}

public class State
{
    public string name { get; set; }
    public string descOpt { get; set; }

}


