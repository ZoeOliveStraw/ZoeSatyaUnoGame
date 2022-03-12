using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Dropdown players;
    [SerializeField] private TMP_InputField name;
    
    public void LoadGameScreen()
    {
        GameInfo._instance.Initialize(name.text,players.value + 1);
        SceneManager.LoadScene(1);
    }
}
