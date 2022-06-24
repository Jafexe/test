using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public void ReturnToPool()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.SetActive(false);
    }
}
