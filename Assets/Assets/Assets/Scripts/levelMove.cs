using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMove : MonoBehaviour
{
    public int sceneBuildIndex;
    public Animator fadeAnim;
    public float fadeTime = .5f;
    public Vector2 newPlayerPosition;
    private Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Entered");

        if(collision.tag == "Player")
        {
            player = collision.transform;
            print("Scene changed to" + sceneBuildIndex);
            fadeAnim.Play("FadeToWhite");
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(fadeTime);
        player.position = newPlayerPosition;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
