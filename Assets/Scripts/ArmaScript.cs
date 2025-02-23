using System;
using UnityEngine;

public class ArmaScript : MonoBehaviour {
    
    [Tooltip("Punto de origen del proyectil")]
    public GameObject punto;
    
    [Tooltip("Prefab del disparo (la explosión")]
    public GameObject fuego;
    
    [Tooltip("Punto de origen del disparo")]
    public GameObject disparo;

    [Tooltip("Sonido")]
    public AudioClip sonido;

    [Tooltip("Distancia Raycast")]
    public float distancia = 100f;
    
    [Header("Debug")] // Esto es opcional, solo para organizar en el Inspector
    [Tooltip("Activar para visualizar el Raycast en la escena")]
    public bool visualizarRaycast = false; // NUEVA VARIABLE BOOLEANA

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }

        if (visualizarRaycast)
        {
            Debug.DrawRay(punto.transform.position, punto.transform.forward * distancia, Color.green);
        }
    }

    private void Disparar()
    {
        if (punto != null)
        {
            RaycastHit hit;
            
            if (Physics.Raycast(punto.transform.position, punto.transform.forward, out hit, distancia))
            {
                
                if (hit.collider.gameObject.name == "enemigo")
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Destruido");
                }

                Debug.Log(hit.collider.gameObject.name);
            }
            
            
            if (fuego != null && disparo != null)
            {
                GameObject disparoInstanciado = Instantiate(disparo, fuego.transform.position, fuego.transform.rotation);
                disparoInstanciado.GetComponent<ParticleSystem>().Play();
                Destroy(disparoInstanciado, 1.2f);
            }

            
            if (sonido != null)
            {
                GetComponent<AudioSource>().PlayOneShot(sonido);
            }
            
            
        }
        else
        {
            Debug.LogWarning("Raycast no impactó");
            
            if (fuego != null && disparo != null)
            {
                GameObject disparoInstanciado = Instantiate(disparo, fuego.transform.position, fuego.transform.rotation);
                disparoInstanciado.GetComponent<ParticleSystem>().Play();
                Destroy(disparoInstanciado, 0.5f);
            }
            if (sonido != null)
            {
                GetComponent<AudioSource>().PlayOneShot(sonido);
            }
        }
        
    }
    
}