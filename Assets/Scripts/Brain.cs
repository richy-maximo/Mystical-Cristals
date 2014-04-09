using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour {


	void Start () {
	
	}
	
	void Update () {
	
	}

    void llamarCuadricula(string pocion) 
    {
        GameObject[] cuadricula = GameObject.FindGameObjectsWithTag("Cuadricula");
        for (int i = 0; i < cuadricula.Length; i++)
            cuadricula[i].BroadcastMessage("Pocion",pocion, SendMessageOptions.RequireReceiver);
    }


}
