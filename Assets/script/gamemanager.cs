using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public int score;
    public Text ScoreText;
    private void Start()
    {
        score = 0; 
    }
    private void Update()
    {
        
    }
    public void UpdateScore ()
    {
        score++;
        ScoreText.text = score.ToString();
    }


}
