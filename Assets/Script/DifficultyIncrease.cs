using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyIncrease : MonoBehaviour
{
    public static int time;
    [SerializeField] private GameObject killEnemyButton;
    [SerializeField] private GameObject FreezeEnemyButton;
    bool spawnKillButton;
    bool spawnFreezeButton;

    private void Start()
    {
        InvokeRepeating("TimeIncrease", 0, 1);

    }

    private void Update()
    {
        if (time == 40)
        {
            if (!spawnKillButton)
            {
                killEnemyButton.SetActive(true);
                spawnKillButton = true;
            }
        }
        else if (time == 59)
        {
            killEnemyButton.SetActive(false);
        }

        if (time == 60)
        {
            if (!spawnFreezeButton)
            {
                FreezeEnemyButton.SetActive(true);
                spawnFreezeButton = true;
            }
        }
    }

    void TimeIncrease()
    {
        time++;
    }

}
