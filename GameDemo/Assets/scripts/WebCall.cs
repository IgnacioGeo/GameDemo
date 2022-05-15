using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebCall : MonoBehaviour
{
    public Text messageText, minute1, minute2, second1, second2;

    readonly string postURLDisSec = "http://localhost/PostBestDisSec.php";//
    readonly string postURLDisMin = "http://localhost/PostBestDisMin.php";//
    readonly string getpostURLtime = "http://localhost/Post&GetBestTime.php";//
    readonly string postURLLevel = "http://localhost/PostBestDemo.php";//
    readonly string getURLLevel = "http://localhost/GetBestDemo.php";//

    public void OnButtonLoadSave()
    {
        messageText.text = "Downloading data...";
        StartCoroutine(GetLoadSave());
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

    public void OnButtonPostScoreDisplaySec()
    {
        StartCoroutine(PostDisplaySec(second1.text + second2.text));
    }

    public void OnButtonPostScoreDisplayMin()
    {
        StartCoroutine(PostDisplayMin(minute1.text + minute2.text));
    }

    public void OnButtonBestTime()
    {
        StartCoroutine(PostDisplayMin(minute1.text + minute2.text));
        System.Threading.Thread.Sleep(1000);
        StartCoroutine(PostDisplaySec(second1.text + second2.text));
        System.Threading.Thread.Sleep(1000);
        StartCoroutine(PostTime(minute1.text + minute2.text + second1.text + second2.text));
    }

    public void OnButtonPostBestLevel()
    {
        StartCoroutine(PostDisplayLevel(messageText.text));
    }

    public void ButtonPostBestLevel2()
    {
        StartCoroutine(PostDisplayMin(minute1.text + minute2.text));
        System.Threading.Thread.Sleep(1000);
        StartCoroutine(PostDisplaySec(second1.text + second2.text));
        System.Threading.Thread.Sleep(1000);
        StartCoroutine(PostTime(minute1.text + minute2.text + second1.text + second2.text));
        System.Threading.Thread.Sleep(1000);
        StartCoroutine(PostDisplayLevel(messageText.text));
        System.Threading.Thread.Sleep(1000);
        StartCoroutine(GetLoadSave());
    }

    IEnumerator PostDisplaySec(string curScore)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("curScoreKey", curScore));

        UnityWebRequest www = UnityWebRequest.Post(postURLDisSec, wwwForm);

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

    IEnumerator PostDisplayMin(string curScore)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("curScoreKey", curScore));

        UnityWebRequest www = UnityWebRequest.Post(postURLDisMin, wwwForm);

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

    IEnumerator PostTime(string curScore)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("curScoreKey", curScore));

        UnityWebRequest www = UnityWebRequest.Post(getpostURLtime, wwwForm);

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

    IEnumerator PostDisplayLevel(string curScore)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("curScoreKey", curScore));

        UnityWebRequest www = UnityWebRequest.Post(postURLLevel, wwwForm);

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
