using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerComponent : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool isTrigger;
    [SerializeField] private List<MeshRenderer> meshes = new List<MeshRenderer>();
    
    private Collider _collider;

    protected virtual void Start()
    {
        _collider = GetComponent<Collider>();
        
        _collider.isTrigger = isTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTrigger) return;
        
        GameManager.Instance.SetDamage(damage);
        StartCoroutine(HideForTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTrigger || collision.contactCount == 0) return;
        
        GameManager.Instance.SetDamage(damage);
        StartCoroutine(HideForTime());
    }

    private IEnumerator HideForTime()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        meshes.ForEach(mesh => mesh.enabled = false);
        _collider.enabled = false;
        
        yield return new WaitForSecondsRealtime(2f);
        meshes.ForEach(mesh => mesh.enabled = true);
        _collider.enabled = true;
    }
}
