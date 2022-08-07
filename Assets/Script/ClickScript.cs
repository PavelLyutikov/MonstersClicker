using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{

    public new Camera camera;
    [SerializeField] private int damage;
    public EnemySettings EnemySettings;
    private int clickOneEnemy;

    public Collider coll;

    void Start()
    {
        coll = GetComponent<Collider>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "Enemy")
                {
                    
                    GameObject enemy = hit.collider.gameObject;
                    EnemySettings enemySettings = enemy.GetComponent<EnemySettings>();
                    if (enemySettings != null)
                    {
                        enemySettings.ReceiveDamage(damage);
                    }

                    clickOneEnemy++;
                    if (clickOneEnemy <= EnemySettings.enemyHealth)
                    {
                        ClickCount.Click++;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemySettings enemySettings = other.GetComponent<EnemySettings>();
        if (enemySettings != null)
        {
            enemySettings.ReceiveDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
