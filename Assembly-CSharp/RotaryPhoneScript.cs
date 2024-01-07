using UnityEngine;

public class RotaryPhoneScript : MonoBehaviour
{
	public PhoneReticleScript PhoneReticle;

	public GameObject ColliderParent;

	public GameObject FunCutscene;

	public UILabel PhoneNumberLabel;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public Transform Reticle;

	public bool Interacting;

	public string PhoneNumber;

	public int[] Numbers;

	private void Start()
	{
		if (!GameGlobals.EightiesTutorial)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.transform.position = new Vector3(-26f, 0f, -4f);
			Prompt.Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			Prompt.Yandere.RPGCamera.enabled = false;
			Prompt.Yandere.CanMove = false;
			Prompt.Yandere.MainCamera.transform.position = new Vector3(-26f, 1f, -3.133333f);
			Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(45f, 0f, 0f);
			Prompt.Yandere.PromptBar.ClearButtons();
			Prompt.Yandere.PromptBar.Label[0].text = "Enter Number";
			Prompt.Yandere.PromptBar.Label[1].text = "Exit";
			Prompt.Yandere.PromptBar.Label[2].text = "Call";
			Prompt.Yandere.PromptBar.Label[4].text = "Move";
			Prompt.Yandere.PromptBar.Label[5].text = "Move";
			Prompt.Yandere.PromptBar.UpdateButtons();
			Prompt.Yandere.PromptBar.Show = true;
			Prompt.Yandere.CameraEffects.UpdateDOF(0.1775f);
			PhoneNumberLabel.transform.parent.gameObject.SetActive(value: true);
			ColliderParent.SetActive(value: true);
			Interacting = true;
		}
		if (!Interacting)
		{
			return;
		}
		if (Input.GetAxis("Horizontal") > 0f || Input.GetKey("right"))
		{
			if (Input.GetAxis("Horizontal") > 0f)
			{
				Reticle.localPosition += new Vector3(Time.deltaTime * Input.GetAxis("Horizontal") * 0.1f, 0f, 0f);
			}
			else
			{
				Reticle.localPosition += new Vector3(Time.deltaTime * 0.1f, 0f, 0f);
			}
		}
		else if (Input.GetAxis("Horizontal") < 0f || Input.GetKey("left"))
		{
			if (Input.GetAxis("Horizontal") < 0f)
			{
				Reticle.localPosition += new Vector3(Time.deltaTime * Input.GetAxis("Horizontal") * 0.1f, 0f, 0f);
			}
			else
			{
				Reticle.localPosition -= new Vector3(Time.deltaTime * 0.1f, 0f, 0f);
			}
		}
		if (Input.GetAxis("Vertical") > 0f || Input.GetKey("up"))
		{
			if (Input.GetAxis("Vertical") > 0f)
			{
				Reticle.localPosition += new Vector3(0f, 0f, Time.deltaTime * Input.GetAxis("Vertical") * 0.1f);
			}
			else
			{
				Reticle.localPosition += new Vector3(0f, 0f, Time.deltaTime * 0.1f);
			}
		}
		else if (Input.GetAxis("Vertical") < 0f || Input.GetKey("down"))
		{
			if (Input.GetAxis("Vertical") < 0f)
			{
				Reticle.localPosition += new Vector3(0f, 0f, Time.deltaTime * Input.GetAxis("Vertical") * 0.1f);
			}
			else
			{
				Reticle.localPosition -= new Vector3(0f, 0f, Time.deltaTime * 0.1f);
			}
		}
		if (Reticle.localPosition.x > 0.025f)
		{
			Reticle.localPosition = new Vector3(0.025f, 0f, Reticle.localPosition.z);
		}
		if (Reticle.localPosition.x < -0.025f)
		{
			Reticle.localPosition = new Vector3(-0.025f, 0f, Reticle.localPosition.z);
		}
		if (Reticle.localPosition.z > 0.014f)
		{
			Reticle.localPosition = new Vector3(Reticle.localPosition.x, 0f, 0.014f);
		}
		if (Reticle.localPosition.z < -0.036f)
		{
			Reticle.localPosition = new Vector3(Reticle.localPosition.x, 0f, -0.036f);
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (PhoneReticle.CurrentNumber < 10)
			{
				ShuffleNumbers();
				MyAudio.pitch = 1f + (float)PhoneReticle.CurrentNumber * 0.1f;
				MyAudio.Play();
				PhoneNumberLabel.text = PhoneNumber;
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			Prompt.Yandere.RPGCamera.enabled = true;
			Prompt.Yandere.CanMove = true;
			Exit();
		}
		if (PhoneNumber == "75-067-5708")
		{
			Prompt.Yandere.PromptBar.Label[2].text = "Call";
			Prompt.Yandere.PromptBar.UpdateButtons();
			if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				Prompt.Yandere.StudentManager.Tutorial.Jukebox.SetActive(value: false);
				FunCutscene.SetActive(value: true);
				Prompt.enabled = false;
				base.enabled = false;
				Prompt.Hide();
				Exit();
			}
		}
		else
		{
			Prompt.Yandere.PromptBar.Label[2].text = "";
			Prompt.Yandere.PromptBar.UpdateButtons();
		}
	}

	public void ShuffleNumbers()
	{
		Numbers[1] = Numbers[2];
		Numbers[2] = Numbers[3];
		Numbers[3] = Numbers[4];
		Numbers[4] = Numbers[5];
		Numbers[5] = Numbers[6];
		Numbers[6] = Numbers[7];
		Numbers[7] = Numbers[8];
		Numbers[8] = Numbers[9];
		Numbers[9] = PhoneReticle.CurrentNumber;
		PhoneNumber = Numbers[1].ToString() + Numbers[2] + "-" + Numbers[3] + Numbers[4] + Numbers[5] + "-" + Numbers[6] + Numbers[7] + Numbers[8] + Numbers[9];
	}

	public void Exit()
	{
		Prompt.Yandere.CameraEffects.UpdateDOF(2f);
		Prompt.Yandere.PromptBar.ClearButtons();
		Prompt.Yandere.PromptBar.Show = false;
		PhoneNumberLabel.transform.parent.gameObject.SetActive(value: false);
		ColliderParent.SetActive(value: false);
		Interacting = false;
	}
}
