using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePallerController : MonoBehaviour
{
    public int atomCount { get; private set; }
    GameObject instantiatedObject;

    private void Start() {
        atomCount = 0;
    }

    public void SetTileChild(GameObject atomGameObject){
        atomCount++;
        instantiatedObject = Instantiate(atomGameObject, gameObject.transform);
    }

    public void ResetAtomCount(){
        atomCount = 0;
    }
}
