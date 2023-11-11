using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    
    // void OnCollisionEnter(Collision collision) {
    //     foreach (ContactPoint contact in collision.contacts) {
    //         // Debug.DrawRay(contact.point, contact.normal * 10, Color.red); // Projects line from the collision, with normal pointing away from the collided object (i.e. not player)
    //         if (collision.collider.gameObject.layer == 9) {
    //             //Physics.IgnoreCollision(collision.collider.gameObject.GetComponent<Collider>(), GetComponent<Collider>());

    //             if (contact.normal.y < 0) {
    //                 Physics.IgnoreLayerCollision(9, 8, true);
    //             } else {
    //                 Physics.IgnoreLayerCollision(9, 8, false);
    //             }
                
    //         }
    //         Debug.Log("Collision!");
    //     }
    // }

}
