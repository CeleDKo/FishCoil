using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DarkScreen : MonoBehaviour
{
    [SerializeField] private GameObject _blackScreen;
    private void Start()
    {
        StartCoroutine(ChangeSceneFrom());
    }
    public IEnumerator ChangeSceneOn(int neededScene)
    {
        _blackScreen.SetActive(true);
        Color _neededColor = _blackScreen.GetComponent<Image>().color;
        _neededColor.a = 0;
        _blackScreen.GetComponent<Image>().color = _neededColor;
        Color _blackScreenColor = _blackScreen.GetComponent<Image>().color;
        _neededColor.a = 1;
        float _time = 0;
        while (_time < 1)
        {
            _blackScreen.GetComponent<Image>().color = Color.Lerp(_blackScreenColor, _neededColor, _time);
            _time += Time.unscaledDeltaTime;
            yield return null;
        }
        SceneManager.LoadScene(neededScene);
    }

    public IEnumerator ChangeSceneFrom()
    {
        _blackScreen.SetActive(true);
        _blackScreen.GetComponent<Image>().color = Color.black;
        Color _neededColor = _blackScreen.GetComponent<Image>().color;
        Color _blackScreenColor = _blackScreen.GetComponent<Image>().color;
        _neededColor.a = 0;
        float _time = 0;
        while (_time < 1)
        {
            _blackScreen.GetComponent<Image>().color = Color.Lerp(_blackScreenColor, _neededColor, _time);
            _time += Time.unscaledDeltaTime;
            yield return null;
        }
        _blackScreen.SetActive(false);
    }
}
