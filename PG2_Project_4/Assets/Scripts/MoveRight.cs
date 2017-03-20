using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {
    private float direction = 10f;
    public GameObject PickUp;
    private bool foward;
    float timer;
    bool start = true;
    Shader on;
    Shader off;
    public Renderer rend = new Renderer();
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.yellow;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Checks if The pickups are in the right or left
        if (PickUp.transform.position.x == -9)
        {
            foward = true;
        }
        else if (PickUp.transform.position.x == 9)
        {
            foward = false;
        }
        //Moves the pickups right or left depending on the previous check
        if (foward == true)
        PickUp.transform.position = Vector3.MoveTowards(PickUp.transform.position, new Vector3(9, 0.5f, PickUp.transform.position.z), direction * Time.deltaTime);
     
        if(foward == false)
            PickUp.transform.position = Vector3.MoveTowards(PickUp.transform.position, new Vector3(-9, 0.5f, PickUp.transform.position.z), direction * Time.deltaTime);

        //This is a timer that follows the beet of the music. 
        //Every time the lights go off, the shaders for the pick ups change to make a "glow" effect.
        //The start bool is there in order to put the timer in sequence with the music since the song doesn't start off right
        timer += Time.deltaTime;
        if (timer >= 3.5 && start == true)
        {
           
            off = Shader.Find("GUI/Text Shader");
            rend.material.shader = off; 
        }

        if (timer >= 4 && start == false)
        {
            
            off = Shader.Find("GUI/Text Shader");
            rend.material.shader = off;
        }
        if (timer >= 8 && start == false)
        {
            timer = 0;
            on = Shader.Find("Standard");
            rend.material.shader = on;
            
        }

        if (timer >= 7.5 && start == true)
        {
            timer = 0;
            on = Shader.Find("Standard");
            rend.material.shader = on;         
            start = false;
        }
    }
}
