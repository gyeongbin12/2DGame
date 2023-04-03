using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : MonoBehaviour
{
    public class PoolItem
    {
        public GameObject gameObject;             // ���� ȭ�鿡 ��Ÿ�� ���� ������Ʈ
    }

    private int increaseCount = 1;         // ���� ������Ʈ�� ������ �� �߰���Ű�� ����
    private int maxCount;                  // ���� ����Ʈ�� ��ϵǾ� �ִ� ���� ������Ʈ ����
    private int activeCount;               // ���� Ȱ��ȭ�Ǿ� �ִ� ���� ������Ʈ ����

    private GameObject poolObject;         // ������Ʈ Ǯ������ �����ϴ� ���� ������Ʈ
    private List<PoolItem> poolItemList;   // ��� ������Ʈ�� �����ϰ� �����ϴ� ����Ʈ


    LinkedList<int> a = new LinkedList<int>();

    public MemoryPool(GameObject poolObject)
    {

        maxCount = 0;
        activeCount = 0;
        this.poolObject = poolObject;

        poolItemList = new List<PoolItem>();

        InstantiateObjects(this.poolObject);
    }

    public void InstantiateObjects(GameObject poolObject)
    {
        // maxCount�� ���� 
        maxCount += increaseCount;

        for (int i = 0; i < increaseCount; i++)
        {
            PoolItem poolItem = new PoolItem();

            this.poolObject = poolObject; 

            poolItem.gameObject = GameObject.Instantiate(poolObject);
            poolItem.gameObject.SetActive(false);

            poolItemList.Add(poolItem);
        }
    }

    public GameObject ActivatePoolItem(GameObject poolObject)
    {
        if (poolItemList == null)
        {
            return null;
        }

        if (maxCount == activeCount)
        {
            InstantiateObjects(poolObject);
        }

        for (int i = 0; i < poolItemList.Count; i++)
        {
            PoolItem poolItem = poolItemList[i];

            // ���� ������Ʈ�� ��Ȱ��ȭ�Ǿ����� Ȯ���ϴ� ������Ƽ
            if (poolItem.gameObject.activeSelf == false)
            {
                activeCount++;

                poolItem.gameObject.SetActive(true);

                return poolItem.gameObject;

            }
        }

        return null;
    }

    public void DeactivatePoolItem(GameObject removeObject)
    {
        if (poolItemList == null || removeObject == null)
        {
            return;
        }

        for(int i = 0; i < poolItemList.Count; i++)
        {
            PoolItem poolItem = poolItemList[i];

            if(poolItem.gameObject == removeObject)
            {
                activeCount--;

                poolItem.gameObject.SetActive(false);

                return;
            }
        }
    }
}