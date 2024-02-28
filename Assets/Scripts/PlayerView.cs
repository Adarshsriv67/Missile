using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    private PlayerModel pM = new PlayerModel();
    private GameManager gameManager;
    public Text score;
    public float time;
    public int scoreD;
    public Text finalScore;
    public GameObject cloud;
    private int coinPoint;
    [SerializeField]private GameObject speedBoost;
    public GameObject shield;
    public bool shieldActive = false;
    [SerializeField] private FixedJoystick _joyStick;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pM.speed = 3f;
        pM.rotationSpeed = 225;
    }

    void Update()
    {
        time += Time.deltaTime;
        scoreD = (int)time+coinPoint;
        score.text = "SCORE:" + scoreD;
        finalScore.text =""+ scoreD;
        InputCheck();
        transform.Translate(Vector3.up * pM.speed * Time.deltaTime);
    }

    public void InputCheck()
    {
        float horizontalInput = _joyStick.Horizontal;
        float verticalInput = _joyStick.Vertical;
        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;
        float inputMagnitude = Mathf.Clamp01(direction.magnitude);

        transform.Translate(direction  * inputMagnitude * Time.deltaTime, Space.World);
 
        if(direction !=Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, pM.rotationSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Point")
        {
            Debug.Log("Point Collected");
            coinPoint += 10;
            Destroy(collision.gameObject);
        }
        if(collision.tag=="Border")
        {
            Debug.Log("Border");
            cloud.transform.position = new Vector3(transform.position.x,transform.position.y,12);
        }
        if(collision.tag=="Speed")
        {
            Debug.Log("Speed Boost");
            pM.speed = 5;
            speedBoost.SetActive(true);
            Destroy(collision.gameObject);
        }
        if(collision.tag=="Shield")
        {
            Debug.Log("Shield");
            ShieldOn();
            gameManager.shieldActive = true;
            //shieldActive = true;
            Destroy(collision.gameObject);
        }
    }
    public void ShieldOn()
    {
        shield.SetActive(true);
    }
    public void ShieldOff()
    {
        shield.SetActive(false);
    }
}