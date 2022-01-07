using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Rigidbody2D PlayerRB;

    public Vector3 leftFource = new Vector3(-4,0,0);
    public Vector3 rightForce = new Vector3(4,0,0);
    public Vector3 upForce = new Vector3(0, -2, 0);
    public Vector3 downForce = new Vector3(0, 2, 0);
    public Text txtScore;
    public float Score = 00;
    private AudioSource Audiosou;
    public float ForceMultiplier = 100;

    // Start is called before the first frame update
    void Start()
    {
        Audiosou = GetComponent<AudioSource>();
        txtScore.text = (Score.ToString());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            JumpLeft();
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            JumpRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            JumpUp();

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            JumpDown();
        }
    }
    public void JumpRight()
    {
        PlayerRB.velocity = Vector3.zero;
        PlayerRB.AddForce(rightForce * ForceMultiplier);
        Audiosou.Play();
    }
    public void JumpLeft()
    {
        PlayerRB.velocity = Vector3.zero;
        PlayerRB.AddForce(leftFource * ForceMultiplier);
        Audiosou.Play();
    }
    public void JumpUp()
    {
        PlayerRB.velocity = Vector3.zero;
        PlayerRB.AddForce(upForce * ForceMultiplier);
        Audiosou.Play();
    }
    public void JumpDown()
    {
        PlayerRB.velocity = Vector3.zero;
        PlayerRB.AddForce(downForce * ForceMultiplier);
        Audiosou.Play();
    }
    public void IncreseScore()
    {
        Score = Score + 1;
        // Debug.log(Score);

        txtScore.text = (Score.ToString());
    }
       
    public void resetScore()
    {
        Score = 0;
        txtScore.text = "0";

    }
    private void OnCollisionEnter2D(Collision2D CollisionTemp)
    {
        if (CollisionTemp.gameObject.CompareTag("colletible"))
        {
            if(CollisionTemp.gameObject.GetComponent<colletible>().onCollect() == false)
            {
                IncreseScore();
            }
           
        }
    }
}
