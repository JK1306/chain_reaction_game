using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePallerController : MonoBehaviour
{
    public int atomCount { get; private set; }
    public AtomController movingAtom;
    GameObject instantiatedObject;
    AtomController spawnedObject;
    int childCount;

    private void Start() {
        atomCount = 0;
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
}
