using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGamePhase
{
    void Enter();
    void Exit();
    void Execute();
}
