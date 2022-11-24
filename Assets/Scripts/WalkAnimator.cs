using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _forwardProperty = "forward";
    [SerializeField] private Joystick _input;

    private void Update()
    {
        _animator.SetFloat(_forwardProperty, _input.Vertical);
    }
}
