using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace AgaFramework
{
    public class AgaCentralRandom : MonoBehaviour
    {
        
    }

    public class AgaRandomBaker : Baker<AgaCentralRandom>
    {
        public override void Bake(AgaCentralRandom authoring)
        {
            CentralRandomable rand = new CentralRandomable()
            {
                Random = Random.CreateFromIndex((uint)UnityEngine.Random.Range(1, 100))
            };
            AddComponent(rand);
        }
    }
    
    
    public struct IndiRandomable : IComponentData
    {
        public Random Random;
    }
    
    //When use central random, use RefRW to modify
    public struct CentralRandomable : IComponentData
    {
        public Random Random;
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
    //         var t = SystemAPI.GetSingletonRW<CentralRandomable>();
    //         if (Input.GetKeyDown(KeyCode.A))
    //         {
    //             // Debug.Log(t.Random.NextFloat());
    //             Debug.Log(t.ValueRW.Random.NextFloat());
    //         }
    //     }
    // }

}