using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    [SerializeField]
    Transform parent;

    [SerializeField]
    Player playerObj;

    [SerializeField]
    Enemy enemyObj;

    Player player;
    Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Instantiate(playerObj, parent);
        player.transform.localPosition = new Vector3(0, -678, 0);
        player.SetInit(parent);


        StartCoroutine(EnemyCreate(0));
    }


    IEnumerator EnemyCreate(float delay)
    {
        yield return new WaitForSeconds(delay);

        var pos = new Vector3(0, 676, 0);
        enemy = Enemy.Instantiate(enemyObj, Vector3.zero, Quaternion.identity, parent);
        enemy.transform.localPosition = pos;
        enemy.SetInit(parent , () =>
        {
            GameObject.Destroy(enemy.gameObject);
            StartCoroutine(EnemyCreate(2));
        });

        player.SetTarget(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
