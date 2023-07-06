using UnityEngine;

public class SafeScript : MonoBehaviour
{
	public MissionModeScript MissionMode;

	public PromptScript SafePrompt;

	public PromptScript KeyPrompt;

	public Transform Door;

	public GameObject Contents;

	public GameObject Key;

	public float Rotation;

	public bool Open;

	private void Start()
	{
		SafePrompt.enabled = false;
	}

	private void Update()
	{
		if (Key.activeInHierarchy && KeyPrompt.Circle[0].fillAmount == 0f)
		{
			KeyPrompt.Hide();
			KeyPrompt.enabled = false;
			KeyPrompt.Yandere.Inventory.SafeKey = true;
			SafePrompt.HideButton[0] = false;
			SafePrompt.enabled = true;
			Key.SetActive(value: false);
		}
		if (SafePrompt.Circle[0].fillAmount == 0f)
		{
			SafePrompt.Circle[0].fillAmount = 1f;
			if (!Open)
			{
				KeyPrompt.Yandere.Inventory.SafeKey = false;
				SafePrompt.Text[0] = "Steal Documents";
				SafePrompt.Label[0].text = "     Steal Documents";
				Open = true;
			}
			else
			{
				Contents.gameObject.SetActive(value: false);
				MissionMode.DocumentsStolen = true;
				base.enabled = false;
				SafePrompt.Hide();
				SafePrompt.enabled = false;
			}
		}
		if (Open)
		{
			Rotation = Mathf.Lerp(Rotation, -165f, Time.deltaTime * 10f);
			Door.localEulerAngles = new Vector3(Door.localEulerAngles.x, Rotation, Door.localEulerAngles.z);
		}
	}
}
