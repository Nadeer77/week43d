using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoveCube : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public Rigidbody rb;
    public GameObject gameOver;
    public GameObject win;
    public TextMeshProUGUI textScore;
    [SerializeField]
    private float xvalue;
    private int score;
    public GameObject scoreboard;

    
    void Start()
    {
        Time.timeScale = 1;
        gameOver.SetActive(false);
        win.SetActive(false);
        scoreboard.SetActive(true);
        xvalue = transform.position.x;
        score = 0;
    }

    void Update()
    {
        score = -((int)transform.position.x -(int)xvalue);
        updatescore();
        if(Input.GetKey(KeyCode.Escape))
        {
            exit();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 2f;

        Vector3 movement = new Vector3(moveVertical, 0, -moveHorizontal) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector3.zero;
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            rb.velocity = Vector3.zero;
            Time.timeScale = 0;
            win.SetActive(true);
        }
    }
    public void retry()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
    }
    public void updatescore()
    {
        if (textScore != null)
        {
            textScore.text = score.ToString();
        }
    }
    
}
