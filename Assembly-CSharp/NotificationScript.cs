using UnityEngine;

public class NotificationScript : MonoBehaviour
{
	public NotificationManagerScript NotificationManager;

	public UISprite[] Icon;

	public UIPanel Panel;

	public UILabel Label;

	public bool Display;

	public float Timer;

	public int ID;

	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			Icon[0].color = new Color(1f, 1f, 1f, 1f);
			Icon[1].color = new Color(1f, 1f, 1f, 1f);
			Label.color = new Color(1f, 1f, 1f, 1f);
			Label.applyGradient = false;
		}
	}

	private void Update()
	{
		if (!Display)
		{
			Panel.alpha -= Time.deltaTime * ((NotificationManager.NotificationsSpawned > ID + 2) ? 3f : 1f);
			if (Panel.alpha <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
			return;
		}
		Timer += Time.deltaTime;
		if (Timer > 4f)
		{
			Display = false;
		}
		if (NotificationManager.NotificationsSpawned > ID + 2)
		{
			Display = false;
		}
	}
}
