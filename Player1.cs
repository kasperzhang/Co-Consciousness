using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
{
    private Transform _bulletParent;

    private float _timer = 0f;

    protected override void OnInit()
    {
        _bulletParent = GameObject.FindWithTag("bullet_parent").transform;
    }

    protected override void OnMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            IsMoving = true;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            IsMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            IsMoving = false;
        }
    }

    protected override void OnUpdate()
    {
        _timer += Time.deltaTime;

        Shoot();
    }
    

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (_timer < Constants.Player1ShootCoolTime)
                return;
        
            var bullet = Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"), transform);
            bullet.transform.localPosition = new Vector3(0.7f, -0.35f, 0f);
            bullet.transform.SetParent(_bulletParent);

            _timer = 0f;
        }
    }
}
