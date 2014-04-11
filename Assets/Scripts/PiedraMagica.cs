using UnityEngine;
using System.Collections;

public class PiedraMagica : MonoBehaviour {

    public int distanciaEsfera;

	void Start () {
	
	}
	
	void Update () {
       
	}


    void OnMouseDown() 
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, distanciaEsfera);
        for (int i = 0; i < hitColliders.Length; i++) 
        {
            if (hitColliders[i].gameObject.tag == "GemaQuieta")
                hitColliders[i].transform.parent = this.gameObject.transform;
                
        }
    }

    
    private IEnumerator Yeild()
    {
        for (int i = 0; i < 90; i++)
        {
            if (i % 2 == 0) yield return new WaitForSeconds(.01f);
            transform.Rotate(Vector3.back, 1f);
        }
    }
}
