using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(Instance);
    }

    public TMP_Text stageInfoText;

    public GameObject _panel;

    public void GameStart()
    {
        GameManager.Instance.isStart = true;
        _panel.SetActive(false);
    }
}
