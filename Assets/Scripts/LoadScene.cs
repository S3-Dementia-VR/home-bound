using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    public void OnMouseClick() {
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame() {
        Application.Quit();
    }
}
