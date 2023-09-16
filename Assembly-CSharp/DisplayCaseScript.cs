using UnityEngine;

public class DisplayCaseScript : MonoBehaviour
{
	public GameObject[] ShatteredGlass;

	public BoxCollider MyCollider;

	public GameObject AlarmDisc;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public Transform BreakSpot;

	public Transform Door;

	public string BreakAnimName;

	public float BreakTimer;

	public float Rotation;

	public bool Open;

	public int Type;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Yandere.Inventory.CaseKey)
			{
				Prompt.enabled = false;
				Prompt.Hide();
				Open = true;
				if (Type == 1 || Type == 3)
				{
					MyCollider.enabled = false;
				}
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "You need the Weapon Case Key";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (Prompt.Circle[1].fillAmount == 0f)
		{
			Prompt.Circle[1].fillAmount = 1f;
			Prompt.Yandere.SuspiciousActionTimer = Prompt.Yandere.CharacterAnimation[BreakAnimName].time;
			Prompt.Yandere.CharacterAnimation.CrossFade(BreakAnimName);
			Prompt.Yandere.LockpickTarget = BreakSpot;
			Prompt.Yandere.BreakAnim = BreakAnimName;
			Prompt.Yandere.BreakingGlass = true;
			Prompt.Yandere.CanMove = false;
			if (Type == 1 || Type == 3)
			{
				BreakTimer = 0.66666f;
			}
			else if (Type == 2)
			{
				BreakTimer = 1.33333f;
			}
		}
		if (Open)
		{
			if (Type == 1)
			{
				Rotation = Mathf.Lerp(Rotation, -109f, Time.deltaTime * 10f);
				if (Rotation < -108.5f)
				{
					Rotation = -109f;
					base.enabled = false;
				}
				Door.localEulerAngles = new Vector3(0f, 0f, Rotation);
			}
			else if (Type == 2)
			{
				Rotation = Mathf.Lerp(Rotation, -22.5f, Time.deltaTime * 10f);
				if (Rotation > -22f)
				{
					Rotation = -22.5f;
					base.enabled = false;
				}
				Door.localEulerAngles = new Vector3(Rotation, 90f, -90f);
			}
			else if (Type == 3)
			{
				Rotation = Mathf.Lerp(Rotation, 85f, Time.deltaTime * 10f);
				if (Rotation > 84.5f)
				{
					Rotation = 85f;
					base.enabled = false;
				}
				Door.localEulerAngles = new Vector3(-90f, Rotation, 0f);
			}
		}
		if (!(BreakTimer > 0f))
		{
			return;
		}
		BreakTimer = Mathf.MoveTowards(BreakTimer, 0f, Time.deltaTime);
		if (BreakTimer != 0f)
		{
			return;
		}
		AudioSource.PlayClipAtPoint(MyAudio.clip, Prompt.Yandere.MainCamera.transform.position);
		GameObject obj = Object.Instantiate(AlarmDisc, base.transform.position, Quaternion.identity);
		obj.transform.localScale = new Vector3(1150f, 1150f, 1150f);
		obj.GetComponent<AlarmDiscScript>().NoScream = true;
		ShatteredGlass[1].SetActive(value: true);
		ShatteredGlass[2].SetActive(value: true);
		foreach (Transform item in ShatteredGlass[2].transform)
		{
			float x = Random.Range(-15f, 15f);
			float y = Random.Range(-15f, 15f);
			float z = Random.Range(-15f, 15f);
			Vector3 vector = new Vector3(x, y, z);
			item.eulerAngles += vector;
		}
		if (Type == 1)
		{
			ShatteredGlass[3].SetActive(value: true);
		}
		base.gameObject.SetActive(value: false);
		Prompt.enabled = false;
		Prompt.Hide();
		base.enabled = false;
	}
}
