using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBallTrigger : MonoBehaviour {
    [SerializeField]int Lives;
    [SerializeField] BallProperties TesticularCancer;
    // Use this for initialization
	void Start () {
    
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Lives--;
        TesticularCancer.LockToDock();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
