using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public int level;
    public TMP_Text levelText;


    private void Start()
    {
        levelText.text = "Select Level " + level.ToString();

        Button button = GetComponent<Button>();

        button.onClick.AddListener(()=> {
            Debug.Log("Load Level");
            OpenScene();
        });
    }

    private void OpenScene()
    {
        SceneManager.LoadScene(level);
    }
}
