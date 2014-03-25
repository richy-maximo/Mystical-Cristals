using UnityEngine;
using System.Collections;

public class Piedra : MonoBehaviour {

	private string pocion;

	void Start () {
		pocion = "Nada";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Eliminar(string x){
		pocion = x;
	}
	/*
	#if UNITY_EDITOR
	void OnMouseDown(){
		OnTouchDown ();
	}

	#endif*/

	void OnMouseDown(){
		if (pocion == "Eliminar"){
			GameObject[] piedras = GameObject.FindGameObjectsWithTag ("GemaEnMovimiento");
			for (int i = 0; i < piedras.Length; i++){
				piedras[i].BroadcastMessage("Eliminar","Nada", SendMessageOptions.RequireReceiver);
				piedras[i].gameObject.tag = "Piedra";	
			}
			Destroy (this.gameObject);
		}
	}

}
