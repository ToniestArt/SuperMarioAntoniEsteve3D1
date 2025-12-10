using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5f;
    public float jumpForce = 10;
    public int direction = 1;

    public Vector3 initialPosition;
    public Vector3 finalPosition;

    private InputAction moveAction;
    public Vector2 moveDirection;

    public Rigidbody2D rBody2D;

    void Awake ()
    {
        rBody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        transform.position = startPosition;

        moveAction = InputSystem.actions["Move"];

        rBody2D.AddForce(Vector2.up * jumpForce);

    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = moveAction.ReadValue<Vector2>();
        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        transform.Translate(new Vector3(moveDirection.x * movementSpeed * Time.deltaTime, 0, 0));
        
        //transform.position = Vector2.MoveTowards(transform.position, finalPosition, movementSpeed * Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + direction, transform.position.y), movementSpeed * time.deltaTime);
  
        
        //transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
  
    }
}
