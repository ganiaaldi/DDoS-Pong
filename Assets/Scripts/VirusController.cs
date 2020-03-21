using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
   public int force;
    Rigidbody2D rigid;
 
    // Use this for initialization    
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 direct = new Vector2(2, 0).normalized;
        rigid.AddForce(direct * force);    
    }
  
    // Update is called once per frame
    void Update () {
 
    }
 
    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == "Rightside") {
            ResetBall();
            Vector2 direct = new Vector2(2, 0).normalized;
            rigid.AddForce(direct * force);
        }
        if (coll.gameObject.name == "Leftside") {
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
}
