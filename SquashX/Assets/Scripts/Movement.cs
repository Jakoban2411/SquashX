using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float movementscale;
    float dist;
    float leftBorder;
    float rightBorder ;
    // Use this for initialization
    void Start () {
        dist = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<BlockCount>().isAutoplay())
        {
            float DockPosition = FindObjectOfType<BallProperties>().transform.position.x;
            transform.position = new Vector3(DockPosition, transform.position.y,transform.position.z);
        }
        else
        {
            float val = Input.GetAxis("Horizontal");
            //float displacementx = val * Time.deltaTime;
            Vector3 position = transform.position;
            Vector2 newposition = new Vector2(val, 0);
            newposition *= Time.deltaTime;
            //transform.Translate(newposition * movementscalWe);
            float xpos = Mathf.Clamp(transform.position.x+newposition.x * movementscale,leftBorder+.8f,rightBorder-.8f);
            transform.position = new Vector3(xpos, transform.position.y, transform.position.z);            
        }
    }
}
