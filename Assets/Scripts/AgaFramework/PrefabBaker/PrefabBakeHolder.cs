using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace AgaFramework
{
    public class PrefabBakeHolder : MonoBehaviour
    {
        public PrefabConfigs PrefabConfigs;
    }

    public class BakePrefabBakeHolder : Baker<PrefabBakeHolder>
    {
        public override void Bake(PrefabBakeHolder authoring)
        {
            var prefabholder = new PrefabHolder()
            {
                Entity = GetEntityWithoutDependency()
            };
            
            AddComponent<PrefabHolder>(prefabholder);
            DynamicBuffer<PrefabInfo> prefabInfos = AddBuffer<PrefabInfo>();
            if (authoring.PrefabConfigs != null)
            {
                var prefabs = authoring.PrefabConfigs.Prefabs;
                for (int i = 0; i < prefabs.Count; i++)
                {
                    prefabInfos.Add(new PrefabInfo()
                    {
                        Entity = GetEntity(prefabs[i].Object, TransformUsageFlags.Dynamic)
                    });
                }
            }
        }
    }
    
    
    //Component
    public struct PrefabInfo : IBufferElementData
    {
        public Entity Entity;
    }

    public struct PrefabHolder : IComponentData
    {
        public Entity Entity;
        public DynamicBuffer<PrefabInfo> PrefabInfos;
    }


    // public partial struct TestSystem : ISystem
    // {
    //     public void OnCreate(ref SystemState state)
    //     {
    //         
    //     }
    //     
    //     public void OnUpdate(ref SystemState state)
    //     {
    //         var prefabBakerSigleton = SystemAPI.GetSingleton<PrefabHolder>();
    //         var ecb = state.World.GetExistingSystemManaged<EndSimulationEntityCommandBufferSystem>()
    //             .CreateCommandBuffer();
    //         if (Input.GetKeyDown(KeyCode.A))
    //         {
    //             ecb.Instantiate(state.EntityManager.GetBuffer<PrefabInfo>(prefabBakerSigleton.Entity)[0].Entity);
    //         }
    //     }
    // }
}


