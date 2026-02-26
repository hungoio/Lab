using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        PlayerPrefs.SetInt("Sound", 80);
        int sound = PlayerPrefs.GetInt("Sound", 100);
        Debug.Log("Sound: " + sound);
        // Lấy điểm đã lưu
        score = PlayerPrefs.GetInt("Score", 0);
        Debug.Log("Score hiện tại: " + score);
    }

    public void AddScore(int value)
    {
        score += value;

        // Lưu điểm
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        Debug.Log("Score mới: " + score);
    }
}
