using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegulateColorBasedOnPitch : MonoBehaviour
{
    public AudioSource audio;

    [Header("Type (opcional). Cargar sobre objeto img o sp.rend")]
    public UnityEngine.UI.Image img;
    public SpriteRenderer sprR;

    public Color colorBackwards = Color.black;
    private Color firstColor;


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<UnityEngine.UI.Image>(out img);
        TryGetComponent<SpriteRenderer>(out sprR);
        
        if (sprR)
            firstColor = sprR.color;
        else
            firstColor = img.color;
    }


    // Update is called once per frame
    void Update()
    {


        if (sprR)
            sprR.color = firstColor;
        else
            img.color = firstColor;


        if (audio.pitch > 0.56f)
            return;


        if (sprR)
            sprR.color = colorBackwards;
        else
            img.color = colorBackwards;
    }
}
