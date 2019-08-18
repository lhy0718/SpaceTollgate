using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectScene : MonoBehaviour
{
    public int sceneNum = 0;
    public string title = "";
    public string description = "";

    public void OpenScene()
    {
        MainSound.inst.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(sceneNum);
    }
}
