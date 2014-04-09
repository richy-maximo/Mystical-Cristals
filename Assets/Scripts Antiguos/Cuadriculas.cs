using UnityEngine;
using System.Collections;

public class Cuadriculas : MonoBehaviour {
	private string pocion;
	public Texture2D[] texturaa = new Texture2D[2];
	public GameObject prefab;
	private GameObject gema;

	void Start () {
		pocion = "Nada";
		gema = null;
	}


	void Update () {
		if (pocion == "Nada" || this.gameObject.tag == "Cuadricula") {
			this.gameObject.collider.enabled = false;
			this.gameObject.collider.isTrigger = false;
			this.gameObject.renderer.enabled = false;
			this.gameObject.renderer.material.mainTexture = texturaa [0];
		}
		if (pocion == "Teletransportacion") {
			GameObject[] portal = GameObject.FindGameObjectsWithTag("PortalActivo");
			if(portal.Length == 2 && this.gameObject.tag == "GemaEnMovimiento"){
				this.gameObject.tag = "Cuadricula";
				pocion = "Nada";
			}
		}

        if (pocion == "Rotacion") 
        {
            this.gameObject.renderer.enabled = true;
        }



		//Debug.Log (this.gameObject.name + pocion);
	}

	public void Pocion(string eleccion){
		this.pocion = eleccion;
	}
	void UnMovimiento(){
		pocion = "UnMovimiento";
		this.gameObject.tag = "GemaEnMovimiento";
		//this.gameObject.renderer.enabled = true;
		this.gameObject.collider.enabled = true;
		this.gameObject.collider.isTrigger = true;

	}
/*******************************************************************************************************************/
											//TELETRANSPORTACION//				
						
	void Teletransportacion(){
		pocion = "Teletransportacion";
		this.gameObject.tag = "GemaEnMovimiento";
		this.gameObject.renderer.enabled = true;
		this.gameObject.collider.enabled = true;
		this.gameObject.collider.isTrigger = true;
	}

	void OnTriggerStay (Collider other)
	{	
		if (other.gameObject.tag == "GemaQuieta" || other.gameObject.tag == "Piedra") {
			this.gameObject.transform.tag = "Cuadricula";
			this.gameObject.renderer.enabled = false;
			this.gameObject.collider.enabled = false;
		}
	}
/*******************************************************************************************************************/
											//ROTACION//
	void Rotacion(){
		pocion = "Rotacion";
		this.gameObject.tag = "GemaEnMovimiento";
		this.gameObject.renderer.enabled = true;
		this.gameObject.collider.enabled = true;
		this.gameObject.collider.isTrigger = true;
	}
/*******************************************************************************************************************/

	void OnMouseDown(){
		if (this.gameObject.tag == "GemaEnMovimiento" && pocion == "Teletransportacion") {
			GameObject[] validation = GameObject.FindGameObjectsWithTag ("GemaEnMovimiento");
			if (validation.Length >= 10) {
				this.gameObject.tag = "PortalActivo";
				this.gameObject.renderer.material.mainTexture = texturaa [1];
			}
		}

		if(this.gameObject.tag == "GemaEnMovimiento" && pocion == "UnMovimiento"){
			this.gameObject.renderer.material.mainTexture = texturaa [1];
			this.gameObject.tag = "PortalActivo";
			GameObject[] x = GameObject.FindGameObjectsWithTag ("GemaEnMovimiento");
			for(int i = 0; i < x.Length; i++){
				x[i].gameObject.tag = "Cuadricula";
				x[i].BroadcastMessage("Pocion","Nada",SendMessageOptions.RequireReceiver);
			}
			gema.transform.position = this.gameObject.transform.position;

		}

		if (this.gameObject.tag == "GemaEnMovimiento" && pocion == "Rotacion") {

			GameObject[] validation = GameObject.FindGameObjectsWithTag ("GemaEnMovimiento");
			if (validation.Length >= 10) {
				GameObject roca = Instantiate(prefab, new Vector3(this.transform.position.x, this.transform.position.y - .2f, this.transform.position.z), Quaternion.identity) as GameObject;
				roca.transform.Rotate(-90,0,0);
				GameObject[] cuadricula = GameObject.FindGameObjectsWithTag("GemaEnMovimiento");
				for (int i = 0; i < cuadricula.Length; i++){
					cuadricula[i].BroadcastMessage("Pocion","Nada",SendMessageOptions.RequireReceiver);
					cuadricula[i].tag = "Cuadricula";
				}
			}		
		}
	}

	void Objeto(GameObject x){
		gema = x;
	}



}
