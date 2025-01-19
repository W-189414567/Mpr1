using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FirstCSharp : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 round_vec = new Vector3(1, 0, 0);
    Transform parent = null;

    [ Tooltip("���Ǹ������ʾ��")]
    public float Rotate_Speed = 0;   // awake��Ϣ�������ǻ�����Ϸ����ʱ���ã���ʹ�ű�������
    private void Awake() 
    {
        Debug.Log("Awake");
    }   void Start()
    {
        Debug.Log("***  ��һ���ű�");
        GameObject obj = this.gameObject;
        string name = obj.name;
        Debug.Log(name);
        Vector3 vector3 = new Vector3(10,10,10);
        parent = obj.transform.parent;

    }

    // Update is called once per frame
    void Update()
    {
        round_vec.x += 1.0f;
        this.transform.localEulerAngles = round_vec;
        // parent.transform.Rotate(0, 0.5f, 0, Space.Self);
    }
}
