using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameManager.dashBarValue <= .66f)
            {
                gameManager.dashBarValue += .33f;
            }
            else if (gameManager.dashBarValue > .66f)
            {
                gameManager.dashBarValue = 1;
            }
            Destroy(this);
        }
    }
}
