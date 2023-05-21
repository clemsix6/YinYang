using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Camera camera;
    public TMP_Text bestScoreText;
    public TMP_Text lastScoreText;
    public Image buttonImage;
    
    
    void Start()
    {
        var color = Spawner.dark ? Color.black : Color.white;
        this.camera.backgroundColor = Spawner.dark ? Color.white : Color.black;
        
        this.bestScoreText.color = color;
        this.bestScoreText.text  = "Best Score : " + PlayerPrefs.GetInt("bestScore").ToString();
        this.lastScoreText.color = color;
        this.lastScoreText.text  = "Last Score : " + PlayerPrefs.GetInt("currentScore").ToString();
        this.buttonImage.color   = color;
    }


    public void Play()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
}
