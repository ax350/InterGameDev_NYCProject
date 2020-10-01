using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour
{

    public GameObject coins;
    public GameObject player;
    public GameObject camera;
    public GameObject UI_coin;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Singleton.mainSceneLoaded = true;
        GameManager.Singleton.coins = this.coins;
        GameManager.Singleton.camera = this.camera;
        GameManager.Singleton.player = this.player;
        GameManager.Singleton.UI_coin = this.UI_coin;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
