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
    private InputAction _pauseAction;

    private InputAction _attackAction;

    public Rigidbody2D rBody2D;
    private SpriteRenderer renderer;

    private GroundSensor sensor;

    private Animator animator;
    private AudioSource _audioSource; //Añadimos el acceso al componente "AudioSource".
    
    public AudioClip jumpSound; //Creamos un parámetro "AudioClip" dentro del componente "AudioSource" a este componente le asignamos la variable "gameMusic".
    public AudioClip killPlayerSound;

    private BGMManager _bGMManager;
    private BoxCollider2D _boxCollider;

    private GameManager _gameManager;
    private SceneLoader _goToGameOver;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public GameObject attackHitBox;

    private bool _canShoot = false;

    private float _powerUpDuration = 10;
    private float _powerUpTimer;

    public float attackImpactForce = 30;
    void Awake ()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>(); //Porque es un componente que esta en el propio objeto.
        sensor = GetComponentInChildren<GroundSensor>(); //Porque es un objeto que esta dentro de Mario.

        animator = GetComponent <Animator>();

        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions ["Jump"];
        _pauseAction = InputSystem.actions ["Pause"];
        _attackAction = InputSystem.actions ["Attack"];

        _audioSource = GetComponent<AudioSource>();
        _bGMManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
        _boxCollider = GetComponent <BoxCollider2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        _goToGameOver = GameObject.Find("GameOverLoader").GetComponent<SceneLoader>();

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

        if (_pauseAction.WasPressedThisFrame())
        {

            _gameManager.Pause();

        }
        if(_gameManager._pause == true)
        {
            return;
        }
        moveDirection = moveAction.ReadValue<Vector2>();
        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.Translate(new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, 0, 0));
        //transform.position = Vector2.MoveTowards(transform.position, finalPosition, movementSpeed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + direction, transform.position.y), movementSpeed * time.deltaTime);
        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);

       if (moveDirection.x > 0)
       {

            //renderer.flipX = false;
            transform.rotation = Quaternion.Euler(0,0,0);
            animator.SetBool("IsRunning", true);

       }

       else if (moveDirection.x < 0)
       {

            //renderer.flipX = true;
            transform.rotation = Quaternion.Euler(0,180,0);
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

        if (_attackAction.WasPressedThisFrame() && _canShoot)
        {
            
            Shoot();
            //Attack();
            //animator.SetTrigger("Attack");
        }

        if(_canShoot)
        {
            ShootPowerUp();
        }

    }

void ShootPowerUp()
{
    _powerUpTimer += Time.deltaTime;

    if(_powerUpTimer >= _powerUpDuration)
    {
        _canShoot = false;
    }
}
    public void Bounce()
{
    rBody2D.linearVelocity = new Vector2(rBody2D.linearVelocity.x, 0);
  rBody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);


}

void JumpSound() //Creamos una función la cual llamamos en VoidStart para no enguarrar ahí dentro.
    {
        _audioSource.PlayOneShot(jumpSound); //Ejecuta el clip de audio.
    }

    public void MarioDeath()
    {

        _audioSource.PlayOneShot(killPlayerSound); //Ejecuta el clip de audio.
        
        _bGMManager.StopBGM();
        _boxCollider.enabled = false;
        animator.SetTrigger("Death");
        Destroy(gameObject, 5);
        _goToGameOver.ChangeScene("GameOver");     
       // _audioSource.PlayOneShot(deathSFX);//Reproduce un sonido una vez, en este caso el que hemos asignado a la variable "deathSFX". //Puede reproducir varios sonidos al mismo tiempo. //Sólo reproduce una vez.
        //_audioSource.clip = deathSFC:
        //_audioSource.Play(); //Sólo puede reproducir un sonido al mismo tiempo, sirve por ejemplo para cambiar la musica del juego. //Reproduce en bucle.
        
       // movementSpeed = 0;
        //_boxCollider.enabled = false;

        
        //_animator.SetTrigger("IsDead");

        //Destroy (gameObject, 1); //En este cado 0.2f es el dilay para que la muerte no sea instantanea.

       // _gameManager.AddKill(); //Gracias a que antes hemos asignado el valor dentro de "_gameManager", podemos llamar a la función que hay dentro del script "GameManager" llamada "AddKill".
         
        


    }

    void Shoot ()
    {

        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

    }

    void Attack()
    {
        if(attackHitBox.activeInHierarchy)
        {
            attackHitBox.SetActive(false);
        }
        else
        {
            attackHitBox.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.gameObject.CompareTag("PowerUp"))
       {
        _powerUpTimer = 0;
        _canShoot = true;
       } 
    }

}
