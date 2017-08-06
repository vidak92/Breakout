using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    Transform paddleTransform;
    Vector2 direction;
    Collider2D col;
    Vector3 paddleOffset;
    bool canMove;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        transform.position = FindObjectOfType<Paddle>().transform.position + new Vector3(1f, 1f, 0f);
        paddleTransform = FindObjectOfType<Paddle>().transform;
        paddleOffset = transform.position - paddleTransform.position;
        canMove = false;
        direction = Vector2.zero;
    }

    void Update()
    {
        if (!canMove && Input.GetKeyDown(KeyCode.Space))
        {
            canMove = true;
            col.enabled = true;
            direction = Vector2.one;
        }

        if (canMove)
        {
            Vector2 velocity = direction.normalized * movementSpeed * Time.deltaTime;
            transform.position += new Vector3(velocity.x, velocity.y, 0f);

            Debug.DrawLine(transform.position + Vector3.down, transform.position + Vector3.up, Color.white);
            Debug.DrawLine(transform.position + Vector3.left, transform.position + Vector3.right, Color.white);

            Vector3 debugVector = new Vector3(velocity.x, velocity.y, 0f);
            Debug.DrawLine(transform.position, transform.position + debugVector * 10f, Color.green);    
        }
        else
        {
            transform.position = paddleTransform.position + paddleOffset;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(ColliderDisableForOneFrame());
    }

    System.Collections.IEnumerator ColliderDisableForOneFrame()
    {
        col.enabled = false;
        yield return null;
        col.enabled = true;
    }

    public void SetDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
    }

    public void Bounce(Direction bounceDirection)
    {
        switch (bounceDirection)
        {
            case Direction.Up:
                direction.y = Mathf.Abs(direction.y);
                break;
            case Direction.Right:
                direction.x = (Mathf.Abs(direction.x));
                break;
            case Direction.Down:
                direction.y = -Mathf.Abs(direction.y);
                break;
            case Direction.Left:
                direction.x = -Mathf.Abs(direction.x);
                break;
            default:
                break;
        }
    }
}
