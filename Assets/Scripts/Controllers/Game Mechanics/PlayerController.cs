using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // level info
    private Transform levelTransform;

    private LayerMask blockLayer;
    private LayerMask groundLayer;
    private LayerMask boxLayer;
    private LayerMask boxHeldLayer;
    private LayerMask wallLayer;

    // player info
    private Rigidbody2D body;
    private Animator move;
    private BoxCollider2D boxCollider;
    private float speed;
    private float jumpPower;

    public bool canEnter;

    // grab controller
    public bool handsEmpty;
    private int holdingBoxID;
    private float rayDist;
    private float pickUpCoolDown;
    private Transform grabDetect;
    private Transform boxHolder;
    private Transform place;
    private Transform holdDetect;
    private Transform placeBehind;

    private float jumpCoolDown;
    private float horizontalInput;

    // runs when the script is loaded
    private void Awake()
    {   
        // store layer data        
        wallLayer = this.transform.parent.GetComponent<LevelController>().wallLayer;
        boxLayer = this.transform.parent.GetComponent<LevelController>().boxLayer;
        groundLayer = this.transform.parent.GetComponent<LevelController>().groundLayer;
        blockLayer = this.transform.parent.GetComponent<LevelController>().blockLayer;
        boxHeldLayer = this.transform.parent.GetComponent<LevelController>().boxHeldLayer;

        levelTransform = this.transform.parent.GetComponent<Transform>();

        // player info
        speed = 8;
        jumpPower = 12;
        body = GetComponent<Rigidbody2D>();
        move = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        // grab controller
        handsEmpty = true;
        rayDist = 1;
        holdingBoxID = 0; // 0 means hands empty
        grabDetect = this.transform.GetChild(0).GetComponent<Transform>();
        boxHolder = this.transform.GetChild(1).GetComponent<Transform>();
        place = this.transform.GetChild(2).GetComponent<Transform>();
        holdDetect = this.transform.GetChild(3).GetComponent<Transform>();
        placeBehind = this.transform.GetChild(4).GetComponent<Transform>();

        // door enter controller
        canEnter = false;
    }
    
    // runs on every frame
    private void Update()
    {   
        if(Input.GetKey(KeyCode.E))
            enterDoor();

        if(pickUpCoolDown > 0.2f)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                if(handsEmpty)
                {
                    pickUp();
                } else {
                    putDown();
                }
            }

        } else {
            pickUpCoolDown += Time.deltaTime;
        }
        
        // gets input from left and right arrow keys, negative = left, positive = right
        horizontalInput = Input.GetAxis("Horizontal");

        // flip player when moving laterally
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < 0.0f)
            transform.localScale = new Vector3(-1, 1, 1);

        // set  animator preferences
        move.SetBool("Run", horizontalInput != 0);
        move.SetBool("Grounded", isGrounded());

        // wall jump logic
        if (jumpCoolDown > 0.4f) // if jumping is allowed
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            body.gravityScale = 4;
            
            if(onWall() && !isGrounded())
            {   
                body.velocity = new Vector2(0, body.velocity.y);
            }
            
            if(Input.GetKey(KeyCode.Space))
                Jump();

        } else {
            jumpCoolDown += Time.deltaTime;
        }

    }

    private void pickUp()
    {   
        // check if there is a box to pick up, if yes, pick up box
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist, boxLayer);

        if(grabCheck.collider != null && grabCheck.collider.tag == "Box"){
            // pick up
            grabCheck.collider.gameObject.transform.parent = boxHolder;
            grabCheck.collider.gameObject.transform.position = boxHolder.position;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabCheck.collider.gameObject.GetComponent<PickUpable>().isHeld = true;
            grabCheck.collider.gameObject.layer = 11; // put in box held layer, can check for held box and jump
            handsEmpty = false;
            holdingBoxID = grabCheck.collider.gameObject.GetComponent<PickUpable>().boxID;
            pickUpCoolDown = 0;
        } 
    }

    private void putDown()
    {   
        // check if player is holding box, check for walls, put box behind player if wall detected
        RaycastHit2D holdCheck = Physics2D.Raycast(holdDetect.position, Vector2.up, rayDist, boxHeldLayer);
        RaycastHit2D wallCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist, wallLayer);

        if(holdCheck.collider != null && holdCheck.collider.tag == "Box"){

            holdCheck.collider.gameObject.transform.parent = levelTransform;
            holdCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            holdCheck.collider.gameObject.GetComponent<PickUpable>().isHeld = false;
            holdCheck.collider.gameObject.layer = 9; // put back in box layer
            handsEmpty = true;
            holdingBoxID = 0;

            if(wallCheck.collider != null)
            {
                // if hit wall, put down in behind position
                holdCheck.collider.gameObject.transform.position = placeBehind.position;
            } else {
                // put down in front
                holdCheck.collider.gameObject.transform.position = place.position;
            }
            
        } 
    }

    private void enterDoor()
    {
        if(canEnter && handsEmpty)
        {
            this.transform.parent.GetComponent<LevelController>().nextLevel();
        }
    }
    
    private void Jump()
    {   
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            move.SetTrigger("Jump"); // changes animation

        } 
        else if(onWall() && !isGrounded())
        {   
            if(horizontalInput == 0)
            {   
                // jumping off wall
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            } else {
                // jumping up wall
                // 3 is the power at which the player is pushed away from the wall, 6 is the force at which player will be pushed up, can change these
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                body.gravityScale = 2;
            }

            // reset
            jumpCoolDown = 0;
        }
    }

    private bool isGrounded()
    {   
        // casts rays only on ground (includes buttons (buttons are ground layer))
        RaycastHit2D groundHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.3f, groundLayer);
        // casts rays only on boxes (excludes the box held if there is one)
        RaycastHit2D boxHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.3f, boxLayer);
        // casts rays only on blocks
        RaycastHit2D blockHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.3f, blockLayer);

        if(boxHit.collider != null || groundHit.collider != null || blockHit.collider != null)
        {
            return true;
        } else {
            return false;
        }
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

}
