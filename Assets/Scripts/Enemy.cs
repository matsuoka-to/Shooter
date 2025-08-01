using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    Hit hit;

    Transform parent;
    Action callback;
    bool isDead;

    public void SetInit(Transform parent, Action callback)
    {
        this.parent = parent;
        this.callback = callback;

        isDead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead)
        {
            return;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            isDead = true;
            image.enabled = false;
            var obj = Instantiate(hit, transform.position, transform.rotation, parent);
            obj.Play(() =>
            {
                callback?.Invoke();
                Destroy(gameObject);
            });
        }
    }
}
