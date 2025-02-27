using UnityEngine;

namespace Animations.Enemies
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AnimatorData))]
    public class EnemyAnimations : MonoBehaviour
    {
        private Animator _animator;
        private AnimatorData _animatorData;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _animatorData = GetComponent<AnimatorData>();
        }

        public void Idle()
        {
            _animator.SetTrigger(_animatorData.Idle);
        }

        public void Walk()
        {
            _animator.SetTrigger(_animatorData.Walk);
        }

        public void Run()
        {
            _animator.SetTrigger(_animatorData.Run);
        }

        public void FightIdle()
        {
            _animator.SetTrigger(_animatorData.FightIdle);
        }

        public void Punch()
        {
            _animator.SetTrigger(_animatorData.Punch);
        }

        public void Died()
        {
            _animator.SetTrigger(_animatorData.Died);
        }
    }
}