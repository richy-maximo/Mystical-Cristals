using UnityEngine;
using System.Collections;

public class PiedraMagica2 : MonoBehaviour {
	private GameObject[] gemas;
	private int cont;
	private RaycastHit hit;
    private string validation;
	private string pocion;



	void Start () {
		cont = 0;
		pocion = "Nada";
	}
	
	void Update () {


	}
	/*
	#if UNITY_EDITOR
	void OnMouseDown(){
		OnTouchDown ();
	}
	#endif
*/
	void OnMousehDown(){

		if (pocion == "Eliminar"){
			GameObject[] piedras = GameObject.FindGameObjectsWithTag ("GemaEnMovimiento");
			for (int i = 0; i < piedras.Length; i++){
				piedras[i].BroadcastMessage("Eliminar","Nada", SendMessageOptions.RequireReceiver);
				piedras[i].gameObject.tag = "Piedra";	
			}
			Destroy (this.gameObject);
		}
	


		GameObject[] ok = GameObject.FindGameObjectsWithTag ("GemaEnMovimiento");
		if (this.gameObject.tag == "Pared" && ok.Length == 0) {
			this.gameObject.tag = "GemaEnMovimiento";
			Raycasting ();
			if (validation == "Adelante") {
				for (int i = 0; i < cont; i++) 
						gemas [i].transform.parent = this.gameObject.transform; 	
				StartCoroutine (Yeild ());
				validation = "Nada";
			}
		}
	}


	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Pared") {
			rigidbody.constraints = RigidbodyConstraints.FreezePosition;
		}
	}


	IEnumerator Yeild(){
		validation = "Quieto";
		for (int i = 0; i<90; i++) {
			yield return new WaitForSeconds (.00000001f);
			transform.Rotate (Vector3.back, 1f);
		}
		for (int i = 0; i < cont; i++) {
			gemas[i].transform.parent = null; 	
		}
		cont = 0;
		this.gameObject.tag = "Pared";
	}

    void Raycasting()
    {
        Debug.DrawRay(transform.position, -Vector3.back, Color.green);
        Debug.DrawRay(transform.position, Vector3.back, Color.green);
        Debug.DrawRay(transform.position, Vector3.right, Color.green);
        Debug.DrawRay(transform.position, Vector3.left, Color.green);
        gemas = new GameObject[4];
        if (Physics.Raycast(transform.position, -Vector3.back, out hit, 1))
        {

            if (hit.collider.gameObject.tag == "GemaQuieta")
            {
                gemas[cont] = hit.collider.gameObject;
                cont++;
                validation = "Adelante";
            }
            if (hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "Piedra")
            {
                this.gameObject.tag = "PiedraBloqueada";
            }
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1))
        {
            if (hit.collider.gameObject.tag == "GemaQuieta")
            {
                gemas[cont] = hit.collider.gameObject;
                cont++;
                validation = "Adelante";
            }
            if (hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "Piedra")
            {
                this.gameObject.tag = "PiedraBloqueada";
            }
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 1))
        {

            if (hit.collider.gameObject.tag == "GemaQuieta")
            {
                gemas[cont] = hit.collider.gameObject;
                cont++;
                validation = "Adelante";
            }
            if (hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "Piedra")
            {
                this.gameObject.tag = "PiedraBloqueada";
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 1))
        {

            if (hit.collider.gameObject.tag == "GemaQuieta")
            {
                gemas[cont] = hit.collider.gameObject;
                cont++;
                validation = "Adelante";
            }
            if (hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "Piedra")
            {
                this.gameObject.tag = "PiedraBloqueada";
            }
        }
    }

/********************************************************************************************************************/
	//
	//

	void Eliminar(string x){
		pocion = x;
	}
}
