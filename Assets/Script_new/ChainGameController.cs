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
    int clickCount;
    Color recentAppliedColor;

    private void Start() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
        clickCount=0;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            MouseClicked();
        }
    }

    public void DisplayAtom(TilePallerController tileController){
        tileController.IncreaseAtomCount();
        if(clickCount%2 == 0){
            recentAppliedColor = Color.red;
        }else{
            recentAppliedColor = Color.yellow;
        }
        tileController.applyColor = recentAppliedColor;
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

    bool CheckRecentAppliedColor(TilePallerController tileObject){
        if(tileObject.applyColor == recentAppliedColor){
            return true;
        }
        return false;
    }
    
    void MouseClicked(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitObject = Physics2D.Raycast(clickedPosition, transform.TransformDirection(Vector3.forward));
        if(hitObject){
            tileController = hitObject.transform.GetComponent<TilePallerController>();
            if(hitObject.transform.childCount == 0 || !CheckRecentAppliedColor(tileController)){
                clickCount++;
                DisplayAtom(tileController);
            }
        }
    }
}
