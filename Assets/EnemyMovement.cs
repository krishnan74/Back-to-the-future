using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float damageThreshold = 2f; // Distance threshold for taking damage
    private Transform target;
    private Vector3 extra = new Vector3(2f,2f,0f);
    private SpriteRenderer spriteRenderer;
    private GameChanges gameChanges;    public GameObject plutoPrefab; // Reference to the Pluto prefab



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameChanges = target.GetComponent<GameChanges>();
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
        if (distance < damageThreshold)
        {
            gameChanges.TakeDamage();
            if (Input.GetMouseButtonDown(1))
            {
            // Destroy the enemy game object

            Destroy(gameObject);

            // Spawn the Pluto prefab at the enemy's position
            Instantiate(plutoPrefab, transform.position + extra, Quaternion.identity);
            }
        }
    }
}
