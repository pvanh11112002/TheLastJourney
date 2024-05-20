using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UriaSoulEaterControl : Singleton<UriaSoulEaterControl>
{
    public detectionzone biteDetectionzone;
    Animator anim;
    public bool _hasTarget = false;
    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
            anim.SetBool(AnimationString.hasTarget, value);
        }
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        HasTarget = biteDetectionzone.detectedColliders.Count > 0;
    }
    public void OnDespawn()
    {
        anim.SetTrigger("isDead");
        Invoke("OnDestroy", 1);
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
    public void SetIdle()
    {
        anim.SetTrigger("Idle");
    }
}
