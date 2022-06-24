using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float Hp;
    public float Max_Hp;
    public GameObject ragdoll;
    public GameObject hp_line;
    [SerializeField]
    private GameObject hair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void change_hp()
    {
        hp_line.transform.GetChild(0).GetComponent<Image>().fillAmount = Hp / Max_Hp;
        hp_line.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + Hp + "/" + Max_Hp;
        if (Hp <= 0)
        {
            hair.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            hp_line.SetActive(false);
        }
    }
}
