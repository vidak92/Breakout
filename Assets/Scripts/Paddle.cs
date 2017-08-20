using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float wallGap = 1f;

    float MinX { get { return -14.5f + wallGap + transform.localScale.x / 2f; } }

    float MaxX { get { return  14.5f - wallGap - transform.localScale.x / 2f; } }

    float direction = 0f;

    void Update()
    {
        if (LeftKeyDown)
        {
            direction = -1f;
        }
        else if (RightKeyDown)
        {
            direction = 1f;
        }
        else if (LeftKeyUp)
        {
            direction = RightKey ? 1f : 0f;
        }
        else if (RightKeyUp)
        {
            direction = LeftKey ? -1f : 0f;
        }
        transform.position += new Vector3(direction * movementSpeed * Time.deltaTime, 0f, 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
//            Debug.Log("collision: Paddle");
            float diffX = (other.transform.position.x - transform.position.x) / transform.localScale.x * 2f;
            float signX = Mathf.Sign(diffX);
            diffX = Mathf.Abs(diffX);
//            Debug.Log("difference = " + difference);
            float degrees = Mathf.Lerp(90f, 30f, diffX);
//            Debug.Log("degrees = " + degrees);
            float x = Mathf.Cos(degrees * Mathf.Deg2Rad) * signX;

            float diffY = other.transform.position.y - transform.position.y;
            float signY = Mathf.Sign(diffY);
//            Debug.Log("diif y: " + diffY);
            float y = Mathf.Sin(degrees * Mathf.Deg2Rad) * signY;

            other.GetComponent<Ball>().SetDirection(x, y);
        }
    }

    bool LeftKey { get { return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow); } }

    bool RightKey { get { return Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow); } }

    bool LeftKeyDown { get { return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow); } }

    bool RightKeyDown { get { return Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow); } }

    bool LeftKeyUp { get { return Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow); } }

    bool RightKeyUp { get { return Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow); } }
}
