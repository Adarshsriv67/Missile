using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject missile;
    public GameObject shield;
    private GameManager gameManager;
    public GameObject cloud;
    public GameObject player;

    public GameObject[] powerUps;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(MissileSpawnRoutine());
        StartCoroutine(PowerUpsSpawnRoutine());

    }
    public void StartSpawnRoutine()
    {
        StartCoroutine(MissileSpawnRoutine());
    }

    public void PowerUpSpawnRoutine()
    {
        //Vector3 offset = PlayerController.instance.pV.transform.position + new Vector3(PlayerController.instance.pV.transform.position.x + Random.Range(0f, 1f), PlayerController.instance.pV.transform.position.y + Random.Range(0f, 1f),0);
        Vector3 offset = player.transform.position + new Vector3(player.transform.position.x + Random.Range(0f, 1f), player.transform.position.y + Random.Range(0f, 1f), 0);

        print("Powerup spawned");
        var powerUp = Instantiate(powerUps[Random.Range(0,powerUps.Length)],offset,Quaternion.identity);
    }

    IEnumerator MissileSpawnRoutine()
    {
        while (gameManager.gameOver==false)
        {
           // Instantiate(missile, new Vector3(Random.Range(-10f, 10f), Random.Range(-20f, 20f), 0), Quaternion.identity);
            Vector3 offset = player.transform.position + new Vector3(player.transform.position.x + Random.Range(0f, 10f), player.transform.position.y + Random.Range(0f, 10f), 0);
            var msl = Instantiate(missile, offset, Quaternion.identity);
            //Instantiate(missile, new Vector3(Random.Range(cloud.transform.position.x-10f, cloud.transform.position.x + 10f), Random.Range(cloud.transform.position.y - 10f, cloud.transform.position.y + 10f), Quaternion.identity));
            //Instantiate(missile, new Vector3(Random.Range(0,5), offset, 0), Quaternion.identity);
            yield return new WaitForSeconds(4.0f);
        }
    }
    IEnumerator PowerUpsSpawnRoutine()
    {
        while(gameManager.gameOver==false)
        {
            yield return new WaitForSeconds(3);
            PowerUpSpawnRoutine();
        }
    }
}
