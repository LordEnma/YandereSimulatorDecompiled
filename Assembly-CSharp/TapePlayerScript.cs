using UnityEngine;

public class TapePlayerScript : MonoBehaviour
{
	public TapePlayerMenuScript TapePlayerMenu;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform RWButton;

	public Transform FFButton;

	public Camera TapePlayerCamera;

	public Transform[] Rolls;

	public GameObject TaskTapePlayer;

	public GameObject NoteWindow;

	public GameObject Tape;

	public bool MelodyRecording;

	public bool FastForward;

	public bool Eighties;

	public bool Rewind;

	public bool Spin;

	public float SpinSpeed;

	private void Start()
	{
		Eighties = GameGlobals.Eighties;
		Tape.SetActive(value: false);
		if (Eighties)
		{
			Prompt.Text[0] = "Pick Up";
			Prompt.Label[0].text = "     " + Prompt.Text[0];
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (Eighties)
			{
				Yandere.Inventory.TapePlayer = true;
				base.gameObject.SetActive(value: false);
				Prompt.Hide();
				Prompt.enabled = false;
				TaskTapePlayer.SetActive(value: true);
			}
			else
			{
				Yandere.HeartCamera.enabled = false;
				Yandere.RPGCamera.enabled = false;
				TapePlayerMenu.TimeBar.gameObject.SetActive(value: true);
				TapePlayerMenu.List.gameObject.SetActive(value: true);
				TapePlayerCamera.enabled = true;
				TapePlayerMenu.UpdateLabels();
				TapePlayerMenu.Show = true;
				NoteWindow.SetActive(value: false);
				Yandere.CanMove = false;
				Yandere.HUD.alpha = 0f;
				Time.timeScale = 0.0001f;
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "EXIT";
				PromptBar.Label[4].text = "CHOOSE";
				PromptBar.Label[5].text = "CATEGORY";
				TapePlayerMenu.CheckSelection();
				PromptBar.Show = true;
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		if (TapePlayerMenu.Show)
		{
			if (Spin)
			{
				Transform transform = Rolls[0];
				transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 1f / 60f * (360f * SpinSpeed), transform.localEulerAngles.z);
				Transform transform2 = Rolls[1];
				transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, transform2.localEulerAngles.y + 1f / 60f * (360f * SpinSpeed), transform2.localEulerAngles.z);
			}
			if (FastForward)
			{
				FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(FFButton.localEulerAngles.x, 6.25f, 1.6666666f), FFButton.localEulerAngles.y, FFButton.localEulerAngles.z);
				SpinSpeed = 2f;
			}
			else
			{
				FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(FFButton.localEulerAngles.x, 0f, 1.6666666f), FFButton.localEulerAngles.y, FFButton.localEulerAngles.z);
				SpinSpeed = 1f;
			}
			if (Rewind)
			{
				RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(RWButton.localEulerAngles.x, 6.25f, 1.6666666f), RWButton.localEulerAngles.y, RWButton.localEulerAngles.z);
				SpinSpeed = -2f;
			}
			else
			{
				RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(RWButton.localEulerAngles.x, 0f, 1.6666666f), RWButton.localEulerAngles.y, RWButton.localEulerAngles.z);
			}
		}
	}
}
