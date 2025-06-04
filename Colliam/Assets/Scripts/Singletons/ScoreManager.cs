using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

namespace Singleton
{
    public class ScoreManager : BaseSingleton<ScoreManager>
    {

        public Action<int> OnScoreChanged;
        public int score = 0;


        private void Start()
        {
            UpdateScore(500);
        }

        public void UpdateScore(int newScore)
        {
            score = newScore;
            OnScoreChanged?.Invoke(score);
        }
    }
}
