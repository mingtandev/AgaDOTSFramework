using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgaFramework
{
    [CreateAssetMenu(menuName = "PrefabConfig", fileName = "PrefabConfigs")]

    public class PrefabConfigs : ScriptableObject
    {
        public List<PrefabConfig> Prefabs;
    }
        
    [Serializable]
    public class PrefabConfig
    {
        public GameObject Object;
    }

}