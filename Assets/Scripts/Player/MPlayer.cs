using UnityEngine;

public class MPlayer : MonoBehaviour {
    public static bool canView=true, canWalk=true, canFall=true, canJump=true;
    public static float camSensitivity=20f, camST, mx, my, xrot;
    public static float walkSpeed=8f, runSpeed=2f, gravity=-9.81f, jumpHeight=3f, groundSize=0.4f;
	public LayerMask groundLayer;
	Vector3 velocity;
	bool isGrounded;
	Transform cam;
	CharacterController cc;

	private void Start() {
		GManager.ResumeGame();
		cam = transform.Find("Cam");
		cc = GetComponent<CharacterController>();
	}	
	private void Update() {
		if(canView) {PView(KeyEvents.viewDir); PCursor(false);} else PCursor(true);
		if(canWalk) PMove(KeyEvents.moveDir);
		if(canFall) PApplyGravity();
		if(KeyEvents.onToggleConsole || KeyEvents.onPause) PCursor(true);
	}

	public static void setCanStats(bool t) {canView=t; canWalk=t; canJump=t; canFall=t;}

	void PCursor(bool toggle) {
		if(toggle) {Cursor.visible=true; Cursor.lockState=CursorLockMode.None;}
		else {Cursor.visible=false; Cursor.lockState=CursorLockMode.Locked;}
	}
	void PView(Vector2 tView) {
		camST = (Application.targetFrameRate/(camSensitivity/2))*2;
		mx = tView.x * camST * Time.deltaTime;
		my = tView.y * camST * Time.deltaTime;
		xrot-=my; xrot=Mathf.Clamp(xrot,-90f,90f);
		cam.transform.localRotation = Quaternion.Euler(Vector3.right * xrot);
		transform.Rotate(Vector3.up * mx);
	}
	void PMove(Vector2 tWalk) {
		float x = tWalk.x;
		float z = tWalk.y;
		Vector3 move = (transform.right*x + transform.forward*z) * (KeyEvents.isRunning?walkSpeed*runSpeed : walkSpeed) * Time.deltaTime;
		cc.Move(move);
	}
	void PApplyGravity() {
		isGrounded = Physics.CheckSphere(transform.position, groundSize, groundLayer);
		if(KeyEvents.isJumping && isGrounded && canJump) {velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);}
		if(isGrounded && velocity.y < 0 && gravity < 0) {velocity.y = -2f;}
		velocity.y += gravity * Time.deltaTime;
		cc.Move(velocity * Time.deltaTime);
	}
}
