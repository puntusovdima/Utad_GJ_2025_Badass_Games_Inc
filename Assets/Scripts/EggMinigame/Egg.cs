using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public EggScore eggScore;
    public Rigidbody2D rb;
    public float rotCoeff = 0.1f;

    private void Start()
    {
        // eggScore = FindObjectOfType<EggScore>();
        rb = GetComponent<Rigidbody2D>();
        eggScore = FindObjectOfType<EggScore>();
    }

    private void Update()
    {
        if (rb.velocity.x > 0)
        {
            rb.rotation += rotCoeff * Time.deltaTime;
        }
        else
        {
            rb.rotation -= rotCoeff * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CatchPosition"))
            eggScore.score++;
        Destroy(gameObject);
    }
}
