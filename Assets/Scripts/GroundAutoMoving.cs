using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAutoMoving : MonoBehaviour
{
    public float moveDistance = 2f; // Khoảng cách di chuyển
    public float moveSpeed = 1f; // Tốc độ di chuyển

    private Vector3 originalPosition;
    private float timer;

    void Start()
    {
        originalPosition = transform.position;
        timer = 0f;
    }

    void Update()
    {
        // Tính toán thời gian di chuyển
        timer += Time.deltaTime;

        // Di chuyển vật thể giữa trái và phải
        float newX = originalPosition.x + Mathf.PingPong(timer * moveSpeed, moveDistance);
        transform.position = new Vector3(newX, originalPosition.y, originalPosition.z);
    }
}
