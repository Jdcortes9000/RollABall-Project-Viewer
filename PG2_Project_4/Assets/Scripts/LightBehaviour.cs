using UnityEngine;
using System.Collections;

public class LightBehaviour : MonoBehaviour {

    public Light l;
    float timer;
    bool start = true;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //This is a timer that follows the beet of the music. 
        //Every four seconds, the lights go off, another four seconds and the light on. And so on.
        //The start bool is there in order to put the timer in sequence with the music since the song doesn't start of right.
        timer += Time.deltaTime;
        if (timer >= 3.5 && start == true)
        {
            //changes the ambient light to black and the directory light off in order to have the Pitch Black effect.
            //I also had to change the skyblock shader in the Windows>Lighting Box to something else that would make the surroundings black
            RenderSettings.ambientLight = Color.black;
            l.enabled = false;
        }

        if (timer>=4 && start == false)
        {
            //changes the ambient light to black and the directory light off in order to have the Pitch Black effect.
            RenderSettings.ambientLight = Color.black;
            l.enabled = false;
        }
        if (timer >= 8 && start == false)
        {
            //changes the ambient light to White and the directory light on. Plus it resets the timer.
            RenderSettings.ambientLight = Color.white;
            l.enabled = true;
            timer = 0;
        }

        if (timer>=7.5 && start == true)
        {
            //changes the ambient light to White and the directory light on. Plus it resets the timer.
            RenderSettings.ambientLight = Color.white;
            l.enabled = true;
            timer = 0;
            start = false;
        }
	}
}
