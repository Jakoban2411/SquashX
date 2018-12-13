using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour {
    [SerializeField] AudioClip crunchsound;
    bool bSoundPlayed = false;
    [SerializeField] int PointsToAdd = 10;
    BlockCount blockCount;
    ParticleSystem ThanosSnap;
    Sprite particlesprite;
    public GameObject ParticleEffectObject;
    // Use this for initialization
    void Start ()
    {
        GameObject CreatedPrefab=Instantiate(ParticleEffectObject, transform.position, transform.rotation);
        ThanosSnap=CreatedPrefab.GetComponent<ParticleSystem>();
        blockCount = FindObjectOfType<BlockCount>();
        blockCount.IncBlockNo();
        SpriteRenderer something=GetComponent<SpriteRenderer>();
        particlesprite=something.sprite;
        ThanosSnap.textureSheetAnimation.SetSprite(0, particlesprite);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (!bSoundPlayed)
        {
            AudioSource.PlayClipAtPoint(crunchsound, Camera.main.transform.position);
            bSoundPlayed = true;
        }
        blockCount.AddToScore(PointsToAdd);
        Destroy(gameObject,crunchsound.length);
    }
    private void OnDestroy()
    {
        if(ThanosSnap)
        ThanosSnap.Play();
        blockCount.DecBlock();
        //Destroy(ParticleEffectObject, 5);
        

    }
    // Update is called once per frame
    void Update()
    {
    }
}
