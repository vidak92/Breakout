using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float wallGap = 1f;

    float MinX { get { return -14.5f + wallGap + transform.localScale.x / 2f; } }

    float MaxX { get { return  14.5f - wallGap - transform.localScale.x / 2f; } }

    void Update()
    {
        float h = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            h -= 1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            h += 1f;
        }
//        Debug.Log("h: " + h);
//        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h * movementSpeed * Time.deltaTime, 0f, 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
//            Debug.Log("collision: Paddle");
            float difference = (other.transform.position.x - transform.position.x) / transform.localScale.x * 2f;
            float sign = Mathf.Sign(difference);
            difference = Mathf.Abs(difference);
//            Debug.Log("difference = " + difference);
            float degrees = Mathf.Lerp(90f, 30f, difference);
//            Debug.Log("degrees = " + degrees);
            float x = Mathf.Cos(degrees * Mathf.Deg2Rad) * sign;
            float y = Mathf.Sin(degrees * Mathf.Deg2Rad);
            other.GetComponent<Ball>().SetDirection(x, y);
        }
    }
}
