using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlowControllerlast; 


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

        public List<Sprite> attackAnim;

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

        List<Sprite> directionSprites;




        // Start is called before the first frame update
        void Start()
        {
            if (StateManager.increaseHeroSpeed == 0)
            {
                walkSpeed = 14;
            }
            else if (StateManager.increaseHeroSpeed == 1)
            {
                walkSpeed = 16;
            }
            else if (StateManager.increaseHeroSpeed == 2)
            {
                walkSpeed = 18;
            }
            else if (StateManager.increaseHeroSpeed == 3)
            {
                walkSpeed = 20;
            }

        }

        // Update is called once per frame
        void Update()
        {


            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            rb.velocity = direction * walkSpeed;
            HandleSpriteRenderer();

            if (Input.GetMouseButtonDown(0))
            {
                directionSprites = attackAnim;

            }

            else
            {
                directionSprites = SetSprite();
            }


            if (directionSprites != null)
            {

                float playTime = Time.time - idleTime;
                int frame = (int)((playTime * frameRate) % directionSprites.Count);
                spriteRenderer.sprite = directionSprites[frame];
            }
            else
            {
                idleTime = Time.time;
            }



        }




        void HandleSpriteRenderer()
        {
            if (!spriteRenderer.flipX && direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }

            else if (spriteRenderer.flipX && direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }

        List<Sprite> SetSprite()
        {

            List<Sprite> selectedSprites = null;

            if (!Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (direction.x == 0 && direction.y == 0)
                {
                    selectedSprites = idleSpritesWalk;
                }

                if (direction.y > 0)
                {
                    if (Mathf.Abs(direction.x) > 0)
                    {
                        selectedSprites = neSpritesWalk;
                    }
                    else
                    {
                        selectedSprites = nSpritesWalk;
                    }
                }
                else if (direction.y < 0)
                {
                    if (Mathf.Abs(direction.x) > 0)
                    {
                        selectedSprites = seSpritesWalk;
                    }
                    else
                    {
                        selectedSprites = sSpritesWalk;
                    }
                }
                else
                {
                    if (Mathf.Abs(direction.x) > 0)
                    {
                        selectedSprites = eSpritesWalk;
                    }


                }
            }

            else
            {

                if (direction.x == 0 && direction.y == 0)
                {
                    selectedSprites = idleSpritesWalk;
                }

                if (direction.y > 0)
                {
                    if (Mathf.Abs(direction.x) > 0)
                    {
                        selectedSprites = neSpritesRun;
                    }
                    else
                    {
                        selectedSprites = nSpritesRun;
                    }
                }
                else if (direction.y < 0)
                {
                    if (Mathf.Abs(direction.x) > 0)
                    {
                        selectedSprites = seSpritesRun;
                    }
                    else
                    {
                        selectedSprites = sSpritesRun;
                    }
                }
                else
                {
                    if (Mathf.Abs(direction.x) < 0)
                    {
                        selectedSprites = wSpritesRun;
                    }


                }
            }





            return selectedSprites;

        }
    }
