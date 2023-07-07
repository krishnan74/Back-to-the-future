using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
 {
    public static readonly string[] staticDirections = { "N-Idle", "NW-Idle", "W-Idle", "SW-Idle", "Idle", "SE-Idle", "E-Idle", "NE-Idle" };
    public static readonly string[] runDirections = {"N-walk", "NW-walk", "W-walk", "SW-walk", "S-walk", "SE-walk", "E-walk", "NE-walk"};
    
    Animator animator;
    int lastDirection;
    
    private void Awake(){
        //cache the animator component
        animator = GetComponent<Animator>();
    }
    
    public void SetDirection(Vector2 direction, bool flag){
        //use the Run states by default
        string[] directionArray = null;   
           
        if(flag){
            

            directionArray = runDirections;  
            lastDirection = DirectionToIndex(direction, 8);
        animator.Play(directionArray[lastDirection]);
        }
        else{   
             directionArray = runDirections;  
            lastDirection = DirectionToIndex(direction, 8);
            animator.Play(staticDirections[lastDirection]);

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