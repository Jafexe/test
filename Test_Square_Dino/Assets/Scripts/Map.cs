using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Points[] all_points = new Points[1];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public (bool have_enemy, int? id_enemy) CheckEnemyOnPoint(int number_point)
    {
        for(int a = 0; a < all_points[number_point].enemies.Length; a++)
        {
            if (all_points[number_point].enemies[a].Hp > 0) return(true, a); 
        }
        return (false, null);
    }


    [System.Serializable]
    public class Points
    {
        public Transform WayPoint;
        public Enemy[] enemies = new Enemy[1];
    }
}



