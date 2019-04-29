using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenu : MonoBehaviour
{

    public void ChangeToMainMenu()
    {
        StartCoroutine("MainMenu");
    }

    public void ChangeToLevelSelect()
    {
        StartCoroutine("LevelSelect");
    }

    IEnumerator LevelSelect()
    {
        int count = 0;
        while(count < 260)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.01f);
            count++;
        }
    }

    IEnumerator MainMenu()
    {
        int count = 0;
        while (count < 260)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.001f);
            count++;
        }
    }
}
