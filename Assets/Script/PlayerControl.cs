using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    private GameObject Camera;
    private Object BulletProfab;

    //玩家移动方向
    private Vector3 MoveVec;
    //摄像机移动方向
    private Vector3 CameraVec;
    // 玩家在屏幕位置
    private Vector3 Player2Screan;
    //鼠标位置
    private Vector3 MousePos;
    // 朝向位置
    private Vector2 ForwordVec;

    //用于计算朝向的向量
    //物体向右的向量
    private Vector2 RightVec;
    //物体朝向的向量

    // 发射标志
    private bool CanShoot;
    private float MoveSpeed;
    private float ForwordAngel;
    void Start()
    {
        Player = this.gameObject;
        Camera = GameObject.Find("MainCamera");
        MoveSpeed = 0.2f;
        // Debug.Log("Screen width:" + Screen.width);
        // Debug.Log("Screen height:" + Screen.height);

        Player2Screan.x = Screen.width / 2;
        Player2Screan.z = Screen.height / 2;
        RightVec = new Vector2(1, 0);
        BulletProfab = Resources.Load("Spot");
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
        ForwordVec.x = MousePos.x - Player2Screan.x;
        ForwordVec.y = MousePos.y - Player2Screan.z;
        ForwordVec.Normalize();
        ForwordAngel = Vector2.Angle(ForwordVec, RightVec);
        if (ForwordVec.y > 0)
        {
            ForwordAngel *= -1;
        }
        Player.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, ForwordAngel, 0), 0.5f);


        //if (Input.GetMouseButtonDown(0)) {
        //    Debug.Log(ForwordAngel.ToString());
        //}
        if (Input.GetKey(KeyCode.A))
        {
            MoveVec.x -= MoveSpeed;
            CameraVec.x -= MoveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveVec.x += MoveSpeed;
            CameraVec.x += MoveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveVec.z += MoveSpeed;
            CameraVec.y += MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveVec.z -= MoveSpeed;
            CameraVec.y -= MoveSpeed;
        }
        Player.transform.Translate(MoveVec, Space.World);
        GameState.Instance.Player_Position = Player.transform.position;
        Camera.transform.Translate(CameraVec);
        MoveVec = Vector3.zero;
        CameraVec = Vector3.zero;


        if (Input.GetMouseButton(0))
        {
            if (!IsInvoking("ShootWaite"))
            {
                this.Invoke("ShootWaite", 1);
            }

            if (this.CanShoot)
            {
                this.CanShoot = false;
                //Debug.Log("发射");
                GameObject bullet = Instantiate((GameObject)BulletProfab, null);
                bullet.transform.position = this.transform.position;
                bullet.transform.eulerAngles = this.transform.eulerAngles;
                bullet.transform.Rotate(0, 90, 0);
                BulletControl bulletControl = bullet.GetComponent<BulletControl>();
                bulletControl.speed = 1f;
            }
        }

    }

    private void ShootWaite()
    {
        this.CanShoot = true;
    }

}
