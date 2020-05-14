using System.Collections.Generic;
using Duel.Interfaces;


namespace Duel.Helpers
{
    public class SystemCollection
    {
        public List<IAwakeSystem> AwakeSystems = new List<IAwakeSystem>();
        public List<IStartSystem> StartSystems = new List<IStartSystem>();
        public List<IUpdateSystem> UpdateSystems = new List<IUpdateSystem>();
        public List<IFixedUpdateSystem> FixedUpdateSystems = new List<IFixedUpdateSystem>();
        public List<ILateUpdateSystem> LateUpdateSystems = new List<ILateUpdateSystem>();

        public void Add<T>(T item)
        {
            var type = typeof(T);
            var interfaces = type.GetInterfaces();

            foreach (var @interface in interfaces)
            {
                if (@interface.Name.Equals(nameof(IAwakeSystem)))
                {
                    AwakeSystems.Add(item as IAwakeSystem);
                }

                if (@interface.Name.Equals(nameof(IStartSystem)))
                {
                    StartSystems.Add(item as IStartSystem);
                }

                if (@interface.Name.Equals(nameof(IUpdateSystem)))
                {
                    UpdateSystems.Add(item as IUpdateSystem);
                }

                if (@interface.Name.Equals(nameof(IFixedUpdateSystem)))
                {
                    FixedUpdateSystems.Add(item as IFixedUpdateSystem);
                }

                if (@interface.Name.Equals(nameof(ILateUpdateSystem)))
                {
                    LateUpdateSystems.Add(item as ILateUpdateSystem);
                }
            }
        }
    }
}