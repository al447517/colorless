using System;
using System.Net;
using UnityEngine;
//visto en un video de youtube
public class PlataformaMovil_Y : MonoBehaviour 
{
    public GameObject objetoAmover;

    public Transform puntoInicial;
    public Transform puntoFinal;

    public float velocidad=3f;

    private bool direccionarriba;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direccionarriba=true;

    }

    // Update is called once per frame
    void Update()
    {

        if (direccionarriba)
        {
            rb.linearVelocity = new Vector2(0, velocidad);
            if (transform.position.y >= puntoFinal.position.y)
            {
                Girar();
                direccionarriba=false;
            }
        }
        else 
        {
            rb.linearVelocity = new Vector2(0, -velocidad);
            if (transform.position.y <= puntoInicial.position.y)
            {
                Girar();
                direccionarriba=true;
            }
        }

    }


    void Girar()
    {
        Vector3 escala = objetoAmover.transform.localScale;
        escala.x *= -1;
        objetoAmover.transform.localScale = escala;
    }
}

