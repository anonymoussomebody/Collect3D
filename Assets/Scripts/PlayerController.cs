using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Define Private Variables

    // Level Settings
    private Rigidbody rb;
    private int count;
    private string levelNumber;
    private bool isPaused = false;

    // Define Public Variables

    // Level GUI/Settings
    public float speed;
    public Text countText;
    public Text levelText;
    public GameObject levelInfo;
    // Level Pause/End
    public GameObject levelCompleted;
    public GameObject levelPaused;

    // NEW Mouse
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
        count = 0;
        LevelCompleted();
        levelCompleted.SetActive(false);
        levelPaused.SetActive(false);
        LevelInfo();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement);

        // Pause Menu
        //KeyCode pause = KeyCode.Escape;
        //if (isPaused == false)
        //{
        //    if (Input.GetKeyDown(pause))
        //    {
        //        levelPaused.SetActive(true);
        //        isPaused = true;
        //    }
        //} else if (isPaused == true)
        //{
        //    if (Input.GetKeyDown(pause))
        //    {
        //        levelPaused.SetActive(false);
        //        isPaused = false;
        //    }
        //}

        // Escape Key for Menu Exit
        if (Input.GetKeyDown("escape"))
        {
            //Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }

        // NEW Mouse Input
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

    public void ReturnGameClicked()
    {
        levelPaused.SetActive(false);
        isPaused = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            LevelCompleted();
        }
    }

    void LevelCompleted()
    {
        countText.text = "Count: " + count.ToString();

        // Level 1 - 4 PickUps
        if (levelNumber == "L1")
        {
            if (count == 4)
            {
                levelCompleted.SetActive(true);

                // Save string when level is completed
                if (PlayerPrefs.GetString("HLC") == "")
                {
                    PlayerPrefs.SetString("HLC", "Level 1");
                    Debug.Log("Set HLC to 1.");
                }
            }
        }

        // Level 2 - 4 PickUps
        else if (levelNumber == "L2")
        {
            if (count == 4)
            {
                levelCompleted.SetActive(true);

                // Save string when level is completed
                if (PlayerPrefs.GetString("HLC") == "Level 1")
                {
                    PlayerPrefs.SetString("HLC", "Level 2");
                    Debug.Log("Set HLC to 2.");
                }
            }
        }

        // Level 3 - 8 PickUps
        else if (levelNumber == "L3")
        {
            if (count == 8)
            {
                levelCompleted.SetActive(true);

                // Save string when level is completed
                if (PlayerPrefs.GetString("HLC") == "Level 2")
                {
                    PlayerPrefs.SetString("HLC", "Level 3");
                    Debug.Log("Set HLC to 3.");
                }
            }
        }
    }

    void LevelInfo()
    {
        levelNumber = levelInfo.transform.name;
        Debug.Log("levelNumber: " + levelNumber);

        // Level 1
        if (levelNumber == "L1")
        {
            levelText.text = "Level 1";
        }

        // Level 2
        else if (levelNumber == "L2")
        {
            levelText.text = "Level 2";
        }

        // Level 3
        else if (levelNumber == "L3")
        {
            levelText.text = "Level 3";
        }
        else
        {
            Debug.LogError("Valid Level Number not found!\nLevel Info will now be disabled.");
            levelText.text = "";
        }
    }
}
