using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class GhostController : MonoBehaviour
{

  public float moveSpeed;

  private Rigidbody2D myRigidbody;

  private bool moving;

  public float timeBetweenMove;
  private float timeBetweenMoveCounter;

  public float timeToMove;
  private float timeToMoveCounter;

  private Vector3 moveDirection;

  //public float waitToReload;
  //private bool reloadig;
  //private GameObject thePlayer;


    // Start is called before the first frame update
    void Start()
    {
      myRigidbody = GetComponent<Rigidbody2D>();
      //timeBetweenMove = timeBetweenMoveCounter;
      //timeToMove = timeToMoveCounter ;
      timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f,timeBetweenMove*1.25f);
timeToMoveCounter = Random.Range(timeToMove * 0.75f,timeToMove*1.25f);
    }

    // Update is called once per frame
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
    /*  if (reloading)
      {
        waitToReload -= Time.deltaTime;
        if(waitToReload < 0)
        {
          Application.LoadLevel1(Application.loadedLevel1);
          thePlayer.SetActive = true;
        }
      }*/

    }
    /*void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
{
  other.gameObject.SetActive(false);
  reloading = true;
  thePlayer = other.gameObject;

        }*/
    //}
}
