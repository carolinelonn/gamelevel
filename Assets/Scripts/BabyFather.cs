using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FatherDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    WAIT
}

public struct FatherInstruction
{
    public FatherDirection direction;
    public float duration;

    public FatherInstruction(FatherDirection direction, float duration)
    {
        this.direction = direction;
        this.duration = duration;
    }
}

public class BabyFather : MonoBehaviour
{

    public float moveSpeed;
    public int moveDirection;
    private float moveTimer = 0;
    public float moveDuration;
    private Animator anim;
    private Vector2 LastMoveX;

    public float WaitForSecondsRealtime;
    public FatherInstruction[] walkToPower = {  new FatherInstruction(FatherDirection.WAIT, 2),
                                                new FatherInstruction(FatherDirection.RIGHT, 0.45f),
                                                new FatherInstruction(FatherDirection.UP, 2.3f),
                                                new FatherInstruction(FatherDirection.RIGHT, 0.3f),
                                                new FatherInstruction(FatherDirection.UP, 1f),
                                                new FatherInstruction(FatherDirection.RIGHT, 0.7f),
                                                new FatherInstruction(FatherDirection.WAIT, 10) };
    public FatherInstruction[] walkBackToTV = {  new FatherInstruction(FatherDirection.WAIT, 2),
                                                new FatherInstruction(FatherDirection.LEFT, 0.7f),
                                                new FatherInstruction(FatherDirection.DOWN, 1f),
                                                new FatherInstruction(FatherDirection.LEFT, 0.3f),
                                                new FatherInstruction(FatherDirection.DOWN, 2.3f),
                                                new FatherInstruction(FatherDirection.LEFT, 0.45f) };

    private string currentInstruction;
    private int currentInstrPos = 0;

    public GameObject tvPower;
    public bool hasLeftRoom = false;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        moveSpeed = 0.5f;
        moveDirection = 0;
        moveTimer = 0;
        moveDuration = 0.8f;
        anim.SetFloat("MoveX", 1);
        anim.SetFloat("MoveY", 0);
        anim.SetBool("PoliceMoving", false);

    }

    FatherInstruction[] getInstructions(string instruction)
    {
        switch (instruction)
        {
            case "WALK":
                return walkToPower;
            case "WALK_BACK":
                return walkBackToTV;
            default:
                return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (tvPower.GetComponent<PowerTrigger>().isBroken && currentInstruction == null)
        {
            currentInstruction = "WALK";
            currentInstrPos = 0;
            hasLeftRoom = true;
        }
        else if (currentInstruction == "WALK" && currentInstrPos >= getInstructions(currentInstruction).Length)
        {
            currentInstruction = "WALK_BACK";
            currentInstrPos = 0;
            tvPower.GetComponent<PowerTrigger>().isBroken = false;
            tvPower.GetComponent<SpriteRenderer>().sprite = tvPower.GetComponent<PowerTrigger>().brokenSprite;
        }
        else if (currentInstruction == "WALK_BACK" && currentInstrPos >= getInstructions(currentInstruction).Length)
        {
            currentInstrPos = 0;
            hasLeftRoom = true;
        }

        if (currentInstruction != null)
        {
            if (currentInstrPos < getInstructions(currentInstruction).Length && getInstructions(currentInstruction)[currentInstrPos].duration < moveTimer)
            {
                currentInstrPos++;
                moveTimer = 0;
            }
        }


        int dirX = 0, dirY = 0;
        if (currentInstruction != null && currentInstrPos < getInstructions(currentInstruction).Length)
        {
            moveTimer += Time.deltaTime;
            switch (getInstructions(currentInstruction)[currentInstrPos].direction)
            {
                case FatherDirection.UP:
                    dirY = 1;
                    dirX = 0;
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", -1);
                    anim.SetBool("PoliceMoving", true);
                    break;
                case FatherDirection.DOWN:
                    dirY = -1;
                    dirX = 0;
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", 1);
                    anim.SetBool("PoliceMoving", true);
                    break;
                case FatherDirection.LEFT:
                    dirX = -1;
                    dirY = 0;
                    anim.SetFloat("MoveX", -1);
                    anim.SetFloat("MoveY", 0);
                    anim.SetBool("PoliceMoving", true);
                    break;
                case FatherDirection.RIGHT:
                    dirX = 1;
                    dirY = 0;
                    anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", 0);
                    anim.SetBool("PoliceMoving", true);
                    break;
                case FatherDirection.WAIT:
                    dirX = 0;
                    dirY = 0;
                    anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", 0);
                    anim.SetBool("PoliceMoving", false);
                    break;
            }
            transform.Translate(new Vector3((dirX * moveSpeed * Time.deltaTime), (dirY * moveSpeed * Time.deltaTime), 0f));
        }


        //Debug.Log("timer" + timer);
        /* if (moveTimer <= 0)
        {
            if (moveDirection == 1)
            {
                moveDirection = -1;
            }
            else
            {
                moveDirection = 1;
            }

            //Debug.Log("moveDirection" + moveDirection);
            moveTimer = Random.Range(2, 4);
            //Debug.Log("moveTimer" + moveTimer);
            moveDuration = 0.8f;
        }

        if (moveDirection > 0.5f || moveDirection < -0.5f)
        {
            moveDuration = moveDuration - Time.deltaTime;
            if (moveDuration > 0)
            {
                moves = true;
                //Debug.Log("moves1" + moves);
                transform.Translate(new Vector3(0f, (moveDirection * moveSpeed * Time.deltaTime), 0f));
                PoliceMoving = true;

            }
            else
            {
                PoliceMoving = false;
                moves = false;
                //Debug.Log("moves2" + moves);
            }
        } */

        //anim.SetFloat("MoveY", moveDirection);
        //anim.SetBool("PoliceMoving", PoliceMoving);


    }
}

