using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	//private int opcion;
	private float mouseinix;
	private float mouseiniy;
	private float mousefinx;
	private float mousefiny;
	private float mousediferencex;
	private float mousediferencey;
	private RaycastHit hit;
	private string direccion;
	public float distancia;
	//public Cerebro brain;
	private bool unMovimiento;
	public int d;
    public float velocity;

	void Start () {
		unMovimiento = false;
	}

	void Update () {
				Raycasting ();
				if (gameObject.tag == "GemaQuieta")
					rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				if (direccion == "Arriba")
					rigidbody.velocity = new Vector3 (0, 0, velocity);
				if (direccion == "Abajo")
                    rigidbody.velocity = new Vector3(0, 0, -velocity);
				if (direccion == "Izquierda")
                    rigidbody.velocity = new Vector3(-velocity, 0, 0);
				if (direccion == "Derecha")
                    rigidbody.velocity = new Vector3(velocity, 0, 0);
	}

	//********************************************************************//
	//							Mouse Actions							  //
	//********************************************************************//
	
	//Al momento de presionar el botón de mouse.
	//Registra la posición inicial del click.
	//Manda activar el RayCast.

	void OnMouseDown()
	{
		mouseinix = Input.mousePosition.x;
		mouseiniy = Input.mousePosition.y;
	}	
	
	//Al soltar el botón.		 
	void OnMouseUp()
	{
		if(gameObject.tag == "GemaQuieta")
        {
				mousefinx = Input.mousePosition.x;
				mousefiny = Input.mousePosition.y;
				
				//Obtiene la diferencia del movimiento.
				mousediferencex = mousefinx - mouseinix;
				mousediferencey = mousefiny - mouseiniy;
				
				//Convierte la diferencia en positiva para comparar correctamente.
				if (mousediferencex < 0)
						mousediferencex = mousediferencex * -1;
				if (mousediferencey < 0)
						mousediferencey = mousediferencey * -1;
				
				//Si el desplazamiento fue mayor en x que en y.
				if (mousediferencex > mousediferencey) {
						//Y el movimiento fue positivo entonces muevete a la derecha, sino a la izquierda.
						if (mouseinix < mousefinx)
								direccion = "Derecha";
						else 
						if (mouseinix > mousefinx)
								direccion = "Izquierda";
						else direccion = "Nada";
				} 	
				
	//Si el desplazamiento fue mayor en y que en x.
				else {
						//Y el movimiento fue positivo entonces muevete hacia arriba, sino hacia abajo.
						if (mouseiniy < mousefiny)
								direccion = "Arriba";
						else 
						if (mouseiniy > mousefiny)
								direccion = "Abajo";
						else direccion = "Nada";
				}
				if (validation () == 0 && direccion != "Nada") {
						gameObject.tag = "GemaEnMovimiento";
						rigidbody.constraints = RigidbodyConstraints.None;
						rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				} else {
						direccion = "Nada";	
				}
		}
	}



	int validation(){
		GameObject[] x;
		x = GameObject.FindGameObjectsWithTag ("GemaEnMovimiento");
		return x.Length;
	}

	void Raycasting(){
		Debug.DrawRay(transform.position, -Vector3.back, Color.green);
		Debug.DrawRay(transform.position, Vector3.back, Color.green);
		Debug.DrawRay(transform.position, Vector3.right, Color.green);
		Debug.DrawRay(transform.position, Vector3.left, Color.green);
		Debug.DrawRay(transform.position, new Vector3(1,0,1), Color.red);
		Debug.DrawRay(transform.position, new Vector3(-1,0,1), Color.red);
		Debug.DrawRay(transform.position, new Vector3(1,0,-1), Color.red);
		Debug.DrawRay(transform.position, new Vector3(-1,0,-1), Color.red);

		if (!unMovimiento) 
        {
						if (Physics.Raycast (transform.position, -Vector3.back, out hit, distancia)) {
								if ((hit.collider.gameObject.name == "Enemigo" || hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "GemaQuieta" || hit.collider.gameObject.tag == "Piedra") && direccion == "Arriba") { 
										gameObject.tag = "GemaQuieta";
								}
						}
		
						if (Physics.Raycast (transform.position, Vector3.back, out hit, distancia)) {
                            if ((hit.collider.gameObject.name == "Enemigo" || hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "GemaQuieta" || hit.collider.gameObject.tag == "Piedra") && direccion == "Abajo")
                            { 
										gameObject.tag = "GemaQuieta";
								}
						}
		
						if (Physics.Raycast (transform.position, Vector3.left, out hit, distancia)) {
                            if ((hit.collider.gameObject.name == "Enemigo" || hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "GemaQuieta" || hit.collider.gameObject.tag == "Piedra") && direccion == "Izquierda")
                            { 
										gameObject.tag = "GemaQuieta";
								}

						}
		
						if (Physics.Raycast (transform.position, Vector3.right, out hit, distancia)) {
                            if ((hit.collider.gameObject.name == "Enemigo" || hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "GemaQuieta" || hit.collider.gameObject.tag == "Piedra") && direccion == "Derecha")
                            { 
										gameObject.tag = "GemaQuieta";
								}
						}

				}
		if (unMovimiento) {
			Debug.Log(this.gameObject.name);

			if (Physics.Raycast (transform.position, new Vector3 (1, 0, 1), out hit, d)) {
				if (hit.collider.gameObject.tag == "Cuadricula") {
					Debug.Log(hit.collider.name);
					hit.collider.tag = "GemaEnMovimiento";					
                    //hit.collider.gameObject.renderer.enabled = true;
					//hit.collider.BroadcastMessage("Objeto",this.gameObject,SendMessageOptions.RequireReceiver);
					//hit.collider.BroadcastMessage("UnMovimiento",this.gameObject,SendMessageOptions.RequireReceiver);
				}
			}

			if (Physics.Raycast (transform.position, new Vector3 (1, 0, -1), out hit, d)) {
				if (hit.collider.gameObject.tag == "Cuadricula") {
					Debug.Log(hit.collider.name);
					hit.collider.renderer.enabled = true;
					//hit.collider.gameObject.renderer.enabled = true;
					//hit.collider.BroadcastMessage("Objeto",this.gameObject,SendMessageOptions.RequireReceiver);
					//hit.collider.BroadcastMessage("UnMovimiento",this.gameObject,SendMessageOptions.RequireReceiver);
				}


			}
			if (Physics.Raycast (transform.position, new Vector3 (-1, 0, 1), out hit, d)) {
				if (hit.collider.gameObject.tag == "Cuadricula") {
					Debug.Log(hit.collider.name);
					hit.collider.renderer.enabled = true;
					//hit.collider.gameObject.renderer.enabled = true;
					//hit.collider.BroadcastMessage("Objeto",this.gameObject,SendMessageOptions.RequireReceiver);
					//hit.collider.BroadcastMessage("UnMovimiento",this.gameObject,SendMessageOptions.RequireReceiver);
				}
			}

			if (Physics.Raycast (transform.position, new Vector3 (-1, 0, -1), out hit, d)) {
				if (hit.collider.gameObject.tag == "Cuadricula") {
					Debug.Log(hit.collider.name);
					hit.collider.renderer.enabled = true;
					//hit.collider.gameObject.renderer.enabled = true;
					//hit.collider.BroadcastMessage("Objeto",this.gameObject,SendMessageOptions.RequireReceiver);
					//hit.collider.BroadcastMessage("UnMovimiento",this.gameObject,SendMessageOptions.RequireReceiver);
				}
			}

			if (Physics.Raycast (transform.position, new Vector3 (0, 0, 1), out hit, d)) {
				if (hit.collider.gameObject.tag == "Cuadricula") {
					Debug.Log(hit.collider.name);
					hit.collider.renderer.enabled = true;
					//hit.collider.gameObject.renderer.enabled = true;
					//hit.collider.BroadcastMessage("Objeto",this.gameObject,SendMessageOptions.RequireReceiver);
					//hit.collider.BroadcastMessage("UnMovimiento",this.gameObject,SendMessageOptions.RequireReceiver);
				}
			}

			if (Physics.Raycast (transform.position, new Vector3 (0, 0, -1), out hit, d)) {
				if (hit.collider.gameObject.tag == "Cuadricula") {
					Debug.Log(hit.collider.name);
					hit.collider.renderer.enabled = true;
					//hit.collider.gameObject.renderer.enabled = true;
					//hit.collider.BroadcastMessage("Objeto",this.gameObject,SendMessageOptions.RequireReceiver);
					//hit.collider.BroadcastMessage("UnMovimiento",this.gameObject,SendMessageOptions.RequireReceiver);
				}
			}

			if (Physics.Raycast (transform.position, new Vector3 (1, 0, 0), out hit, d)) {
				if (hit.collider.gameObject.tag == "Cuadricula") {
					Debug.Log(hit.collider.name);
					hit.collider.renderer.enabled = true;
					//hit.collider.gameObject.renderer.enabled = true;
					//hit.collider.BroadcastMessage("Objeto",this.gameObject,SendMessageOptions.RequireReceiver);
					//hit.collider.BroadcastMessage("UnMovimiento",this.gameObject,SendMessageOptions.RequireReceiver);
				}
			}

			if (Physics.Raycast (transform.position, new Vector3 (-1, 0, 0), out hit, d)) {
				if (hit.collider.gameObject.tag == "Cuadricula") {
					Debug.Log(hit.collider.name);
					hit.collider.renderer.enabled = true;
					//hit.collider.gameObject.renderer.enabled = true;
					//hit.collider.BroadcastMessage("Objeto",this.gameObject,SendMessageOptions.RequireReceiver);
					//hit.collider.BroadcastMessage("UnMovimiento",this.gameObject,SendMessageOptions.RequireReceiver);
				}
			}
			unMovimiento = false;
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "PortalActivo") {
			other.gameObject.tag = "Cuadricula";
			GameObject portal = GameObject.FindGameObjectWithTag("PortalActivo");
			this.gameObject.transform.position = portal.transform.position;
			portal.gameObject.tag = "Cuadricula";
		}
	}

/********************************************************************************************************************************/
											// 1 MOVIMIENTO //

	void UnMovimiento(){
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 1.5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Cuadricula")
            {
                hitColliders[i].renderer.enabled = true;

            }
        }
	}



}//END OF CLASS
