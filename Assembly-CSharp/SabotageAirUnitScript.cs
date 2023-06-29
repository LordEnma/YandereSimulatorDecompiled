using UnityEngine;

public class SabotageAirUnitScript : MonoBehaviour
{
	public FallingObjectScript AirUnit;

	public Transform SabotageSpot;

	public PromptScript Prompt;

	public float Timer;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.WeaponID == 24)
			{
				Prompt.Yandere.CharacterAnimation.CrossFade("f02_sabotageAirUnit_00");
				Prompt.Yandere.SabotagingWithWrench = true;
				Prompt.Yandere.LockpickTarget = SabotageSpot;
				Prompt.Yandere.CanMove = false;
				Timer = 5.8667f;
				Prompt.Yandere.EquippedWeapon.Flip = true;
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "Pipe Wrench Required";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (Timer > 0f)
		{
			Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
			if (Timer < 0.33333f)
			{
				AirUnit.transform.localEulerAngles += new Vector3(Time.deltaTime * 36f, 0f, 0f);
			}
			if (Timer == 0f)
			{
				AirUnit.enabled = true;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
			}
		}
	}
}
