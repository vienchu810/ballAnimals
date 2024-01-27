using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImageContainerScript : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    public int numberOfObjectsToSpawn = 10;
    public GameObject tilePrefab;

    private GameObject imageObject;
    public Rigidbody2D rb;
    private bool mouseClicked = false;

    void Start()
    {
        StartCoroutine(SpawnPrefabs(0f));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClicked = true;
            if (imageObject != null)
            {
                rb = imageObject.GetComponent<Rigidbody2D>();
                if (rb == null)
                {
                    rb = imageObject.AddComponent<Rigidbody2D>();
                }

                rb.gravityScale = 1f;
                StartCoroutine(SpawnPrefabs(0.3f));
            }
        }
    }


    IEnumerator SpawnPrefabs(float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Chọn một prefab ngẫu nhiên từ danh sách
            GameObject selectedPrefab = prefabList[Random.Range(0, prefabList.Count)];
 UnityEngine.Debug.Log("selectedPrefab "+ selectedPrefab);
  UnityEngine.Debug.Log("tilePrefab "+ imageObject);
            // Kiểm tra xem tên của selectedPrefab (loại bỏ phần "(Clone)") có giống với tên của tilePrefab hay không
            if (PrefabNamesEqual(selectedPrefab, tilePrefab))
            {
               UnityEngine.Debug.Log("vacham");
            }else{
                UnityEngine.Debug.Log("ko va");
            }

            // Sử dụng prefab đã chọn thay vì tạo mới từ tilePrefab
            imageObject = Instantiate(selectedPrefab, new Vector3(-0.04f, 2.61f, 0.01707233f), Quaternion.identity, transform);

            SpriteRenderer spriteRenderer = imageObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = imageObject.AddComponent<SpriteRenderer>();
            }

            // Thay đổi SpriteRenderer nếu cần
        }
    }

    // Hàm kiểm tra xem hai prefab có tên giống nhau hay không (bỏ phần "(Clone)")
    bool PrefabNamesEqual(GameObject prefab1, GameObject prefab2)
    {
        string name1 = RemoveCloneSuffix(prefab1.name);
        string name2 = RemoveCloneSuffix(prefab2.name);
          UnityEngine.Debug.Log(""+ name1 +"____"+ "  "+ name2);
        return name1 == name2;
    }

    // Hàm loại bỏ phần "(Clone)" từ tên prefab
    string RemoveCloneSuffix(string name)
    {
        if (name.EndsWith("(Clone)"))
        {
            return name.Substring(0, name.Length - "(Clone)".Length);
        }
        return name;
    }
}
