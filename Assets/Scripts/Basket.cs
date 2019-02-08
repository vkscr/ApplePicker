using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");               
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;                             
                                                                             
        mousePos2D.z = -Camera.main.transform.position.z;                    
                                                                            
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);    
                                                                            
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
    void OnCollisionEnter(Collision coll)
    {                        
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;                   
        if (collidedWith.tag == "Apple")
        {                        
            Destroy(collidedWith);
        }

        // Parse the text of the scoreGT into an int
        int score = int.Parse(scoreGT.text);                          
                                                                     
        score += 100;
        // Convert the score back to a string and display it
        scoreGT.text = score.ToString();

        if (score > HighScore.score)
        {
            HighScore.score = score;
        }

    }

}
