using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 30f;
    [SerializeField] float xClampThreshold = 2f;

    string playerName = "";
    Rigidbody2D playerRigidBody;
    float dirX;
    PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
        playerName = photonView.Owner.NickName;
        gameObject.name = playerName;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPlayerTranslation();
    }

    private void FixedUpdate()
    {
        //ProcessPlayerVelocity();
    }

    private void ProcessPlayerTranslation()
    {
        // Movement for player
        //dirX = Input.acceleration.x * playerSpeed;
        //float xClampPos = Mathf.Clamp(transform.position.x, -xClampThreshold, xClampThreshold);
        //transform.position = new Vector2(xClampPos, transform.position.y);

        //Testing code
        if (photonView.IsMine)
        {
            float xOffset = Input.GetAxis("Horizontal") * playerSpeed;
            float xClampPos = Mathf.Clamp(xOffset, -xClampThreshold, xClampThreshold);
            transform.position = new Vector2(xClampPos, transform.position.y);
        }
    }

    private void ProcessPlayerVelocity()
    {
        playerRigidBody.velocity = new Vector2(dirX, 0f);
    }
}
