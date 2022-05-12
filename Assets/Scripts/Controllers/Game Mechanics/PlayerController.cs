using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // level information
    private Transform levelTransform;

    private LayerMask blockLayer;
    private LayerMask groundLayer;
    private LayerMask boxLayer;
    private LayerMask boxHeldLayer;
    private LayerMask wallLayer;
    private LayerMask buttonLayer;

    private int numButtons;
    private int numObstacles;
    private bool hasObstacles;

    // player information
    private Rigidbody2D body;
    private Animator move;
    private BoxCollider2D boxCollider;
    private float speed;
    private float jumpPower;
    public int onBoxID;
    public bool canEnter;
    private float jumpCoolDown;
    private float horizontalInput;

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

        hasObstacles = this.transform.parent.GetComponent<LevelController>().hasObstacles;
        if(hasObstacles){
            numObstacles = this.transform.parent.GetChild(6).childCount;
        } else {
            numObstacles = 0;
        }
        
        // set player information
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
        if(Input.GetKey(KeyCode.E))
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

        // check if box on head
        if(handsEmpty){
            onHead();
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

        // if on side of object - slide down to ground
        if(!isGrounded() && againstObject()){
            body.velocity = new Vector2(0, body.velocity.y);
        }

        // check jump cool down
        if(jumpCoolDown > 0.2f){

            if(isGrounded() && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))){
                // jump
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                move.SetTrigger("Jump"); // change animation

                jumpCoolDown = 0;
            }

        } else {
            jumpCoolDown += Time.deltaTime;
        }        

    }

    private void pickUp()
    {   
        // casts rays only on boxes (excludes the box held if there is one, excludes the box trigger colliders)
        RaycastHit2D grabCheck = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.right * transform.localScale, 0.5f, boxLayer);
        RaycastHit2D grabCheckDown = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.5f, boxLayer);

        int tempBoxID = 0;

        if(grabCheck.collider != null && grabCheck.collider.tag == "Box"){
            tempBoxID = grabCheck.collider.gameObject.GetComponent<BoxController>().boxID;
            // pick up
            grabCheck.collider.gameObject.transform.parent = boxHolder;
            grabCheck.collider.gameObject.transform.position = boxHolder.position;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabCheck.collider.gameObject.GetComponent<BoxController>().isHeld = true;

            grabCheck.collider.gameObject.layer = 11; // put in box held layer, therefore can check for held box and can jump when holding box

            handsEmpty = false;
            holdingBoxID = tempBoxID;
            pickUpCoolDown = 0;

            // set box velocity to 0, 0 to prevent sliding
            this.transform.GetChild(1).GetChild(0).GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

            // get 'items on button' lists from each button, if contains box id then remove from list
            for(int i = 0; i < numButtons; i++){
                if(this.transform.parent.GetChild(3).GetChild(i).GetChild(1).GetComponent<Pressable>().itemsOnbutton.Contains(tempBoxID)){
                    this.transform.parent.GetChild(3).GetChild(i).GetChild(1).GetComponent<Pressable>().itemsOnbutton.Remove(tempBoxID);
                }
            }

            if(hasObstacles){
                // get 'boxes in area' list for each obstacle, if contains box id then remove it
                for(int j = 0; j < numObstacles; j++){
                    if(this.transform.parent.GetChild(6).GetChild(j).GetChild(0).GetComponent<detectBoxes>().boxesInArea.Contains(tempBoxID)){
                        this.transform.parent.GetChild(6).GetChild(j).GetChild(0).GetComponent<detectBoxes>().boxesInArea.Remove(tempBoxID);
                    }
                }
            }

        } 

        // pick up box below player
        if(grabCheck.collider == null && grabCheckDown.collider != null && grabCheckDown.collider.tag == "Box")
        {
            tempBoxID = grabCheckDown.collider.gameObject.GetComponent<BoxController>().boxID;
            // pick up
            grabCheckDown.collider.gameObject.transform.parent = boxHolder;
            grabCheckDown.collider.gameObject.transform.position = boxHolder.position;
            grabCheckDown.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabCheckDown.collider.gameObject.GetComponent<BoxController>().isHeld = true;

            grabCheckDown.collider.gameObject.layer = 11; // put in box held layer, therefore can check for held box and can jump when holding box

            handsEmpty = false;
            holdingBoxID = tempBoxID;
            pickUpCoolDown = 0;

            // get 'items on button' lists from each button, if contains box id then remove from list
            for(int i = 0; i < numButtons; i++){
                if(this.transform.parent.GetChild(3).GetChild(i).GetChild(1).GetComponent<Pressable>().itemsOnbutton.Contains(tempBoxID)){
                    this.transform.parent.GetChild(3).GetChild(i).GetChild(1).GetComponent<Pressable>().itemsOnbutton.Remove(tempBoxID);
                }
            }

            if(hasObstacles){
                // get 'boxes in area' list for each obstacle, if contains box id then remove it
                for(int j = 0; j < numObstacles; j++){
                    if(this.transform.parent.GetChild(6).GetChild(j).GetChild(0).GetComponent<detectBoxes>().boxesInArea.Contains(tempBoxID)){
                        this.transform.parent.GetChild(6).GetChild(j).GetChild(0).GetComponent<detectBoxes>().boxesInArea.Remove(tempBoxID);
                    }
                }
            }

            // set box velocity to 0, 0 to prevent sliding
            this.transform.GetChild(1).GetChild(0).GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            
        }

    }

    private void putDown()
    {   
        // check if player is holding box, check for walls, put box behind player if wall detected
        RaycastHit2D holdCheck = Physics2D.Raycast(holdDetect.position, Vector2.up, rayDist, boxHeldLayer);


        if(holdCheck.collider != null && holdCheck.collider.tag == "Box"){

            holdCheck.collider.gameObject.transform.parent = boxContainer;
            holdCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            holdCheck.collider.gameObject.GetComponent<BoxController>().isHeld = false;

            holdCheck.collider.gameObject.layer = 9; // put back in box layer

            handsEmpty = true;
            holdingBoxID = 0;
            pickUpCoolDown = 0;

            if(putBehind()){
                // if hit wall or obstacle, put down in behind position
                holdCheck.collider.gameObject.transform.position = placeBehind.position;
            } else {
                // put down in front
                holdCheck.collider.gameObject.transform.position = place.position;
            }

        } else {
            // if game glitches and box is not directly above players head 

            // box is stored in 'boxholder' parent in player object
            int boxholding = this.transform.GetChild(1).childCount;

            // if box is held
            if(boxholding != 0){
                this.transform.GetChild(1).GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                this.transform.GetChild(1).GetChild(0).GetComponent<BoxController>().isHeld = false;

                this.transform.GetChild(1).GetChild(0).gameObject.layer = 9; // put back in box layer

                handsEmpty = true;
                holdingBoxID = 0;
                pickUpCoolDown = 0;

                if(putBehind()){
                    // if hit wall or obstacle, put down in behind position
                    this.transform.GetChild(1).GetChild(0).gameObject.transform.position = placeBehind.position;
                } else {
                    // put down in front
                    this.transform.GetChild(1).GetChild(0).gameObject.transform.position = place.position;
                }

                this.transform.GetChild(1).GetChild(0).gameObject.transform.parent = boxContainer;
                
            }

        }
    }

    // function determines if the box needs to be placed behind the player if there is an obstruction in front
    private bool putBehind()
    {
        // check for walls and obstacles, put box behind player if wall or obstacle detected
        RaycastHit2D wallCheck = Physics2D.Raycast(boxHolder.position, Vector2.right * transform.localScale, 1.3f, wallLayer);
        RaycastHit2D obsCheck = Physics2D.Raycast(boxHolder.position, Vector2.right * transform.localScale, 1.3f, blockLayer);
        RaycastHit2D boxCheck = Physics2D.Raycast(boxHolder.position, Vector2.right * transform.localScale, 1.3f, boxLayer);
        
        if(wallCheck.collider != null || obsCheck.collider != null || boxCheck.collider != null){
            return true;
        } else {
            return false;
        }
    }

    // check for a box on players head
    private void onHead()
    {
        RaycastHit2D aboveCheck = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size/2, 0, Vector2.up, 0.4f, boxLayer);
        
        if(aboveCheck.collider != null && aboveCheck.collider.tag == "Box"){

            if(putBehind()){
                // if hit wall or obstacle, put down in behind position
                aboveCheck.collider.gameObject.transform.position = placeBehind.position;
            } else {
                // put down in front
                aboveCheck.collider.gameObject.transform.position = place.position;
            }

        }

    }

    // function allows player to go to next level
    private void enterDoor()
    {
        if(canEnter && handsEmpty)
        {
            // call to change scene
            this.transform.parent.GetComponent<LevelController>().nextLevel();
        }
    }

    // function returns whether or not the player is on the ground
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

    // function returns whether or not the player is against an object
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
