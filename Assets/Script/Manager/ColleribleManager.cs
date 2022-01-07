using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColleribleManager : MonoBehaviour
{
    public static ColleribleManager instance;
    public colletible ColletiblePreFab;
    public float ypos;
    public float minx;
    public float maxx;
    public float delayTime = 3;
    public float timeIncrese = 1;
    public Button replyButton;
    public player myplayer;
    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        colletibleGenerate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void colletibleGenerate()
    {
        StartCoroutine(generateColletiable());
    }
    IEnumerator generateColletiable()
    {
        while (true)
        {
            if((timeIncrese % 15 == 0 ))
            {
                timeIncrese = 1;
                if (delayTime > 1)
                {
                    delayTime = delayTime - 1;
                }
            }
            timeIncrese = timeIncrese + delayTime;
            yield return new WaitForSeconds(delayTime);
            
            var collectiable = Instantiate(ColletiblePreFab, transform);
            var randPos = Random.Range(minx, maxx);
            var generatedPos = new Vector3(randPos, ypos, 0);
            collectiable.transform.position = generatedPos;
        }
    }

    public void Replay()
    {
        for(int i = transform.childCount - 1; i>=0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);

        }
        myplayer.resetScore();
        
        replyButton.gameObject.SetActive(false);
        generateColletiable();


    }

    public void GameOver()
    {
        StopAllCoroutines();
        replyButton.gameObject.SetActive(true);
    }
}
