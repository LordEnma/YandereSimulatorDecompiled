using UnityEngine;

public class SpyScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject SpyCamera;

	public Transform SpyTarget;

	public Transform SpySpot;

	public float Timer;

	public bool RecordEvent;

	public bool CanRecord;

	public bool Recording;

	public bool OsanaSpecific;

	public int Phase;

	private void Start()
	{
		if (OsanaSpecific && DateGlobals.Week > 1)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Yandere.CharacterAnimation.CrossFade("f02_spying_00");
			Yandere.YandereVision = false;
			Yandere.ResetYandereEffects();
			Yandere.CanMove = false;
			Phase++;
		}
		if (Phase == 1)
		{
			Quaternion b = Quaternion.LookRotation(SpyTarget.transform.position - Yandere.transform.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, b, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(SpySpot.position);
			if (!Recording && RecordEvent && Yandere.Inventory.DirectionalMic)
			{
				Yandere.CharacterAnimation.CrossFade("f02_spyRecord_00");
				Yandere.Microphone.SetActive(value: true);
				Recording = true;
			}
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				PromptBar.Label[1].text = "Stop";
				PromptBar.Label[2].text = "";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Yandere.MainCamera.enabled = false;
				SpyCamera.SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 2 && Input.GetButtonDown(InputNames.Xbox_B))
		{
			End();
		}
	}

	public void End()
	{
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		Yandere.Microphone.SetActive(value: false);
		Yandere.MainCamera.enabled = true;
		Yandere.CanMove = true;
		SpyCamera.SetActive(value: false);
		Timer = 0f;
		Phase = 0;
	}
}
