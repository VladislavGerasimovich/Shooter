using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class PlayerHealth : AbstractHealth
    {
        public override void Die()
        {
            Debug.Log("player died");
        }
    }
}