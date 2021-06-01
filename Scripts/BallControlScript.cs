using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class BallControlScript : MonoBehaviour
{

    public Rigidbody2D rigidbody;

    [Range(0.2f, 2f)]
    public float moveSpeedMod = 0.5f;

    float directionX, directionY;

    Animator animator;

    static bool isDead;

    static bool moveAllowed;

    static bool youWin;

    Score score;

    [SerializeField]
    GameObject winText;
    //  public RewardedVideoAds rewardedVideoAds;
    // public Monetization monetization;
    ADGenerator adGenerator;

    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
        youWin = false;
        moveAllowed = true;
        isDead = false;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("BallDead", isDead);
        adGenerator = FindObjectOfType<ADGenerator>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.acceleration.x * moveSpeedMod;
        directionY = Input.acceleration.y * moveSpeedMod;

        if (isDead)
        {
          
            rigidbody.velocity = new Vector2(0, 0);

            animator.SetBool("BallDead", isDead);
            Invoke("RestartScene", 1f);
            adGenerator.generateInterstitial();
            Debug.Log("You lose - Showing Interstitial Ad");

        }
        if (youWin)
        {
            winText.gameObject.SetActive(true);
            moveAllowed = false;
            animator.SetBool("BallDead", true);
            Invoke("RestartScene", 2f);
            adGenerator.generateRewardVideo();
            Debug.Log("You win, displaying rewarded video add");
           // score.IncrementScore();
            Debug.Log("Incrementing score");
        }

    }

    void FixedUpdate()
    {
        if (moveAllowed)

            rigidbody.velocity = new Vector2(rigidbody.velocity.x + directionX, rigidbody.velocity.y + directionY);

    }
       public static void setIsDeadTrue()
        {
            isDead = true;
        }
    public static void setWinToTrue()
    {
        youWin = true;
    }
    void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
        adGenerator.generateRewardVideo();
    }

        
    }

