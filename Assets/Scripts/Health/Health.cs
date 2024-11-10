using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float value)
    {
        currentHealth += value;
    }

    public float GetHealth()
    {
        return currentHealth;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeHealth(-35);
        }

    }
}