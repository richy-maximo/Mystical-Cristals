using UnityEngine;
using System.Collections;

public class Click_Contador_Pociones : MonoBehaviour {
    public bool teletransportacion;
    public bool rotacion;
    public bool tiempo;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        if (teletransportacion && Brain.teletransportacion >= 0) Brain.teletransportacion--;
        if (rotacion && Brain.rotacion >= 0) Brain.rotacion--;
        if (tiempo && Brain.tiempo >= 0) Brain.tiempo--;
    }
}
