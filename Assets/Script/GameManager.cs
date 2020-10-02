using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public float player_speed;

    public int coin_count;
    public GameObject coins;
    public GameObject player;
    public GameObject camera;
    public GameObject UI_coin;

    Boolean camera_zoom = true;
    private Vector3 camera_original_pos;

    public bool mainSceneLoaded = false;
    Boolean manual_start = false;

    private void Awake()
    {
        if (Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }        
    }

    // Start is called before the first frame update
    void Start()
    {

        if (mainSceneLoaded)
        {
            coin_count = 0;
            camera_original_pos = camera.GetComponent<Transform>().transform.position;
            Debug.Log(camera_original_pos);
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log("0");
                camera.GetComponent<Transform>().transform.position = new Vector3(
                    player.GetComponent<Transform>().transform.position.x,
                    player.GetComponent<Transform>().transform.position.y,
                    camera.GetComponent<Transform>().transform.position.z);
                camera.GetComponent<Camera>().orthographicSize = 1;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (mainSceneLoaded && !manual_start)
        {  
            manual_start = true;
            coin_count = 0;
            camera_original_pos = camera.GetComponent<Transform>().transform.position;
            Debug.Log(camera_original_pos);
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log("0");
                camera.GetComponent<Transform>().transform.position = new Vector3(
                    player.GetComponent<Transform>().transform.position.x,
                    player.GetComponent<Transform>().transform.position.y,
                    camera.GetComponent<Transform>().transform.position.z);
                camera.GetComponent<Camera>().orthographicSize = 1;
            }
        }

        if (mainSceneLoaded)
        {

         //   if (SceneManager.GetActiveScene().buildIndex == 1) //you don't need this!
          //  {
                if (camera_zoom)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log("1");
                        camera.GetComponent<Transform>().transform.position = camera_original_pos;
                        camera.GetComponent<Camera>().orthographicSize = 5;
                        camera_zoom = false;
                    }
                    else
                    {
                        Debug.Log("2");
                        camera.GetComponent<Transform>().transform.position = new Vector3(
                        player.GetComponent<Transform>().transform.position.x,
                        player.GetComponent<Transform>().transform.position.y,
                        camera.GetComponent<Transform>().transform.position.z);
                    }
                }
                else if (!camera_zoom)
                {
                    if (!Input.GetKey(KeyCode.Space))
                    {
                    Debug.Log("3");
                        camera_zoom = true;
                        camera.GetComponent<Transform>().transform.position = new Vector3(
                            player.GetComponent<Transform>().transform.position.x,
                            player.GetComponent<Transform>().transform.position.y,
                            camera.GetComponent<Transform>().transform.position.z);
                        camera.GetComponent<Camera>().orthographicSize = 1;
                    }
                }
            //}

            if (player.GetComponent<PlayerControl>().oncollision)
            {
                UI_coin.GetComponent<TextMeshProUGUI>().text = "Coin: " + coin_count;
            }
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    
}
