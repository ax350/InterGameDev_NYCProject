using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator PlayerAnim;
    private float speed;
    Boolean tmp_moving_flag = false;
    public Boolean oncollision = false;
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        speed = GameManager.Singleton.player_speed;
    }

    // Update is called once per frame
    void Update()
    {
        float tmp_sp = speed;
        
        if (tmp_moving_flag && Input.GetKey(KeyCode.LeftShift))
        {
            tmp_sp += tmp_sp;
            PlayerAnim.SetBool("Run", true);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            tmp_moving_flag = true;
            GetComponent<Transform>().Translate(new Vector3(0f,tmp_sp,0f));
            PlayerAnim.SetBool("UpKey",true);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            tmp_moving_flag = true;
            GetComponent<Transform>().Translate(new Vector3(0f,-tmp_sp,0f));
            PlayerAnim.SetBool("DownKey",true);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            tmp_moving_flag = true;
            GetComponent<Transform>().Translate(new Vector3(tmp_sp, 0f, 0f));
            PlayerAnim.SetBool("RightKey", true);
            if (PlayerAnim.GetBool("Run") && GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if(!PlayerAnim.GetBool("Run"))
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            tmp_moving_flag = true;
            GetComponent<Transform>().Translate(new Vector3(-tmp_sp, 0f, 0f));
            PlayerAnim.SetBool("LeftKey", true);
            if (PlayerAnim.GetBool("Run") && GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(!PlayerAnim.GetBool("Run"))
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            PlayerAnim.SetBool("UpKey",false);
            PlayerAnim.SetBool("Run", false);
            tmp_moving_flag = false;
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            PlayerAnim.SetBool("DownKey",false);
            PlayerAnim.SetBool("Run", false);
            tmp_moving_flag = false;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerAnim.SetBool("RightKey",false);
            PlayerAnim.SetBool("Run", false);
            tmp_moving_flag = false;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PlayerAnim.SetBool("LeftKey",false);
            PlayerAnim.SetBool("Run", false);
            tmp_moving_flag = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerAnim.SetBool("Run", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        oncollision = true;
        Debug.Log(collision.collider.name.Substring(0, 4));
        if (collision.collider.name.Substring(0, 4) == "Coin")
        {
            GameManager.Singleton.coin_count++;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        oncollision = false;
    }
}
