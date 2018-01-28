using UnityEngine;
using System.Collections;

public class ArmTrigger : MonoBehaviour {

    public Transform home;


    void OnTriggerStay2D(Collider2D other)
    {
        if(other)
            transform.Find("target").position = Vector2.Lerp(transform.Find("target").position, other.transform.position,.1f);
        else
            transform.Find("target").position = Vector2.Lerp(transform.Find("target").position, home.position, .1f);
    }
    
    void Update()
    {
      
    }




}
