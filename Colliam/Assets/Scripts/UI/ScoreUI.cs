using Singleton;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreUI : MonoBehaviour
    {
        private const string Scoreprefix = "Score : ";
        private TextMeshProUGUI _text;

        void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            HandleScoreChanged(0);
        }

        private void OnEnable()
        {
            var scoreManager = ScoreManager.Instance;
            scoreManager.OnScoreChanged -= HandleScoreChanged;
            scoreManager.OnScoreChanged += HandleScoreChanged;
        }

        void HandleScoreChanged(int newScore)
        {
            _text.text = Scoreprefix + newScore;
        }
    }
}