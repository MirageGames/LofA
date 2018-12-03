using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public float waitTime = 1.0f;
    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;

        if((Input.GetKeyDown(KeyCode.Space)) && waitTime <= 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
