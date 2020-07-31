using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] Transform explosionContainer;
    [SerializeField] int scorePerHit = 10;

    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.name == "Bullet Right" || other.name == "Bullet Left")
        {
            scoreBoard.ScoreHit(scorePerHit);
            InstantiateExplosion();
            Destroy(gameObject);
        }
    }

    private void InstantiateExplosion()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.parent = explosionContainer;
    }
}
