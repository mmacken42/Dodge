using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 movementSpeedMinMax;
    private float movementSpeed;
    private float visibleHeightThreshold;

    private void Start()
    {
        movementSpeed = Mathf.Lerp(movementSpeedMinMax.x, movementSpeedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);

        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
