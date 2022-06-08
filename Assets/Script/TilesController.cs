using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesController : MonoBehaviour
{
    public int noOfAtom,
                atomMovingSpeed;
    public GameObject singleAtom,
                        doubleAtom,
                        tripleAtom,
                        fourAtom;
    public AtomMoveDirection[] atomMovements;
    public AtomController[] movingAtoms;
    GameObject currentActiveAtom;
    Animator tileAnimator;
    Vector3 atomObjectPosition;

    private void Start() {
        noOfAtom = 0;
        GetComponent<Button>().onClick.AddListener(IncreaseAtom);
    }
    
    void IncreaseAtom(){
        if(currentActiveAtom != null){
            currentActiveAtom.SetActive(false);
        }
        noOfAtom++;
        switch(noOfAtom){
            case 1:
                singleAtom.SetActive(true);
                currentActiveAtom = singleAtom;
                break;
            case 2:
                doubleAtom.SetActive(true);
                currentActiveAtom = doubleAtom;
                break;
            case 3:
                tripleAtom.SetActive(true);
                currentActiveAtom = tripleAtom;
                break;
            case 4:
                fourAtom.SetActive(true);
                currentActiveAtom = fourAtom;
                break;
            default:
                noOfAtom = 0;
                break;
        }
        ReleaseAtom();
    }

    void ReleaseAtom(){
        if(noOfAtom == atomMovements.Length){
            currentActiveAtom.SetActive(false);
            for(int i=0; i<atomMovements.Length; i++){
                for(int j=0; j<movingAtoms.Length; j++){
                    if(!movingAtoms[j].gameObject.activeSelf){
                        StartAtomMovement(movingAtoms[j], atomMovements[i]);
                        return;
                    }
                }
            }
            // StartAtomMovement
            // for(int i=0; i<atomMovements.Length; i++){
            //     switch(atomMovements[i]){
            //         case AtomMoveDirection.Left:
            //             // movingAtoms[i].transform.position.x += (atomMovingSpeed * Time.deltaTime);
            //             break;
            //     }
            // }

        }
    }

    void StartAtomMovement(AtomController atomObject, AtomMoveDirection movementDirection){
        atomObject.gameObject.SetActive(true);
        atomObject.StartMovement(GameController.instance.atomMovementSpeed, movementDirection);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered from TilesController");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision from TilesController");
    }
}


public enum AtomMoveDirection{
    Left,
    Right,
    Top,
    Bottom
}