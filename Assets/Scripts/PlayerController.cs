using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Variables

    // Level Settings
    private Rigidbody rb;
    private string levelNumber;
    public float speed;
    public Text levelText;
    public GameObject levelInfo;

    // Mouse Controls (Disabled)
    Vector2 mLook;
    Vector2 mSmoothV;
    public float mSensitivity = 5.0F;
    public float mSmoothing = 2.0F;
    public Camera camera;
    public GameObject playerHost;

    void Start ()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        LevelInfo();
    }

    void FixedUpdate()
    {
        // Rigidbody Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement);

        // Escape Key for Menu Exit
        if (Input.GetKeyDown("escape"))
        {
            //Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }

        // Mouse Input (Disabled)
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(mSensitivity * mSmoothing, mSensitivity * mSmoothing));
        mSmoothV.x = Mathf.Lerp(mSmoothV.x, md.x, 1f / mSmoothing);
        mSmoothV.y = Mathf.Lerp(mSmoothV.y, md.y, 1f / mSmoothing);
        mLook += mSmoothV;
        mLook.y = Mathf.Clamp(mLook.y, -45f, 45f);
        mLook.x = Mathf.Clamp(mLook.x, -45f, 45f);
        //camera.transform.localRotation = Quaternion.AngleAxis(-mLook.y, Vector3.right);
        //playerHost.transform.localRotation = Quaternion.AngleAxis(mLook.x, playerHost.transform.up);
    }

    void LevelInfo()
    {
        levelNumber = levelInfo.transform.name;
        Debug.Log("levelNumber: " + levelNumber);

        // Tutorial v2
        if (levelNumber == "level.Tutorial-v2")
        {
            levelText.text = "Level: Tutorial v2";
        }
        else
        {
            Debug.LogError("Valid Level Number not found!\nLevel Info will now be disabled.");
            levelText.text = "";
        }
    }
}
