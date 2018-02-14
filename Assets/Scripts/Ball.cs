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
        Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Init();
        }

        if (!canMove && Input.GetKeyDown(KeyCode.Space))
        {
            canMove = true;
            col.enabled = true;
            direction = new Vector2(1f, 1f);
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
        if (other.CompareTag(Tags.WallTop))
        {
            direction.y = -Mathf.Abs(direction.y);
        }
        else if (other.CompareTag(Tags.WallLeft))
        {
            direction.x = Mathf.Abs(direction.x);
        }
        else if (other.CompareTag(Tags.WallBottom))
        {
            direction.y = Mathf.Abs(direction.y);
        }
        else if (other.CompareTag(Tags.WallRight))
        {
            direction.x = -Mathf.Abs(direction.x);
        }
        else if (other.CompareTag(Tags.Brick))
        {
            float xDiff = transform.position.x - other.transform.position.x;
            float yDiff = transform.position.y - other.transform.position.y;
            //Debug.Log("x diff: " + xDiff + "\ny diff: " + yDiff);

            float brickAspectRatio = other.transform.localScale.y / other.transform.localScale.x;

            if (Mathf.Abs(xDiff * brickAspectRatio) > Mathf.Abs(yDiff))
            {
                direction.x = -direction.x;
            }
            else
            {
                direction.y = -direction.y;
            }

            Destroy(other.gameObject);
        }
    }

    void Init()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        transform.position = FindObjectOfType<Paddle>().transform.position + new Vector3(1f, 1f, 0f);
        paddleTransform = FindObjectOfType<Paddle>().transform;
        paddleOffset = transform.position - paddleTransform.position;
        canMove = false;
        direction = Vector2.zero;
    }

    public void SetDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
    }
}
