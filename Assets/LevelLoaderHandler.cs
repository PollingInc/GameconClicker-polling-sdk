using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderHandler : MonoBehaviour
{
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = this.GetComponent<LevelManager>();
    }


    void LoaderHandler()
    {
        //THE IDEA OF THIS FUNCTION IS TO KEEP LOADED ONLY THE CURRENT LEVEL, PLUS THE PREVIOUS AND/OR THE NEXT LEVEL. 
        //EVERY OTHER LEVEL WONT BE IN SCENE AND NEEDS TO BE UNLOADED FROM EMORY TO MAKE IT MORE SCALABLE IN TERMS OF PERFORMANCE

        //ALSO, THERE WILL BE A NEED TO MAKE A COMMOM OBJECT USAGE HANDLER, LIKE AN OBJECT POOLING MANAGER, BUT THAT WILL BE ANOTHER SEPARATE BEHAVIOUR.

        //currentLevel (LevelData) may change to a prefab oriented object, not an already instantiated object
        var currentLevel = levelManager.currentLevel;
        int levelCount = levelManager.allLevels.Count - 1;
        int currentLevelIndex = levelManager.allLevels.IndexOf(currentLevel);


        //if (currentLevelIndex >= levelCount || !currentLevel.isConcluded)
        if (currentLevelIndex >= levelCount)
        {
            LoadLevels(true, false);
        }
        else

        if (currentLevelIndex <= 0)
        {
            LoadLevels(false, true);
        }
        else LoadLevels(true, true);


        void LoadLevels(bool includePrevious, bool includeNext)
        {

        }

    }



}
