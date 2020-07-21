using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    // member variables
    private Rigidbody rocketRigidBody;
    private AudioSource audioSource;

    // state variables
    [SerializeField] private float cylinderSpeed = 100f;
    [SerializeField] private float thrustSpeed = 1000f;

    enum State { Alive, Dying, Transitioning }
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }
        else
        {
            StopRocketSound();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;

            case "Finish":
                state = State.Transitioning;
                Invoke("LoadNextLevel", 2f);
                //GameManager.Instance.LoadNextLevel();
                break;

            default:
                state = State.Dying;
                Invoke("LoadStartLevel", 2f);
                //GameManager.Instance.LoadStartLevel();
                break;
        }
    }

    private void StopRocketSound() { audioSource.Stop(); }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadStartLevel()
    {
        SceneManager.LoadScene(0);
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
            StopRocketSound();
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
