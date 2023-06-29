using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
    }

    
}
