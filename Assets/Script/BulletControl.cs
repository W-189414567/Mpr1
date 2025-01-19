using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Vector3 shoot;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        shoot = Vector3.forward;
        shoot *= speed;
        this.Invoke("DeBullet", 3);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(shoot);
    }

    private void DeBullet()
    {
        Object.Destroy(this.gameObject);
    }

    // Åö×²¼ì²â
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("hit");
        CancelInvoke("DoBullet");
        Object.Destroy(this.gameObject);

    }

}
