using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    [SerializeField]
    private Text _currentScoreText;

    [SerializeField]
    private Text _highScoreText;

    private int _highScore;

    private int _currentScore;

    private void Awake()
    {

        _highScore = PlayerPrefs.GetInt("highScore", 0);

    }

    private void FixedUpdate()
    {

        _currentScore += 1;

        if (_currentScore > _highScore)
        {

            _highScore = _currentScore;

        }

        _currentScoreText.text = $"Score: {_currentScore:n0}";

        _highScoreText.text = $"High Score: {_highScore:n0}";

    }

    private void OnDestroy()
    {

        PlayerPrefs.SetInt("highScore", _highScore);

    }

}
