using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePallerController : MonoBehaviour
{
    public int atomCount { get; private set; }
    public AtomController movingAtom;
    public List<AtomMoveDirection> collidedObjectDirection;
    public bool execute;
    GameObject instantiatedObject;
    AtomController spawnedObject;
    int childCount;
    Vector3 objectDirection, upDirection, rightDirection;

    private void Start() {
        atomCount = 0;
        collidedObjectDirection = new List<AtomMoveDirection>();
        upDirection = transform.up;
        rightDirection = transform.right;
        // Debug.Log("In start : ");
        // Debug.Log("Up : "+(-transform.up));
        // Debug.Log("Down : "+(-transform.right));
        // Debug.Log("Left : "+transform.left);
        // Debug.Log("Right : "+transform.right);
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
        instantiatedObject = Instantiate(atomGameObject, gameObject.transform);
    }

    public void ResetAtomCount(){
        atomCount = 0;
        DestroyChild();
        spawnedObject = Instantiate<AtomController>(movingAtom, gameObject.transform);
        spawnedObject.StartMovement(ChainGameController.instance.atomMovementSpeed, AtomMoveDirection.Right);
    }

    void GetDirection(Vector3 otherAtomDirection){
        Debug.Log("Other Gameobject : "+otherAtomDirection);
        Debug.Log("Down : "+(-(transform.up.normalized)));
        Debug.Log("tranform up : "+(-(transform.up.normalized) == otherAtomDirection));
        if(otherAtomDirection.Equals(transform.up.normalized)){
            collidedObjectDirection.Add(AtomMoveDirection.Top);
        }else if(otherAtomDirection.Equals(-(transform.up.normalized))){
            collidedObjectDirection.Add(AtomMoveDirection.Bottom);
        }else if(otherAtomDirection.Equals(transform.right.normalized)){
            collidedObjectDirection.Add(AtomMoveDirection.Right);
        }else if(otherAtomDirection.Equals(-(transform.right.normalized))){
            collidedObjectDirection.Add(AtomMoveDirection.Left);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!execute) { return; }
        if(other.gameObject.TryGetComponent(out TilePallerController _)){
            objectDirection = other.gameObject.transform.position - transform.position;
            objectDirection.Normalize();
            GetDirection(objectDirection);
            Debug.Log(gameObject.name+" Collision Detected : "+other.gameObject.name+" Direction : "+objectDirection, other.gameObject);
        }
    }
}
