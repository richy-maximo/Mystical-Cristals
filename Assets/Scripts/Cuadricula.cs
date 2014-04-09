using UnityEngine;
using System.Collections;

public class Cuadricula : MonoBehaviour {

    //Variables de Generales.
    public Texture2D[] textura = new Texture2D[2];
    private string pocion;
    private string estado;

    //Variables de Teletransportacion.
    private int contadorPortales;
     
    void Start() 
    {
        this.gameObject.renderer.material.mainTexture = textura[0];
        pocion = "Nada";
        estado = "Activo";
        contadorPortales = 0; 
    }

    void pocionActual(string pocion) 
    {
        if (pocion == "Teletransportacion") 
        {
            //Valores de inicialización de poción.
            this.gameObject.renderer.enabled = true;
            this.collider.enabled = true;
            this.pocion = pocion;
            contadorPortales = 0;
        }
    }

    void OnMouseDown() 
    {
        if (pocion == "Teletransportacion") 
        {
            
        }
    }

    void finDePocion() 
    {
        this.renderer.enabled = false;
        this.collider.enabled = false;
        pocion = "Nada";
    }

}
