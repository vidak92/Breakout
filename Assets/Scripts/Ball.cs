using UnityEngine;

// TODO reimplement collisions without physics engine
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.B))
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
        CheckWallCollisions(other);

        if (other.CompareTag(Tags.Brick))
        {
            Transform brickTransform = other.transform;
            float xDiff = (transform.position.x - brickTransform.position.x);
            float xDiffPerc = xDiff / (transform.localScale.x / 2f + brickTransform.localScale.x / 2f);
            float yDiff = (transform.position.y - brickTransform.position.y);
            float yDiffPerc = yDiff / (transform.localScale.y / 2f + brickTransform.localScale.y / 2f);
//            Debug.Log("x diff: " + xDiff + "\t\tperc: " + xDiffPerc + "\ny diff: " + yDiff + "\t\tperc: " + yDiffPerc);

//            float brickAspectRatio = other.transform.localScale.y / other.transform.localScale.x;

            if (Mathf.Abs(xDiffPerc) >= 0.75f && Mathf.Abs(yDiffPerc) >= 0.75f) // corners
            {
//                Debug.Log("bounce xy");
                direction.x = Mathf.Sign(xDiffPerc) * Mathf.Abs(direction.x);
                direction.y = Mathf.Sign(yDiffPerc) * Mathf.Abs(direction.y);
            }
            else if (Mathf.Abs(xDiffPerc) >= Mathf.Abs(yDiffPerc))
            {
                direction.x = -direction.x;
//                Debug.Log("bounce x");
            }
            else
            {
                direction.y = -direction.y;
//                Debug.Log("bounce y");
            }

            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        CheckWallCollisions(other);
    }

    void CheckWallCollisions(Collider2D collider)
    {
        if (collider.CompareTag(Tags.WallTop))
        {
            direction.y = -Mathf.Abs(direction.y);
        }
        else if (collider.CompareTag(Tags.WallLeft))
        {
            direction.x = Mathf.Abs(direction.x);
        }
        else if (collider.CompareTag(Tags.WallBottom))
        {
            direction.y = Mathf.Abs(direction.y);
        }
        else if (collider.CompareTag(Tags.WallRight))
        {
            direction.x = -Mathf.Abs(direction.x);
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
