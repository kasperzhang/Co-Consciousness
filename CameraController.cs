using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5f;
    public bool isMove = false;

    private void Start()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        isMove = true;
    }

    private void Update()
    {
        if (GameManager.Instance.gameStatus != GameStatus.Run)
            return;
        
        if (!isMove)
            return;

        if (transform.position.x >= Constants.CameraEndPosition)
            return;
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
