using Duel.ScriptableObjects;


namespace Duel.Contexts
{
    public abstract class Context
    {
        public DiceObject DiceObject;
        public CharacterObject CharacterObject;
        public WeaponObject WeaponObject;
        public StatusesObject StatusesObject;
        public PositionsObject PositionsObject;
        public WorldObject WorldObject;
    }
}