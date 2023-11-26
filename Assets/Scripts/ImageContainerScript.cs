using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageContainerScript : MonoBehaviour
{
   public List<Sprite> imageList = new List<Sprite>();
    public int numberOfObjectsToSpawn = 10;
    public GameObject tilePrefab;

    private int currentImageIndex = 0;
    private GameObject[] imageObjects;  // Sử dụng mảng để theo dõi nhiều đối tượng
    private Rigidbody2D[] rbs;  // Sử dụng mảng để theo dõi nhiều RigidBody2D
    private bool mouseClicked = false;

    void Start()
    {
        imageObjects = new GameObject[numberOfObjectsToSpawn];
        rbs = new Rigidbody2D[numberOfObjectsToSpawn];
        StartCoroutine(SpawnRandomImages(0f));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClicked = true;
          
                if (rbs[i] == null)
                {
                    rbs[i] = imageObjects[i].AddComponent<Rigidbody2D>();
                }
                rbs[i].gravityScale = 1f;
            
            StartCoroutine(SpawnRandomImages(0.3f));
        }

        if (mouseClicked)
        {
            // Di chuyển vị trí của các đối tượng theo hướng di chuyển chuột
            float moveDirection = Input.GetAxis("Mouse X");
            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
if (imageObjects[i] != null)
            {
                imageObjects[i].transform.Translate(new Vector3(moveDirection, 0, 0));
            }            }
        }
    }

    IEnumerator SpawnRandomImages(float delay)
    {
        yield return new WaitForSeconds(delay);

         for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            imageObjects[i] = Instantiate(tilePrefab, new Vector3(-0.04f, 2.61f, 0.01707233f), Quaternion.identity, transform);

            // Kiểm tra xem Rigidbody2D đã được thêm vào tilePrefab chưa
            Rigidbody2D existingRigidbody = imageObjects[i].GetComponent<Rigidbody2D>();
            if (existingRigidbody == null)
            {
                // Nếu chưa có Rigidbody2D, thêm mới vào
                Rigidbody2D rb = imageObjects[i].AddComponent<Rigidbody2D>();
                rb.gravityScale = 0;  // Đặt gravityScale thành 0 để không bị ảnh hưởng bởi gravity
            }

            int randomIndex = Random.Range(0, imageList.Count);
            Sprite randomImage = imageList[randomIndex];

            SpriteRenderer spriteRenderer = imageObjects[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = imageObjects[i].AddComponent<SpriteRenderer>();
            }
            spriteRenderer.sprite = randomImage;
        }
    }
}