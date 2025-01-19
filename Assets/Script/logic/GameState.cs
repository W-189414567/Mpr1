using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : SingleTon<GameState>
{
    // Start is called before the first frame update
    public int Player_EXP;
    public int Player_Health;
    public int Player_Level;
    public Vector3 Player_Position;
}
