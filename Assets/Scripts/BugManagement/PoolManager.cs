using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    Dictionary<int, Queue<ObjectInstance>> m_PoolDictionary = new Dictionary<int, Queue<ObjectInstance>>();

    static PoolManager _Instance;

    public static PoolManager Instance
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = FindObjectOfType<PoolManager>();
            }
            return _Instance;
        }
    }

	public void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();

        if(!m_PoolDictionary.ContainsKey(poolKey))
        {
            m_PoolDictionary.Add(poolKey, new Queue<ObjectInstance>());

            for(int i = 0; i < poolSize; i++)
            {
                ObjectInstance newObject = new ObjectInstance(Instantiate(prefab) as GameObject);
                m_PoolDictionary[poolKey].Enqueue(newObject);
            }

        }
    }

    public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();

        if(m_PoolDictionary.ContainsKey(poolKey))
        {
            ObjectInstance objectToReuse = m_PoolDictionary[poolKey].Dequeue();
            m_PoolDictionary[poolKey].Enqueue(objectToReuse);

            objectToReuse.Reuse(position, rotation);
        }
    }

    public class ObjectInstance
    {
        GameObject gameObject;
        Transform transform;

        bool hasPoolObjectComponent;
        PoolObject poolObjectScript;

        public ObjectInstance(GameObject objectInstance)
        {
            gameObject = objectInstance;
            transform = gameObject.transform;
            gameObject.SetActive(false);

            if (gameObject.GetComponent<PoolObject>())
            {
                hasPoolObjectComponent = true;
                poolObjectScript = gameObject.GetComponent<PoolObject>();
            }
        }

        public void Reuse(Vector3 position, Quaternion rotation)
        {
            gameObject.SetActive(true);
            transform.position = position;
            transform.rotation = rotation;
            Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
            Collider2D collider2D = gameObject.GetComponent<Collider2D>();
            collider2D.enabled = true;
            rigidbody.velocity = new Vector2(0,4f);
            rigidbody.gravityScale = 0;
            if (hasPoolObjectComponent)
            {
                poolObjectScript.OnObjectReuse();
            }
        }

    }
}
