using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour {
    float r, g, b;
    Color col;
    // Use this for initialization
    void Start () {
        r = 0;
        g = 0;
        b = 0;
        col = this.GetComponent<Renderer>().material.color = col; ;
	}
	private Color RandomColour()
    {
        r = Random.Range(0, 255) * 0.004f;
        g = Random.Range(0, 255) * 0.004f;
        b = Random.Range(0, 255) * 0.004f;
        
        return new Color(r, g, b);
    }
    private void ColourSwitch(Color target)
    {
        Color temp = Color.Lerp(this.GetComponent<Renderer>().material.color, target, Time.deltaTime * 2.0f);
        this.GetComponent<Renderer>().material.color = temp;
    }
    // Update is called once per frame
    void Update () {

        //col = RandomColor();
        if (this.GetComponent<Renderer>().material.color == col)
            col = RandomColour();

        ColourSwitch(col);
        //Debug.Log("Red = "+ r + " green = " + g +" blue = "+ b);

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);

    }
}
