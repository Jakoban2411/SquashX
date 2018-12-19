using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour {
    [SerializeField] AudioClip crunchsound;
    bool bSoundPlayed = false;
    [SerializeField] int PointsToAdd = 10;
    BlockCount blockCount;
    ParticleSystem ThanosSnap;
    int Hitsmade;
    Animator ScaleDown;
    [SerializeField] Sprite[] Hitsprites;
    SpriteRenderer SpriteRenderer;
    int HitReq;
    Sprite particlesprite;
    public GameObject ParticleEffectObject;
    GameObject CreatedPrefab;
    // Use this for initialization
    void Start ()
    {
        SpriteRenderer=GetComponent<SpriteRenderer>();
        ScaleDown = GetComponent<Animator>();
        CreatedPrefab=Instantiate(ParticleEffectObject, transform.position, transform.rotation);
        ThanosSnap=CreatedPrefab.GetComponent<ParticleSystem>();
        blockCount = FindObjectOfType<BlockCount>();
        blockCount.IncBlockNo();
        SpriteRenderer something =GetComponent<SpriteRenderer>();
        particlesprite=something.sprite;
        ThanosSnap.textureSheetAnimation.SetSprite(0, particlesprite);
        Hitsmade = 0;
        HitReq = Hitsprites.Length + 1;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {

        Hitsmade++;
        if (!bSoundPlayed)
        {
            AudioSource.PlayClipAtPoint(crunchsound, Camera.main.transform.position);
            bSoundPlayed = true;
        }
        blockCount.AddToScore(5);
        if (Hitsmade == HitReq)
        {
            if (ScaleDown)
                ScaleDown.enabled = true;

            blockCount.AddToScore(PointsToAdd);
            if (ThanosSnap)
                ThanosSnap.Play();
            if (ScaleDown)
                ScaleDown.Play("Shrink");
            Destroy(gameObject, 2);
        }
        else
        {   if(Hitsmade<HitReq)
            SpriteRenderer.sprite = Hitsprites[Hitsmade - 1];
        }
    }
    private void OnDestroy()
    {
        
        blockCount.DecBlock();
        Destroy(CreatedPrefab, 5);

    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
