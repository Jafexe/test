using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class Bullet : MonoBehaviour
{
    private float life_time = 2;
    private PoolObject _poolObject;
    [SerializeField]
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        _poolObject = GetComponent<PoolObject>();
    }

    void Update()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(life_time);
        _poolObject.ReturnToPool();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Hp -= damage;
            collision.gameObject.GetComponent<Enemy>().change_hp();

        }
        else if(collision.gameObject.tag == "Props")
        {
            collision.gameObject.SetActive(false);
        }
        _poolObject.ReturnToPool();
    }
}
