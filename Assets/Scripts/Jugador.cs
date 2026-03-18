using UnityEngine;
using System;
using Unity.Cinemachine;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Jugador : MonoBehaviour
{
    public float movementSpeed= 3f;
    public float speed;
    public float jump = 5f;
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



    private void OnDrawGizmos()
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

        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
        {
            direccion=true;
            rb.AddForce(Vector2.right * movementSpeed, ForceMode2D.Impulse);
            
        }
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
        {
            direccion=false;
            rb.AddForce(Vector2.left * movementSpeed, ForceMode2D.Impulse);
           
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if (Input.GetMouseButton(0))
        {
            //añadir que dispare la magia 
        }

        if (Input.GetAxisRaw("Horizontal") == 0f)
        {
            animator.SetBool("IsMoving",false);
        }
        else
        {
            animator.SetBool("IsMoving",true);
        }


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
        void OnTriggerEnter(Collider limitefinal) {
        
            SceneManager.LoadScene("Nivel1boss");
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
