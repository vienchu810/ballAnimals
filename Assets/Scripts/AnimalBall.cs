using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBall : MonoBehaviour
{
    public GameObject newObjectPrefab; // Prefab của GameObject mới cần sinh ra
    private bool hasGeneratedObject = false; // Biến kiểm tra xem đã sinh ra GameObject cho cặp đối tượng này chưa
    public String animBall;
    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra xem GameObject khác có tag "Interactable" không
        if (collision.gameObject.CompareTag(animBall))
        {
            // Kiểm tra xem hai GameObject có giống nhau hay không
            if (collision.gameObject == gameObject && !hasGeneratedObject)
            {
                // Xử lý khi hai GameObject giống nhau va chạm vào nhau
                GenerateNewObject();
                hasGeneratedObject = true; // Đặt biến này để tránh sinh ra nhiều GameObject cho cùng một cặp đối tượng
            }
        }
    }

    private void GenerateNewObject()
    {
        // Sinh ra một GameObject mới từ Prefab
        Instantiate(newObjectPrefab, transform.position, transform.rotation);
    }
}
