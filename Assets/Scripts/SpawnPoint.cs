using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] float _avaiableX;
    [SerializeField] float _avaiableY;

    public Vector2 RandomizeAvaiableSpawnArea()
    {
        float randomX = Random.Range(transform.position.x - _avaiableX, transform.position.x + _avaiableX);
        float randomY = Random.Range(transform.position.y - _avaiableY, transform.position.y + _avaiableY);

        return new Vector2(randomX, randomY);
    }

}
