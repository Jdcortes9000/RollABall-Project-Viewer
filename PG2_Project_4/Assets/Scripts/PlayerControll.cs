using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControll : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    private Rigidbody rb;
    private int count;
    bool GameOver;
    bool win = false;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
    }
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //checks if the player has collided with the walls or obstacles. If true, its gameover.
        //It also checks if the player has already won or not before declaring gameover.
        if(collision.gameObject.tag == "Wall" && win == false)
        {
            GameOver = true;
            loseText.text = "Game Over!";          
        }
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12 && GameOver == false)
        {
            winText.text = "You Win!";
            win = true;
        }
    }
}
