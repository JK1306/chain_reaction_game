using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGameController : MonoBehaviour
{
    public GameObject tilePallete, singleAtom, doubleAtom, tripleAtom;
    public int row, column;
    public float maxDistance, atomMovementSpeed;
    Vector3 clickedPosition;
    GameObject instantiatedObject;
    TilePallerController tileController;
    public static ChainGameController instance;

    private void Start() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            MouseClicked();
        }
    }

    public void DisplayAtom(TilePallerController tileController){
        tileController.IncreaseAtomCount();
        switch(tileController.atomCount){
            case 1:
                tileController.SetTileChild(singleAtom);
                break;
            case 2:
                tileController.SetTileChild(doubleAtom);
                break;
            case 3:
                tileController.SetTileChild(tripleAtom);
                break;
            case 4:
                tileController.ReleaseAtom();
                break;
        }
    }
    
    void MouseClicked(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitObject = Physics2D.Raycast(clickedPosition, transform.TransformDirection(Vector3.forward));
        if(hitObject){
            tileController = hitObject.transform.GetComponent<TilePallerController>();
            DisplayAtom(tileController);
        }
    }
}
