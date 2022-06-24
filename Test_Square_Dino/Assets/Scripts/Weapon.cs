using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class Weapon : MonoBehaviour
{
    private Vector3 mousePosClick;
    public Map _map;
    private Character _character;
    private Pool _pool;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        _pool = GetComponent<Pool>();
        _character = transform.parent.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _map.CheckEnemyOnPoint(_character.number_point).have_enemy == true)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                mousePosClick = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                gameObject.transform.LookAt(mousePosClick);
                var element = _pool.GetFreeElement();
                element.transform.position = transform.position;
                element.transform.rotation = transform.rotation;
                element.transform.GetComponent<Rigidbody>().isKinematic = false;
                element.transform.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
            }
        }

    }
}

