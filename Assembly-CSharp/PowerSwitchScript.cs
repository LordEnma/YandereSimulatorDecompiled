using UnityEngine;

public class PowerSwitchScript : MonoBehaviour
{
	public DrinkingFountainScript DrinkingFountain;

	public PowerOutletScript PowerOutlet;

	public GameObject PuddleDetector;

	public GameObject Electricity;

	public GameObject NewPuddle;

	public Light BathroomLight;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public AudioClip[] Flick;

	public bool Haunted;

	public bool On;

	public GameObject NewPuddleDetector;

	private void Start()
	{
		if (BathroomLight != null)
		{
			Prompt.Label[0].text = "     Turn Off";
		}
		if (!GameGlobals.Eighties && Haunted)
		{
			BathroomLight = null;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		On = !On;
		if (BathroomLight == null)
		{
			if (On)
			{
				Prompt.Label[0].text = "     Turn Off";
				MyAudio.clip = Flick[1];
			}
			else
			{
				Prompt.Label[0].text = "     Turn On";
				MyAudio.clip = Flick[0];
			}
		}
		else
		{
			if (On)
			{
				Prompt.Label[0].text = "     Turn Off";
				MyAudio.clip = Flick[1];
			}
			else
			{
				Prompt.Label[0].text = "     Turn On";
				MyAudio.clip = Flick[0];
			}
			BathroomLight.enabled = !BathroomLight.enabled;
		}
		CheckPuddle();
		MyAudio.Play();
	}

	public void CheckPuddle()
	{
		Debug.Log("The lightswitch is currently: " + On);
		if (On)
		{
			NewPuddleDetector = Object.Instantiate(PuddleDetector, PowerOutlet.SabotagedOutlet.transform.position, Quaternion.identity);
			NewPuddleDetector.transform.parent = PowerOutlet.SabotagedOutlet.transform;
			NewPuddleDetector.transform.localPosition = new Vector3(0.08555f, 0f, 0.03445f);
			NewPuddleDetector.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			NewPuddleDetector.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			NewPuddleDetector.GetComponent<PuddleDetectorScript>().PowerSwitch = this;
			if (DrinkingFountain.Puddle != null && DrinkingFountain.Puddle.gameObject.activeInHierarchy && PowerOutlet.SabotagedOutlet.activeInHierarchy)
			{
				Electricity.transform.position = DrinkingFountain.Puddle.transform.position;
				Electricity.SetActive(value: true);
			}
		}
		else
		{
			Electricity.SetActive(value: false);
		}
	}
}
