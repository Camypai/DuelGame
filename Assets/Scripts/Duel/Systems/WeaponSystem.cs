using Duel.Contexts;
using Duel.Interfaces;
using Duel.Services;


namespace Duel.Systems
{
    public class WeaponSystem : System, IStartSystem, IUpdateSystem
    {
        public WeaponSystem(GameContext context, UsableServices services) : base(context, services)
        {
        }
        
        public void Start()
        {
            
        }

        public void Update()
        {
            
        }
    }
}