using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float ScreenExit = -.80f;
    [SerializeField] float ScreenEntry = 18.625f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float val = Input.GetAxis("Horizontal");
        //float displacementx = val * Time.deltaTime;
        Vector3 position = transform.position;
        Vector2 newposition = new Vector2(val, 0);
        newposition *= Time.deltaTime;
        if (transform.position.x <= ScreenExit)
        {
            transform.position=new Vector3(ScreenEntry, position.y,-1);
            Debug.Log("Yup!");
        }
        else
        {
            if (transform.position.x >= ScreenEntry)
                transform.position = new Vector3(ScreenExit, position.y,-1);
        }
        transform.Translate(newposition*5);
    }
}
