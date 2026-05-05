using System;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    JugadorController jugador;

    BoxCollider2D hitbox;
    [SerializeField] LayerMask enemyLayer;

    //al metodo InicializarHitbox me ayudo Adrià Sánchez ya que como lo tenia anteriormente me daba problemas y los enemigos no funcionaban correctamente
    public void InicializarHitbox(int Damage)
    {
        
        Bounds b = hitbox.bounds;
        //cuenta el numero de objetos en la enemyLayer que hay en la 'caja' del ataque
        Collider2D[] hits = Physics2D.OverlapBoxAll(b.center,b.size,0f,enemyLayer); 

        foreach(Collider2D hit in hits)
        {
            IDamageable Damageable=hit.gameObject.GetComponent<IDamageable>();
            if (Damageable != null)
            {
                Damageable.Damage(Damage);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        jugador = GetComponentInParent<JugadorController>();
        hitbox = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
