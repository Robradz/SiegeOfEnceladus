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
        GameObject fx = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        scoreBoard.ScoreHit(scorePerHit);

        Destroy(gameObject);
    }
}
