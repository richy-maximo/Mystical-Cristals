using UnityEngine;
using System.Collections;

public class Cuadricula : MonoBehaviour
{
    //Variables de Generales.
    public Texture2D[] textura = new Texture2D[2];

    //Variables de pociones.
        //Rotación
    public GameObject prefabPiedraMagica;


    void Start()
    {
        //Establece los valores de entrada de la cuadricula.
        this.gameObject.renderer.material.mainTexture = textura[0];
        this.gameObject.tag = "Cuadricula";
    }


    void Update()
    {
        if (Brain.ESTADO == "Nada" && this.gameObject.tag == "Cuadricula")      //En caso de que no haya poción activa y se llame Cuadricula mantente desactivado.
            Desactivar();
        if (Brain.ESTADO == "Teletransportacion" && Brain.portalesActivos == 2) //Si está la poción de Teletransportación y los portales ya se activaron, finaliza la poción.
            Brain.ESTADO = "Nada";

        
    }

    void OnMouseDown() 
    {
        if (Brain.ESTADO == "Teletransportacion" && Brain.portalesActivos <= 1 && this.gameObject.tag == "Cuadricula")  //Si estás en la poción de Teletransportación, faltan portales por activar y no eres un portal activo.
        {
            Brain.portalesActivos++;                    //Aumenta la cantidad de portales activos.
            this.gameObject.renderer.material.mainTexture = textura[1];     //Cambia su textura.
            this.gameObject.tag = "PortalActivo";       //Cambia su tag.
        }

        if (Brain.ESTADO == "Rotacion") 
        {
            GameObject roca = Instantiate(prefabPiedraMagica, new Vector3(this.transform.position.x, this.transform.position.y - .2f, this.transform.position.z), Quaternion.identity) as GameObject;
            roca.transform.Rotate(-90, 0, 0);
            Brain.ESTADO = "Nada";
        }
        
        if (Brain.ESTADO == "Un Movimiento")
        {
            bool okcambia = true;
            Collider[] gemas = Physics.OverlapSphere(this.gameObject.transform.position, 1.5f);     
            for (int i = 0; i < gemas.Length; i++)
                if (gemas[i].tag == "GemaQuieta" && okcambia)
                {
                    gemas[i].BroadcastMessage("UnMovimiento", this.gameObject.transform.position, SendMessageOptions.DontRequireReceiver);
                    okcambia = false;
                }
            Brain.ESTADO = "Nada";
        }
    }


    void Activar() 
    {
        //Establece los valores activos para poder ver y tocar la cuadricula.
        this.gameObject.renderer.enabled = true;        
        this.gameObject.collider.enabled = true;
        
        //Permite que si se encuentra sobre una gema desaparezca sin causar problemas.
        Collider[] x = Physics.OverlapSphere(this.gameObject.transform.position, 0);
        for (int i = 0; i < x.Length; i++)
            if (x[i].gameObject.tag == "GemaQuieta")
                Desactivar();
    }


    void Desactivar()
    {
        //Regresa la cuadricula a su estado orginal.
        this.gameObject.tag = "Cuadricula";
        this.gameObject.renderer.enabled = false;
        this.gameObject.collider.enabled = false;
        this.gameObject.renderer.material.mainTexture = textura[0];
    }

    //Activa unicamente los collider.
    void ActivarCollider() 
    {
        this.gameObject.collider.enabled = true;
    }
}
