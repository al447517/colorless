using UnityEngine;

public class EnemyController : MonoBehaviour,IDamageable
{
    public Transform player;
    public float detectionRadius =5.0f;
    public float speed = 2.0f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public void Damage(int DamageAmount)
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<JugadorController>().Damage(1);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancetToPlayer = Vector2.Distance(transform.position, player.position);

        if (distancetToPlayer < detectionRadius)
        {
            Vector2 direction =(player.position-transform.position).normalized;
            movement=new Vector2(direction.x,0);
        }
        else
        {
            movement=Vector2.zero;
        }
        rb.MovePosition(rb.position+movement*speed*Time.deltaTime);

        if (rb.linearVelocityX > 0)
        {
            rb.transform.localScale = new Vector3(0.0702726f, 0.0702726f, 1f);
        }
        else if (rb.linearVelocityX < 0)
        {
            rb.transform.localScale = new Vector3(-0.0702726f, 0.0702726f, 1f);
        }

    }
}
