using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int startinghealth = 3;


    int currentHealth;
    private void Awake()
    {
        currentHealth = startinghealth;

    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
