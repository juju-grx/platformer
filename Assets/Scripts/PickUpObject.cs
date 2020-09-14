using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public int lifeBonus = 20;
    public int coins = 1;
    public int jumpBoost = 100;

    private int maxHealth;
    private int currentHealth;

    public GameObject obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        maxHealth = PlayerHealt.instance.GetMaxHeal();
        currentHealth = PlayerHealt.instance.GetHeal();

        if (obj.CompareTag("Coins"))
        {
            if (collision.CompareTag("Player"))
            {
                Inventory.instance.AddCoins(coins);
                Destroy(obj);
            }
        }
        else if (obj.CompareTag("HealthBonus"))
        {
            if (collision.CompareTag("Player") && (currentHealth < maxHealth))
            {
                PlayerHealt.instance.AddLife(lifeBonus);
                Destroy(obj);
            }
        }
        else if (obj.CompareTag("JumpBoost"))
        {
            if (collision.CompareTag("Player"))
            {
                PlayerBoost.instance.JumpBoost(jumpBoost);
                Destroy(obj);
            }
        }
    }
}
