using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectScene : MonoBehaviour
{

    public Image ConUI;
    public Text[] TobeWritten = new Text[2];
    public Text[] ToWrite = new Text[1];

    public void ConfirmUI()
    {
        ConUI.gameObject.SetActive(true);
        ConUI.transform.Find("StageName").gameObject.GetComponent<Text>().text = transform.Find("Text").gameObject.GetComponent<Text>().text;
        ConUI.transform.Find("Script").gameObject.GetComponent<Text>().text = transform.Find("Script").gameObject.GetComponent<Text>().text;
    }
}
