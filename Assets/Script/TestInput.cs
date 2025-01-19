using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEditor.VersionControl;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    // Start is called before the first frame update
    string message;
    Vector3 input;
    bool input2;
    float input3;
    GameObject ThisObj;
    private bool CanShoot;
    private Object BulletProfab;
    private Vector3 round_vec = new Vector3(0, 0, 0);
    void Start()
    {
        ThisObj = this.gameObject;
        CanShoot = true;
        BulletProfab = Resources.Load("Spot");
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.mousePosition;
        input2 = Input.GetMouseButton(0);
        message = input.ToString();
        input3 = Input.GetAxis("Horizontal");

        //if (Input.GetKey(KeyCode.Space)){ 
        //    // ¿Õ¸ñ¼üÉÏÉý
        //    ThisObj.transform.Translate(0f, 1.0f, 0, Space.Self);
        //}

        if (Input.GetKey(KeyCode.D)) { 
            Rotate_self();
        }
        if (input2)
        {
            if (!IsInvoking("ShootWaite")){
                 this.Invoke("ShootWaite", 1);
            }
            
            if (this.CanShoot)
            {
                this.CanShoot = false;
                Debug.Log("·¢Éä");
                GameObject bullet = Instantiate((GameObject)BulletProfab, null);
                bullet.transform.position = this.transform.position;
                bullet.transform.eulerAngles = this.transform.eulerAngles;
                BulletControl bulletControl = bullet.GetComponent<BulletControl>();
                bulletControl.speed = 0.1f;
            }
        }

    }
    private void Rotate_self()
    {
        round_vec.y += 1.0f;
        this.transform.eulerAngles = round_vec;
    }

    private void OnGUI()
    {
        GUILayout.TextArea(message, 100);
        GUILayout.TextArea(input2.ToString(), 100);
        GUILayout.TextArea(input3.ToString(), 100);
        GUILayout.TextArea(GameState.Instance.Player_Position.ToString(), 100);
    }

    private void ShootWaite()
    {
        this.CanShoot = true;
    }

}
