using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform spawnTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnTransform.position, Quaternion.identity); //Quaternion.identity, pilla los valores 0,0,0 del prefab. La rotación funciona con Quaternions, son formulas matemáticas.
    }

   void OnTriggerEnter2D(Collider2D collision)//Esta es una función de Unity por eso necesita parámetros adiconales es los parentesis.
   {  
      if (collision.gameObject.CompareTag("Player"))
      {
        SpawnEnemy();
      }
       
   
   } 


}
