using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public bool öldümü = false;

    
    public float ziplama = 5f;

    
    public Rigidbody2D rigidbody2d;

   
    public gamemanager managergame;

    public GameObject olumVFX;

   
    public GameObject gameOverScreen;

  
    public GameObject normalScore;

    
    public Text gameOverScore;


    void Start()
    {
      
        öldümü = false;

       
        Time.timeScale = 1f;

     
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }

    
        if (normalScore != null)
        {
            normalScore.SetActive(true);
        }
    }


    void Update()
    {
     
        if (öldümü)
            return;


      

        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            rigidbody2d.linearVelocity = Vector2.up * ziplama;
        }


      

        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            rigidbody2d.linearVelocity = Vector2.up * ziplama;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(
            "Çarpışma oldu: " +
            collision.gameObject.name +
            " tag: " +
            collision.gameObject.tag
        );


      

        if (collision.gameObject.CompareTag("Para"))
        {
            if (managergame != null)
            {
                managergame.UpdateScore();
            }

            Destroy(collision.gameObject);
        }




        if (collision.gameObject.CompareTag("ölüm"))
        {
           
            if (öldümü)
                return;


            
            öldümü = true;


            if (olumVFX != null)
            {
                Instantiate(
                    olumVFX,
                    transform.position,
                    Quaternion.identity
                );
            }



            if (normalScore != null)
            {
                normalScore.SetActive(false);
            }


       

            if (gameOverScore != null && managergame != null)
            {
                gameOverScore.text = managergame.score.ToString();
            }


      

            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }


      

            Time.timeScale = 0f;
        }
    }


  

    public void RestartGame()
    {
    
        Time.timeScale = 1f;

        
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }



    public void GoToMenu()
    {
     
        Time.timeScale = 1f;


    }
}