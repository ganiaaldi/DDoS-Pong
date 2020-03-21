using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusController : MonoBehaviour
{
   public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    GameObject panelFinish;
    Text txWinner;
 
    // Use this for initialization    
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 direct = new Vector2(2, 0).normalized;
        rigid.AddForce(direct * force);    
         scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find ("Score1").GetComponent<Text> ();
        scoreUIP2 = GameObject.Find ("Score2").GetComponent<Text> ();
         panelFinish = GameObject.Find("Finish");
        panelFinish.SetActive(false);
    }
  
    // Update is called once per frame
    void Update () {
 
    }
 
    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == "Rightside") {
            scoreP1 += 1;
            TampilkanScore ();
            if (scoreP1 == 5) {
                panelFinish.SetActive(true);
                txWinner = GameObject.Find("Winner").GetComponent<Text>();
                txWinner.text = "Whitehat Winner!";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 direct = new Vector2(2, 0).normalized;
            rigid.AddForce(direct * force);
        }
        if (coll.gameObject.name == "Leftside") {
             scoreP2 += 1;
             TampilkanScore ();
             if (scoreP2 == 5) {
                panelFinish.SetActive(true);
                txWinner = GameObject.Find("Winner").GetComponent<Text>();
                txWinner.text = "Blackhat Winner!";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 direct = new Vector2(-2, 0).normalized;
            rigid.AddForce(direct * force);
        }
        if (coll.gameObject.name == "whitehat" || coll.gameObject.name == "blackhat") {
            float corner = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 direct = new Vector2(rigid.velocity.x, corner).normalized;
            rigid.velocity = new Vector2(0, 0);    
            rigid.AddForce(direct * force * 2);
        }
    }
 
    void ResetBall() {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

     void TampilkanScore () {
        Debug.Log ("Score White Hat: " + scoreP1 + " Score Blackhat: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }
}
