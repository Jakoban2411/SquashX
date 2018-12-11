using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour {
    [SerializeField] AudioClip crunchsound;
    bool bSoundPlayed = false;
    BlockCount blockCount;
    // Use this for initialization
    void Start () {
        blockCount = FindObjectOfType<BlockCount>();
        blockCount.IncBlockNo();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (!bSoundPlayed)
        {
            AudioSource.PlayClipAtPoint(crunchsound, Camera.main.transform.position);
            bSoundPlayed = true;
        }
        GetComponent<ParticleSystem>().Play();
        Destroy(gameObject,2.0f);
        blockCount.DecBlock();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
