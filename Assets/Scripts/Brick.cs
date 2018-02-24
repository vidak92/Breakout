using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] BrickType type;
    [SerializeField] Color regularColor;
    [SerializeField] Color unbreakableColor;

    SpriteRenderer sr;

    public BrickType Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
            if (type == BrickType.Regular)
            {
                sr.color = regularColor;
            }
            else if (type == BrickType.Unbreakable)
            {
                sr.color = unbreakableColor;
            }
        }
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
}
