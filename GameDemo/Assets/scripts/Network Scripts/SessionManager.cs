using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Text;
using Unity.Netcode;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
    [SerializeField]
    private TMP_InputField passwordInputField;

    [SerializeField]
    private GameObject passwordUI;

    [SerializeField]
    private GameObject leaveBtn;

    private NetworkVariable<int> playersInGame = new NetworkVariable<int>();

    public int PlayersInGame
    {
        get
        {
            return playersInGame.Value;
        }
    }
    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
        /* NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
         {
             if (IsServer)
                 playersInGame.Value++;
         };
         NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
         {
             if (IsServer)
                 playersInGame.Value--;
         };*/
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton == null)
            return;

        NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnect;
    }

    public void Host()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.StartHost();
    }

    public void Client()
    {
        NetworkManager.Singleton.NetworkConfig.ConnectionData = Encoding.ASCII.GetBytes(passwordInputField.text);
        NetworkManager.Singleton.StartClient();

    }

    public void Leave()
    {
        NetworkManager.Singleton.Shutdown();
        if (NetworkManager.Singleton.IsHost)
            NetworkManager.Singleton.ConnectionApprovalCallback -= ApprovalCheck;

        passwordUI.SetActive(true);
        leaveBtn.SetActive(false);
    }

    public void HandleServerStarted()
    {
        if (NetworkManager.Singleton.IsHost)
            HandleClientConnected(NetworkManager.Singleton.ServerClientId);
    }

    private void HandleClientConnected(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            passwordUI.SetActive(false);
            leaveBtn.SetActive(true);
            AddClient(clientId);
        }
    }

    private void HandleClientDisconnect(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            passwordUI.SetActive(true);
            leaveBtn.SetActive(false);
            RemoveClient(clientId);
        }
    }

    private void ApprovalCheck(byte[] connectionData, ulong clientId, NetworkManager.ConnectionApprovedDelegate callback)
    {
        string password = Encoding.ASCII.GetString(connectionData);

        bool approveConnection = password == passwordInputField.text;

        callback(true, null, approveConnection, null, null);
    }
    #region Functions

    private void AddClient(ulong id)
    {
        if (IsServer)
            playersInGame.Value++;
    }
    private void RemoveClient(ulong id)
    {
        if (IsServer)
            playersInGame.Value--;
    }

    #endregion
}
