using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float minXSpeed, maxXSpeed, minYSpeed, maxYSpeed;
    [SerializeField] private float destroyTime;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minXSpeed, maxXSpeed), Random.Range(minYSpeed, maxYSpeed));
        Destroy(gameObject, destroyTime);
    }
}
