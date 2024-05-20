using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] GameObject theHolder;
    private float curentHealth;
    private float maxHealth;
    
    public void UpdateHealthBar(float currentVal, float maxVal)
    {
        slider.value = currentVal/maxVal;
    }
    private void Update()
    {
        curentHealth = theHolder.GetComponent<Damageable>().Health;
        maxHealth = theHolder.GetComponent<Damageable>().MaxHealth;
        UpdateHealthBar(curentHealth, maxHealth);
    }
}
