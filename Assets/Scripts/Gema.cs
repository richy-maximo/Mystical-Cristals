using UnityEngine;
using System.Collections;

public class Gema : MonoBehaviour {
    //Cerebro.

    // Variables para movimiento.
    private float mouseinix;
    private float mouseiniy;
    private float mousefinx;
    private float mousefiny;
    private float mousediferencex;
    private float mousediferencey;
    private string direccion;
    public float velocity;

    //Variables para RayCasting.
    private RaycastHit hit;
    public float distancia;

    //Variables de estado.
    public string pocion;

    //Variable para OverlapSphere
    public float distanciaEsfera;



	void Start () {
        pocion = "Nada";
	}
	
	void Update () 
    {
        
        movimiento();
        accionPociones();
	}

    /******************************************************************************************/
    //                              CONTROL DEMOVIMIENTO                                      //
    /******************************************************************************************/

    void movimiento()
    {
        if (Brain.moverGemas == true)
        {
            Raycasting();
            if (gameObject.tag == "GemaQuieta")
                rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            if (direccion == "Arriba")
                rigidbody.velocity = new Vector3(0, 0, velocity);
            if (direccion == "Abajo")
                rigidbody.velocity = new Vector3(0, 0, -velocity);
            if (direccion == "Izquierda")
                rigidbody.velocity = new Vector3(-velocity, 0, 0);
            if (direccion == "Derecha")
                rigidbody.velocity = new Vector3(velocity, 0, 0);
        }
    }


    /******************************************************************************************/
    //                                  MOUSE ACTIONS                                         //
    /******************************************************************************************/

    void OnMouseDown()
    {
        mouseinix = Input.mousePosition.x;
        mouseiniy = Input.mousePosition.y;
    }
    void OnMouseUp()
    {
        if (gameObject.tag == "GemaQuieta" && Brain.pocion == "Nada")
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
            if (mousediferencex > mousediferencey)
            {
                //Y el movimiento fue positivo entonces muevete a la derecha, sino a la izquierda.
                if (mouseinix < mousefinx)
                    direccion = "Derecha";
                else
                    if (mouseinix > mousefinx)
                        direccion = "Izquierda";
                    else direccion = "Nada";
            }

            //Si el desplazamiento fue mayor en y que en x.
            else
            {
                //Y el movimiento fue positivo entonces muevete hacia arriba, sino hacia abajo.
                if (mouseiniy < mousefiny)
                    direccion = "Arriba";
                else
                    if (mouseiniy > mousefiny)
                        direccion = "Abajo";
                    else direccion = "Nada";
            }
            if (validation() == 0 && direccion != "Nada")
            {
                gameObject.tag = "GemaEnMovimiento";
                rigidbody.constraints = RigidbodyConstraints.None;
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                direccion = "Nada";
            }
        }
    }

    /******************************************************************************************/
    //                           VALIDACION DE MOVIMIENTO                                     //
    /******************************************************************************************/
    int validation()
    {
        GameObject[] x;
        x = GameObject.FindGameObjectsWithTag("GemaEnMovimiento"); //Detecta cuantas gemas en movimiento hay.
        return x.Length;                                           //Retorna la cantidad.
    }


    /******************************************************************************************/
    //                                  RAYCASTING                                            //
    /******************************************************************************************/
	void Raycasting(){
		Debug.DrawRay(transform.position, -Vector3.back, Color.green);
		Debug.DrawRay(transform.position, Vector3.back, Color.green);
		Debug.DrawRay(transform.position, Vector3.right, Color.green);
		Debug.DrawRay(transform.position, Vector3.left, Color.green);

        if (Physics.Raycast(transform.position, -Vector3.back, out hit, distancia))
            if ((hit.collider.gameObject.name == "Enemigo" || hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "GemaQuieta" || hit.collider.gameObject.tag == "Piedra") && direccion == "Arriba")
                gameObject.tag = "GemaQuieta";
        
        if (Physics.Raycast(transform.position, Vector3.back, out hit, distancia))
            if ((hit.collider.gameObject.name == "Enemigo" || hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "GemaQuieta" || hit.collider.gameObject.tag == "Piedra") && direccion == "Abajo")
                gameObject.tag = "GemaQuieta";
        
        if (Physics.Raycast(transform.position, Vector3.left, out hit, distancia))
            if ((hit.collider.gameObject.name == "Enemigo" || hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "GemaQuieta" || hit.collider.gameObject.tag == "Piedra") && direccion == "Izquierda")
                gameObject.tag = "GemaQuieta";
        
        if (Physics.Raycast(transform.position, Vector3.right, out hit, distancia))
            if ((hit.collider.gameObject.name == "Enemigo" || hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "GemaQuieta" || hit.collider.gameObject.tag == "Piedra") && direccion == "Derecha")
                gameObject.tag = "GemaQuieta";					
    }

    /******************************************************************************************/
    //                                    Pociones                                            //
    /******************************************************************************************/
    void accionPociones() 
    {
        if (Brain.pocion == "Teletransportacion" || Brain.pocion == "Rotacion") 
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, distanciaEsfera);
            for (int i = 0; i < hitColliders.Length; i++)
                if (hitColliders[i].tag == "Cuadricula")
                    hitColliders[i].BroadcastMessage("finDePocion", SendMessageOptions.RequireReceiver);
        }
    }

    /******************************************************************************************/
    //                                  Colisiones                                            //
    /******************************************************************************************/
    void OnCollisionEnter(Collision collider) 
    {
        if (collider.gameObject.tag == "PortalActivo")
        {
            collider.gameObject.BroadcastMessage("finDePocion", SendMessageOptions.RequireReceiver);
            GameObject portalUltimo = GameObject.FindGameObjectWithTag("PortalActivo");
            portalUltimo.gameObject.BroadcastMessage("finDePocion", SendMessageOptions.RequireReceiver);
            this.transform.position = portalUltimo.gameObject.transform.position;
            portalUltimo.tag = "Cuadricula";
            pocion = "Nada";
        }
    }

    
}
