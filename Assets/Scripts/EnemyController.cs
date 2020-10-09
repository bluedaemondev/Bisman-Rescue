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
    

    public void Damage(DamageType type)
    {
        Debug.Log("Damaged Enemy " + this.name);
        switch (type)
        {
            case DamageType.Knock:
                SetKnockedState();
                break;

            case DamageType.Kill:
                Instantiate(bloodCorpsePrefab, transform.position, Quaternion.identity);
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
}

public class State
{
    public string name { get; set; }
    public string descOpt { get; set; }

}


