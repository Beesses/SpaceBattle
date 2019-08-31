using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public float ScoreValue = 0;
    private float HealthRegen = 20;
    private float ScoreForHeal = 100;
    private PlayerShipScript PSS;
    private Text MyText;

    // Start is called before the first frame update
    void Start()
    {
        MyText = GetComponent<Text>();
        PSS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        RegenHp();
        MyText.text = "Score: " + ScoreValue;
    }
    private void RegenHp()
    {
        if(ScoreValue > ScoreForHeal)
        {
            ScoreForHeal += 100;
            PSS._currentHealth += HealthRegen;
        }
    }
}
