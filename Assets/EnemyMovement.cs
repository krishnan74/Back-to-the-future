using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FlowControllerlast;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float damageThreshold = 2f; // Distance threshold for taking damage
    private Transform target;
    private GameObject targetObject;
    private Vector3 extra = new Vector3(2f,2f,0f);
    private SpriteRenderer spriteRenderer;
    public Slider enemyHealth;
    public float DamagePoints;
    public float DamagePoints1;
    public float DamagePoints2;
    public float DamagePoints3;
    private GameChanges gameChanges;    
    public GameObject plutoPrefab; // Reference to the Pluto prefab
    public GameObject lightningPrefab;
    public Animator enemyAnimator;



    private void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player");
        target = targetObject.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameChanges = target.GetComponent<GameChanges>();
        SpriteRenderer spriteRendererPlayer = targetObject.GetComponent<SpriteRenderer>();

        if(StateManager.slowEnemySpeed == 0){
            movementSpeed = 3f;
        }
        else if(StateManager.slowEnemySpeed == 1){
            movementSpeed = 2.5f;
        }
        else if(StateManager.slowEnemySpeed == 2){
            movementSpeed = 5f;
        }
        else if(StateManager.slowEnemySpeed == 3){
            movementSpeed = 1f;
        }

    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        Vector3 targetPosition = transform.position + direction * movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Flip the sprite if the enemy is on the left side of the player
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        // Calculate the distance between player and enemy
        float distance = Vector3.Distance(transform.position, target.position);

        // Check if the distance is less than the damage threshold
        if (distance < damageThreshold && !(PauseGame.isPaused))
        {
            gameChanges.TakeDamage();
            
            if (Input.GetMouseButtonDown(0))
            {
                if(StateManager.increasedDamageIncrement == 0){
                    enemyHealth.value -= (DamagePoints/1000);
                }

                else if(StateManager.increasedDamageIncrement == 1){
                    enemyHealth.value -= (DamagePoints1/1000);
                }

                else if(StateManager.increasedDamageIncrement == 2){
                    enemyHealth.value -= (DamagePoints2/1000);
                }
                else if(StateManager.increasedDamageIncrement == 3){
                    enemyHealth.value -= (DamagePoints3/1000);
                }

                if(StateManager.increasedDamageIncrement == 0){
                    gameChanges.powerSlider.value += 0.02f;
                }

                else if(StateManager.increasedDamageIncrement == 1){
                    gameChanges.powerSlider.value += 0.05f;
                }

                else if(StateManager.increasedDamageIncrement == 2){
                    gameChanges.powerSlider.value += 0.1f;
                }
                else if(StateManager.increasedDamageIncrement == 3){
                    gameChanges.powerSlider.value += 0.5f;
                }

                
            }
        }

        
        DestroyEnemy();
        
    }

    void DestroyEnemy(){
        if(enemyHealth.value== 0){
            Destroy(gameObject);
            Instantiate(plutoPrefab, transform.position + extra, Quaternion.identity);

        }
        if (Input.GetMouseButtonDown(1) && gameChanges.powerSlider.value == 1f){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            enemyAnimator.SetBool("Dead", true);
            StartCoroutine(WaitAndDestroyEnemies(enemies));
            gameChanges.powerSlider.value = 0f;
        }
    }

    IEnumerator WaitAndDestroyEnemies(GameObject[] enemies)
    {
        yield return new WaitForSeconds(1f);

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
            Instantiate(plutoPrefab, enemy.transform.position + extra, Quaternion.identity);
        }
    }

}
