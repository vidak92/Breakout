using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] Direction bounceDirection;
    [SerializeField] bool destroyOnCollision;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
//            Debug.Log("collision: " + name);
            Ball ball = other.GetComponent<Ball>();
            ball.Bounce(bounceDirection);
            if (destroyOnCollision)
            {
                Destroy(transform.parent.gameObject);   
            }
        }
    }
}
