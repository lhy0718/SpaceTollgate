using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IfSelectOff : MonoBehaviour
{
    public Image ConUI;
    public void TurnOff()
    {
        transform.Find("IfSelect").gameObject.SetActive(false);
    }
}
