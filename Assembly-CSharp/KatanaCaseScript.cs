using UnityEngine;

public class KatanaCaseScript : MonoBehaviour
{
	public PromptScript CasePrompt;

	public PromptScript KeyPrompt;

	public Transform Door;

	public GameObject Key;

	public float Rotation;

	public bool Open;

	private void Start()
	{
		CasePrompt.enabled = false;
	}

	private void Update()
	{
		if (Key.activeInHierarchy && KeyPrompt.Circle[0].fillAmount == 0f)
		{
			KeyPrompt.Yandere.Inventory.CaseKey = true;
			CasePrompt.HideButton[0] = false;
			CasePrompt.enabled = true;
			Key.SetActive(false);
		}
		if (CasePrompt.Circle[0].fillAmount == 0f)
		{
			KeyPrompt.Yandere.Inventory.CaseKey = false;
			Open = true;
			CasePrompt.Hide();
			CasePrompt.enabled = false;
		}
		if (CasePrompt.Yandere.Inventory.LockPick)
		{
			CasePrompt.HideButton[2] = false;
			CasePrompt.enabled = true;
			if (CasePrompt.Circle[2].fillAmount == 0f)
			{
				KeyPrompt.Hide();
				KeyPrompt.enabled = false;
				CasePrompt.Yandere.Inventory.LockPick = false;
				CasePrompt.Label[0].text = "     Open";
				CasePrompt.HideButton[2] = true;
				CasePrompt.HideButton[0] = true;
				Open = true;
			}
		}
		else if (!CasePrompt.HideButton[2])
		{
			CasePrompt.HideButton[2] = true;
		}
		if (Open)
		{
			Rotation = Mathf.Lerp(Rotation, -180f, Time.deltaTime * 10f);
			Door.eulerAngles = new Vector3(Door.eulerAngles.x, Door.eulerAngles.y, Rotation);
			if (Rotation < -179.9f)
			{
				base.enabled = false;
			}
		}
	}
}
