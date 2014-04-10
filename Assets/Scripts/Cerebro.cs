using UnityEngine;
using System.Collections;

public class Cerebro : MonoBehaviour {
	//Variables de ContadorMovimientos
	public bool decenaMovimientoTag;
	public bool digitoMovimientoTag;
	private int decenaMovimiento;
	private int digitoMovimiento;
	private int cantidadMovimiento;
	private int numeroMovimiento;
	private bool continuaContando;


	//Variables de ContadorTiempo
	public bool centenaTiempoTag;
	public bool decenaTiempoTag;
	public bool unidadTiempoTag;
	private int centenaTiempo;
	private int decenaTiempo;
	private int unidadTiempo;
	private int cantidadTiempo;
	private int numeroTiempo;
	
	//Texturas
	public Texture2D[] textura = new Texture2D[10]; 

	void Start () {
		cantidadMovimiento = 0;
		continuaContando = true;
	}
	
	void Update () {
		ContadorMovimientos();
		ContadorTiempo();
	}
	
	void ContadorMovimientos(){
		decenaMovimiento = (cantidadMovimiento / 10);
		digitoMovimiento = cantidadMovimiento-(decenaMovimiento*10);
	
		if (decenaMovimientoTag)
			numeroMovimiento=decenaMovimiento;

		if (digitoMovimientoTag)
			numeroMovimiento=digitoMovimiento;

		if (decenaMovimientoTag || digitoMovimientoTag) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
			gameObject.renderer.material.mainTexture = textura [numeroMovimiento];
		}

		GameObject[] GemaEnMovimiento = GameObject.FindGameObjectsWithTag("GemaEnMovimiento");

		if (GemaEnMovimiento.Length == 1 && continuaContando == true) {
						cantidadMovimiento++;
						continuaContando = false;
				} else if (GemaEnMovimiento.Length == 0)
						continuaContando = true;
	}


	void ContadorTiempo(){
		cantidadTiempo = 360 - (int)Time.timeSinceLevelLoad;


		centenaTiempo = cantidadTiempo/100;
		decenaTiempo = (cantidadTiempo/10)-(centenaTiempo*10);
		unidadTiempo =cantidadTiempo-(decenaTiempo*10)-(centenaTiempo*100);

		if (centenaTiempoTag)
			numeroTiempo = centenaTiempo;

		if (decenaTiempoTag)
			numeroTiempo = decenaTiempo;
		
		if (unidadTiempoTag)
			numeroTiempo = unidadTiempo;

		if (decenaTiempoTag || unidadTiempoTag || centenaTiempoTag) {
			gameObject.renderer.material.shader = Shader.Find ("Unlit/Texture");
			if(cantidadTiempo >= 0) gameObject.renderer.material.mainTexture = textura [numeroTiempo];
			if(cantidadTiempo == 0) Debug.Log("Tiempo Terminado");
		}
	}
	
}//END OF CLASS
