using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClass : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        int scene = Random.Range(2, 5);
        SceneManager.LoadScene(scene);
    }

    public void BackTo()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void QuiteGame()
    {
        Application.Quit();
        
    }
}
