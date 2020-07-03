using UnityEngine;

public class RetryGameOnClick : MonoBehaviour
{
    public void RetryGame()
    {
        GameManager.gm.RestartGame();
    }
}
