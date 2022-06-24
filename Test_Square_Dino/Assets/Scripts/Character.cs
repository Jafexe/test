using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Character : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    
    public int number_point;
    public Map _map;
    public bool start_game = false;
    [SerializeField]
    private float speed_rotate;
    [SerializeField]
    private UI_Buttons Interface;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        (bool have_enemy, int? id_enemy) = _map.CheckEnemyOnPoint(number_point);
        if (number_point + 1 < _map.all_points.Length && have_enemy == false && start_game == true)
        {
            Vector3 pos_player = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 pos_point = new Vector3(_map.all_points[number_point + 1].WayPoint.position.x, _map.all_points[number_point + 1].WayPoint.position.y, _map.all_points[number_point + 1].WayPoint.position.z);
            agent.SetDestination(pos_point);
            animator.SetBool("run", true);
            float distance = Vector3.Distance(pos_player, pos_point);

            if (distance < 0.1) number_point++;
        }
        else
        {
            animator.SetBool("run", false);
            if (id_enemy != null)
            {
                var targetRoration = Quaternion.LookRotation(_map.all_points[number_point].enemies[(int)id_enemy].gameObject.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRoration, speed_rotate * Time.deltaTime);
            }
            if(number_point + 1 >= _map.all_points.Length && have_enemy == false)
            {
                Interface.Compleate();
            }
           // if(id_enemy != null) gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, _map.all_points[number_point].enemies[(int)id_enemy].gameObject.transform.rotation, Time.deltaTime * speed_rotate);


        }
    }
}
