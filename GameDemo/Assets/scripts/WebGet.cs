using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebGet : MonoBehaviour
{
    public Text messageTextL2;
    public Text messageTextL3;
    public Text messageTextL8;

    readonly string getURLLevel2 = "http://localhost/GetBestDemo.php";//
    readonly string getURLLevel3 = "http://localhost/GetBestDemo2.php";//

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetLoadSave());
        StartCoroutine(GetLoadSaveL3());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetLoadSave()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURLLevel2);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }

        else
        {
            messageTextL2.text = www.downloadHandler.text;
        }
    }

    IEnumerator GetLoadSaveL3()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURLLevel3);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }

        else
        {
            messageTextL3.text = www.downloadHandler.text;
        }
    }

}