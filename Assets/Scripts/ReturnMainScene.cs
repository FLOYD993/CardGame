using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnMainScene : MonoBehaviour
{
    public void ReturnMain()
    {
        SceneManager.LoadScene(0);
    }
}
