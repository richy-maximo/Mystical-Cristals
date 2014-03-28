using UnityEngine;
using System.Collections;

public class PiedraMagica : MonoBehaviour {
	private GameObject[] gemas;
	private int contCruz;
    private int contRadial;
	private string validation;
    private RaycastHit hit;
    private string estado;


    public int dis;

	void Start () 
    {
        estado = "Inactivo";
        contCruz = 0;
        contRadial = 0;
        dis = 0;
	}
	
	void Update () 
    {
        radar();
	}

    private void radar() 
    {
        /*GameObject[] cuadricula = GameObject.FindGameObjectsWithTag("Cuadricula");
        for (int i = 0; i < cuadricula.Length; i++) 
        {
            Vector3 diferenciax = Vector3.Distance(cuadricula[i].transform.position, this.gameObject.transform.position);
            if (cuadricula[i].name == "ZE3")
                Debug.Log(diferenciax);
           
                cuadricula[i].renderer.enabled = true;
            
        }*/

        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, dis);

        for (int i = 0; i < hitColliders.Length; i++) 
        {
            if (hitColliders[i].tag == "Cuadricula")
            {
                hitColliders[i].BroadcastMessage("Pocion", "Rotacion", SendMessageOptions.RequireReceiver);
            }


        }
    }
    
    void OnMouseDown() 
    {
        if (estado == "Inactivo")
        {
            GameObject[] gemasEnMovimiento = GameObject.FindGameObjectsWithTag("GemaEnMovimiento");
            if (gemasEnMovimiento.Length <= 0)
            {
                GameObject[] gemasConRoca = RaycastingEnCruz(hit, 6, "GemaQuieta");
                if (contCruz > 0)
                {
                    for (int i = 0; i < contCruz; i++)
                    {
                        gemasConRoca[i].transform.parent = this.gameObject.transform;
                        
                    }
                    
        
                    StartCoroutine(Yeild());

                }
            }
        } 
    }


    private void RaycastingRadial(RaycastHit hit, int distancia, string choqueCon)
    {
        Debug.DrawRay(transform.position, -Vector3.back, Color.green);
        Debug.DrawRay(transform.position, Vector3.back, Color.green);
        Debug.DrawRay(transform.position, Vector3.right, Color.green);
        Debug.DrawRay(transform.position, Vector3.left, Color.green);
        Debug.DrawRay(transform.position, new Vector3(1, 0, 1), Color.red);
        Debug.DrawRay(transform.position, new Vector3(-1, 0, 1), Color.red);
        Debug.DrawRay(transform.position, new Vector3(1, 0, -1), Color.red);
        Debug.DrawRay(transform.position, new Vector3(-1, 0, -1), Color.red);
        GameObject[] objetos = new GameObject[8];
        

        if (Physics.Raycast(transform.position, -Vector3.back, out hit, distancia))
        {
            
               // objetos[contRadial] = hit.collider.gameObject;
               // contRadial++;
                Debug.Log(hit.collider.gameObject.tag);
            
            if (Physics.Raycast(transform.position, Vector3.back, out hit, distancia))
            {
                
                    Debug.Log(hit.collider.gameObject.tag);
                
            }
            if (Physics.Raycast(transform.position, Vector3.left, out hit, distancia))
            {
                
                    Debug.Log(hit.collider.gameObject.tag);
                
            }
            if (Physics.Raycast(transform.position, Vector3.right, out hit, distancia))
            {
                
                    Debug.Log(hit.collider.gameObject.tag);
                
            }

            if (Physics.Raycast(transform.position, new Vector3(1,0,1), out hit, distancia))
            {
                
                    Debug.Log(hit.collider.gameObject.tag);
                
            }

            if (Physics.Raycast(transform.position, new Vector3(1, 0, -1), out hit, distancia))
            {
                
                    Debug.Log(hit.collider.gameObject.tag);
                
            }

            if (Physics.Raycast(transform.position, new Vector3(-1, 0, 1), out hit, distancia))
            {
                
                    Debug.Log(hit.collider.gameObject.tag);
                
            }

            if (Physics.Raycast(transform.position, new Vector3(-1, 0, -1), out hit, distancia))
            {
                
                    Debug.Log(hit.collider.gameObject.tag);
                
            }
        }
       // return objetos;
    }

    private GameObject[] RaycastingEnCruz(RaycastHit hit, int distancia, string choqueCon)
    {
        Debug.DrawRay(transform.position, -Vector3.back, Color.green);
        Debug.DrawRay(transform.position, Vector3.back, Color.green);
        Debug.DrawRay(transform.position, Vector3.right, Color.green);
        Debug.DrawRay(transform.position, Vector3.left, Color.green);

        GameObject[] objetos = new GameObject[4];


        if (Physics.Raycast(transform.position, -Vector3.back, out hit, distancia))
        {
            if (hit.collider.gameObject.tag == choqueCon)
            {
                objetos[contCruz] = hit.collider.gameObject;
                contCruz++;
            }
            if (Physics.Raycast(transform.position, Vector3.back, out hit, distancia))
            {
                if (hit.collider.gameObject.tag == choqueCon)
                {
                    objetos[contCruz] = hit.collider.gameObject;
                    contCruz++;
                }
            }
            if (Physics.Raycast(transform.position, Vector3.left, out hit, distancia))
            {
                if (hit.collider.gameObject.tag == choqueCon)
                {
                    objetos[contCruz] = hit.collider.gameObject;
                    contCruz++;
                }
            }
            if (Physics.Raycast(transform.position, Vector3.right, out hit, distancia))
            {
                if (hit.collider.gameObject.tag == choqueCon)
                {
                    objetos[contCruz] = hit.collider.gameObject;
                    contCruz++;
                }
            }
        }
        return objetos;
    }

    private IEnumerator Yeild()
    {
        estado = "Activo";
        for (int i = 0; i < 90; i++)
        {
            if(i % 2 == 0) yield return new WaitForSeconds(.01f);
            transform.Rotate(Vector3.back, 1f);
        }
        contCruz = 0;
        GameObject[] gemasConRoca = RaycastingEnCruz(hit, 6, "GemaQuieta");
        for (int i = 0; i < contCruz; i++)
            gemasConRoca[i].transform.parent = null;
        contCruz = 0;
        estado = "Inactivo";
   
    }
}
