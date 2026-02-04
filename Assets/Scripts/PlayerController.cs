using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5f;
    public float jumpForce = 10;
    public float bounceForce = 4;
    public int direction = 1;

    public Vector3 initialPosition;
    public Vector3 finalPosition;

    private InputAction moveAction;
    public Vector2 moveDirection;

    private InputAction jumpAction;

    public Rigidbody2D rBody2D;
    private SpriteRenderer renderer;

    private GroundSensor sensor;

    private Animator animator;
    private AudioSource _audioSource; //Añadimos el acceso al componente "AudioSource".
    
    public AudioClip jumpSound; //Creamos un parámetro "AudioClip" dentro del componente "AudioSource" a este componente le asignamos la variable "gameMusic".
    public AudioClip killPlayerSound;

    BGMManager _bGMManager;

    void Awake ()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>(); //Porque es un componente que esta en el propio objeto.
        sensor = GetComponentInChildren<GroundSensor>(); //Porque es un objeto que esta dentro de Mario.

        animator = GetComponent <Animator>();

        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions ["Jump"];

        _audioSource = GetComponent<AudioSource>();
        _bGMManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          //Al inicio modifica la posición de mario al inicio del nivel.
        //transform.position = new Vector3(0, 0, 0);
        //transform.position = startPosition;

    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = moveAction.ReadValue<Vector2>();
        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.Translate(new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, 0, 0));
        //transform.position = Vector2.MoveTowards(transform.position, finalPosition, movementSpeed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + direction, transform.position.y), movementSpeed * time.deltaTime);
        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);

       if (moveDirection.x > 0)
       {

            renderer.flipX = false;
            animator.SetBool("IsRunning", true);

       }

       else if (moveDirection.x < 0)
       {

            renderer.flipX = true;
            animator.SetBool("IsRunning", true);

       }

       else
       {

            animator.SetBool("IsRunning", false);

       }
       
       if (jumpAction.WasPressedThisFrame() && sensor.isGrounded)
       {

          rBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
          JumpSound();

       }

       

       animator.SetBool("IsJumping", !sensor.isGrounded);

    }

    public void Bounce()
{

  rBody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);


}

void JumpSound() //Creamos una función la cual llamamos en VoidStart para no enguarrar ahí dentro.
    {
        _audioSource.PlayOneShot(jumpSound); //Ejecuta el clip de audio.
    }

    public void MarioDeath()
    {

          _audioSource.PlayOneShot(killPlayerSound); //Ejecuta el clip de audio.
          Destroy(gameObject, 0.5f);
          _bGMManager.StopBGM();


      
       // _audioSource.PlayOneShot(deathSFX);//Reproduce un sonido una vez, en este caso el que hemos asignado a la variable "deathSFX". //Puede reproducir varios sonidos al mismo tiempo. //Sólo reproduce una vez.
        //_audioSource.clip = deathSFC:
        //_audioSource.Play(); //Sólo puede reproducir un sonido al mismo tiempo, sirve por ejemplo para cambiar la musica del juego. //Reproduce en bucle.
        
       // movementSpeed = 0;
        //_boxCollider.enabled = false;

        
        //_animator.SetTrigger("IsDead");

        //Destroy (gameObject, 1); //En este cado 0.2f es el dilay para que la muerte no sea instantanea.

       // _gameManager.AddKill(); //Gracias a que antes hemos asignado el valor dentro de "_gameManager", podemos llamar a la función que hay dentro del script "GameManager" llamada "AddKill".
         
        


    }

}
