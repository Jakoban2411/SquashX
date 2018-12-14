using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour {
    [SerializeField] AudioClip crunchsound;
    bool bSoundPlayed = false;
    [SerializeField] int PointsToAdd = 10;
    BlockCount blockCount;
    ParticleSystem ThanosSnap;
    Animator ScaleDown;
    Sprite particlesprite;
    int i = 150,j=0;
    public GameObject ParticleEffectObject;
    // Use this for initialization
    void Start ()
    {
        ScaleDown = GetComponent<Animator>();
        GameObject CreatedPrefab=Instantiate(ParticleEffectObject, transform.position, transform.rotation);
        ThanosSnap=CreatedPrefab.GetComponent<ParticleSystem>();
        blockCount = FindObjectOfType<BlockCount>();
        blockCount.IncBlockNo();
        SpriteRenderer something =GetComponent<SpriteRenderer>();
        particlesprite=something.sprite;
        ThanosSnap.textureSheetAnimation.SetSprite(0, particlesprite);
        
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (ScaleDown)
            ScaleDown.enabled = true;
        if (!bSoundPlayed)
        {
            AudioSource.PlayClipAtPoint(crunchsound, Camera.main.transform.position);
            bSoundPlayed = true;
        }
        blockCount.AddToScore(PointsToAdd);
        
        ScaleDown.Play("Shrink");
       // Destroy(gameObject,crunchsound.length);
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
        if (j == i)
        {
            if (ScaleDown)
            {
                ScaleDown.enabled = true; ScaleDown.Play("Shrink");

                //ScaleDown.SetBool("Shrink", true);
            }
            Debug.Log("Anumation shouldve startetd");
        }
            j++;
        Debug.Log("J=" + j);
        
    }
}
