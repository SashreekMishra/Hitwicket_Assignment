using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        score = 0;
        if(Instance!=null && Instance!=this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }


}
