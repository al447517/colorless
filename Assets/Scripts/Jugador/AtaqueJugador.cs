using System;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    JugadorController jugador;

    BoxCollider2D hitbox;
    [SerializeField] LayerMask enemyLayer;
    public void InicializarHitbox(int Damage)
    {
        Collider2D[] hits=Physics2D.OverlapBoxAll(hitbox.transform.position,hitbox.size,0f,enemyLayer); 

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
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
