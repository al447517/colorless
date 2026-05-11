using UnityEngine;
using System;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.InputSystem;

public class JugadorController : MonoBehaviour, IDamageable
{
    [Header("Movimiento")]
    public float movementSpeed = 3f;
    public float speed;
    public float jump = 7f;

    private Rigidbody2D rb;
    private bool isGrounded;

    public float groundRadius;
    public LayerMask groundLayer;
    public Transform groundChecker;

    [Header("Camara")]
    public CinemachinePositionComposer cineMachine2;

    public float suavizadoCamara = 5f;
    private Vector3 offsetObjetivo;

    [Header("Animaciones")]
    private Animator animator;

    [Header("Vida")]
    public GameObject limitefinal;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;

    public int vidaActual = 3;

    public bool esInvulnerable = false;

    [Header("Ataque")]
    private bool atacando;

    [SerializeField] private AtaqueJugador ataque;

    [Header("Materiales")]
    private Renderer myRenderer;

    public Material materialNuevo;
    public Material materialViejo;

    [Header("Plataforma")]
    private PlataformaMovil plataformaActual;


    private Vector2 moveInput;
    private bool jumpPressed;
    private bool attackPressed;

    private bool IsMoving = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpPressed = true;
        }
    }

    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            attackPressed = true;
        }
    }
    public void DarVida(int cantidad)
    {
        if (vidaActual < 3)
        {
            vidaActual += cantidad;
            ActualizarVida();
        }

    }

    private void ActualizarVida()
    {
        if (vidaActual >= 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
        }
        else if (vidaActual == 2)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(false);
        }
        else if (vidaActual == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
        else if (vidaActual <= 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("vida"))
        {
            ActualizarVida();
        }

        //asi puedo acceder al script de la plataforma en la q estoy subido en ese momento
        if (collision.gameObject.CompareTag("plataformaMovil"))
        {
            plataformaActual = collision.gameObject.GetComponent<PlataformaMovil>();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataformaMovil"))
        {
            plataformaActual = null;
        }
    }

    //lo hice con ayuda buscando en internet
    IEnumerator PeriodoInvulnerabilidad()
    {
        //parpadeo
        esInvulnerable = true;
        myRenderer.material = materialNuevo;
        yield return new WaitForSeconds(0.5f);
        myRenderer.material = materialViejo;
        yield return new WaitForSeconds(0.5f); 
        myRenderer.material = materialNuevo;
        yield return new WaitForSeconds(0.5f);
        myRenderer.material = materialViejo;
        esInvulnerable = false;
    }

    private void OnDrawGizmos() //circulito verde para el isgrounded (me lo dijo javi)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundChecker.transform.position, groundRadius);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetObjetivo = new Vector3(3f, 1f, 0f);
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //comprueba que esta constantemente tocando el suelo (me lo dijo javi)
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);

        //movimiento derecha con la tecla d
        float movimientoX = moveInput.x * speed;

        if (plataformaActual != null)
        {
            movimientoX += plataformaActual.velocidadPlataforma.x;
        }

        //saltar con el espacio

        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jump);
        }

        jumpPressed = false;

        rb.linearVelocity = new Vector2(movimientoX,rb.linearVelocity.y);

        //atacar con click izquierdo

        if (attackPressed && !atacando)
        {
            Atacando();
        }

        attackPressed = false;

        //configuracion cambio animaciones

        if (!IsMoving)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }

        animator.SetBool("atacando", atacando);

        animator.SetBool("saltando", !isGrounded);

        // para q la camara cambie de sentido y se flipee la imagen

        if (moveInput.x > 0)
        {
            offsetObjetivo = new Vector3(3f, 1f, 0f);
            rb.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
            cineMachine2.TargetOffset = Vector3.Lerp(cineMachine2.TargetOffset, new Vector3(4f, 1f, 0f), Time.deltaTime * 5f);
        }
        else if (moveInput.x < 0)
        {
            offsetObjetivo = new Vector3(-3f, 1f, 0f);
            rb.transform.localScale = new Vector3(-0.001f, 0.001f, 1f);
            cineMachine2.TargetOffset = Vector3.Lerp(cineMachine2.TargetOffset, new Vector3(-4f, 1f, 0f), Time.deltaTime * 5f);
        }

        IsMoving = rb.linearVelocity != Vector2.zero;

        //para que muera si cae al vacío
        
        if (transform.position.y < -11)
        {
            Die();
        }
    }
    void FixedUpdate()
    {
        //Velocidad maxima (lo he visto en internet)
        if (Math.Abs(rb.linearVelocity.x) > speed)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * speed, rb.linearVelocity.y);
        }
    }

    void Atacando()
    {
        atacando = true;
    }
    void DejaDeAtacar()
    {
        atacando = false;
    }
    public void AplicarDaño()
    {
        ataque.InicializarHitbox(5);
    }
    public void Damage(int DamageAmount)
    {
        if (esInvulnerable) return;
        vidaActual -= 1;
        StartCoroutine(PeriodoInvulnerabilidad());
        if (vidaActual <= 0 )
        {
            Die();
        }
        ActualizarVida();
    }

    public void Die()
    {
        Scene escenaActual = SceneManager.GetActiveScene();
        if (escenaActual.name == "Nivel1")
        {
            SceneManager.LoadScene("HasPerdido1");
        }
        if (escenaActual.name == "Nivel2")
        {
            SceneManager.LoadScene("HasPerdido2");
        }

    }
}
