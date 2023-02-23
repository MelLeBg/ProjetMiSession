using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;

    private List<GameObject> ObjectInPool = new List<GameObject>();
    private int PoolSize = 60;

    [SerializeField] private GameObject bullet;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i <PoolSize; i++)
        {
            GameObject obj = Instantiate(bullet);
                obj.SetActive(false);
            ObjectInPool.Add(obj);

        }
            
        
    }

    public GameObject GetObjectInPool()
    {
        for (int i =0; i < ObjectInPool.Count; i++)
        {
            if (!ObjectInPool[i].activeInHierarchy)
            {
                return ObjectInPool[i];
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
