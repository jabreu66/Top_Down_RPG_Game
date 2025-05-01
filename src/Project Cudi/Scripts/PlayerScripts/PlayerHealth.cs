using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;
    public TMP_Text healthText;

    private void Start()
    {
        healthText.text = "Health: " + currHealth + " / 10";
    }

    public void ChangeHealth (int amount) {
        currHealth += amount;

        if (currHealth <= 0) {
            gameObject.SetActive(false);
        }
        else if (currHealth > maxHealth) {
            currHealth = maxHealth;
        }
        
        healthText.text = "Health: " + currHealth + " / 10";
    }
}
