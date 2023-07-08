using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    public List<Sprite> swSprites;
    public List<Sprite> wSprites;
    public List<Sprite> nwSprites;
    public List<Sprite> idleSprites;


    public float walkSpeed;
    public float frameRate;

    float idleTime;

    Vector2 direction;

    private Collider2D coll;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();

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
            coll.enabled = false; // Disable the Collider
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            coll.enabled = true; // Enable the Collider
        }

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

        if(direction.x == 0 && direction.y == 0){
            selectedSprites = idleSprites;
        }

        if(direction.y > 0){
            if(Mathf.Abs(direction.x) > 0){
                selectedSprites = neSprites;
            }
            else{
                selectedSprites = nSprites;
            }
        }
        else if(direction.y < 0){
            if(Mathf.Abs(direction.x) > 0){
                selectedSprites = seSprites;
            }
            else{
                selectedSprites = sSprites;
            }
        }
        else{
            if(Mathf.Abs(direction.x) > 0){
                selectedSprites = eSprites;
            }

        }



        return selectedSprites;

    }
}
