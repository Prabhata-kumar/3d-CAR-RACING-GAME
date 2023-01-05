using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void ScreneLoder(int index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
