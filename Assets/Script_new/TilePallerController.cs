using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePallerController : MonoBehaviour
{
    public int atomCount { get; private set; }
    GameObject instantiatedObject;
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
    }
}
