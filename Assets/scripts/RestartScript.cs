using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void restartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
