using UnityEngine;

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

    #endregion

}