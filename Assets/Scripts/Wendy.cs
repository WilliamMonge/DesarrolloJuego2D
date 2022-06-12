using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wendy : MonoBehaviour
{
    public GameObject Menuprincipal;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private float Vertical;
    private bool Grounded; //Verificar si esta en el suelo
    [Header("Escalar")]
    [SerializeField] private float climbingSpeed;
    private BoxCollider2D boxCollider2D;
    private float initialSeverity;
    private bool climbing;
    [Header("Progreso vida")]
    public Image corazon;
    public int Cantcorazon;
    public RectTransform PosicionPrimerCorazon;
    public Canvas MyCanvas;
    public int OffSet;
    public bool Startt = false;
    public bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        initialSeverity = Rigidbody2D.gravityScale;
        Transform PosCorazon = PosicionPrimerCorazon;
        for(int i =0; i < Cantcorazon; i++)
        {
            Image NewCorazon = Instantiate(corazon, PosCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            PosCorazon.position = new Vector2(PosCorazon.position.x + OffSet, PosCorazon.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Startt == false)
        {
            if (Input.GetKey(KeyCode.X))
            {
                Startt = true;
            }
        }
        if (Startt == true && GameOver == true)
        {
            if (Input.GetKey(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (Startt == true && GameOver == false)
        {
            Menuprincipal.SetActive(false);
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            if (Horizontal < 0.0f) transform.localScale = new Vector4(-1.0f, 1.0f, 1.0f);
            else if (Horizontal > 0.0f) transform.localScale = new Vector4(1.0f, 1.0f, 1.0f);
            Animator.SetBool("corriendo", Horizontal != 0.0f);


            Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
            if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
            {
                Grounded = true;
            }
            else Grounded = false;

            if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            {
                Animator.SetBool("saltando", true);
                Jump();
            }
            if (Cantcorazon <= 0)
            {
                Destroy(gameObject);
                Destroy(corazon);
            }
        }
    }
 

        //Funciones o Metodos
        private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up* JumpForce);
    }
        private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
        Escalar();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "suelo")
        {
            Animator.SetBool("saltando", false);
        }
        if(other.gameObject.tag == "disparo")
        {
            Destroy(MyCanvas.transform.GetChild(Cantcorazon + 1).gameObject);
            Cantcorazon -= 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "obstaculo")
        {
            Destroy(MyCanvas.transform.GetChild(Cantcorazon + 1).gameObject);
            Cantcorazon -= 1;
        }

    }

    private void Escalar()
    {
        if ((Vertical != 0 || climbing) && (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("escaleras"))))
        {
            Vector4 velosidadSubida = new Vector4(Rigidbody2D.velocity.x, Vertical * climbingSpeed);//Suir y bajar de la escalera
            Rigidbody2D.velocity = velosidadSubida;
            Rigidbody2D.gravityScale = 0;
            climbing = true;
        }
        else
        {
            Rigidbody2D.gravityScale = initialSeverity;
            climbing = false;
        }
    }
}
