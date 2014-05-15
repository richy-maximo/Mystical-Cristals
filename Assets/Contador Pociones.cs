using UnityEngine;
using System.Collections;

public class ContadorPociones : MonoBehaviour {
    public bool teletransportacion;
    public bool rotacion;
    public bool tiempo;

    //Texturas
    public Texture2D[] textura = new Texture2D[10];

    void Start()
    {

    }

    void Update()
    {
        if (teletransportacion)
        {
            gameObject.renderer.material.shader = Shader.Find("Unlit/Texture");
            gameObject.renderer.material.mainTexture = textura[Brain.teletransportacion];
        }
        if (rotacion)
        {
            gameObject.renderer.material.shader = Shader.Find("Unlit/Texture");
            gameObject.renderer.material.mainTexture = textura[Brain.rotacion];
        }
        if (rotacion)
        {
            gameObject.renderer.material.shader = Shader.Find("Unlit/Texture");
            gameObject.renderer.material.mainTexture = textura[Brain.tiempo];
        }
    }
}
