using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Enemigos;
    int enemyCount;

    private void Awake()
    {
       int managers = GameObject.FindObjectsOfType<GameManager>().Length;
        if (managers > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnseceneLoaded;
        enemyCount = Enemigos.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void StarGame()
    {
        SceneManager.LoadScene(0);
    }

    void OnseceneLoaded(Scene scene, LoadSceneMode mode)
    {
       // GameObject.Find("Canvas").SetActive(false);

        foreach(GameObject enemy in Enemigos)
        {
            float minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            float maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;

            float X = Random.Range(minX, maxX);
            Instantiate(enemy, new Vector2(X, 0.6f), Quaternion.identity);
        }
    }
}
