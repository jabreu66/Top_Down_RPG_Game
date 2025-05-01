using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Mark as singleton variable

    [Header("Persistent Objs")]
    public GameObject[] persistentObjs;
        private void Awake()
    {
        if(Instance != null)  // check if there is another game manager in the scene
        {
            // if so, destroy this game object so we don't have two competing
            CleanUp();
            return;
        }   

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistentObjs();
        }
    }

    private void MarkPersistentObjs()
    {
        foreach(GameObject obj in persistentObjs)
        {
            if(obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    private void CleanUp()
    {
        foreach (GameObject obj in persistentObjs)
        {
            Destroy(obj);
        }
        Destroy(gameObject); // tell the game manager to destroy itself
    }
}
