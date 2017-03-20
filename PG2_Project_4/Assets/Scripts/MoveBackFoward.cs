using UnityEngine;
using System.Collections;

public class MoveBackFoward : MonoBehaviour {
    private float direction = 5f;
    public GameObject OBS;
    private bool foward;
    float timer;
    bool start = true;
    Shader on;
    Shader off;
    public Renderer rend = new Renderer();
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = rend.material.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Checks if the obstacles are in front or in the back
        if (OBS.transform.position.z == -9)
        {
            foward = true;
        }
        else if (OBS.transform.position.z == 9)
        {
            foward = false;
        }
        //moves the obstacles fowards or backwards depending on the previous check.
        if (foward == true)
            OBS.transform.position = Vector3.MoveTowards(OBS.transform.position, new Vector3(OBS.transform.position.x, 0.1f, 9), direction * Time.deltaTime);

        if (foward == false)
            OBS.transform.position = Vector3.MoveTowards(OBS.transform.position, new Vector3(OBS.transform.position.x, 0.1f, -9), direction * Time.deltaTime);
        //This is a timer that follows the beet of the music. 
        //Every time the lights go off, the shaders for the obstacles change to make a "glow" effect.
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
