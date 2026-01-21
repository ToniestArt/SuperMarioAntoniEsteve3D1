using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;

    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;

    public AudioClip deathSFX;
    private Animator _animator;

    public float movementSpeed = 4;
    public int direction = 1;

    private GameManager _gameManager; //Creamos la variable "_gameManager" de tipo "GameManager" el tipo es un nombre único que pertenece al nombre del script en cuestión en este caso.

    void Awake()
    {
        _rigidBody2D = GetComponent <Rigidbody2D>();
        _audioSource = GetComponent <AudioSource>();
        _boxCollider = GetComponent <BoxCollider2D>();
        _animator = GetComponent <Animator>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //Asignamos un valor a la variable que hemos creado con aterioridad mediante la búsqueda de un objeto que contenga el script, en este caso el objeto "Game Manager", una vez encontrado el objeto, buscamos un compoente dentro del objeto, en este caso "GameManager" el script, ahora "_gameManager" ya tiene acceso al script "GameManager" de forma que puedo utilizarlo en este script.
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody2D.linearVelocity = new Vector2(direction * movementSpeed, _rigidBody2D.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tuberias") || collision.gameObject.layer == 7)
        {
            //Esto hacec lo mismo que la linea de abajo pero de forma mas intuitiva
            //direction = direction * -1;
            direction *= -1;
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void GoombaDeath()
    {

        _audioSource.PlayOneShot(deathSFX);//Reproduce un sonido una vez, en este caso el que hemos asignado a la variable "deathSFX". //Puede reproducir varios sonidos al mismo tiempo. //Sólo reproduce una vez.
        //_audioSource.clip = deathSFC:
        //_audioSource.Play(); //Sólo puede reproducir un sonido al mismo tiempo, sirve por ejemplo para cambiar la musica del juego. //Reproduce en bucle.
        
        movementSpeed = 0;
        _boxCollider.enabled = false;

        
        _animator.SetTrigger("IsDead");

        Destroy (gameObject, 1); //En este cado 0.2f es el dilay para que la muerte no sea instantanea.

        _gameManager.AddKill(); //Gracias a que antes hemos asignado el valor dentro de "_gameManager", podemos llamar a la función que hay dentro del script "GameManager" llamada "AddKill".
       

            

       

    }

}