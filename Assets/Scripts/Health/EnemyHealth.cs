using UnityEngine;

namespace Health
{
    public class EnemyHealth : AbstractHealth
    {
        public override void Die()
        {
            Debug.Log("died");
        }
    }
}