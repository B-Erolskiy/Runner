using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerStats),
    typeof(Rigidbody),
    typeof(SphereCollider))]
public abstract class BasePlayerController : MonoBehaviour
{
    private PlayerStats _stats;
    private Rigidbody _body;
    private SphereCollider _sphereCollider;

    private bool _isBodyOnGround;

    protected virtual void Start()
    {
        _stats = GetComponent<PlayerStats>();
        _body = GetComponent<Rigidbody>();
        _sphereCollider = GetComponent<SphereCollider>();
        
        StartCoroutine(MoveForward());
    }

    protected virtual void FixedUpdate()
    {
        CheckDeath();
    }

    private IEnumerator MoveForward()
    {
        while (true)
        {
            float addedValue = _isBodyOnGround ? 1f : 0.3f;
            _body.AddForce(Vector3.forward * _stats.speed * addedValue, ForceMode.Force);
            yield return new WaitForFixedUpdate();
        }
    }

    private void CheckDeath()
    {
        if (_body.transform.position.y > _stats.deadYZone) return;

        GameManager.Instance.LoseGame();
    }

    protected void MoveHorizontal(float movement)
    {
        _body.AddForce(Vector3.right * _stats.horizontalSpeed * movement, ForceMode.Force);
    }

    protected void Jump()
    {
        _isBodyOnGround = Physics.CheckSphere(_sphereCollider.bounds.center,
            _sphereCollider.radius * 1.05f, _stats.groundLayer);
        if (!_isBodyOnGround) return;

        _body.AddForce(Vector3.up * _stats.jumpForce, ForceMode.Impulse);
    }
}
