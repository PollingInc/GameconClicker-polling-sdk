using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float currentGoal;
    public float goalProgress;

    public int currentPriority;

    public LevelProgressUI levelProgressBar;
    public TMP_Text levelProgressText;

    public Button levelSwitch_Left;
    public Button levelSwitch_Right;

    public TMP_Text currentLevelDisplay;

    //TEMPORARIO PARA MOSTRAR MOCKUP NO EVENTO
    public List<LevelData> allLevels;
    //public List<GameObject> allLevels;

    public LevelData currentLevel;
    //public int currentLevelNumber = 1;


    ClickAnimation clickAnimation;

    void Awake()
    {
        clickAnimation = this.GetComponent<ClickAnimation>();
    }

    void Start()
    {
        currentLevel = allLevels[0];
        FlushLevelArrows();
        DisplayLevelName();

        clickAnimation.currentInDisplay = currentLevel.GetComponent<LevelAnimation>().levelOnClickAnimations;
    }

    private void Update()
    {
        //NAO PRECISARA SER NO UPDATE, DEPOIS DO EVENTO MUDAR PARA ACONTECIMENTOS DE ACOES. ESTUDAR SE EVENTOS PODEM SER UMA BOA IDEIA
        //(POIS CONECTAR TODAS AS ENTRADAS DE PONTOS EM UMA ACTION SO TALVEZ, SEM NECESSITAR FAZER A OPERACAO TODO O FRAME)
        levelProgressBar.image.fillAmount = Mathf.Lerp(0,1, currentLevel.currentCumulative/currentLevel.cumulativeGoal);
        levelProgressText.text = $"{currentLevel.currentCumulative.ToString("F0")} / {currentLevel.cumulativeGoal.ToString("F0")}";
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
        //FORMA RAPIDA DE NÃO DEIXAR GOAL PASSAR COM A QUANTIDADE DO ULTIMO CLIQUE
        currentLevel.currentCumulative = currentLevel.cumulativeGoal;


        
        if (currentLevelIndex + 1 == allLevels.Count) return;

        var nextLevel = allLevels[currentLevelIndex + 1];

        //var fromCamera = allLevels[currentLevelIndex].virtualCamera;
        //var toCamera = nextLevel.virtualCamera;

        //SwitchCameraByPriority(fromCamera, toCamera);
        SwitchLevel(nextLevel);
    }


    public void SwitchLevel(LevelData targetLevel)
    {
        SwitchCameraByPriority(currentLevel.virtualCamera, targetLevel.virtualCamera);

        currentLevel = targetLevel;
        FlushLevelArrows();
        DisplayLevelName();

        var levelAnimation = currentLevel.GetComponent<LevelAnimation>();

        clickAnimation.currentInDisplay = levelAnimation.levelOnClickAnimations;
    }

    //public void UISwitchLevelHandler(GameObject originButton, bool next)


    //PROVISORIO PARA EVENTO
    public void DisplayLevelName()
    {
        currentLevelDisplay.text = currentLevel.gameObject.name;
    }


    public void FlushLevelArrows()
    {
        int levelCount = allLevels.Count - 1;
        int currentLevelIndex = allLevels.IndexOf(currentLevel);
        //Button arrow;

        if (currentLevelIndex >= levelCount|| !currentLevel.isConcluded)
        {
            levelSwitch_Right.gameObject.SetActive(false);
        }
        else levelSwitch_Right.gameObject.SetActive(true);

        if (currentLevelIndex <= 0)
        {
            levelSwitch_Left.gameObject.SetActive(false);
        }
        else levelSwitch_Left.gameObject.SetActive(true);
        //arrow.gameObject.SetActive(arrow.gameObject.activeSelf);
    }


    public void UISwitchLevelHandler(bool next)
    {
        int currentLevelIndex = allLevels.IndexOf(currentLevel);
        int targetLevelIndex = 0;

        if (next)
        {
            if (currentLevelIndex >= allLevels.Count) return;

            targetLevelIndex = currentLevelIndex + 1;

            var targetLevel = allLevels[targetLevelIndex];
//            if (!targetLevel.isConcluded) originButton.SetActive(false);
        }

        else
        {
            if (currentLevelIndex <= 0) return;

            targetLevelIndex = currentLevelIndex -1;
        }




        SwitchLevel(allLevels[targetLevelIndex]);
    }



}
