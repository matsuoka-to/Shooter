using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Bullet bullet;

    [SerializeField]
    Missile missileObj;

    Transform parent;
    Enemy target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetInit(Transform parent)
    {
        this.parent = parent;
    }

    public void SetTarget(Enemy target)
    {
        this.target = target;
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        var move = new Vector3(moveX, moveY, 0).normalized;
        transform.position += move * moveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation, parent);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(target == null)
            {
                return;
            }
            var missile = Instantiate(missileObj, transform.position, transform.rotation, parent);
            missile.SetTarget(target.transform);
        }
    }
}
