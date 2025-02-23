using UnityEngine;

    public class ProyectilScript : MonoBehaviour
    {
        [Tooltip("Velocidad en m/s")]
        public float velocidad = 10f;
        
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = transform.forward * velocidad;
                Debug.Log("Rigidbody encontrado en ProyectilScript");
            }
            else
            {
                Debug.Log("rb es null");
            }
        }
    }
