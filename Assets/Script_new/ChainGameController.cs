using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGameController : MonoBehaviour
{
    public GameObject tilePallete;
    public int row, column;
    public float maxDistance;
    Vector3 clickedPosition;
    GameObject instantiatedObject;
    void OnEnable()
    {
        
        // Debug.Log("Screen Width : "+Screen.width);
        // Debug.Log("Screen Height : "+Screen.height);
        // Debug.Log("Pixel Width : "+Camera.main.pixelWidth);
        // Debug.Log("Pixel Height : "+Camera.main.pixelHeight);

        // spawnPosition = transform.position;
        // Debug.Log("Screen Width : "+Camera.main.ScreenToWorldPoint());
        // SpawnTilePallete();
    }

    private void FixedUpdate() {
        if(Input.GetMouseButtonDown(0)){
            MouseClicked();
        }
    }
    
    void MouseClicked(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(clickedPosition, transform.TransformDirection(Vector3.forward));
        RaycastHit2D hitObject = Physics2D.Raycast(clickedPosition, transform.TransformDirection(Vector3.forward));
        if(hitObject){
            hitObject.transform.GetComponent<SpriteRenderer>().sprite = null;
        }
        // if(Physics.Raycast(ray)){
        //     Debug.Log("Hit something");
        // }
    }

    // private void OnDrawGizmos() {
    //     Gizmos.DrawIcon(
    //         clickedPosition,
    //         "Mouse Clicked Position"
    //     );
    // }
}
