using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;
    public GameManager manager;
    float h;
    float v;
    bool isHorizonMove;
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObject;

    //--------------
    public RuntimeAnimatorController[] animcon;
    public string playerName;
    public int CharNum;
    //--------------
    void SetChar()
    {
        anim.runtimeAnimatorController = animcon[PlayerPrefs.GetInt("playerNumber")];
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid =GetComponent<Rigidbody2D>();
        SetChar();
    }

    void Update()
    {
        //move value
        h= manager.isAction? 0: Input.GetAxisRaw("Horizontal");
        v= manager.isAction? 0: Input.GetAxisRaw("Vertical");

        //check button up & down
        bool hDown= manager.isAction? false: Input.GetButtonDown("Horizontal");
        bool hUp= manager.isAction? false: Input.GetButtonUp("Horizontal");
        bool vDown=manager.isAction? false: Input.GetButtonDown("Vertical");
        bool vUp=manager.isAction? false: Input.GetButtonUp("Vertical");
        
        //check horizontal move
        if(hDown)
            isHorizonMove=true;
        else if(vDown)
            isHorizonMove=false;
        else if(hUp||vUp)
            isHorizonMove=h!=0;

        //Animation
        if(anim.GetInteger("HorizonAxisRaw")!=h){
            anim.SetBool("IsChange", true);
            anim.SetInteger("HorizonAxisRaw", (int)h);
        }
        else if(anim.GetInteger("VerticalAxisRaw")!=v){
            anim.SetBool("IsChange", true);
            anim.SetInteger("VerticalAxisRaw", (int)v);
        }
        else
            anim.SetBool("IsChange", false);

        //Direction
        if(vDown&&v==1)
            dirVec=Vector3.up;
        else if(vDown&&v==-1)
            dirVec=Vector3.down;
        else if (hDown&&h==1)
            dirVec=Vector3.right;
        else if(hDown&&h==-1)
            dirVec=Vector3.left;

        //Scan Object
        if(Input.GetButtonDown("Jump")&&scanObject!=null)
            manager.Action(scanObject);    
    }

    void FixedUpdate()
    {
        //move
        Vector2 moveVec=isHorizonMove? new Vector2(h,0): new Vector2(0,v);
        rigid.velocity=moveVec*Speed;   

        //Ray
        Debug.DrawRay(rigid.position, dirVec*0.7f,new Color(0,1,0));
        RaycastHit2D rayHit=Physics2D.Raycast(rigid.position, dirVec,
                                             0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider!=null){
            scanObject=rayHit.collider.gameObject;
        }
        else
            scanObject=null;
    }
}
