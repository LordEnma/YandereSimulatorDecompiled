using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
	public ToiletEventScript ToiletEvent;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform ElectrocutionSpot;

	public GameObject BathroomLight;

	public GameObject Electricity;

	public Rigidbody Panel;

	public Transform Wires;

	public AudioClip[] ReactionClips;

	public string[] ReactionTexts;

	public AudioClip[] Flick;

	public float SubtitleTimer;

	public float FlickerTimer;

	public int ReactionID;

	public bool Flicker;

	private void Start()
	{
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	private void Update()
	{
		if (Flicker)
		{
			FlickerTimer += Time.deltaTime;
			if (FlickerTimer > 0.1f)
			{
				FlickerTimer = 0f;
				BathroomLight.SetActive(!BathroomLight.activeInHierarchy);
			}
		}
		if (!Panel.useGravity)
		{
			if (Yandere.Armed)
			{
				Prompt.HideButton[3] = Yandere.EquippedWeapon.WeaponID != 6;
			}
			else
			{
				Prompt.HideButton[3] = true;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			AudioSource component = GetComponent<AudioSource>();
			if (BathroomLight.activeInHierarchy)
			{
				Prompt.Label[0].text = "     Turn On";
				BathroomLight.SetActive(value: false);
				component.clip = Flick[1];
				component.Play();
				if (ToiletEvent.EventActive && (ToiletEvent.EventPhase == 2 || ToiletEvent.EventPhase == 3))
				{
					ReactionID = Random.Range(1, 4);
					AudioClipPlayer.Play(ReactionClips[ReactionID], ToiletEvent.EventStudent.transform.position, 5f, 10f, out ToiletEvent.VoiceClip);
					ToiletEvent.EventSubtitle.text = ReactionTexts[ReactionID];
					SubtitleTimer += Time.deltaTime;
				}
			}
			else
			{
				Prompt.Label[0].text = "     Turn Off";
				BathroomLight.SetActive(value: true);
				component.clip = Flick[0];
				component.Play();
			}
		}
		if (SubtitleTimer > 0f)
		{
			SubtitleTimer += Time.deltaTime;
			if (SubtitleTimer > 3f)
			{
				ToiletEvent.EventSubtitle.text = string.Empty;
				SubtitleTimer = 0f;
			}
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.HideButton[3] = true;
			Wires.localScale = new Vector3(Wires.localScale.x, Wires.localScale.y, 1f);
			Panel.useGravity = true;
			Panel.AddForce(0f, 0f, 10f);
		}
	}
}
