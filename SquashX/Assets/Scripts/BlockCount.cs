using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCount : MonoBehaviour {
    public int BlockNo = 0;
    // Use this for initialization
    void Start() {

    }
    public void IncBlockNo()
    {
        BlockNo++;
        Debug.Log("I WAS CALLED: "+ BlockNo);
    }
    public void DecBlock()
    {
        BlockNo--;
        if(BlockNo==0)
        {
            Debug.Log("Ok,THiS iS EpIC!");
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
