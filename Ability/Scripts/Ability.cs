using UnityEngine;

namespace AbilitySystem.Ability.Scripts
{
    public class Ability<T> : IAbility where T : IAbilityCaster
    {
        #region Virtual Properties

        public virtual float MaxResourceCount => 0f;
        public virtual float StartingResourceCount => MaxResourceCount;
        public virtual float ResourceCastCost => 0f;

        #endregion

        #region Properties

        public T Caster { get; private set; }
        public float CurrentResourceCount { get; private set; }
        private bool IsTriggerDown { get; set; }

        #endregion

        #region IAbility Implementation

        public void Initialise(IAbilityCaster owner)
        {
            Caster = (T)owner;
            CurrentResourceCount = StartingResourceCount;

            OnAssign();
        }

        public void Uninitialise()
        {
            OnUnassign();
        }

        public void Trigger()
        {
            if (CurrentResourceCount >= ResourceCastCost)
            {
                CurrentResourceCount -= ResourceCastCost;
                OnTrigger();
                IsTriggerDown = true;
            }
        }

        public void Release()
        {
            if (IsTriggerDown)
            {
                OnRelease();
                IsTriggerDown = false;
            }
        }

        public void Update(float deltaTime)
        {
            if (MaxResourceCount > 0f)
            {
                CurrentResourceCount = Mathf.Min(MaxResourceCount, RecoverResource(deltaTime));
            }
        }

        #endregion

        #region Virtual Methods

        public virtual void OnAssign() { }
        public virtual void OnUnassign() { }
        public virtual void OnTrigger() { }
        public virtual void OnRelease() { }

        public virtual float RecoverResource(float deltaTime)
        {
            return CurrentResourceCount + deltaTime;
        }

        #endregion
    }
}
