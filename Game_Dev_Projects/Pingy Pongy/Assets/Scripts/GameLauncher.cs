using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameLauncher : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject controlPanel;
    [Space(5)]
    public GameObject roomJoinUI;
    public GameObject loadArenaBtn;
    public GameObject joinRoomBtn;
    [Space(5)]
    public Text playerStatus;
    public Text connectionStatus;
    [Space(5)]
    public InputField playerNameField;
    public InputField roomNameField;

    string playerName = "";
    string roomID = "";
    string gameVersion = "1";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        print("Connecting to Photon Network");

        roomJoinUI.SetActive(false);
        loadArenaBtn.SetActive(false);

        ConnectToPhoton();
    }

    void ConnectToPhoton()
    {
        connectionStatus.text = "Connecting ...";
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void SetPlayerName()
    {
        playerName = playerNameField.text;
    }

    public void SetRoomID()
    {
        roomID = roomNameField.text;
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            print("Photon Network is connected!! Trying to Create/Join Room: " + roomID);
            RoomOptions roomOptions = new RoomOptions();
            TypedLobby typedLobby = new TypedLobby(roomID, LobbyType.Default);
            PhotonNetwork.JoinOrCreateRoom(roomID, roomOptions, typedLobby);
        }
    }

    public void LoadArena()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            PhotonNetwork.LoadLevel("Game");
        }
        else
        {
            playerStatus.text = "2 player needed to start!";
        }
    }

    public override void OnConnected()
    {
        base.OnConnected();
        connectionStatus.text = "Connected";
        connectionStatus.color = Color.green;
        roomJoinUI.SetActive(true);
        loadArenaBtn.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        controlPanel.SetActive(true);
        Debug.LogError("Disconnected. Please check your Internet connection.");
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            loadArenaBtn.SetActive(true);
            joinRoomBtn.SetActive(false);
            playerStatus.text = "You are Lobby Leader!";
        }
        else
        {
            playerStatus.text = "Connected to Lobby!";
        }
    }
}
