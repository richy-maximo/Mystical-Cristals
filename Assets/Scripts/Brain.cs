using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour {
    public static string pocion = "Nada";
    public static int portales = 0;
    public static int unidadTeletransportador = 3;
    public static int unidadRotacion = 3;


	void Start () {
	
	}
	
	void Update () {
	}

    public void llamarCuadricula(string pocion) 
    {
        GameObject[] cuadricula = GameObject.FindGameObjectsWithTag("Cuadricula");
        for (int i = 0; i < cuadricula.Length; i++)
            cuadricula[i].BroadcastMessage("pocionActual", pocion, SendMessageOptions.RequireReceiver);
    }

    
}
