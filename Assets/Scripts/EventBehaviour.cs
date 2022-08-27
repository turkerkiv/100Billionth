using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventBehaviour : MonoBehaviour
{
    [SerializeField] string _eventType;
    [SerializeField] string _eventName;

    public string EventType
    {
        get { return _eventType; }
        set { _eventType = value; }
    }
}
