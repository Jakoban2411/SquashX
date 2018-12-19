using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProperties : MonoBehaviour
{
    public int randomvelocityfactor;
    [SerializeField] Movement P1Dock;
    [SerializeField] AudioClip StartBounce;
    [SerializeField] AudioClip[] OnCollisionClip;
    bool bHasFired, bSoundPlayed;
    //bool bLaunched;
    Vector2 LaunchVelocity;
    Rigidbody2D ballrigidbody2d;
    [SerializeField] float speedy;
    [SerializeField] float speedx;
    AudioSource Source;
    Vector2 PaddleDistance;
    //float PaddleDistance;
    //Use this for initialization

    IEnumerator PlayAndChange()
    {
        //if (!bSoundPlayed)
       // {
            Source.PlayOneShot(Source.clip);
            bSoundPlayed = true;
       // }
        yield return new WaitForSeconds(Source.clip.length);
        bSoundPlayed = false;
        Source.clip = OnCollisionClip[UnityEngine.Random.Range(0,OnCollisionClip.Length)];

    }
    void Start()
    {
        ballrigidbody2d = GetComponent<Rigidbody2D>();
        PaddleDistance = transform.position - P1Dock.transform.position;
        bHasFired = false;
        //  bLaunched = false;
        Source = GetComponent<AudioSource>();
        bSoundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Updated");
        if (!bHasFired)
        {
            LockToDock();
            LaunchOnPress();
        }
        /*FirePendInput();
        if (bHasFired == false )//&& !bLaunched)
        {
            bLaunched = true;
            Debug.Log("Fired!");
            LaunchVelocity = new Vector2(speedx, speedy);
            GetComponent<Rigidbody2D>().velocity = LaunchVelocity;
        }*/

    }

    private void LaunchOnPress()
    {
        if (Input.GetButton("Fire1"))
        {
            bHasFired = true;
            Source.clip = StartBounce;
            StartCoroutine(PlayAndChange());
            LaunchVelocity = new Vector2(speedx, speedy);
            GetComponent<Rigidbody2D>().velocity = LaunchVelocity;
        }
    }

    public void LockToDock()
    {/*
       
        if (bHasFired == false)
        {*/

        bHasFired = false;
        Vector2 Docklocation = new Vector2(P1Dock.transform.position.x, P1Dock.transform.position.y);
        transform.position = Docklocation + PaddleDistance;
        // }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityadd = new Vector2(UnityEngine.Random.Range(0, randomvelocityfactor), UnityEngine.Random.Range(0, randomvelocityfactor));
        if (bHasFired && !bSoundPlayed)
        {
            StartCoroutine(PlayAndChange());
            bSoundPlayed = true;
            ballrigidbody2d.velocity += velocityadd;
        }
    }
}
