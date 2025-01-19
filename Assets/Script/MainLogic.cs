using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    public GameObject obj1;
    private GameObject obj2;
    private GameObject obj3;

    Vector3 CameraPos;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        //访问另一个节点
        obj1 = GameObject.Find("Ob1");
        obj2 = GameObject.Find("Player1");
        obj3 = GameObject.Find("MainCamera");
        CameraPos = obj2.transform.position;
        GameState.Instance.Player_Position = CameraPos;// 单例模式下的调用方法,通过一个static的Instance类来访问
        CameraPos.y = 15;
        obj3.transform.localPosition = CameraPos;

    }

    // Update is called once per frame
    void Update()
    {
        obj1.transform.Rotate(0, 2.0f, 0, Space.Self);
    }

    private void OnGUI()
    {
        GUILayout.TextArea(GameState.Instance.Player_Position.ToString(),100);
    }
}
