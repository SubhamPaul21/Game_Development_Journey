using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float force = 3f;
    Rigidbody2D ballRigidBody;
    Vector2[] ballPosArray = { Vector2.up, Vector2.down };
    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        Vector2 randomBallPos = ballPosArray[Random.Range(0,2)];
        ballRigidBody.AddForce(randomBallPos * force, ForceMode2D.Impulse);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector2 reverseBallPos = collision.gameObject.name == "Player 1" ? Vector2.up : Vector2.down;
        float randomForce = Random.Range(2, 4);
        ballRigidBody.AddForce(reverseBallPos * randomForce, ForceMode2D.Impulse);
    }
}
