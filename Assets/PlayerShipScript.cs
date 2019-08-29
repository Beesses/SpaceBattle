using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipScript : BaseForPlayerShip, ISetDamage
{
    public Image UIHealth;
    public Text UIText;
    void Start()
    {
        FindAllGunPlaces();
        _currentHealth = 100;
        _maxHealth = 100;
        _fireRate = 1;
        _projectile = Resources.Load("PlayerProjectile") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Controllers();
        if (Attacking)
        {
            Attack();
        }
        Reload(_fireRate);
        Move(8);
        CheckHealth(_currentHealth, 0);
        UpdateHealthBar();
    }
    public void ApplyDamage(float Damage)
    {
        _currentHealth -= Damage;
    }
    private void UpdateHealthBar()
    {
        float ratio = _currentHealth / _maxHealth;
        UIText.text = _currentHealth.ToString();
        UIHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
