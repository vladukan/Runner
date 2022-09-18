using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Player _player;
    private CanvasGroup _gameOverGroup;
    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }
    private void OnEnable()
    {
        _player.Died += OnDied;
        _restart.onClick.AddListener(OnRestatBtnClick);
    }
    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restart.onClick.RemoveListener(OnRestatBtnClick);
    }
    private void OnDied()
    {
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
    }
    private void OnRestatBtnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void OnExitBtnClick()
    {
        Application.Quit();
    }
}
