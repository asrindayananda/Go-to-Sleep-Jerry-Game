using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
      public float moveSpeed;

    private Rigidbody2D myRigidbody;

      private bool moving;

      public float timeBetweenMove;
      private float timeBetweenMoveCounter;

      public float timeToMove;
      private float timeToMoveCounter;

      private Vector3 moveDirection;
        public AudioClip ouch;
        internal Animator animator;


        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => _collider.bounds;
        void Start()
        {
          myRigidbody = GetComponent<Rigidbody2D>();
          //timeBetweenMove = timeBetweenMoveCounter;
          //timeToMove = timeToMoveCounter ;
          timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f,timeBetweenMove*1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f,timeToMove*1.25f);
        }
        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }

        void Update()
        {
          if(moving )
          {
            timeToMoveCounter =-Time.deltaTime;
            myRigidbody.velocity = moveDirection;
            if(timeToMoveCounter<0f)
            {
              moving = false;
            //  timeBetweenMoveCounter = timeBetweenMove;
            timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f,timeBetweenMove*1.25f);
            }else{
              timeBetweenMoveCounter -= Time.deltaTime;
              myRigidbody.velocity = Vector2.zero;
            }


          }else{
            timeToMoveCounter -=Time.deltaTime;
            if(timeToMoveCounter < 0f)
            {
              moving = true;
              //timeToMoveCounter = timeToMove;
              timeToMoveCounter = Random.Range(timeToMove * 0.75f,timeToMove*1.25f);

              moveDirection = new Vector3(0f,Random.Range(-1f,1f)*moveSpeed,0f);
            }
        }

    }
}
}
