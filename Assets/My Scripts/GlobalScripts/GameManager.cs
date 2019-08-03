using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Fields

    public static GameManager INSTANCE;

    #endregion

    #region Methods

    private void Awake()
    {

        if (INSTANCE == null)
        {
            INSTANCE = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    #endregion

}