using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{
    private string[] unitName = new string[2];

    void Start()
    {
        unitName[0] = "Goblin";
        unitName[1] = "Slime";

        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        var wait = new WaitForSeconds(5f);

        while (true)
        {
            yield return wait;

            Instantiate(Resources.Load<GameObject>
            (
                unitName[Random.Range(0, 2)]),
                Random.insideUnitCircle.normalized * 5,
                Quaternion.identity
            );
        }
    }




}
