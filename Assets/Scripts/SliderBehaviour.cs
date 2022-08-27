using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField] List<string> _usableAbilities;
    [SerializeField] float _eventPoint;
    GameManager _gameManager;

    public List<string> UsableAbilities
    {
        get { return _usableAbilities; }
        set { _usableAbilities = value; }
    }

    Slider _slider;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {

    }

    public void IncreaseValue()
    {
        _slider.value++;

        if (_slider.value == _slider.maxValue)
        {
            _gameManager.Chaos -= _eventPoint;
            Invoke("Destroy", 0.3f);
        }
    }

    void Destroy()
    {
        Destroy(GetComponentInParent<EventBehaviour>().gameObject);
    }
}
