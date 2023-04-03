using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{
    private MemoryPool memoryPool;
    private string[] unitName = new string[2];

    private void Awake()
    {
        unitName[0] = "Goblin";
        unitName[1] = "Slime";

        memoryPool = new MemoryPool(Resources.Load<GameObject>(unitName[Random.Range(0, 2)]));
    }

    void Start()
    {

        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        var wait = new WaitForSeconds(5f);

        while (true)
        {
            yield return wait;

            GameObject monster = Resources.Load<GameObject>(unitName[Random.Range(0, 2)]);

            monster = memoryPool.ActivatePoolItem(monster);

            monster.GetComponent<Monster>().SetUp(memoryPool);

            monster.transform.position = Random.insideUnitCircle.normalized * 7.5f;
        }
    }




}
