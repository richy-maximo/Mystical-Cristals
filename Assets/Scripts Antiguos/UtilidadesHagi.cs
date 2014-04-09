using UnityEngine;
using System.Collections;

public class UtilidadesHagi : MonoBehaviour
    {
        public void RaycastingEnCruz(RaycastHit hit, int distancia, string colisionar)
        {
            Debug.DrawRay(transform.position, -Vector3.back, Color.green);
            Debug.DrawRay(transform.position, Vector3.back, Color.green);
            Debug.DrawRay(transform.position, Vector3.right, Color.green);
            Debug.DrawRay(transform.position, Vector3.left, Color.green);
            if (Physics.Raycast(transform.position, -Vector3.back, out hit, distancia))
            {

                if (hit.collider.gameObject.tag == colisionar)
                {

                }

                if (Physics.Raycast(transform.position, Vector3.back, out hit, distancia))
                {

                }
                if (Physics.Raycast(transform.position, Vector3.left, out hit, distancia))
                {

                }
                if (Physics.Raycast(transform.position, Vector3.right, out hit, distancia))
                {


                }
            }
        }
    }

