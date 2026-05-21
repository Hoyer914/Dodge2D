using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float minFallSpeed = 3f;
    public float maxFallSpeed = 8f;

    private float fallSpeed;
    private float destroyY = -5f;

    void Start()
    {
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
    }

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}