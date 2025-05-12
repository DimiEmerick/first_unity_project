using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;
    public string namePlayer;
    public string nameEnemy;

    private string saveMemoryKey = "SavedWinner";
    private static SaveController _instance;

    public static SaveController Instance // Propriedade estática para acessar a instância
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveController>(); // Procure a instância na cena
                if (_instance == null) // Se não encontrar, cria uma nova instância
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this) // Garante que apenas uma instância do Singleton exista
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject); // Mantém o Singleton vivo entre as cenas
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveMemoryKey, winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveMemoryKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
