using UnityEngine;
using System;
using Unity.Cinemachine;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Collections;

public class Jugador : MonoBehaviour
{
    public float movementSpeed= 3f;
    public float speed;
    public float jump = 7f;
    Rigidbody2D rb;
    private bool isGrounded;
    public float groundRadius;
    public LayerMask groundLayer;
    public Transform groundChecker;

    public CinemachinePositionComposer cineMachine2;

    public bool direccion;

    public GameObject magia;

    private Animator animator;

    public GameObject limitefinal;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public int contador=0;

    public bool esInvulnerable=false;

    

 void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemigo") && !esInvulnerable) 
        {
            contador+=1;
            if (contador == 1)
            {
                vida3.SetActive(false);
                StartCoroutine(PeriodoInvulnerabilidad()); 
            }
            else if (contador == 2) 
            {
                vida2.SetActive(false);
                StartCoroutine(PeriodoInvulnerabilidad());
            }
            else if (contador == 3)
            {
                vida1.SetActive(false);
                SceneManager.LoadScene("HasPerdido");
            }
        }
        if (other.CompareTag("vida"))
        {
            if (contador == 1)
            {
                vida3.SetActive(true);
            }
            else if (contador == 2) 
            {
                vida2.SetActive(true);
            }
            contador-=1;
            //que desaparezca la vida que coges pero ns como
        }
        
    }

    IEnumerator PeriodoInvulnerabilidad()
    {
        esInvulnerable = true;
        yield return new WaitForSeconds(1); // Espera 2 segundos
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
        rb = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //comprueba que esta constantemente tocando el suelo (me lo dijo javi)
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);
        //movimiento derecha con la tecla d
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
        {
            direccion=true;
            rb.AddForce(Vector2.right * movementSpeed, ForceMode2D.Impulse);
            
        }
        //movimiento izquierda con la tecla a
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
        {
            direccion=false;
            rb.AddForce(Vector2.left * movementSpeed, ForceMode2D.Impulse);
           
        }
        //saltar con el espacio
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if (Input.GetMouseButton(0))
        {
            //añadir que dispare la magia 
        }

        //configuracion cambio animaciones

        if (Input.GetAxisRaw("Horizontal") == 0f)
        {
            animator.SetBool("IsMoving",false);
        }
        else
        {
            animator.SetBool("IsMoving",true);
        }

        //activar animacion jump(?) no funciona
        //if (isGrounded == true)
       // {
        //    animator.SetBool("IsJumping",true);
        //}
        //else
        //{
        //    animator.SetBool("IsJumping",false);
        //}

        // para q la camara cambie de sentido y se flipee la imagen

        if (direccion == true) 
        {
            rb.transform.localScale = new Vector2(0.001f, 0.001f);
            cineMachine2.TargetOffset=new Vector3(4.5f,1f,0f);

        }
        else 
        {
            // Ponemos la X en negativo para que se gire
            rb.transform.localScale = new Vector2(-0.001f, 0.001f);
            cineMachine2.TargetOffset=new Vector3(-4.5f,1f,-0f);
        }
    }
    void FixedUpdate()
    {
        //Velocidad maxima (lo he visto en internet)
        if (Math.Abs(rb.linearVelocity.x)>speed)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * speed, rb.linearVelocity.y);
        }
    }
}
