using UnityEngine;

public class VandalizeCakeMinigameScript : MonoBehaviour
{
	public ModernRivalSabotageScript Sabotage;

	public Transform DollopParent;

	public Transform Reticle;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public GameObject Dollop;

	public int DollopsDropped;

	private void Update()
	{
		if (Input.GetAxis("Horizontal") > 0f || Input.GetKey("right"))
		{
			if (Input.GetAxis("Horizontal") > 0f)
			{
				Reticle.localPosition += new Vector3(Time.deltaTime * Input.GetAxis("Horizontal") * 0.1f * 10f, 0f, 0f);
			}
			else
			{
				Reticle.localPosition += new Vector3(Time.deltaTime * 0.1f * 10f, 0f, 0f);
			}
		}
		else if (Input.GetAxis("Horizontal") < 0f || Input.GetKey("left"))
		{
			if (Input.GetAxis("Horizontal") < 0f)
			{
				Reticle.localPosition += new Vector3(Time.deltaTime * Input.GetAxis("Horizontal") * 0.1f * 10f, 0f, 0f);
			}
			else
			{
				Reticle.localPosition -= new Vector3(Time.deltaTime * 0.1f * 10f, 0f, 0f);
			}
		}
		if (Input.GetAxis("Vertical") > 0f || Input.GetKey("up"))
		{
			if (Input.GetAxis("Vertical") > 0f)
			{
				Reticle.localPosition += new Vector3(0f, 0f, Time.deltaTime * Input.GetAxis("Vertical") * 0.1f * 10f);
			}
			else
			{
				Reticle.localPosition += new Vector3(0f, 0f, Time.deltaTime * 0.1f * 10f);
			}
		}
		else if (Input.GetAxis("Vertical") < 0f || Input.GetKey("down"))
		{
			if (Input.GetAxis("Vertical") < 0f)
			{
				Reticle.localPosition += new Vector3(0f, 0f, Time.deltaTime * Input.GetAxis("Vertical") * 0.1f * 10f);
			}
			else
			{
				Reticle.localPosition -= new Vector3(0f, 0f, Time.deltaTime * 0.1f * 10f);
			}
		}
		if (Reticle.localPosition.x > 0.25f)
		{
			Reticle.localPosition = new Vector3(0.25f, 0f, Reticle.localPosition.z);
		}
		if (Reticle.localPosition.x < -0.266666f)
		{
			Reticle.localPosition = new Vector3(-0.266666f, 0f, Reticle.localPosition.z);
		}
		if (Reticle.localPosition.z > 0.12f)
		{
			Reticle.localPosition = new Vector3(Reticle.localPosition.x, 0f, 0.12f);
		}
		if (Reticle.localPosition.z < -0.1f)
		{
			Reticle.localPosition = new Vector3(Reticle.localPosition.x, 0f, -0.1f);
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			GameObject obj = Object.Instantiate(Dollop, Reticle.position, Quaternion.identity);
			obj.transform.parent = DollopParent;
			obj.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			MyAudio.pitch = Random.Range(0.9f, 1.1f);
			MyAudio.Play();
			DollopsDropped++;
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			Prompt.Yandere.RPGCamera.enabled = true;
			Prompt.Yandere.CanMove = true;
			if (DollopsDropped > 0)
			{
				Sabotage.Prompt.Label[0].text = "     Post Cake on Social Media";
				Sabotage.Phase++;
			}
			Exit();
		}
	}

	public void Exit()
	{
		Prompt.Yandere.CameraEffects.UpdateDOF(2f);
		Prompt.Yandere.PromptBar.ClearButtons();
		Prompt.Yandere.PromptBar.Show = false;
		DollopParent.parent = base.transform.parent;
		base.gameObject.SetActive(value: false);
	}
}
