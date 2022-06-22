using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePallerController : MonoBehaviour
{
    public int atomCount { get; private set; }
    public AtomController movingAtom;
    public List<AtomMoveDirection> collidedObjectDirection;
    GameObject instantiatedObject;
    AtomController spawnedObject;
    int childCount;
    Vector3 objectDirection, upDirection, rightDirection;

    private void Start() {
        atomCount = 0;
        collidedObjectDirection = new List<AtomMoveDirection>();
        upDirection = transform.up;
        rightDirection = transform.right;
    }

    void DestroyChild(){
        childCount = transform.childCount;
        for(int i=0; i<childCount; i++){
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    public void IncreaseAtomCount(){
        ++atomCount;
    }

    public void SetTileChild(GameObject atomGameObject){
        DestroyChild();
        if(atomCount == collidedObjectDirection.Count){
            ReleaseAtom();
        }else{
            instantiatedObject = Instantiate(atomGameObject, gameObject.transform);
        }
    }

    public void ReleaseAtom()
    {
        ResetAtomCount();
        foreach(AtomMoveDirection direction in collidedObjectDirection){
            spawnedObject = Instantiate<AtomController>(movingAtom, gameObject.transform);
            spawnedObject.StartMovement(ChainGameController.instance.atomMovementSpeed, direction);
        }
    }

    void ResetAtomCount(){
        atomCount = 0;
        DestroyChild();
    }

    bool CompareVector(Vector3 vector1, Vector3 vector2){
        if(Convert.ToInt32(vector1.x) == Convert.ToInt32(vector2.x) && Convert.ToInt32(vector1.y) == Convert.ToInt32(vector2.y) && Convert.ToInt32(vector1.z) == Convert.ToInt32(vector2.z)){
            return true;
        }
        return false;
    }

    void GetDirection(Vector3 otherAtomDirection){
        if(CompareVector(otherAtomDirection, transform.up.normalized)){
            collidedObjectDirection.Add(AtomMoveDirection.Top);
        }else if(CompareVector(otherAtomDirection, -(transform.up.normalized))){
            collidedObjectDirection.Add(AtomMoveDirection.Bottom);
        }else if(CompareVector(otherAtomDirection, transform.right.normalized)){
            collidedObjectDirection.Add(AtomMoveDirection.Right);
        }else if(CompareVector(otherAtomDirection, -(transform.right.normalized))){
            collidedObjectDirection.Add(AtomMoveDirection.Left);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent(out TilePallerController _)){
            objectDirection = other.gameObject.transform.position - transform.position;
            objectDirection.Normalize();
            GetDirection(objectDirection);
        }
    }
}
