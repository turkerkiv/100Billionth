using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] EventBehaviour[] _events;
    [SerializeField] SpawnPoint[] _spawnPoints;
    [SerializeField] Slider _chaosSlider;
    [SerializeField] TextMeshProUGUI _yearsPassedTMP;
    [SerializeField] TextMeshProUGUI _endingTMP;
    [SerializeField] float _spawnRate = 5f;
    [SerializeField] float _chaosRate = 1f;

    public float Chaos
    {
        get { return _chaos; }
        set { _chaos = value; }
    }

    public bool IsGameOver
    {
        get { return _isGameOver; }
        set { _isGameOver = value; }
    }

    float _chaos = 0f;
    string _chaosSituation;
    float _chaosTimer;
    float _spawnTimer;
    bool _isGameOver;
    int _yearsPassed;
    float _yearsTimer;

    void Start()
    {
        _chaosSituation = "Easy";
    }

    void Update()
    {
        if (!IsGameOver)
        {   //
            SpawnEvent();
            IncreaseChaos();
            //
            if (_chaos < 25)
            {
                _chaosSituation = "Easy";
            }
            else if (_chaos >= 25 && _chaos < 50)
            {
                _chaosSituation = "Medium";
                _chaosRate = 0.75f;
                _spawnRate = 4f;
            }
            else
            {
                _chaosSituation = "Hard";
                _chaosRate = 0.5f;
                _spawnRate = 3f;
            }
            //
            if (_chaos > 100)
            {
                _isGameOver = true;
            }
            //
            _yearsTimer += Time.deltaTime;
            if (_yearsTimer > 1)
            {
                _yearsPassed++;
                _yearsPassedTMP.text = _yearsPassed + " :Years Passed";
                _yearsTimer = 0;
            }
        }
        else
        {
            _endingTMP.gameObject.SetActive(true);
            _endingTMP.text = "You lasted " + _yearsPassed + " years";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void IncreaseChaos()
    {
        _chaosTimer = _chaosTimer + Time.deltaTime;
        if (_chaosTimer > _chaosRate)
        {
            _chaosTimer = 0;
            _chaos++;

            _chaosSlider.value = _chaos;
        }
    }

    void SpawnEvent()
    {
        _spawnTimer = _spawnTimer + Time.deltaTime;
        if (_spawnTimer > _spawnRate)
        {
            Instantiate(SelectEvent(), SelectSpawnPoint(), SelectEvent().transform.rotation, gameObject.transform);

            _spawnTimer = 0;
        }
    }

    EventBehaviour SelectEvent()
    {
        int randomSelecting = Random.Range(0, _events.Length);

        while (_events[randomSelecting].EventType != _chaosSituation)
        {
            randomSelecting = Random.Range(0, _events.Length);
            continue;
        }

        return _events[randomSelecting];
    }

    Vector2 SelectSpawnPoint()
    {
        int randomPoint = Random.Range(0, _spawnPoints.Length);

        return _spawnPoints[randomPoint].RandomizeAvaiableSpawnArea();
    }
}
