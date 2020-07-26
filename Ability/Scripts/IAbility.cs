namespace AbilitySystem.Ability.Scripts
{
    public interface IAbility
    {
        void Initialise(IAbilityCaster owner);
        void Uninitialise();
        void Trigger();
        void Release();
        void Update(float deltaTime);
    }
}
