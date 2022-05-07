using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private void update()
    {
    }

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void Client()
    {
        NetworkManager.Singleton.StartClient();
    }

}