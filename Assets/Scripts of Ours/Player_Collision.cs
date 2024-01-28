using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    private GameObject playerObject;
    private GameObject otherObj;
    private Rigidbody playerRigidBody;

    void Start()
    {
        playerObject = gameObject;
        playerRigidBody = playerObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        otherObj = collision.gameObject;
    }

    private void OnCollisionStay(Collision collision)
    {
        BoxCollider otherBoxCollider = otherObj.GetComponent<BoxCollider>();
        CapsuleCollider playerBoxCollider = playerObject.GetComponent<CapsuleCollider>();

        if (collision.gameObject == otherObj)
        { 
            print("collision with box");
            playerRigidBody.velocity = Vector3.zero;
            playerRigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        print("Exit");
    }

}
