using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera camera;
    private new Rigidbody2D rigidbody;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 8f;

    private void Awake()
    {
        // obtains component attached to the object
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void Update()
    {
        HorizontalMovement();
    }

    private void HorizontalMovement() 
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, Time.deltaTime);

    }

    private void FixedUpdate() 
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x - 1.5f, rightEdge.x - 0.5f); // position.x has to find itself between the other two values

        rigidbody.MovePosition(position);
    }
}
