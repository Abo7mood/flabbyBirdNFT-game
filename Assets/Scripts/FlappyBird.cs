using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class FlappyBird : MonoBehaviour
{
    #region Constructer

    [SerializeField] GameObject PrefabBackGround;
    [SerializeField] Transform MainPosition;
    [SerializeField] Transform[] Group;
    [SerializeField] Vector3 bro;
    [SerializeField] GameObject[] A;
    [SerializeField] GameObject[] Transforms;
    [SerializeField] GameObject DiePanel;
    [SerializeField] TextMeshProUGUI TXT;

   
    GameObject BackGround;
    Rigidbody2D rb;
    SpriteRenderer sprite;
   public Camera cam;
    #endregion
    #region floats&int
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float jumpvalue;
    [SerializeField] float TimeRepeating;
    [SerializeField] float Directionx;
    [SerializeField] float Directiony;
  

    private int CoinsAmount=0;
    #endregion
    #region Boolean
 
    
    #endregion
    private void Awake()
    { 
           cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
 
        A = GameObject.FindGameObjectsWithTag("A");
        Transforms = GameObject.FindGameObjectsWithTag("Transforms");
        InvokeRepeating("InstintiateObject", 0.01f, TimeRepeating);
        Time.timeScale = 0;
    }
    private void Update()
    {
        A= GameObject.FindGameObjectsWithTag("A");
        Transforms = GameObject.FindGameObjectsWithTag("Transforms");

        TXT.text = CoinsAmount.ToString();

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            jump();
#endif
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        
            jump();
        




        transform.Translate(bro * Time.deltaTime);
        cam.transform.Translate(bro * Time.deltaTime);
        Group[0].Translate(bro * Time.deltaTime);




    }
    private void FixedUpdate()
    {
        float maxVelocity = 10;      
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);      
    }
    public void InstintiateObject()=> BackGround = Instantiate(PrefabBackGround, A[A.Length-1].transform.position, Quaternion.identity, null);
    
        
   
    void jump()=> rb.velocity=new Vector2(rb.velocity.x,jumpvalue);
    
      
        
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Die"))
        {
           
                Die();
          
        }
        else if (collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject, 0);
            CoinsAmount++;
            Time.timeScale += 0.05f;
        }




    }
    public void StartGame()=> Time.timeScale = 1;
    private void Die()
    {
        Time.timeScale = 0;
        DiePanel.SetActive(true);
    }
    public void StartTheGame() => SceneManager.LoadScene(0);
  
}
