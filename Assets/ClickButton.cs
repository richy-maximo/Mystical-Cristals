using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {
    public bool teletransportacion;
    public bool rotacion;
    public bool tiempo;
    public bool unMovimiento;
    public bool aPunto;
    public bool destruye;

    void OnMouseDown()
    {
        if (teletransportacion && Brain.teletransportacion >= 1 && Brain.ESTADO == "Nada" && Brain.portalesActivos == 0)
        { 
            Brain.teletransportacion--;
            Brain.ESTADO = "Teletransportacion";
        }
        if (rotacion && Brain.rotacion >= 1 && Brain.ESTADO == "Nada") 
        { 
            Brain.rotacion--;
            Brain.ESTADO = "Rotacion";
        }
        /*
        if (tiempo && Brain.tiempo >= 1) Brain.tiempo--;
        if (unMovimiento && Brain.unMovimiento >= 1) Brain.unMovimiento--;
        if (aPunto && Brain.aPunto >= 1) Brain.aPunto--;
        if (destruye && Brain.destruye >= 1) Brain.destruye--;*/
    }
}
