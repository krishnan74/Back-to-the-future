using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
 {
    public static readonly string[] staticDirections = { "Idle" };
    public static readonly string[] runDirections = {"Run N", "NW-walk", "Run W", "SW-walk", "S-walk", "SE-walk", "Run E", "NE-walk"};
    
    Animator animator;
    int lastDirection;
    
    private void Awake(){
        //cache the animator component
        animator = GetComponent<Animator>();
    }
    
    public void SetDirection(Vector2 direction, bool flag){
        //use the Run states by default
        if(flag){
            string[] directionArray = null;

            directionArray = runDirections;  
            lastDirection = DirectionToIndex(direction, 8);
        animator.Play(directionArray[lastDirection]);
        }
        else{ 
            animator.Play(staticDirections[0]);

        }
    } 


    public static int DirectionToIndex(Vector2 dir, int sliceCount){ 
        
        Vector2 normDir = dir.normalized; 
        float step = 360f/sliceCount;  
        float halfstep = step/2;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);

        angle+=halfstep;   
        if(angle<0){
            angle+= 360;
        } 
         
        float stepCount = angle/step; 

        return Mathf.FloorToInt(stepCount);
    } 
 }