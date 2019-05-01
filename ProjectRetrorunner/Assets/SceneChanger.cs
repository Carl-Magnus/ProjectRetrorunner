using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene()
    {
        SceneManager.LoadScene("victor_scene", LoadSceneMode.Single);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("gustav_scene");
    }
}
