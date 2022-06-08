using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomController : MonoBehaviour
{
    float movementSpeed;
    Vector3 atomPosition;
    bool canMove;
    AtomMoveDirection movementDir;
    public void StartMovement(float speed, AtomMoveDirection direction){
        this.movementSpeed = speed;
        this.movementDir = direction;
        canMove = true;
    }

    private void Update() {
        if(!canMove){ return; }
        atomPosition = transform.position;
        switch(this.movementDir){
            case AtomMoveDirection.Left:
                atomPosition += Vector3.left * (movementSpeed*Time.deltaTime);
                break;
            case AtomMoveDirection.Right:
                atomPosition += Vector3.right * (movementSpeed*Time.deltaTime);
                break;
            case AtomMoveDirection.Top:
                atomPosition += Vector3.up * (movementSpeed*Time.deltaTime);
                break;
            case AtomMoveDirection.Bottom:
                atomPosition += Vector3.down * (movementSpeed*Time.deltaTime);
                break;
        }
        transform.position = atomPosition;
    }

    private void OnDisable() {
        canMove = false;
    }
}
