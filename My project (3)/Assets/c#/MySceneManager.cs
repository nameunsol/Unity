using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneManager : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(1);
    }
}
