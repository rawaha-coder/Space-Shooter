using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Image _livesImages;
    [SerializeField]
    private Sprite[] _liveSprites;
    void Start()
    {
        _livesImages.sprite = _liveSprites[3];
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLive)
    {
        _livesImages.sprite = _liveSprites[currentLive];
        if(currentLive == 0)
        {
            _gameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlikerRoutine());
        }

    }

    IEnumerator GameOverFlikerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }

    }
}
