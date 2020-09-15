using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator PlayerAnim;
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Transform>().Translate(new Vector3(0f,0.01f,0f));
            PlayerAnim.SetBool("UpKey",true);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Transform>().Translate(new Vector3(0f,-0.01f,0f));
            PlayerAnim.SetBool("DownKey",true);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().Translate(new Vector3(0.01f,0f,0f));
            PlayerAnim.SetBool("RightKey",true);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Transform>().Translate(new Vector3(-0.01f,0f,0f));
            PlayerAnim.SetBool("LeftKey",true);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            PlayerAnim.SetBool("UpKey",false);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            PlayerAnim.SetBool("DownKey",false);
        }
    }
}
