using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBottom : MonoBehaviour
{
    bool isEnter;
    //계란이 접촉하면 새로운 계란 투하
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isEnter)
        {
            StartCoroutine(DestroyEgg());
        }
    }
    IEnumerator DestroyEgg()
    {
        isEnter = true;
        var egg = GameObject.Find("Egg");

        Managers.Destroy(egg);
        yield return new WaitForSeconds(0.1f);

        Managers.Resource.Instantiate("Egg", null, 1);
        isEnter = false;
    }
}

