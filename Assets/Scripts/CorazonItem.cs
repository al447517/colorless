using UnityEngine;

public class CorazonItem : MonoBehaviour
{
    BoxCollider2D boxCollider2D;

     void Awake()
    {
        boxCollider2D= GetComponent<BoxCollider2D>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JugadorController jugador = collision.gameObject.GetComponent<JugadorController>();
            if (jugador.vidaActual < 3)
            {
                jugador.DarVida(1);
                Destroy(gameObject);
            }
        
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
