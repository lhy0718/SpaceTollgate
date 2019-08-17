using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public GameObject arrow;
    private GameObject[] enemyList;
    private SpriteRenderer[] enemyRenderList;
    private GameObject[] arrows;

    void Start() {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        enemyRenderList = new SpriteRenderer[enemyList.Length];
        arrows = new GameObject[enemyList.Length];
        for(int i=0; i<enemyList.Length; i++) {
            enemyRenderList[i] = enemyList[i].GetComponent<SpriteRenderer>();
            (arrows[i] = Instantiate(arrow)).SetActive(false);
        }
    }

    void FixedUpdate() {
        FindEnemy();
    }

    private void FindEnemy() {
        Vector3 c = GameManager.instance.camera.transform.position;
        for (int i = 0; i < enemyList.Length; i++) {
            if (enemyList[i] == null || enemyRenderList[i].isVisible) {
                arrows[i].SetActive(false);
            } else {
                Vector3 direction = new Vector3(enemyList[i].transform.position.x - c.x, enemyList[i].transform.position.y - c.y);
                arrows[i].SetActive(true);
                arrows[i].transform.position = new Vector3(c.x, c.y) + Vector3.Normalize(direction) * 3;
                arrows[i].transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90, Vector3.forward);
            }
        }
    }
}
