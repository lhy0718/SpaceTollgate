using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectScene : MonoBehaviour
{
    public int sceneNum = 0;
    public string title = "";
    [TextArea]
    public string description = "";
    public GameObject ifSelect;

    private void Start()
    {
    }

    public void OpenScene()
    {
        ifSelect.GetComponentInChildren<ChangeToStage>().stageNum = sceneNum;
        ifSelect.transform.Find("StageName").GetComponent<Text>().text = title;
        ifSelect.transform.Find("Script").GetComponent<Text>().text = description;
        ifSelect.SetActive(true);
    }
}
