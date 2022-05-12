using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using TMPro;
using UnityEngine;

public class AccessDataBase : MonoBehaviour
{
    private string url = "http://localhost/readScore.php";

    [SerializeField] private TMP_Text highScores;

    private void start()
    {
        StartCoroutine(GetRequest());
    }

    private IEnumerator GetRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        highScores.text = www.downloadHandler.text;
    }
}
