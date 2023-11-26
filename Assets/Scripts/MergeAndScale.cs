using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBallAnimals : MonoBehaviour
{
    private bool isMerged = false; // Biến kiểm soát trạng thái hợp nhất

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem đã hợp nhất chưa và va chạm có liên quan đến một GameObject khác có script này không
        if (!isMerged)
        {
            MergeAndScale otherMergeScript = collision.gameObject.GetComponent<MergeAndScale>();

            if (otherMergeScript != null && IsSameSprite(otherMergeScript))
            {
                MergeAndScaleObjects(otherMergeScript);
            }
        }
    }

    private bool IsSameSprite(MergeAndScale otherMergeScript)
    {
        // So sánh sprites của hai GameObject
        SpriteRenderer thisSpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer otherSpriteRenderer = otherMergeScript.GetComponent<SpriteRenderer>();

        return thisSpriteRenderer.sprite == otherSpriteRenderer.sprite;
    }

    private void MergeAndScaleObjects(MergeAndScale otherMergeScript)
    {
        // Kết hợp hai GameObject thành một
        SpriteRenderer thisSpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer otherSpriteRenderer = otherMergeScript.GetComponent<SpriteRenderer>();

        // Thay đổi sprite thành một sprite lớn hơn
        thisSpriteRenderer.sprite = GetLargerSprite(thisSpriteRenderer.sprite);

        // Co giãn GameObject để làm cho nó lớn hơn
        transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

        // Tắt Collider để tránh va chạm tiếp theo
        GetComponent<Collider2D>().enabled = false;

        // Đánh dấu là đã hợp nhất
        isMerged = true;

        // Hủy bỏ GameObject khác
        Destroy(otherMergeScript.gameObject);
    }

    private Sprite GetLargerSprite(Sprite originalSprite)
    {
        // Đây chỉ là một phương thức tạm thời. Bạn có thể cần một logic phức tạp hơn
        // để xác định sprite lớn hơn dựa trên yêu cầu cụ thể của bạn.
        // Đối với sự đơn giản, ví dụ này chỉ trả về cùng một sprite.

        return originalSprite;
    }
}