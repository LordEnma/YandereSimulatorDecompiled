using UnityEngine;

public class MoneyLabelScript : MonoBehaviour
{
	public YandereScript Yandere;

	public float UpdateTimer;

	public UILabel Label;

	public bool Show;

	private void Update()
	{
		UpdateTimer = Mathf.MoveTowards(UpdateTimer, 0f, Time.deltaTime);
		if (Yandere.VendingMachines > 0 || Yandere.Talking || Yandere.PauseScreen.Show || UpdateTimer > 0f)
		{
			Show = true;
		}
		else
		{
			Show = false;
		}
		if (Show)
		{
			Label.alpha = Mathf.MoveTowards(Label.alpha, 1f, Time.unscaledDeltaTime * 10f);
		}
		else
		{
			Label.alpha = Mathf.MoveTowards(Label.alpha, 0f, Time.unscaledDeltaTime * 10f);
		}
	}
}
