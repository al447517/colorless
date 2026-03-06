using UnityEngine;
using System;
using Unity.Cinemachine;

public class Jugador : MonoBehaviour
{
    public float movementSpeed= 2f;
    public float speed;
    public float jump = 5f;
    Rigidbody2D rb;
    private bool isGrounded;
    public float groundRadius;
    public LayerMask groundLayer;
    public Transform groundChecker;

    public CinemachinePositionComposer cineMachine2;

    public bool direccion;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundChecker.transform.position, groundRadius);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (direccion == true) 
        {
            rb.transform.localScale = new Vector2(0.001f, 0.001f);
            cineMachine2.TargetOffset=new Vector3(3f,0f,0f);

        }
        else 
        {
            // Ponemos la X en negativo para que se gire
            rb.transform.localScale = new Vector2(-0.001f, 0.001f);
            cineMachine2.TargetOffset=new Vector3(-3f,0f,-0f);
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
