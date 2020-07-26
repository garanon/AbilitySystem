namespace AbilitySystem.Ability.Scripts
{
    public interface IAbilityCaster
    {
        void AssignAbility(IAbility ability, int id = 0);
        void UnassignAbility(int id = 0);
        void TriggerAbility(int id = 0);
        void ReleaseAbility(int id = 0);
    }
}