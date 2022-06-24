using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Slider progress_slider;
    public Map _map;
    public Character _character;
    private float max_distance;
    private float player_distance;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        for(int a = 1; a < _map.all_points.Length; a++)
        {
            Vector3 pos_1 = new Vector3(_map.all_points[a - 1].WayPoint.transform.position.x, _map.all_points[a - 1].WayPoint.transform.position.y, _map.all_points[a - 1].WayPoint.transform.position.z);
            Vector3 pos_2 = new Vector3(_map.all_points[a].WayPoint.transform.position.x, _map.all_points[a].WayPoint.transform.position.y, _map.all_points[a].WayPoint.transform.position.z);
            max_distance += Vector3.Distance(pos_1, pos_2);
        }

        progress_slider.maxValue = max_distance;
    }

    // Update is called once per frame
    void Update()
    {
        player_distance = 0;
        for (int a = 1; a <= _character.number_point; a++)
        {
            Vector3 pos_1 = new Vector3(_map.all_points[a - 1].WayPoint.transform.position.x, _map.all_points[a - 1].WayPoint.transform.position.y, _map.all_points[a - 1].WayPoint.transform.position.z);
            Vector3 pos_2 = new Vector3(_map.all_points[a].WayPoint.transform.position.x, _map.all_points[a].WayPoint.transform.position.y, _map.all_points[a].WayPoint.transform.position.z);
            player_distance += Vector3.Distance(pos_1, pos_2);
        }

        Vector3 pos_my = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 pos_next = new Vector3(_map.all_points[_character.number_point].WayPoint.transform.position.x, _map.all_points[_character.number_point].WayPoint.transform.position.y, _map.all_points[_character.number_point].WayPoint.transform.position.z);
        player_distance += Vector3.Distance(pos_my, pos_next);

        progress_slider.value = player_distance;
    }
}
