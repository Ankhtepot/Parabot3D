using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Fireball Games * * * PetrZavodny.com

namespace Utilities.ObjectPool
{
    public class ObjectPool : GCSubscriberSingletonMono<ObjectPool>
    {
        [SerializeField] private Transform spawnParent;
        public List<PreSpawnSetItem> preSpawnSetItems;
        private static readonly Dictionary<string, Queue<GameObject>> Pool = new Dictionary<string, Queue<GameObject>>();

        public override void Awake()
        {
            base.Awake();
            if (!spawnParent)
            {
                spawnParent = transform;
            }
        }

        private void Start()
        {
            if (preSpawnSetItems.Any())
            {
                SpawnPreSpawnItems();
            }
        }

        public GameObject GetFromPool(GameObject go, Vector3 position, Quaternion rotation, GameObject parent = null) 
        {
            if (Pool.ContainsKey(go.name) && Pool[go.name].Any())
            {
                var removedObject = Pool[go.name].Dequeue();
                var removedObjectTransform = removedObject.transform;
                removedObjectTransform.position = position;
                removedObjectTransform.rotation = rotation;
                removedObjectTransform.SetParent(parent != null ? parent.transform : spawnParent);
                removedObject.gameObject.SetActive(true);
                return ProcessInterfaces(removedObject);
            }
        
            return InstantiateNewPoolObject(go, position, rotation, parent);
        }

        public void ReturnToPool(GameObject returningObject)
        {
            if (!Pool.ContainsKey(returningObject.name))
            {
                Pool.Add(returningObject.name, new Queue<GameObject>());
            }

            var returningObjectTransform = returningObject.transform;
            returningObjectTransform.localPosition = spawnParent.position;
            returningObjectTransform.SetParent(spawnParent);
            returningObject.gameObject.SetActive(false);
        
            Pool[returningObject.name].Enqueue(returningObject);
        }

        private GameObject InstantiateNewPoolObject(GameObject requestedObject, Vector3 position, Quaternion rotation, GameObject parent, bool instantiateToDisabled = false) 
        {
            var newObject = Instantiate(requestedObject, position, rotation, parent != null ? parent.transform : spawnParent);
            newObject.name = requestedObject.name;
            newObject = ProcessInterfaces(newObject);
            
            if (instantiateToDisabled)
            {
                newObject.SetActive(false);
            }
                
            return newObject;
        }
        
        private GameObject InstantiateNewPoolObject(GameObject objectToInstantiate, bool instantiateToDisabled = false) 
        {
            var objectToInstantiateTransform = objectToInstantiate.transform;
            return InstantiateNewPoolObject(
                objectToInstantiate, objectToInstantiateTransform.position, objectToInstantiateTransform.rotation, gameObject, instantiateToDisabled
            );
        }
        
        private GameObject ProcessInterfaces(GameObject target)
        {
            var needy = target.GetComponents<IPoolNeedy>();
            if (needy.Any())
            { //TODO: FIX THIS
                foreach (var poolNeedy in needy)
                {
                    if (!poolNeedy.pool)
                    {
                        poolNeedy.pool = this;
                    }
                }
            }

            var initializable = target.GetComponent<IPoolInitializable>();
            initializable?.Initialize();

            return target;
        }
        
        private void SpawnPreSpawnItems()
        {
            preSpawnSetItems.ForEach(item =>
            {
                if (!item.prefabGameObject || item.howMany <= 0) return;

                for (int i = 0; i < item.howMany; i++)
                {
                    var newObject = InstantiateNewPoolObject(item.prefabGameObject, true);
                    ReturnToPool(newObject);
                }
            });
        }

        [Serializable]
        public class PreSpawnSetItem
        {
            public GameObject prefabGameObject;
            public int howMany;
        }
    }
}
