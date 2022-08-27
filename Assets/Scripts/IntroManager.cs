using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] _introTexts;
    [SerializeField] TextMeshProUGUI _pressEnter;
    [SerializeField] Camera _mainCamera;
    [SerializeField] AudioClip _pistolCock;
    [SerializeField] AudioClip _pistolShot;
    [SerializeField] AudioClip _mystery;

    int _textOrder;
    bool _isFirstPartPassed;

    void Start()
    {
        AudioSource.PlayClipAtPoint(_pistolCock, _mainCamera.transform.position);
        Invoke("MakeIntro", 2f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && _isFirstPartPassed)
        {
            if(_textOrder == _introTexts.Length - 1)
            {
                SceneManager.LoadScene(1);
            }

            _introTexts[_textOrder].enabled = false;
            _introTexts[++_textOrder].enabled = true;

            AudioSource.PlayClipAtPoint(_mystery, _mainCamera.transform.position);
        }
    }

    void MakeIntro()
    {
        AudioSource.PlayClipAtPoint(_pistolShot, _mainCamera.transform.position);
        _introTexts[_textOrder].enabled = false;
        _introTexts[++_textOrder].enabled = true;
        _pressEnter.enabled = true;
        _isFirstPartPassed = true;
    }
}
