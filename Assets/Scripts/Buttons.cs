using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	private int unidadRotacion;
	private int unidadTiempo;
	private int unidad1Movimiento;
	private int unidadAPunto;
	private int unidadEliminar;
	public Texture2D[] textura = new Texture2D[10];

	void Start () {
	}

	void Update () {
		Contador ();
	}

    void OnMouseDown()
    {
        if (this.name == "Reset")
            Application.LoadLevel("Test");

        GameObject[] validationGema = GameObject.FindGameObjectsWithTag("GemaEnMovimiento");
        GameObject[] validationTeletransportador = GameObject.FindGameObjectsWithTag("PortalActivo");

        if (this.name == "TeletrasportacionImagen" && validationGema.Length == 0 && validationTeletransportador.Length == 0 && Brain.unidadTeletransportador > 0)
        {
            Brain.unidadTeletransportador--;
            Brain.pocion = "Teletransportacion";
        }

        if (this.name == "RotacionImagen" && validationGema.Length == 0 && Brain.unidadRotacion > 0)
        {
            Brain.unidadRotacion--;
            Brain.pocion = "Rotacion";
        }
    }

	void Contador(){
		if (this.gameObject.name == "TeletransportadorContador" && Brain.unidadTeletransportador >= 0) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
            gameObject.renderer.material.mainTexture = textura[Brain.unidadTeletransportador];
		}

        if (this.gameObject.name == "RotacionContador" && Brain.unidadRotacion >= 0)
        {
            gameObject.renderer.material.shader = Shader.Find("Unlit/Texture");
            gameObject.renderer.material.mainTexture = textura[Brain.unidadRotacion];
        }
	}


    private void llamaA(string objeto, string funcion ,string argumento)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(objeto);
            for (int i = 0; i < objetos.Length; i++)
                objetos[i].BroadcastMessage(funcion, argumento, SendMessageOptions.RequireReceiver);
    }

}//END OF CLASS
