using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCanvas : MonoBehaviour
{
    [SerializeField]
    Camera _camera;


    private void OnEnable()
    {
        _camera.transform.position = GameObject.Find("Egg").GetComponent<Egg>().eggCenterTr.position + new Vector3(0, 0, -10);
        GameManager.Instance.isStart = false;
    }

    public void NextStage()
    {
        var egg = GameObject.Find("Egg");

        Managers.Destroy(egg);

        GameManager.Instance.stage++;
        Managers.Destroy(FindObjectOfType<Scripte_Stageobject>().gameObject);
        GameManager.Instance.StageSetting();

        MainCanvas.Instance._panel.SetActive(true);



        Managers.Destroy(gameObject);
    }

}
