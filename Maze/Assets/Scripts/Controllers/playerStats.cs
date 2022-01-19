using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour
{

    private float maxHealth = 100;
    public float currentHealth = 100;
    private float maxStamina = 100;
    private float currentStamina = 100;

    public Texture2D healthTexture;
    public Texture2D staminaTexture;

    private float barWidth;
    private float barHeight;

    void Awake()
    {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 10.0f;

    }

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
								 Screen.height - barHeight - 30,
								 currentHealth * barWidth / maxHealth,
								 barHeight),
						healthTexture);
		GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
								 Screen.height - barHeight -10,
								 currentStamina * barWidth / maxStamina,
								 barHeight),
						staminaTexture);
	}

}