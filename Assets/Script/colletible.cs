using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colletible : MonoBehaviour
{
    public bool canBeCollected = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool onCollect()
    {
        if (!canBeCollected) return true;
        else {
            Destroy(gameObject);
            return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D CollisionTemp)
    {
        if (CollisionTemp.gameObject.CompareTag("Boundary") || CollisionTemp.gameObject.CompareTag("colletible"))
        {
            canBeCollected = false;
            gameObject.layer = LayerMask.NameToLayer("obstacle");
        }
        if (CollisionTemp.gameObject.layer == LayerMask.NameToLayer("topcolider"))
        {
            ColleribleManager.instance.GameOver();

        }
    }
}
