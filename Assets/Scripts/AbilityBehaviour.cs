using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AbilityBehaviour : MonoBehaviour
{
    [SerializeField] Camera _mainCam;
    [SerializeField] string _abilityName;
    [SerializeField] GameManager _gameManager;
    [SerializeField] AudioClip _SFX;

    void Start()
    {
        Invoke("SetReady", 3f);
    }

    void Update()
    {
    }

    void SetReady()
    {
        if (GetComponent<BoxCollider2D>().enabled)
        {
            return;
        }

        GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.5f);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!_gameManager.IsGameOver)
        {
            Destroy(gameObject);

            SliderBehaviour _slider = other.GetComponentInChildren<SliderBehaviour>();
            if (_slider.UsableAbilities.Contains(_abilityName))
            {
                _slider.IncreaseValue();
                AudioSource.PlayClipAtPoint(_SFX, _mainCam.transform.position, 0.5f);
            }
        }
    }

    void OnMouseDrag()
    {
        transform.position = _mainCam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10f);
    }

    void OnMouseDown()
    {
        GameObject newAbility = Instantiate(gameObject, transform.position, transform.rotation);
        newAbility.GetComponent<SpriteRenderer>().color += new Color (0, 0, 0, -0.5f);
        newAbility.GetComponent<BoxCollider2D>().enabled = false;   
    }

    void OnMouseUp()
    {
        Destroy(gameObject);
    }
}
