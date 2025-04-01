using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int currHealth;
    public int maxHealth = 5;

    private void Start()
    {
        currHealth = maxHealth;
    }

    public void ChangeHealth (int amount) {
        currHealth += amount;

        if (currHealth <= 0) {
            Destroy(gameObject);
        }
        else if (currHealth > maxHealth) {
            currHealth = maxHealth;
        }
    }

}
