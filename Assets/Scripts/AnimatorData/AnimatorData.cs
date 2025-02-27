using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public readonly int Idle = Animator.StringToHash(nameof(Idle));
    public readonly int Walk = Animator.StringToHash(nameof(Walk));
    public readonly int Run = Animator.StringToHash(nameof(Run));
    public readonly int FightIdle = Animator.StringToHash(nameof(FightIdle));
    public readonly int Punch = Animator.StringToHash(nameof(Punch));
    public readonly int Died = Animator.StringToHash(nameof(Died));
}