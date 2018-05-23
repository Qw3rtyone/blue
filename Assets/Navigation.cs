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
}
