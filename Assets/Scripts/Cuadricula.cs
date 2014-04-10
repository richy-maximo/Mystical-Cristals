﻿using UnityEngine;
using System.Collections;

public class Cuadricula : MonoBehaviour {

    //Variables de Generales.
    public Texture2D[] textura = new Texture2D[2];

    //Variables de Rotacion.
    public GameObject prefab;
     
    void Start() 
    {
        this.gameObject.renderer.material.mainTexture = textura[0];
    }

    void Update() 
    {
        if (Brain.pocion == "Nada" && this.gameObject.tag == "Cuadricula")
            finDePocion();

        if (Brain.pocion == "Teletransportacion")
        {
            this.gameObject.renderer.enabled = true;
            this.collider.enabled = true;
            GameObject[] portales = GameObject.FindGameObjectsWithTag("PortalActivo");
            if (portales.Length == 2)
            {
                llamaA("Cuadricula", "finDePocion");
                Brain.pocion = "Nada";
                Brain.portales = 0;
            }
        }

        if (Brain.pocion == "Rotacion")
        {
            this.gameObject.renderer.enabled = true;
            this.collider.enabled = true;

        }
    }


    void OnMouseDown() 
    {
        if (Brain.pocion == "Teletransportacion" && Brain.portales < 2) 
        {
                this.gameObject.renderer.material.mainTexture = textura[1];
                this.tag = "PortalActivo";
        }

        if (Brain.pocion == "Rotacion")
        {
            this.gameObject.renderer.material.mainTexture = textura[1];
            GameObject roca = Instantiate(prefab, new Vector3(this.transform.position.x, this.transform.position.y - .2f, this.transform.position.z), Quaternion.identity) as GameObject;
            roca.transform.Rotate(-90, 0, 0);
            finDePocion();
            Brain.pocion = "Nada";
        }
    }

    public void finDePocion() 
    {
        this.renderer.enabled = false;
        this.collider.enabled = false;
        this.gameObject.tag = "Cuadricula";
        this.gameObject.renderer.material.mainTexture = textura[0];
    }

    private void llamaA(string objeto, string funcion)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(objeto);
        for (int i = 0; i < objetos.Length; i++)
            objetos[i].BroadcastMessage(funcion, SendMessageOptions.RequireReceiver);
    }

    private void llamaA(string objeto, string funcion, string argumento)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(objeto);
        for (int i = 0; i < objetos.Length; i++)
            objetos[i].BroadcastMessage(funcion, argumento, SendMessageOptions.RequireReceiver);
    }
}
