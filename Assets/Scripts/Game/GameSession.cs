using Enemies;
using Health;
using Objects3d;
using Player.Movement;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private AllEnemies _allEnemies;
        [SerializeField] private List<Object3d> _allObjects;

        public void Restart()
        {
            _playerHealth.Restore();
            _playerMovement.SetPosition();
            _allEnemies.SetInitialValues();

            foreach (Object3d item in _allObjects)
            {
                item.Restore();
            }
        }
    }
}