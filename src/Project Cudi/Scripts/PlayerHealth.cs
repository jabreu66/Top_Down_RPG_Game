using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;

    public void ChangeHealth (int amount) {
        currHealth += amount;

        if (currHealth <= 0) {
            gameObject.SetActive(false);
        }
        else if (currHealth > maxHealth) {
            currHealth = maxHealth;
        }
    }
}
