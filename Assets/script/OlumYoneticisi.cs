using UnityEngine;

public class OlumYoneticisi : MonoBehaviour
{
    public bool öldümü = false;
    public GameObject ölümefekti;

    [Header("Kamera Ayarı")]
    public Transform mainCameraTransform; 

    [Header("Skor UI Ayarları")]
    public RectTransform scoreRectTransform;
    public GameObject gameOverScreen;

    void Update()
    {
        
        if (mainCameraTransform != null && !öldümü)
        {
           
            float kameraAltSiniri = mainCameraTransform.position.y - 6.5f;
            if (transform.position.y < kameraAltSiniri)
            {
                if (transform.position.y < kameraAltSiniri)
                {
                    ÖlümüGerceklestir();

                }

                
                if (gameOverScreen != null)
                {
                    gameOverScreen.SetActive(true);
                }

                ÖlümüGerceklestir();
            }

      
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ölüm") && !öldümü)
        {
            ÖlümüGerceklestir();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ölüm") && !öldümü)
        {
            ÖlümüGerceklestir();
        }
    }

    void ÖlümüGerceklestir()
    {
        öldümü = true;

        if (ölümefekti != null)
        {
            GameObject efekt = Instantiate(ölümefekti, transform.position, Quaternion.identity);
            ParticleSystem ps = efekt.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                var mainModule = ps.main;
                mainModule.useUnscaledTime = true;
                mainModule.simulationSpeed = 0.5f;
            }
        }

        Die();
    }

    void Die()
    {
        Debug.Log("OYUN DURDU!");

        if (scoreRectTransform != null)
        {
            scoreRectTransform.anchoredPosition = new Vector2(-63f, 12f);

            scoreRectTransform.localScale = new Vector3(50f, 50f, 27.99659f);
        }

        Time.timeScale = 0f;
    }
}