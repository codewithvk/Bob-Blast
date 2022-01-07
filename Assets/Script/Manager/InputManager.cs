using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public player plr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLeftInput()
    {
        plr.JumpLeft();
    }
    public void OnRightInput()
    {
        plr.JumpRight();

    }
    public void OnUpInput()
    {
        plr.JumpUp();

    }
    public void OnDownInput()
    {
        plr.JumpDown();

    }
}
