using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KillEnemyBonus : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    private GameObject[] enemies;

    void Update()
    {

        if (isPressed)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < enemies.Length; ++i)
            {
                EnemySettings enemySettings = enemies[i].GetComponent<EnemySettings>();
                enemySettings.Die();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        gameObject.SetActive(false);
    }
}
