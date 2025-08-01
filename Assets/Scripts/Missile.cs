using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;

    [SerializeField]
    float rotSpeed = 200.0f;

    Transform target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("UI"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        // ターゲットの方向を取得
        var direction = target.position - transform.position;
        direction.Normalize();

        // 角度を取得する
        var rot = Vector3.Cross(direction, transform.up).z;

        // 回転処理
        transform.Rotate(0, 0, -rot * rotSpeed * Time.deltaTime);

        // 前方向に進む
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
    }
}
