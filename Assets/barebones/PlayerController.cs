using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Keyboard
    public float speed = 10.0F;

    // Mouse
    Vector2 mLook;
    Vector2 mSmoothV;
    public float mSensitivity = 5.0F;
    public float mSmoothing = 2.0F;

    // General
    public GameObject player;
    public new GameObject camera;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        //player = this.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        // Escape Key for Menu
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
        
        // Keyboard Input
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        // Mouse Input
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(mSensitivity * mSmoothing, mSensitivity * mSmoothing));
        mSmoothV.x = Mathf.Lerp(mSmoothV.x, md.x, 1f / mSmoothing);
        mSmoothV.y = Mathf.Lerp(mSmoothV.y, md.y, 1f / mSmoothing);
        mLook += mSmoothV;
        mLook.y = Mathf.Clamp(mLook.y, -45f, 45f);
        camera.transform.localRotation = Quaternion.AngleAxis(-mLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mLook.x, player.transform.up);
    }
}
