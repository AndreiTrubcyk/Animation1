using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Moving : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5f;
    private string[] arrayOfPunches;
    private Random _random =new Random();
    private float _walkFront;
    private float _backWalk;
    private bool _attack;

    private void Awake()
    {
        arrayOfPunches = new[] { "Punching", "Cross Punch" };
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.forward * _speed);
            _walkFront = 1f;
        }
        else
        {
            _walkFront = -1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(Vector3.back * _speed);
            _backWalk = 1f;
        }
        else
        {
            _backWalk = -1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var index = _random.Next(0, arrayOfPunches.Length);
            _animator.Play(arrayOfPunches[index]);
        }
        
        
        _animator.SetFloat("WalkFront", _walkFront);
        _animator.SetFloat("BackWalk", _backWalk);
    }
}
