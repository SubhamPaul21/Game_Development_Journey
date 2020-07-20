using UnityEngine;

public class RocketController : MonoBehaviour
{
    // member variables
    private Rigidbody rocketRigidBody;
    private AudioSource audioSource;

    // state variables
    [SerializeField] private float cylinderSpeed = 100f;
    [SerializeField] private float thrustSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Safe");
                break;

            default:
                print("Dead");
                break;
        }
    }

    private void Thrust()
    {
        float thrustThisFrame = thrustSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            rocketRigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        float cylinderSpeedThisFrame = cylinderSpeed * Time.deltaTime;
        rocketRigidBody.freezeRotation = true; //take manual control of rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * cylinderSpeedThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * cylinderSpeedThisFrame);
        }
        rocketRigidBody.freezeRotation = false; // resume physics control of rotation
    }
}
