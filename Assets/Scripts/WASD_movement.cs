using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    
    public List<Sprite> nSpritesWalk;
    public List<Sprite> neSpritesWalk;
    public List<Sprite> eSpritesWalk;
    public List<Sprite> seSpritesWalk;
    public List<Sprite> sSpritesWalk;
    public List<Sprite> swSpritesWalk;
    public List<Sprite> wSpritesWalk;
    public List<Sprite> nwSpritesWalk;
    public List<Sprite> idleSpritesWalk;

    public List<Sprite> nSpritesRun;
    public List<Sprite> neSpritesRun;
    public List<Sprite> eSpritesRun;
    public List<Sprite> seSpritesRun;
    public List<Sprite> sSpritesRun;
    public List<Sprite> swSpritesRun;
    public List<Sprite> wSpritesRun;
    public List<Sprite> nwSpritesRun;


    public float walkSpeed;
    public float runSpeeed;
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;
    public bool isDashing;
    
    public float frameRate;

    float idleTime;

    Vector2 direction;

    public BoxCollider2D boxCollider;
    public CapsuleCollider2D capsuleCollider;

    public float doubleClickTimeThreshold = 0.3f; // Maximum time between two clicks to consider as a double-click
    private float lastClickTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        

        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = direction * walkSpeed;
        HandleSpriteRenderer();
        List<Sprite> directionSprites =  SetSprite();
    
        if(directionSprites != null){

            float playTime = Time.time - idleTime;
            int frame = (int)((playTime * frameRate)% directionSprites.Count);
            spriteRenderer.sprite = directionSprites[frame];
        }
        else{
            idleTime = Time.time;
        }

         if (Input.GetKeyDown(KeyCode.Space))
        {
            capsuleCollider.enabled = false; // Disable the Collider
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            capsuleCollider.enabled = true; // Enable the Collider
        }


        if (Input.GetMouseButtonDown(0)){
        // Calculate the time elapsed since the last click
        float timeSinceLastClick = Time.time - lastClickTime;

        // Check if the time elapsed is within the double-click threshold
        if (timeSinceLastClick <= doubleClickTimeThreshold)
        {
            // Double-click detected
            StartCoroutine(Dash());        
        }
            lastClickTime = Time.time;

        }
        
    }

    private IEnumerator Dash(){
        isDashing = true;
        rb.velocity = direction * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }


    void HandleSpriteRenderer(){
        if(!spriteRenderer.flipX && direction.x < 0) {
            spriteRenderer.flipX = true;
        }

        else if(spriteRenderer.flipX && direction.x > 0){
            spriteRenderer.flipX = false;
        }
    }

    List<Sprite> SetSprite(){
        
        List<Sprite> selectedSprites = null;

        if(!Input.GetKeyDown(KeyCode.LeftShift)){
            if(direction.x == 0 && direction.y == 0){
            selectedSprites = idleSpritesWalk;
        }

        if(direction.y > 0){
            if(Mathf.Abs(direction.x) > 0){
                selectedSprites = neSpritesWalk;
            }
            else{
                selectedSprites = nSpritesWalk;
            }
        }
        else if(direction.y < 0){
            if(Mathf.Abs(direction.x) > 0){
                selectedSprites = seSpritesWalk;
            }
            else{
                selectedSprites = sSpritesWalk;
            }
        }
        else{
            if(Mathf.Abs(direction.x) > 0){
                selectedSprites = eSpritesWalk;
            }


        }
        }

        else{

            if(direction.x == 0 && direction.y == 0){
            selectedSprites = idleSpritesWalk;
            }

            if(direction.y > 0){
                if(Mathf.Abs(direction.x) > 0){
                    selectedSprites = neSpritesRun;
                }
                else{
                    selectedSprites = nSpritesRun;
                }
            }
            else if(direction.y < 0){
                if(Mathf.Abs(direction.x) > 0){
                    selectedSprites = seSpritesRun;
                }
                else{
                    selectedSprites = sSpritesRun;
                }
            }
            else{
                if(Mathf.Abs(direction.x) < 0){
                    selectedSprites = wSpritesRun;
                }


            }
        }

        



        return selectedSprites;

    }
}
