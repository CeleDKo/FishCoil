using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentDistanceTraveled;
    [SerializeField] private TMP_Text _bestDistanceTraveled;
    [SerializeField] private TMP_Text _currentScoreTaked;
    [SerializeField] private TMP_Text _bestScoreTaked;
    [SerializeField] private TMP_Text _currentBonusTaked;
    [SerializeField] private TMP_Text _bestBonusTaked;
    [SerializeField] private PlayerCollisionSystem _playerCollisionSystem;
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _deathWindow;
    [SerializeField] private float _fadeSpeed;
    private CanvasGroup _deathWindowCanvasGroup;
    private bool _windowIsEnabled;
    private void Start()
    {
        Time.timeScale = 1;
        _deathWindowCanvasGroup = _deathWindow.GetComponent<CanvasGroup>();
        _deathWindowCanvasGroup.alpha = 0;
        _deathWindow.SetActive(false);
        _windowIsEnabled = false;
    }
    private void OnEnable()
    {
        _playerCollisionSystem.PlayerDeath += EnableDeathWindow;
    }
    private void OnDisable()
    {
        _playerCollisionSystem.PlayerDeath -= EnableDeathWindow;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) && _windowIsEnabled)
#elif UNITY_ANDROID
        Touch touch = new Touch();
        if (touch.tapCount > 0 && _windowIsEnabled)
#endif
        {
            SceneManager.LoadScene(1);
        }
    }

    private void EnableDeathWindow()
    {
        _currentDistanceTraveled.text = $"{_gameController.Distance} м";
        _currentBonusTaked.text = _gameController.BonusTaked.ToString();
        _currentScoreTaked.text = _gameController.ScoreTaked.ToString();

        PlayerPrefs.SetInt("Score", _gameController.Score);

        ComparisonResults();

        _deathWindow.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(EnablingDeathWindow(_fadeSpeed));
    }
    private void ComparisonResults()
    {
        if (_gameController.ScoreTaked > PlayerPrefs.GetInt("BestScoreTaked", 0))
        {
            PlayerPrefs.SetInt("BestScoreTaked", _gameController.ScoreTaked);
            _bestScoreTaked.text = _gameController.ScoreTaked.ToString();
            _bestScoreTaked.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (_gameController.BonusTaked > PlayerPrefs.GetInt("BestBonusTaked", 0))
        {
            PlayerPrefs.SetInt("BestBonusTaked", _gameController.BonusTaked);
            _bestBonusTaked.text = _gameController.BonusTaked.ToString();
            _bestBonusTaked.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (_gameController.Distance > PlayerPrefs.GetInt("BestDistanceTraveled", 0))
        {
            PlayerPrefs.SetInt("BestDistanceTraveled", _gameController.Distance);
            _bestDistanceTraveled.text = _gameController.Distance.ToString();
            _bestDistanceTraveled.transform.GetChild(0).gameObject.SetActive(true);
        }
        _bestScoreTaked.text = PlayerPrefs.GetInt("BestScoreTaked", 0).ToString();
        _bestBonusTaked.text = PlayerPrefs.GetInt("BestBonusTaked", 0).ToString();
        _bestDistanceTraveled.text = $"{PlayerPrefs.GetInt("BestDistanceTraveled", 0)} м";
    }
    public IEnumerator EnablingDeathWindow(float _speed)
    {
        float _time = 0;
        while (_time < 1)
        {
            _deathWindowCanvasGroup.alpha = Mathf.Lerp(0f, 1f, _time);
            _time += _speed * Time.unscaledDeltaTime;
            yield return null;
        }
        _windowIsEnabled = true;
    }
}