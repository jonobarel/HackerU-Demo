using UnityEngine;

namespace DefaultNamespace
{
    public class Example : MonoBehaviour
    {
        private float duration;
        private float targetTime;
        private float currentTime;

        void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime > duration)
            {
                //instantiate
                currentTime = 0;
            }
        }

    }
}