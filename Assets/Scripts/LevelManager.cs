using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public float currentGoal;
    public float goalProgress;

    public int currentPriority;

    public LevelProgressUI levelProgressBar;

    //TEMPORARIO PARA MOSTRAR MOCKUP NO EVENTO
    public List<LevelData> allLevels;
    //public List<GameObject> allLevels;

    public LevelData currentLevel;
    //public int currentLevelNumber = 1;

    private void Start()
    {
        currentLevel = allLevels[0];
    }

    private void Update()
    {
        levelProgressBar.image.fillAmount = Mathf.Lerp(0,1, currentLevel.currentCumulative/currentLevel.cumulativeGoal);
    }


    void SwitchCameraByPriority(CinemachineVirtualCamera fromCamera, CinemachineVirtualCamera toCamera)
    {
        currentPriority = fromCamera.Priority;
        
        toCamera.Priority = currentPriority;
        fromCamera.Priority = 0;
    }


    public void UnlockNextLevel()
    {
        var currentLevelIndex = allLevels.IndexOf(currentLevel);

        currentLevel.isConcluded = true;
        
        if (currentLevelIndex + 1 == allLevels.Count) return;

        var nextLevel = allLevels[currentLevelIndex + 1];

        var fromCamera = allLevels[currentLevelIndex].virtualCamera;
        var toCamera = nextLevel.virtualCamera;

        SwitchCameraByPriority(fromCamera, toCamera);
        SwitchLevel(nextLevel);
    }


    public void SwitchLevel(LevelData targetLevel)
    {
        currentLevel = targetLevel;
    }



}
