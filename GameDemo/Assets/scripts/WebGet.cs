using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebGet : MonoBehaviour
{
    public Text messageText;

    readonly string getURLLevel = "http://localhost/GetBestDemo.php";//

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetLoadSave());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetLoadSave()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURLLevel);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }

        else
        {
            messageText.text = www.downloadHandler.text;
        }
    }

}