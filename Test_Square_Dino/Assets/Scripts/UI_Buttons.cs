using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Buttons : MonoBehaviour
{
    public Character _character;
    public GameObject Text_TapToPlay;
    public GameObject but_play;
    public GameObject Text_Compleate;
    public GameObject progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button_play()
    {
        if (Text_Compleate.activeSelf)
        {
            Application.LoadLevel(0);
        }
        else
        {
            _character.start_game = true;
            Text_TapToPlay.SetActive(false);
            but_play.SetActive(false);
        }
    }

    public void Compleate()
    {
        Text_Compleate.SetActive(true);
        Text_TapToPlay.SetActive(false);
        progress.SetActive(false);
        but_play.SetActive(true);

    }
}
