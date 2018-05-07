using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koudai3D_Move : MonoBehaviour {
    private float fPosX = 0;　//X軸移動量
    private float fPosY = 0;  //Y軸移動量
    private float fPosZ = 0;  //Z軸移動量
    private float fRotationY = 0;
    private float fLimit_y = -20.0f;
    private bool bLockOn = false; //ロックオン判定
    private bool bRotation = false;
    private int bhorizon = 0;//x軸移動方向判定   1=PLUS  2=MINUS  0=NULL
    private int bfront = 0;  //z軸移動方向判定   1=PLUS  2=MINUS  0=NULL
    private int nCnt = 0;
    public GameObject ball;

    // Use this for initialization
    void Start ()
    {
        bhorizon = 2;
        bfront = 0;
        //int rand;
        //rand = Random.Range();
    }
    
	void Update ()
	{
        //------------------------------------------------------------------------
        //移動方向の判定と移動量
        //------------------------------------------------------------------------
        if (bLockOn==false)
        {
		    switch (bhorizon)
		    {
                case 0:
                    fPosX = 0;
                    break;
			    case 1:
				    fPosX = Time.deltaTime * 5.0f;
				    break;
			    case 2:
                    fPosX = Time.deltaTime * -5.0f;
                    break;
		    }
		    switch (bfront)
		    {
                case 0:
                    fPosZ = 0;
                    break;
                case 1:
				    fPosZ = Time.deltaTime * 5.0f;
				    break;
			    case 2:
				    fPosZ = Time.deltaTime * -5.0f;
				    break;
		    }
		    transform.Translate(fPosX, fPosY, fPosZ);

		    if (transform.position.y <= fLimit_y)
		    {
			    Destroy(gameObject);
		    }
        }
        //------------------------------------------------------------------------
        //ターゲット追尾中処理
        //------------------------------------------------------------------------
        if (bLockOn==true)
        {
            float DifferencePosX = gameObject.transform.position.x - ball.transform.position.x;
            Debug.Log("LockOn ->" + ball.gameObject.name);
            if (DifferencePosX>=0)
            {
                fPosX = Time.deltaTime * -2.0f;
            }
            else
            {
                fPosX = Time.deltaTime *  2.0f;
            }
            float DifferencePosZ = gameObject.transform.position.z - ball.transform.position.z;
            if (DifferencePosZ >= 0)
            {
                fPosZ = Time.deltaTime * -2.0f;
            }
            else
            {
                fPosZ = Time.deltaTime *  2.0f;
            }
            transform.Translate(fPosX, fPosY, fPosZ);
        }
    }
    //-----------------------------------------------------------------------------------------
    //                   GetCollision
    //-----------------------------------------------------------------------------------------
    // 衝突した瞬間を検出
    void OnCollisionEnter (Collision other)
	{
		//------------------------------------------------------------------------------

	}
	// 衝突したオブジェクトが離れる瞬間を検出
	void OnCollisionExit (Collision other)
	{

	}

	// 衝突中を検出
	void OnCollisionStay (Collision other)
	{

        if(bLockOn==true)
        { 
            if (other.gameObject.tag=="ball")
            {
                nCnt += 1;
                if(nCnt>=150)
                {
                    Destroy(other.gameObject);
                    nCnt = 0;
                    bLockOn = false;
                }
            }
        }
    }

    //-----------------------------------------------------------------------------------------
    //          GetTrigger
    //-----------------------------------------------------------------------------------------
    //トリガーに接触した瞬間
    void OnTriggerEnter(Collider other)
    {
        if (bLockOn==false)
        { 
            if (other.gameObject.tag=="ball")
            {
                ball = other.gameObject;
                bLockOn = true;
            }
        }

        if(other.gameObject.name=="judge")
        {
            //transform.Rotate(0,90,0);
            int rand;
            rand = Random.Range(0,2+1); //int : 第二引数は含まない->+1で調整
            if (rand == 0)
            {
                bfront = 0;
               bhorizon = 1;
            }
            if (rand == 1)
            {
                bfront = 0;
                bhorizon = 2;
            }
            if (rand == 2)
            {
                bfront = 1;
                bhorizon = 0;
            }
        }
        if (other.gameObject.name == "judge2")
        {
            int rand;
            rand = Random.Range(0, 1+1);
            if (rand == 0)
            {
                bfront = 0;
                bhorizon = 1;
            }
            if (rand == 1)
            {
                bfront = 1;
                bhorizon = 0;
            }
        }
        if (other.gameObject.name == "judge3")
        {
            int rand;
            rand = Random.Range(0, 1+1);
            if (rand == 0)
            {
                bfront = 0;
                bhorizon = 2;
            }
            if (rand == 1)
            {
                bfront = 1;
                bhorizon = 0;
            }
        }
        if (other.gameObject.name == "judge4")
        {
            int rand;
            rand = Random.Range(0, 2 + 1);
            if (rand == 0)
            {
                bfront = 0;
                bhorizon = 1;
            }
            if (rand == 1)
            {
                bfront = 1;
                bhorizon = 0;
            }
            if (rand == 2)
            {
                bfront = 2;
                bhorizon = 0;
            }
        }
        if (other.gameObject.name == "judge5")
        {
            int rand;
            rand = Random.Range(0, 1 + 1);
            if (rand == 0)
            {
                bfront = 2;
                bhorizon = 0;
            }
            if (rand == 1)
            {
                bfront = 0;
                bhorizon = 1;
            }
        }
        if (other.gameObject.name == "judge6")
        {
            int rand;
            rand = Random.Range(0, 2 + 1);
            if (rand == 0)
            {
                bfront = 0;
                bhorizon = 2;
            }
            if (rand == 1)
            {
                bfront = 1;
                bhorizon = 0;
            }
            if (rand == 2)
            {
                bfront = 2;
                bhorizon = 0;
            }
        }
        if (other.gameObject.name == "judge7")
        {
            int rand;
            rand = Random.Range(0, 1 + 1);
            if (rand == 0)
            {
                bfront = 2;
                bhorizon = 0;
            }
            if (rand == 1)
            {
                bfront = 0;
                bhorizon = 2;
            }
        }
        if (other.gameObject.name == "judge8")
        {
            int rand;
            rand = Random.Range(0, 3 + 1);
            if (rand == 0)
            {
                bfront = 2;
                bhorizon = 0;
            }
            if (rand == 1)
            {
                bfront = 1;
                bhorizon = 0;
            }
            if (rand == 2)
            {
                bfront = 0;
                bhorizon = 1;
            }
            if (rand == 3)
            {
                bfront = 0;
                bhorizon = 2;
            }
        }
        if (other.gameObject.name == "judge9")
        {
            int rand;
            rand = Random.Range(0, 2 + 1);
            if (rand == 0)
            {
                bfront = 0;
                bhorizon = 1;
            }
            if (rand == 1)
            {
                bfront = 0;
                bhorizon = 2;
            }
            if (rand == 2)
            {
                bfront = 2;
                bhorizon = 0;
            }
        }
    }

    //トリガーと離れた瞬間
    void OnTriggerExit(Collider other)
    {
        
    }

    //トリガーと接触してる間
    void OnTriggerStay(Collider other)
    {

    }
}
