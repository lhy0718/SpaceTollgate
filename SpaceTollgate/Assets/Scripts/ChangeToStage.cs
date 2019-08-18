using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeToStage : MonoBehaviour
{
    public int stageNum = 0;

    public void ToStage()
    {
        MainSound.inst.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(stageNum);
    }
}
