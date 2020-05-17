using System.Collections.Generic;
using Duel.Interfaces;


namespace Duel.Helpers
{
    public class SystemCollection
    {
        public readonly List<IAwakeSystem> AwakeSystems = new List<IAwakeSystem>();
        public readonly List<IStartSystem> StartSystems = new List<IStartSystem>();
        public readonly List<IUpdateSystem> UpdateSystems = new List<IUpdateSystem>();
        public readonly List<IFixedUpdateSystem> FixedUpdateSystems = new List<IFixedUpdateSystem>();
        public readonly List<ILateUpdateSystem> LateUpdateSystems = new List<ILateUpdateSystem>();

        public void Add(ISystem system)
        {
            if (system is IAwakeSystem awake)
            {
                AwakeSystems.Add(awake);
            }
            
            if (system is IStartSystem start)
            {
                StartSystems.Add(start);
            }
            
            if (system is IUpdateSystem update)
            {
                UpdateSystems.Add(update);
            }

            if (system is IFixedUpdateSystem fixedUpdate)
            {
                FixedUpdateSystems.Add(fixedUpdate);
            }

            if (system is ILateUpdateSystem lateUpdate)
            {
                LateUpdateSystems.Add(lateUpdate);
            }
        }
    }
}