using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesController : MonoBehaviour
{
    public int noOfAtom;
    public GameObject singleAtom,
                        doubleAtom,
                        tripleAtom;
    GameObject currentActiveAtom;
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
            default:
                noOfAtom = 0;
                break;
        }
    }

    void ReleaseAtom(){

    }

    private void OnCollisionStay2D(Collision2D other) {
        Debug.Log("Collision : "+other.contacts.Length);
    }
}
