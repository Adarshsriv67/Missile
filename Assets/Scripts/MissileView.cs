using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileView : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private MissileModel mM=new MissileModel();
    private GameManager gameManager;
    //private PlayerView pV=new PlayerView();
    [SerializeField] private GameObject shield;

    void Start()
    {
        mM.speed = 5f;
        mM.rotateSpeed = 175f;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }   

    void Update()
    {
        if(player!=null)
        {
            Vector2 direction = (Vector2)player.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * mM.rotateSpeed;
            rb.velocity = transform.up * mM.speed;
        }        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(gameManager.shieldActive==false)
            {
                Destroy(player.gameObject);
                //SceneManager.LoadScene("SampleScene");
                gameManager.gameOverPanel.SetActive(true);
            }                     
            Debug.Log("Collided");
            Destroy(this.gameObject);
        }
        if (collision.tag=="Missile")
        {
            Debug.Log("Collided with Missile");
            Destroy(this.gameObject);
        }
        if(collision.tag=="AvtiveShield")
        {
            Destroy(this.gameObject);
            gameManager.shieldActive=false;
        }
    }
}
