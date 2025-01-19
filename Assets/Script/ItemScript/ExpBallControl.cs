using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBallControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Local_Position;
    private Vector3 Forword_Pos;
    private float Move_Speed;
    public bool Picked;

    // 直接获取玩家实例
    //GameObject PlayerObj;
    void Start()
    {
        //PlayerObj = GameObject.Find("Player1");
        Local_Position = transform.position;
        Move_Speed = 0.1f;
        Picked = false;
        var Vec_Con = transform.position;
        Vec_Con.y = 0.2f;
        this.transform.position = Vec_Con;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Picked)
        {
            Control_Ball();
        }
        
    }

    private void Control_Ball()
    {
        Forword_Pos = GameState.Instance.Player_Position - Local_Position;
        //Forword_Pos = PlayerObj.transform.position - Local_Position;

        // 通过距离判断是否销毁总是无法准确判断.改成定时销毁
        //if (Vector3.Magnitude(Forword_Pos) < 1)
        //{
        //    GameState.Instance.Player_EXP += 1;
        //    Debug.Log("Destoryed");
        //    CancelInvoke("Deball");
        //    Object.Destroy(gameObject);
        //}
        Forword_Pos.Normalize();
        Forword_Pos *= Move_Speed;
        Forword_Pos.y = 0;
        this.transform.Translate(Forword_Pos);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsInvoking("DeBall"))
        {
            this.Invoke("DeBall",0.3f);
        }
        this.Picked = true;
    }

    private void DeBall()
    {
        GameState.Instance.Player_EXP += 1;
        Object.Destroy(gameObject);
    }
}
