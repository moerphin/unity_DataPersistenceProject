using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public InputField ifName;
    public GameObject noName;
    // Start is called before the first frame update
    void Start()
    {
        if (PersManager.Instance.playerName != "")
        {
            ifName.text = PersManager.Instance.playerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetName()
    {
        PersManager.Instance.playerName = ifName.text;
    }
    public void StartGame()
    {
        if (ifName.text != "")
        {
            SetName();
            noName.SetActive(false);
            SceneManager.LoadScene("main");
        }
        else
        {
            noName.SetActive(true);
        }
    }
    public void StartNew()
    {
        SceneManager.LoadScene("Main");
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
