using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private LevelSystem levelSystem;

    private void Start()
    {
        // Находим LevelSystem программно
        levelSystem = FindObjectOfType<LevelSystem>();

        if (levelSystem == null)
        {
            Debug.LogError("LevelSystem не найден на сцене. Убедитесь, что LevelSystem существует.");
        }
    }

    private void OnTriggerEnter(Collider other)    
    {        
        if (other.CompareTag("Player") && levelSystem != null)
        {
            // Инкрементируем текущий уровень
            levelSystem.CurrentLevel++;
            
            // Сохраняем прогресс
            levelSystem.SaveProgress();

            // Загружаем следующую сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

       /* if(this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            foreach(YellowButton button in FindObjectsOfType<YellowButton>())
            {
                button.canPush = false;
            }
        }
        */
        
    }

    /*private void OnTriggerExit(Collider other)
    {    
          if(this.CompareTag("Cube") && other.CompareTag("Cube"))
            {
            foreach (YellowButton button in FindObjectsOfType<YellowButton>())
            {
                button.canPush = true;
            }

            }
    }

    */
    }
