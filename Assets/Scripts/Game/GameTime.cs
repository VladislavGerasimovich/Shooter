using UnityEngine;

namespace Game
{
    public class GameTime : MonoBehaviour
    {
        public void Run()
        {
            Time.timeScale = 1;
        }

        public void Stop()
        {
            Time.timeScale = 0;
        }
    }
}