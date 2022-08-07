using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlesButton : MonoBehaviour
{
    [SerializeField] private GameObject titlesPanel;
    public TitlesScrollView titlesScrollView;

    public void SpawnTitlesPanel()
    {
        titlesPanel.SetActive(true);
        titlesScrollView.StartScroll();
    }
}
