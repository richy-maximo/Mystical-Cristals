using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	private int unidadTeletransportador;
	private int unidadRotacion;
	private int unidadTiempo;
	private int unidad1Movimiento;
	private int unidadAPunto;
	private int unidadEliminar;
	public Texture2D[] textura = new Texture2D[10];

	void Start () {
		unidadTeletransportador = 9;
		unidadRotacion = 3;
		unidadTiempo = 9;
		unidad1Movimiento = 9;
		unidadAPunto = 9;
		unidadEliminar = 9;
	}

	void Update () {
		Contador ();
//		Debug.Log (unidadRotacion + this.gameObject.name);
	}

	/*
	#if UNITY_EDITOR
	void OnMouseDown(){
		OnTouchDown ();
	}
	#endif
*/
	void OnMouseDown(){
		GameObject[] validationGema = GameObject.FindGameObjectsWithTag ("GemaEnMovimiento");
		GameObject[] validationTeletransportador = GameObject.FindGameObjectsWithTag ("PortalActivo");

		if (this.name == "Reset") {
			Application.LoadLevel("Test");
		}

		if (this.name == "TeletrasportacionImag" && validationGema.Length == 0 && validationTeletransportador.Length == 0 && unidadTeletransportador > 0) {
			GameObject contadorTeletransportador = GameObject.FindGameObjectWithTag("ContTeletransportacion");
			contadorTeletransportador.BroadcastMessage("AfterOnMouseDown", "Teletransportacion",SendMessageOptions.RequireReceiver);

			GameObject[] cuadricula = GameObject.FindGameObjectsWithTag ("Cuadricula");
			for (int i = 0; i < cuadricula.Length; i++)
				cuadricula[i].BroadcastMessage("Teletransportacion", SendMessageOptions.RequireReceiver);	
		}

		if (this.name == "RotacionImag" && validationGema.Length == 0) {

			GameObject contadorRotacion = GameObject.FindGameObjectWithTag("ContRotacion");
			contadorRotacion.BroadcastMessage("AfterOnMouseDown", "Rotacion",SendMessageOptions.RequireReceiver);
			
			GameObject[] cuadricula = GameObject.FindGameObjectsWithTag ("Cuadricula");
			for (int i = 0; i < cuadricula.Length; i++)
				cuadricula[i].BroadcastMessage("Rotacion", SendMessageOptions.RequireReceiver);	
		}


		if (this.name == "TiempoPocionImag" && validationGema.Length == 0) {
			GameObject contadorPocionTiempo = GameObject.FindGameObjectWithTag("ContTiempo");
			contadorPocionTiempo.BroadcastMessage("AfterOnMouseDown", "Tiempo",SendMessageOptions.RequireReceiver);

			//Algo////////
		}

		if (this.name == "1MovimientoImag" && validationGema.Length == 0) {
			GameObject contadorPocionTiempo = GameObject.FindGameObjectWithTag("Cont1Movimiento");
			contadorPocionTiempo.BroadcastMessage("AfterOnMouseDown", "1Movimiento",SendMessageOptions.RequireReceiver);
			
			GameObject[] gemas = GameObject.FindGameObjectsWithTag ("GemaQuieta");
			for (int i = 0; i < gemas.Length; i++)
				gemas[i].BroadcastMessage("UnMovimiento", SendMessageOptions.RequireReceiver);
		}

		if (this.name == "APuntoImag" && validationGema.Length == 0) {
			GameObject contadorPocionTiempo = GameObject.FindGameObjectWithTag("ContAPunto");
			contadorPocionTiempo.BroadcastMessage("AfterOnMouseDown", "APunto",SendMessageOptions.RequireReceiver);
			
			//Algo////////
		}

		if (this.name == "EliminarImag" && validationGema.Length == 0) {
			GameObject contadorPocionTiempo = GameObject.FindGameObjectWithTag("ContEliminar");
			contadorPocionTiempo.BroadcastMessage("AfterOnMouseDown", "Eliminar",SendMessageOptions.RequireReceiver);
			
			GameObject[] piedras = GameObject.FindGameObjectsWithTag ("Piedra");
			for (int i = 0; i < piedras.Length; i++)
				piedras[i].BroadcastMessage("Eliminar","Eliminar", SendMessageOptions.RequireReceiver);
		}
	}

	void Contador(){
		if (this.gameObject.name == "TeletransportadorContador" && unidadTeletransportador >= 0) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
			gameObject.renderer.material.mainTexture = textura [unidadTeletransportador];
		}
		if (this.gameObject.name == "RotacionContador" && unidadRotacion >= 0) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
			gameObject.renderer.material.mainTexture = textura [unidadRotacion];
		}
		if (this.gameObject.name == "TiempoPocionContador" && unidadTiempo >= 0) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
			gameObject.renderer.material.mainTexture = textura [unidadTiempo];
		}
		if (this.gameObject.name == "1MovimientoContador" && unidadTiempo >= 0) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
			gameObject.renderer.material.mainTexture = textura [unidad1Movimiento];
		}
		if (this.gameObject.name == "APuntoContador" && unidadTiempo >= 0) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
			gameObject.renderer.material.mainTexture = textura [unidadAPunto];
		}
		if (this.gameObject.name == "EliminarContador" && unidadTiempo >= 0) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
			gameObject.renderer.material.mainTexture = textura [unidadEliminar];
		}
	}

	void AfterOnMouseDown(string click){
		if (click == "Teletransportacion" && unidadTeletransportador > 0)
						unidadTeletransportador--;
		if (click == "Rotacion" && unidadRotacion > 0)
						unidadRotacion--;
		if (click == "Tiempo" && unidadTiempo > 0)
						unidadTiempo--;
		if (click == "1Movimiento" && unidad1Movimiento > 0)
						unidad1Movimiento--;
		if (click == "APunto" && unidadAPunto >0)
						unidadAPunto--;
		if (click == "Eliminar" && unidadEliminar > 0)
						unidadEliminar--;
	}


}//END OF CLASS
