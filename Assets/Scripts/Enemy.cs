using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BoxCollider boxCollider;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int health = 3;

    int frameCount = 0;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;

        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (frameCount != Time.frameCount)
        {
            scoreBoard.ScoreHit(scorePerHit);
            health--;
            if (health <= 0)
            {
                KillEnemy();
            }
            frameCount = Time.frameCount;
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
