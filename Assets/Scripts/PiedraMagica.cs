using UnityEngine;
using System.Collections;

public class PiedraMagica : MonoBehaviour {
	private GameObject[] gemas;
	private int cont;
	private string validation;
	private string pocion;
    private RaycastHit hit;

	void Start () 
    {
        pocion = "Nada";
        cont = 0;
	}
	
	void Update () 
    {
        
	}

    void OnMouseDown() 
    {
        GameObject[] gemasEnMovimiento = GameObject.FindGameObjectsWithTag("GemaEnMovimiento");
        if (gemasEnMovimiento.Length <= 0) 
        {
            
            GameObject[] gemasConRoca = RaycastingEnCruz(hit, 6, "GemaQuieta");
            if (cont > 0)
            {
                Debug.Log("ffff");
                for (int i = 0; i < cont; i++)
                    gemasConRoca[i].transform.parent = this.gameObject.transform;

                StartCoroutine(Yeild());

                
            }
        }
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
                objetos[cont] = hit.collider.gameObject;
                cont++;
            }
            if (Physics.Raycast(transform.position, Vector3.back, out hit, distancia))
            {
                objetos[cont] = hit.collider.gameObject;
                cont++;
            }
            if (Physics.Raycast(transform.position, Vector3.left, out hit, distancia))
            {
                objetos[cont] = hit.collider.gameObject;
                cont++;
            }
            if (Physics.Raycast(transform.position, Vector3.right, out hit, distancia))
            {
                objetos[cont] = hit.collider.gameObject;
                cont++;
            }
        }
        return objetos;
    }


    private IEnumerator Yeild()
    {
        for (int i = 0; i < 90; i++)
        {
            yield return new WaitForSeconds(.00000001f);
            transform.Rotate(Vector3.back, 1f);
        }
        cont = 0;
        GameObject[] gemasConRoca = RaycastingEnCruz(hit, 6, "GemaQuieta");
        for (int i = 0; i < cont; i++)
            gemasConRoca[i].transform.parent = null;
        cont = 0;  
    }
}
