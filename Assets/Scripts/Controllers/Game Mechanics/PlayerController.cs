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
    private LayerMask buttonLayer;

    private int numButtons;

    // player info
    private Rigidbody2D body;
    private Animator move;
    private BoxCollider2D boxCollider;
    private float speed;
    private float jumpPower;
    public int onBoxID;
    public bool canEnter;

    // grab controller
    public bool handsEmpty;
    private int holdingBoxID;
    private float rayDist;
    private float pickUpCoolDown;

    private Transform boxContainer;
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
        // get level data       
        wallLayer = this.transform.parent.GetComponent<LevelController>().wallLayer;
        boxLayer = this.transform.parent.GetComponent<LevelController>().boxLayer;
        groundLayer = this.transform.parent.GetComponent<LevelController>().groundLayer;
        blockLayer = this.transform.parent.GetComponent<LevelController>().blockLayer;
        boxHeldLayer = this.transform.parent.GetComponent<LevelController>().boxHeldLayer;
        buttonLayer = this.transform.parent.GetComponent<LevelController>().buttonLayer;

        levelTransform = this.transform.parent.GetComponent<Transform>();
        numButtons = this.transform.parent.GetChild(3).childCount;

        // player info
        speed = 8;
        jumpPower = 15;
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 4;
        move = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        onBoxID = 0;

        // grab controller
        handsEmpty = true;
        rayDist = 1;
        holdingBoxID = 0; // 0 means hands empty
        grabDetect = this.transform.GetChild(0).GetComponent<Transform>();
        boxHolder = this.transform.GetChild(1).GetComponent<Transform>();
        place = this.transform.GetChild(2).GetComponent<Transform>();
        holdDetect = this.transform.GetChild(3).GetComponent<Transform>();
        placeBehind = this.transform.GetChild(4).GetComponent<Transform>();

        boxContainer = this.transform.parent.GetChild(4).GetComponent<Transform>();

        // door enter controller
        canEnter = false;
    }
    
    // runs on every frame
    private void Update()
    {   
        // check if player can enter door
        if(Input.GetKey(KeyCode.W))
            enterDoor();

        if(pickUpCoolDown > 0.2f)
        {
            // call to pick up or put down box
            if(Input.GetKeyDown(KeyCode.F))
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

        // set animator preferences
        move.SetBool("Run", horizontalInput != 0);
        move.SetBool("Grounded", isGrounded());

        // update player movement
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if(isGrounded()){

            // check jump cool down
            if(jumpCoolDown > 0.25f){
                
                if(Input.GetKey(KeyCode.Space)){

                    // jump
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                    move.SetTrigger("Jump"); // changes animation

                    jumpCoolDown = 0;

                }
            } else {
                jumpCoolDown += Time.deltaTime;
            }

        } else {
            // if on side of object - slide down to ground
            if(againstObject()){
                body.velocity = new Vector2(0, body.velocity.y);
            }
        }
        

    }

    private void pickUp()
    {   
        // check if there is a box to pick up, if yes, pick up box
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist, boxLayer);
        int tempBoxID = 0;

        if(grabCheck.collider != null && grabCheck.collider.tag == "Box"){
            tempBoxID = grabCheck.collider.gameObject.GetComponent<BoxController>().boxID;
            // pick up
            grabCheck.collider.gameObject.transform.parent = boxHolder;
            grabCheck.collider.gameObject.transform.position = boxHolder.position;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabCheck.collider.gameObject.GetComponent<BoxController>().isHeld = true;

            grabCheck.collider.gameObject.layer = 11; // put in box held layer, therefore can check for held box and jump

            handsEmpty = false;
            holdingBoxID = tempBoxID;
            pickUpCoolDown = 0;

            // get 'items on button' lists from each button, if contains box id then remove from list
            for(int i = 0; i < numButtons; i++){
                if(this.transform.parent.GetChild(3).GetChild(i).GetChild(1).GetComponent<Pressable>().itemsOnbutton.Contains(tempBoxID)){
                    this.transform.parent.GetChild(3).GetChild(i).GetChild(1).GetComponent<Pressable>().itemsOnbutton.Remove(tempBoxID);
                }
            }
        } 
    }

    private void putDown()
    {   
        // check if player is holding box, check for walls, put box behind player if wall detected
        RaycastHit2D holdCheck = Physics2D.Raycast(holdDetect.position, Vector2.up, rayDist, boxHeldLayer);
        RaycastHit2D wallCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, 1.2f, wallLayer);

        if(holdCheck.collider != null && holdCheck.collider.tag == "Box"){

            holdCheck.collider.gameObject.transform.parent = boxContainer;
            holdCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            holdCheck.collider.gameObject.GetComponent<BoxController>().isHeld = false;

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

    private bool isGrounded()
    {   
        // casts rays only on ground 
        RaycastHit2D groundHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
        // casts rays only on boxes (excludes the box held if there is one, excludes the box trigger colliders)
        RaycastHit2D boxHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.2f, boxLayer);
        // casts rays only on blocks
        RaycastHit2D blockHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.2f, blockLayer);
        // casts rays only on physical buttons (includes buttons physical part, excludes button trigger collider)
        RaycastHit2D buttonHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.2f, buttonLayer);

        if(boxHit.collider != null || groundHit.collider != null || blockHit.collider != null || buttonHit.collider != null){
            return true;
        } else {
            return false;
        }
    }

    private bool againstObject()
    {
        // casts rays only on wall
        RaycastHit2D raycastWall = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        // casts rays against physical boxes (excludes box trigger colliders)
        RaycastHit2D raycastBox = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, boxLayer);
        // casts rays only on blocks
        RaycastHit2D raycastBlocks = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, blockLayer);
        // casts rays only on physical buttons (includes buttons physical part, excludes button trigger collider)
        RaycastHit2D raycastButton = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, buttonLayer);

        // casts rays only on ground objects - platforms
        RaycastHit2D raycastGround = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, groundLayer);


        if(raycastBox.collider != null || raycastButton.collider != null || raycastWall.collider != null || raycastBlocks.collider != null || raycastGround.collider != null){
            return true;
        } else {
            return false;
        }
    }
}
