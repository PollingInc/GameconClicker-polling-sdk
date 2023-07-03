using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    public Image image;

    private void Awake()
    {
        if (image != null) return;

        image = this.GetComponent<Image>();
    }

}
