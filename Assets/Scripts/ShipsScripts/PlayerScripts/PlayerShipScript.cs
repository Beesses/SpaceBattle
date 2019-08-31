using UnityEngine;
using UnityEngine.UI;

public class PlayerShipScript : BaseForPlayerShip
{
    public Image UIHealth;
    public Text UIText;
    public Text _text;
    public float D;
    public float F;
    public float H;
    void Start()
    {
        FindAllGunPlaces();
        _currentHealth = 100;
        _maxHealth = 100;
        _fireRate = 1;
        _damage = 1;
        _projectile = Resources.Load("PlayerProjectile") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Controllers();
        if (Attacking)
        {
            Attack();
            Reload();
        }
        Move(8);
        CheckHealth();
        UpdateUI();
    }
    private void UpdateUI()
    {
        float ratio = _currentHealth / _maxHealth;
        UIText.text = _currentHealth.ToString();
        UIHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        _text.text = "Bonuses: D(" + D.ToString() + ") F(" + F.ToString() + ") H(" + H.ToString() + ")";
    }
}
