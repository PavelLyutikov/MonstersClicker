using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FreezeEnemyBonus : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public SpawnEnemy spawn;
    private int freezeTime;

    bool freezeSpawnActive;
    bool freezeActive;
    bool isFirstClick;

    void Update()
    {

        if (isPressed)
        {
            if (!freezeSpawnActive)
            {
                spawn.FreezeSpawn();
                freezeActive = true;
                freezeSpawnActive = true;
            }
        }

        if (freezeActive)
        {

            if (DifficultyIncrease.time >= freezeTime)
            {

                if (freezeSpawnActive)
                {
                    spawn.FreezeSpawnEnd();
                    freezeActive = false;
                    freezeSpawnActive = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isFirstClick)
        {
            isPressed = true;
            freezeTime = DifficultyIncrease.time + 4;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isFirstClick)
        {
            isPressed = false;
            isFirstClick = true;
        }
    }
}
