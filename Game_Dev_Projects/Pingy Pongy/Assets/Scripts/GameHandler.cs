using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameHandler : MonoBehaviourPunCallbacks
{
    public GameObject player1SpawnPos;
    public GameObject player2SpawnPos;
    public GameObject ballSpawnPos;

    private GameObject player1;
    private GameObject player2;
    private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneHandler.Instance.LoadMenuScene();
            return;
        }

        if (PhotonNetwork.IsMasterClient)
        {
            print("Instantiating Player 1");
            player1 = PhotonNetwork.Instantiate("Player 1", player1SpawnPos.transform.position, Quaternion.identity, 0);
            player1.name = "Player 1";
            //Instantiate ball
            ball = PhotonNetwork.Instantiate("Ball", ballSpawnPos.transform.position, Quaternion.identity, 0);
            ball.name = "Ball";
        }
        else
        {
            print("Instantiating Player 2");
            player2 = PhotonNetwork.Instantiate("Player 2", player2SpawnPos.transform.position, Quaternion.identity, 0);
            player2.name = "Player 2";
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Menu");
        }
    }
}
