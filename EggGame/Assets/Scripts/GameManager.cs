using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    [SerializeField]
    public int stage;

    public bool isStart  = false;
    public void StageSetting()
    {
        Managers.Resource.Instantiate($"StageObject/StageObject_{stage}", null, 1);

        Managers.Resource.Instantiate("Egg", null, 1);
    }    
}
