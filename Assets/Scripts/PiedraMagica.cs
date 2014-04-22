using UnityEngine;
using System.Collections;

public class PiedraMagica : MonoBehaviour {
    RaycastHit hit;
    string estado = "Nada";
    public float dis;

	void Start () {
        
        
    }
	
	void Update () {
        
	}


    void OnMouseDown()
    {
        GameObject[] x = Raycasting();
        Debug.Log(estado);
        for (int i = 0; i < x.Length; i++) 
        {
            if(x[i] != null) Debug.Log(x[i].tag + x[i].transform.position);
        }

    }


    /******************************************************************************************/
    //                                      Yeild                                             //
    /******************************************************************************************/
    /*private IEnumerator Yeild()
    {
        for (int i = 0; i < 90; i++)
        {
            if (i % 2 == 0) yield return new WaitForSeconds(.01f);
            transform.Rotate(Vector3.back, 1f);
        }

        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, distanciaEsfera);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "GemaQuieta")
                hitColliders[i].transform.parent = null;
        }
    }
    */
    /******************************************************************************************/
    //                                  RAYCASTING                                            //
    /******************************************************************************************/
    GameObject[] Raycasting()
    {
        GameObject[] objects = new GameObject[4];
        int i = 0;
        if (Physics.Raycast(transform.position, -Vector3.back, out hit, dis))
        {
            if (hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "Piedra")
                estado = "Bloqueado";
            
            if (hit.collider.gameObject.tag == "GemaQuieta") 
            {
                objects[i] = hit.collider.gameObject;
                i++;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit, dis))
        {
            if (hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "Piedra")
                estado = "Bloqueado";

            if (hit.collider.gameObject.tag == "GemaQuieta")
            {
                objects[i] = hit.collider.gameObject;
                i++;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit, dis))
        {
            if (hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "Piedra")
                estado = "Bloqueado";

            if (hit.collider.gameObject.tag == "GemaQuieta")
            {
                objects[i] = hit.collider.gameObject;
                i++;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, dis))
        {
            if (hit.collider.gameObject.tag == "Pared" || hit.collider.gameObject.tag == "Piedra")
                estado = "Bloqueado";

            if (hit.collider.gameObject.tag == "GemaQuieta")
            {
                objects[i] = hit.collider.gameObject;
                i++;
            }
        }

        return objects;
    }
}
