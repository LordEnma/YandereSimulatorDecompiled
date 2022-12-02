using UnityEngine;

public class SecurityCameraScript : MonoBehaviour
{
	public SecuritySystemScript SecuritySystem;

	public MissionModeScript MissionMode;

	public YandereScript Yandere;

	public float Rotation;

	public int Direction = 1;

	private void Update()
	{
		Rotation += (float)Direction * 36f * Time.deltaTime;
		base.transform.parent.localEulerAngles = new Vector3(base.transform.parent.localEulerAngles.x, Rotation, base.transform.parent.localEulerAngles.z);
		if (Direction > 0)
		{
			if (Rotation > 86.5f)
			{
				Direction = -1;
			}
		}
		else if (Rotation < -86.5f)
		{
			Direction = 1;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (MissionMode.GameOverID != 0)
		{
			return;
		}
		if (other.gameObject.layer == 13)
		{
			if ((!Yandere.Armed || !Yandere.EquippedWeapon.Suspicious) && (!(Yandere.Bloodiness > 0f) || Yandere.RedPaint) && !(Yandere.Sanity < 33.333f) && !Yandere.Attacking && !Yandere.Struggling && !Yandere.Dragging && !Yandere.Lewd && !Yandere.Dragging && !Yandere.Carrying && (!Yandere.Laughing || !(Yandere.LaughIntensity > 15f)) && (!(Yandere.PickUp != null) || !Yandere.PickUp.Clothing || !Yandere.PickUp.Evidence || Yandere.PickUp.RedPaint))
			{
				return;
			}
			if (Yandere.Mask == null)
			{
				if (MissionMode.enabled)
				{
					MissionMode.GameOverID = 15;
					MissionMode.GameOver();
					MissionMode.Phase = 4;
					base.enabled = false;
				}
				else if (!SecuritySystem.Evidence)
				{
					Yandere.NotificationManager.DisplayNotification(NotificationType.Evidence);
					SecuritySystem.Evidence = true;
					SecuritySystem.Masked = false;
				}
			}
			else if (!SecuritySystem.Masked)
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Evidence);
				SecuritySystem.Evidence = true;
				SecuritySystem.Masked = true;
			}
		}
		else if (other.gameObject.layer == 11 && MissionMode.enabled)
		{
			MissionMode.GameOverID = 15;
			MissionMode.GameOver();
			MissionMode.Phase = 4;
			base.enabled = false;
		}
	}
}
