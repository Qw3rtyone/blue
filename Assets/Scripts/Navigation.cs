using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Navigation : MonoBehaviour {

	public void RedScene()
    {
        SceneManager.LoadScene(1);
    }
    public void BlueScene()
    {
        SceneManager.LoadScene(2);
    }
    public void MultiSceneHost()
    {
        SceneManager.LoadScene(3);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
