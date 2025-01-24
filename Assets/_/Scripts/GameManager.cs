using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    private int _currentScore;

    private bool isWin;

    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _slider.maxValue = scoreToWin;
        if(_text.gameObject.activeSelf)_text.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (_currentScore >= scoreToWin && !isWin)
        {
            _text.gameObject.SetActive(true);
            isWin =true;
        }
    }

    public void CalculateScore(int score)
    {
        if (isWin) return;
        _currentScore += score;
        _slider.value = _currentScore;
    }

    [ContextMenu("Reload Game")]
    public void RestartTheGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}
