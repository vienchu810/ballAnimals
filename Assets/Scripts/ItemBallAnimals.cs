using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeAndScale : MonoBehaviour
{
  private bool isMerged = false; // Biến kiểm soát trạng thái hợp nhất

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isMerged)
        {
            // Kiểm tra xem va chạm có Collider không
            Collider2D otherCollider = collision.collider;
            if (otherCollider != null)
            {
                MergeAndScale otherMergeScript = otherCollider.GetComponent<MergeAndScale>();
                if (otherMergeScript != null && IsSameSprite(otherMergeScript))
                {
                    MergeAndScaleObjects(otherMergeScript);
                }
            }
        }
    }

    private bool IsSameSprite(MergeAndScale otherMergeScript)
    {
        SpriteRenderer thisSpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer otherSpriteRenderer = otherMergeScript.GetComponent<SpriteRenderer>();

        return thisSpriteRenderer.sprite == otherSpriteRenderer.sprite;
    }

    private void MergeAndScaleObjects(MergeAndScale otherMergeScript)
    {
        if (!isMerged)
        {
            // Kết hợp hai GameObject thành một
            SpriteRenderer thisSpriteRenderer = GetComponent<SpriteRenderer>();
            SpriteRenderer otherSpriteRenderer = otherMergeScript.GetComponent<SpriteRenderer>();

            // Thay đổi sprite thành một sprite lớn hơn
            thisSpriteRenderer.sprite = GetLargerSprite(thisSpriteRenderer.sprite);

            // Co giãn GameObject để làm cho nó lớn hơn
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

            // Đánh dấu là đã hợp nhất
            isMerged = true;

            // Hủy GameObject của đối tượng khác
            
            Destroy(otherMergeScript.gameObject);

            // Tạo một đối tượng mới để thay thế
            InstantiateNewObject();
        }
    }

    private void InstantiateNewObject()
    {
        // Tạo một đối tượng mới tại vị trí và với quay ban đầu tương tự đối tượng hiện tại
        GameObject newObject = Instantiate(gameObject, transform.position, transform.rotation);

        // Reset trạng thái hợp nhất của đối tượng mới
        MergeAndScale newMergeScript = newObject.GetComponent<MergeAndScale>();
        if (newMergeScript != null)
        {
            newMergeScript.isMerged = false;
        }
    }

    private Sprite GetLargerSprite(Sprite originalSprite)
    {
        // Đây chỉ là một phương thức tạm thời. Bạn có thể cần một logic phức tạp hơn
        // để xác định sprite lớn hơn dựa trên yêu cầu cụ thể của bạn.
        // Đối với sự đơn giản, ví dụ này chỉ trả về cùng một sprite.
        return originalSprite;
    }
}