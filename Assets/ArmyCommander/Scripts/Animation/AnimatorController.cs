using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;
    private string _currentAnimation;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangedAnimation(string animation)
    {
        if (_currentAnimation == animation) return;
        _animator.Play(animation);
        _currentAnimation = animation;
    }

    public void IdleAnimation()
    {
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isShooting", false);
    }
    public void RunAnimation()
    {
        _animator.SetBool("isRunning", true);
    }
    public void ShootAnimation()
    {
        _animator.SetBool("isShooting", true);
    }
    public void DeathAnimation()
    {
        _animator.SetBool("isDeath", true);
    }
}
