using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPulpit : MonoBehaviour
{
   private Vector3 spawnPos = new Vector3(0,0,0);
   public GameObject pulpitPrefab;
   public TextAsset jsonFile;
   private float repeatRate;
   public GameObject doofus;
   public GameObject restartpanel;
   void Start()
   {
      GameData gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
      repeatRate = gameData.pulpit_data.pulpit_spawn_time;
   }

   void Update()
   {
      GameLost();
   }

   public void RepeatSpawn()
   {
      InvokeRepeating("Spawn", repeatRate, repeatRate);
   }

   void Spawn()
   {
      int randomPos = Mathf.RoundToInt(Random.Range(0,3));
      if(randomPos == 0)
      {
         Instantiate(pulpitPrefab, new Vector3(spawnPos.x+9,spawnPos.y, spawnPos.z), Quaternion.identity);
         spawnPos = new Vector3(spawnPos.x+9,spawnPos.y, spawnPos.z);
      }  
      if(randomPos == 1)
      {
         Instantiate(pulpitPrefab, new Vector3(spawnPos.x-9,spawnPos.y, spawnPos.z), Quaternion.identity);
         spawnPos = new Vector3(spawnPos.x-9,spawnPos.y, spawnPos.z);
      } 
      if(randomPos == 2)
      {
         Instantiate(pulpitPrefab, new Vector3(spawnPos.x,spawnPos.y, spawnPos.z+9), Quaternion.identity);
         spawnPos = new Vector3(spawnPos.x,spawnPos.y, spawnPos.z+9);
      } 
      if(randomPos == 3)
      {
         Instantiate(pulpitPrefab, new Vector3(spawnPos.x,spawnPos.y, spawnPos.z-9), Quaternion.identity);
         spawnPos = new Vector3(spawnPos.x,spawnPos.y, spawnPos.z-9);
      } 
      
   }

   public void Restart()
   {
      restartpanel.SetActive(false);
      doofus.SetActive(true);
      ScoreManager.Instance.score = 0;
      ScoreManager.Instance.scoreText.text = "0";
      doofus.transform.position = new Vector3(0,1,0);
      spawnPos = new Vector3(0,0,0);
      InvokeRepeating("Spawn", repeatRate, repeatRate);
      Instantiate(pulpitPrefab, new Vector3(0,0,0), Quaternion.identity);
   }

   void GameLost()
    {
        if(doofus.transform.position.y < -5)
        {
            doofus.SetActive(false);
            CancelInvoke();
            restartpanel.SetActive(true);
        }
    }
}
