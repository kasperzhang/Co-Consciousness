using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float destroyTime = 3f;

    private float _timer = 0f;

    private void Update()
    {
        if (GameManager.Instance.gameStatus != GameStatus.Run)
            return;
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        _timer += Time.deltaTime;
        if (_timer >= destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
