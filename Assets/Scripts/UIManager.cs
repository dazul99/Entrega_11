using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject playing;
    [SerializeField] private GameObject pausing;

    [SerializeField] private Button play;
    [SerializeField] private Button pause;
    [SerializeField] private Button stop;
    [SerializeField] private Button previous;
    [SerializeField] private Button next;
    [SerializeField] private Button loop;
    [SerializeField] private Button random;
    [SerializeField] private Slider slider;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image image;

    private bool started = false;

    private GameManager gameManager;

        
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        play.onClick.AddListener(gameManager.Play);
        pause.onClick.AddListener(gameManager.Pause);
        stop.onClick.AddListener(gameManager.Stop);
        previous.onClick.AddListener(gameManager.Previous);
        next.onClick.AddListener(gameManager.Next);
        loop.onClick.AddListener(gameManager.Loop);
        random.onClick.AddListener(gameManager.Rand);
        slider.onValueChanged.AddListener(gameManager.ChangeTime);
        pausing.SetActive(false);
        playing.SetActive(true);
        image.gameObject.SetActive(false);
        text.text = "";
    }

    public void ShowPlay()
    {
        pausing.SetActive(false);
        playing.SetActive(true);
    }

    public void ShowPause()
    {
        pausing.SetActive(true);
        playing.SetActive(false);
    }

    public void SetTime(float time)
    {
        slider.maxValue = time;
        slider.value = 0;
    }

    public void UpdateTime(float time)
    {
        slider.value = time;
    }

    public void WriteName(string name, Sprite img)
    {
        if (!started)
        {
            started = true;
            image.gameObject.SetActive(true);
        }
        
        image.sprite = img;
        text.text = name;
    }
}
