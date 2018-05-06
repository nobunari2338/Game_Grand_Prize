using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koudai3D_Move : MonoBehaviour {
    private float fPosX = 0;　//X軸移動量
    private float fPosY = 0;  //Y軸移動量
    private float fPosZ = 0;  //Z軸移動量
    private float fLimit_y = -20.0f;
    private bool bLockOn = false; //ロックオン判定
    private bool bhorizon = false;//x軸移動方向判定
    private bool bfront = false;  //z軸移動方向判定
    private int nCnt = 0;
    public GameObject ball;

    // Use this for initialization
    void Start ()
    {
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
			    case false:
				    fPosX = Time.deltaTime * -10.0f;
				    break;
			    case true:

				    break;
		    }
		    switch (bfront)
		    {
			    case false:
				    fPosZ = Time.deltaTime * 10.0f;
				    break;
			    case true:
				    fPosZ = Time.deltaTime * -10.0f;
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
		if (other.gameObject.name == "kabe2")
		{
			switch (bhorizon)
			{
				case false:
                    bhorizon = true;
					fPosX = 0.0f;
					break;
			}
		}
        if (other.gameObject.name == "kabe3")
        {
            switch (bhorizon)
            {
                case false:
                    bfront = true;
                    fPosX = 0.0f;
                    break;
            }
        }
        if (other.gameObject.name == "goal")
		{
			Destroy(gameObject);
			Application.Quit();
		}
	}
	// 衝突したオブジェクトが離れる瞬間を検出
	void OnCollisionExit (Collision other)
	{

	}

	// 衝突中を検出
	void OnCollisionStay (Collision other)
	{
		if (other.gameObject.name == "wall4" || other.gameObject.name == "wall3")
		{
			bhorizon = false;
		}
		if (other.gameObject.name == "wall")
		{
			bfront = false;
		}

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
    {if(bLockOn==false)
        { 
            if (other.gameObject.tag=="ball")
            {
                ball = other.gameObject;
                bLockOn = true;
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
