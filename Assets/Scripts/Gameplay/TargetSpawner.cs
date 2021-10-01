using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject standardBall;
    [SerializeField]
    GameObject timerBall;
    [SerializeField]
    GameObject quickBall;
    [SerializeField]
    GameObject ultraBall;
    [SerializeField]
    GameObject masterBall;

    float minSpawnX;
    float maxSpawnX;
    float minSpawnY;
    float maxSpawnY;
    float colliderRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempBall = Instantiate(standardBall, Vector3.zero, Quaternion.identity);
        CircleCollider2D tempBox = tempBall.GetComponent<CircleCollider2D>();
        colliderRadius = tempBox.radius;
        minSpawnX = ScreenUtils.ScreenLeft + colliderRadius;
        maxSpawnX = ScreenUtils.ScreenRight - colliderRadius;
        minSpawnY = ScreenUtils.ScreenBottom + colliderRadius;
        maxSpawnY = ScreenUtils.ScreenTop - colliderRadius;
        Destroy(tempBall);

        for (int i = 0; i < 3; i++)
        {
            SpawnABall();
        }
        EventManager.AddSpawnBallEventListener(SpawnABall);
    }

    void SpawnABall()
    {
        float spawnTries = 0;
        Vector3 spawnLocation = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
        while(Physics2D.OverlapArea(new Vector2(spawnLocation.x - colliderRadius, spawnLocation.y - colliderRadius),
            new Vector2(spawnLocation.x + colliderRadius, spawnLocation.y + colliderRadius)) != null && spawnTries < 20)
        {
            spawnLocation = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
            spawnTries++;
        }
        if(Physics2D.OverlapArea(new Vector2(spawnLocation.x - colliderRadius, spawnLocation.y - colliderRadius),
            new Vector2(spawnLocation.x + colliderRadius, spawnLocation.y + colliderRadius)) != null)
        {
            return;
        }

        int spawnInt = Random.Range(1, 101);
        if (spawnInt >= 1 && spawnInt < 55)
        {
            GameObject newBall = Instantiate(standardBall, spawnLocation, Quaternion.identity);
            newBall.GetComponent<SpecialBall>().Ball = BallType.Standard;
        }
        else if (spawnInt >= 55 && spawnInt < 70)
        {
            GameObject newBall = Instantiate(ultraBall, spawnLocation, Quaternion.identity);
            newBall.GetComponent<SpecialBall>().Ball = BallType.Ultra;
        }
        else if (spawnInt >= 70 && spawnInt < 94)
        {
            GameObject newBall = Instantiate(quickBall, spawnLocation, Quaternion.identity);
            newBall.GetComponent<SpecialBall>().Ball = BallType.Quick;
        }
        else if (spawnInt >= 94 && spawnInt < 97)
        {
            GameObject newBall = Instantiate(timerBall, spawnLocation, Quaternion.identity);
            newBall.GetComponent<SpecialBall>().Ball = BallType.Timer;
        }
        else
        {
            GameObject newBall = Instantiate(masterBall, spawnLocation, Quaternion.identity);
            newBall.GetComponent<SpecialBall>().Ball = BallType.Master;
        }
    }
}

