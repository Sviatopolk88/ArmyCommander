using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void IdleAnimation()
    {
        _animator.SetBool("isIdle", true);
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isShooting", false);
        _animator.SetBool("isDeath", false);
    }
    public void RunAnimation()
    {
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isRunning", true);
        _animator.SetBool("isShooting", false);
    }
    public void ShootAnimation()
    {
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isShooting", true);
    }
    public void DeathAnimation()
    {
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isShooting", false);
        _animator.SetBool("isDeath", true);
    }
}
