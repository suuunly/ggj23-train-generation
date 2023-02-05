using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        private static readonly int NextLevelKey = Animator.StringToHash("next level");

        [SerializeField] private UnityEvent level1Complete;

        [SerializeField] private LevelController level1;
        [SerializeField] private PlayerController player1;

        [SerializeField] private LevelController level2;
        [SerializeField] private PlayerController player2;

        [SerializeField] private float[] timeBetweenLevels;

        [SerializeField] private Animator animator;

        private void Start()
        {
            StartCoroutine(LevelProgressionRoutine());
        }

        private IEnumerator LevelProgressionRoutine()
        {
            var levelTimerIndex = 0;
            for (var i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(timeBetweenLevels[levelTimerIndex]);
                animator.SetTrigger(NextLevelKey);

                levelTimerIndex = Math.Min(levelTimerIndex + 1, timeBetweenLevels.Length - 1);
            }
        }

        public void SlowDownLevel1()
        {
            level1Complete.Invoke();
            level1.SlowDown();

            player1.SlowDown();
        }

        public void SlowDownLevel1And2()
        {
            level1.SlowDown();
            level2.SlowDown();

            player1.SlowDown();
            player2.SlowDown();
        }
    }
}