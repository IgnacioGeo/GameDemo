using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerMovementOfi2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed;
    public float jumpForce;
    private bool isJumping;
    public GameObject PauseMenu;
    public GameObject Win;
    public GameObject BestSave;
    public float endGame = 0;

    public Text messageText, minute1, minute2, second1, second2;

    readonly string postURLDisSec = "http://localhost/PostBestDisSec2.php";//
    readonly string postURLDisMin = "http://localhost/PostBestDisMin2.php";//
    readonly string getpostURLtime = "http://localhost/Post&GetBestTime2.php";//
    readonly string postURLLevel = "http://localhost/PostBestDemo2.php";//
    readonly string getURLLevel = "http://localhost/GetBestDemo2.php";//

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Debug.Log("Space = jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P = pause");
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }

        if (endGame == 2)
        {
            Debug.Log("End Game");
            Win.SetActive(true);

            if (messageText.text == "")
            {
                Win.SetActive(true);
            }

            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(PostDisplayMin(minute1.text + minute2.text));
            System.Threading.Thread.Sleep(1000);
            StartCoroutine(PostDisplaySec(second1.text + second2.text));
            System.Threading.Thread.Sleep(1000);
            StartCoroutine(PostTime(minute1.text + minute2.text + second1.text + second2.text));
            //System.Threading.Thread.Sleep(1000);
            //StartCoroutine(PostDisplayLevel(messageText.text));
            //System.Threading.Thread.Sleep(1000);
            //StartCoroutine(GetLoadSave());
            Time.timeScale = 0;
            endGame = endGame + 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity;
        newVelocity.x = Input.GetAxisRaw("Horizontal") * movementSpeed;
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestrucCol"))
        {
            Debug.Log("Trigger Enter!");
            endGame = endGame + 1;
            Debug.Log("endGame= " + endGame);
            Destroy(collision.gameObject);
        }

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
