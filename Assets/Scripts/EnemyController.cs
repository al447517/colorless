using UnityEngine;

public class EnemyController : MonoBehaviour,IDamageable
{
    public Transform player;
    public float detectionRadius =5.0f;
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private Animator animator;
    private bool isDead = false;

    [SerializeField] private ScoreController Score;

    public void Damage(int DamageAmount)
    {
        if (isDead) return;

        isDead = true;
        GetComponent<Collider2D>().enabled = false;
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("IsDead", true);
        Score.SumaScore(10);
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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius && !isDead)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);

            // Mantener la velocidad actual en Y (gravedad) y solo modificar la X
            rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
        }
        else
        {
            // Frenar gradualmente cuando no persigue
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * 0.95f, rb.linearVelocity.y);
        }

        // Flip del sprite
        if (rb.linearVelocity.x < 0)
        {
            transform.localScale = new Vector3(0.0702726f, 0.0702726f, 1f);
        }
        else if (rb.linearVelocity.x > 0)
        {
            transform.localScale = new Vector3(-0.0702726f, 0.0702726f, 1f);
        }
    }
}
