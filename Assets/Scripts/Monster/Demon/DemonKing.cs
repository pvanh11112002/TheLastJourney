using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonKigng : Singleton<DemonKigng>
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
        SoundManager.Instance.Play("Ariel");
        Destroy(gameObject);       
    }
    public void SetIdle()
    {
        anim.SetTrigger("Idle");
    }
    public void DemonAttack()
    {
        SoundManager.Instance.Play("Throw Fire");
    }
}
