using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int playerScore = 0;
    public Text scoreText;
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(0, verticalInput * speed * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreTrigger"))
        {
            playerScore += 10;
            scoreText.text = "SCORE: " + playerScore;
            // Optional: Debugging to check if the trigger is detected
            Debug.Log("ScoreTrigger entered.");
        }
    }
}
