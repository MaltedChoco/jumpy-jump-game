using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.InputSystem;

public class PlayerControllerLegacy : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip landingNoise;
    public ContactFilter2D ContactFilter;
    public ContactFilter2D DieFilter;
    public bool IsGrounded => GetComponent<Rigidbody2D>().IsTouching(ContactFilter);
    private int debounce = 0;
    private int jumpTicker = 0;
    private bool readyForAJump = false;
    public bool inHell = false;

    public SideColliderLegacy LeftCollider;
    public SideColliderLegacy RightCollider;

    public float moveSpeed = 10;
    public bool IsDie => GetComponent<Rigidbody2D>().IsTouching(DieFilter);
    public Vector3 spawn;
    public StoryControllerLegacy story;

    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        audioSource = GetComponent<AudioSource>();
        spawn = transform.position;
        story.TypewriterText("The Skyhops");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsGrounded)
        {
            jumpTicker++;
        }
        if (Input.GetKey(KeyCode.D)) {
             GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveSpeed, 0));
        }
        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            if (debounce > 0)
            {
                debounce--;
            } else
            {
                int directionX = 0;
                if (LeftCollider.mapCollide)
                {
                    directionX += 200;
                }
                if (RightCollider.mapCollide)
                {
                    directionX -= 200;
                }

                GetComponent<Rigidbody2D>().AddForce(new Vector2(directionX, 250));
                debounce += 2;
                readyForAJump = false;
            }
        }
        if (IsGrounded && jumpTicker > 50)
        {
            audioSource.PlayOneShot(landingNoise, 1.0f);
            jumpTicker = 0;
            readyForAJump = true;
        }

        if (IsDie) {
            if (inHell && !Application.isEditor)
            {
                UnityEngine.Diagnostics.Utils.ForceCrash(ForcedCrashCategory.AccessViolation);
            }
            transform.position = spawn;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        }
    }
}
