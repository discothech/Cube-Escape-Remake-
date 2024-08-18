using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int CurrentLevel; // Текущий уровень
    public static LevelSystem instance; // Экземпляр Singleton

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дублирующийся экземпляр
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Подписываемся на событие загрузки сцены
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Отписываемся от события, когда объект уничтожается
    }

    void Start()
    {
        // Загружаем прогресс уровня из PlayerPrefs
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Привязываем события к кнопкам
        Button startButton = GameObject.Find("startButton")?.GetComponent<Button>();
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartButton);
            Debug.Log("Start button found and event listener added.");
        }
        else
        {
            Debug.LogError("Start button not found!");
        }

        

        Button homeButton = GameObject.Find("HomeButton")?.GetComponent<Button>();
        if (homeButton != null)
        {
            homeButton.onClick.AddListener(HomeButton);
            Debug.Log("Home button found and event listener added.");
        }
        else
        {
            Debug.LogError("Home button not found!");
        }

        Button resetButton = GameObject.Find("ResetButton")?.GetComponent<Button>();
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetButton);
            Debug.Log("Reset button found and event listener added.");
        }
        else
        {
            Debug.LogError("Reset button not found!");
        }
    }

    private void Update() 
    {
        if(Input.GetKey("h"))
        {
            HomeButton();
        }

        if(Input.GetKey("r"))
        {
            ResetButton();
        }

    }

    public void StartButton() // Вызывается при нажатии кнопки старта
    { 
        SceneManager.LoadScene("Level" + CurrentLevel); // Загружаем сцену по имени
    }

    public void HomeButton()
    {
        Debug.Log("Возвращаемся на главную сцену");
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        SceneManager.LoadScene(0); // Загружаем начальную сцену
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагружаем текущую сцену
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel); // Сохраняем текущий уровень
        PlayerPrefs.Save(); // Сохраняем данные PlayerPrefs
    }
}