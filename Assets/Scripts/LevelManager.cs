using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public float currentGoal;
    public float goalProgress;

    public int currentPriority;

    //TEMPORARIO PARA MOSTRAR MOCKUP NO EVENTO
    public List<LevelData> allLevels;
    //public List<GameObject> allLevels;

    public LevelData currentLevel;
    //public int currentLevelNumber = 1;


    void SwitchCameraByPriority(CinemachineVirtualCamera fromCamera, CinemachineVirtualCamera toCamera)
    {
        currentPriority = fromCamera.Priority;
        
        toCamera.Priority = currentPriority;
        fromCamera.Priority = 0;
    }


    public void UnlockNextLevel()
    {
        
    }



}
