using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{    
    public detectionzone biteDetectionzone;
    Animator anim;
    Rigidbody2D rb;
    public bool _hasTarget = false;
    Damageable damageable;
    public float flightSpeed = 2f;
    
    public Collider2D deathCollider;
    public float moveSpeed = 2f; // Tốc độ di chuyển
    public float rotationAngle = 180f; // Góc xoay
    public float repeatInterval = 4f; // Thời gian lặp lại

    private Vector3 originalPosition;
    private float timer;
    private bool isRotating;
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
    public bool CanMove
    {
        get
        {
            return anim.GetBool(AnimationString.canMove);
        }
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damageable= GetComponent<Damageable>();
        deathCollider = GetComponent<Collider2D>();
    }
    void OnEnable()
    {
        damageable.damageableDeath.AddListener(OnDeath);
        damageable.Respawn();
    }
    private void Start()
    {
        originalPosition = transform.position;
        timer = 0f;
        isRotating = false;
    }
    // Update is called once per frame
    void Update()
    {
        HasTarget = biteDetectionzone.detectedColliders.Count > 0;
        timer += Time.deltaTime;

        // Di chuyển vật thể sang trái
        float newX = originalPosition.x - moveSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, originalPosition.y, originalPosition.z);

        // Kiểm tra nếu đã đủ thời gian để xoay
        if (timer >= repeatInterval / 2f && !isRotating)
        {
            // Xoay quanh trục Y
            transform.Rotate(0f, rotationAngle, 0f);
            isRotating = true;
        }

        // Kiểm tra nếu đã đủ thời gian để quay lại
        if (timer >= repeatInterval)
        {
            // Đặt lại thời gian và trạng thái xoay
            timer = 0f;
            isRotating = false;
        }
    }
    
    public void OnDeath()
    {
        gameObject.SetActive(false);
        
    }
}
