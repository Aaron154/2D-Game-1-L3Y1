using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //Tell Unity to add theses components to the gameobject this code is attached to.
[RequireComponent(typeof(BoxCollider2D))] //We will still need to tweak some of the settings.
 public class RigidbodyMovement : MonoBehaviour
{   
   Rigidbody2D rb2d;
   public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        // Normalize the vector so that we don't move faster when moving diagonally.
        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();

        // Assign velocity directly to the Rigidbody
     rb2d.velocity = moveDirection * moveSpeed;
    }
}