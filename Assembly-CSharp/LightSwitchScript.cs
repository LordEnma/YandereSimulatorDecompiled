using System;
using UnityEngine;

// Token: 0x02000352 RID: 850
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x0600196D RID: 6509 RVA: 0x000FFAEB File Offset: 0x000FDCEB
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x0600196E RID: 6510 RVA: 0x000FFB04 File Offset: 0x000FDD04
	private void Update()
	{
		if (this.Flicker)
		{
			this.FlickerTimer += Time.deltaTime;
			if (this.FlickerTimer > 0.1f)
			{
				this.FlickerTimer = 0f;
				this.BathroomLight.SetActive(!this.BathroomLight.activeInHierarchy);
			}
		}
		if (!this.Panel.useGravity)
		{
			if (this.Yandere.Armed)
			{
				this.Prompt.HideButton[3] = (this.Yandere.EquippedWeapon.WeaponID != 6);
			}
			else
			{
				this.Prompt.HideButton[3] = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.BathroomLight.activeInHierarchy)
			{
				this.Prompt.Label[0].text = "     Turn On";
				this.BathroomLight.SetActive(false);
				component.clip = this.Flick[1];
				component.Play();
				if (this.ToiletEvent.EventActive && (this.ToiletEvent.EventPhase == 2 || this.ToiletEvent.EventPhase == 3))
				{
					this.ReactionID = UnityEngine.Random.Range(1, 4);
					AudioClipPlayer.Play(this.ReactionClips[this.ReactionID], this.ToiletEvent.EventStudent.transform.position, 5f, 10f, out this.ToiletEvent.VoiceClip);
					this.ToiletEvent.EventSubtitle.text = this.ReactionTexts[this.ReactionID];
					this.SubtitleTimer += Time.deltaTime;
				}
			}
			else
			{
				this.Prompt.Label[0].text = "     Turn Off";
				this.BathroomLight.SetActive(true);
				component.clip = this.Flick[0];
				component.Play();
			}
		}
		if (this.SubtitleTimer > 0f)
		{
			this.SubtitleTimer += Time.deltaTime;
			if (this.SubtitleTimer > 3f)
			{
				this.ToiletEvent.EventSubtitle.text = string.Empty;
				this.SubtitleTimer = 0f;
			}
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.HideButton[3] = true;
			this.Wires.localScale = new Vector3(this.Wires.localScale.x, this.Wires.localScale.y, 1f);
			this.Panel.useGravity = true;
			this.Panel.AddForce(0f, 0f, 10f);
		}
	}

	// Token: 0x04002858 RID: 10328
	public ToiletEventScript ToiletEvent;

	// Token: 0x04002859 RID: 10329
	public YandereScript Yandere;

	// Token: 0x0400285A RID: 10330
	public PromptScript Prompt;

	// Token: 0x0400285B RID: 10331
	public Transform ElectrocutionSpot;

	// Token: 0x0400285C RID: 10332
	public GameObject BathroomLight;

	// Token: 0x0400285D RID: 10333
	public GameObject Electricity;

	// Token: 0x0400285E RID: 10334
	public Rigidbody Panel;

	// Token: 0x0400285F RID: 10335
	public Transform Wires;

	// Token: 0x04002860 RID: 10336
	public AudioClip[] ReactionClips;

	// Token: 0x04002861 RID: 10337
	public string[] ReactionTexts;

	// Token: 0x04002862 RID: 10338
	public AudioClip[] Flick;

	// Token: 0x04002863 RID: 10339
	public float SubtitleTimer;

	// Token: 0x04002864 RID: 10340
	public float FlickerTimer;

	// Token: 0x04002865 RID: 10341
	public int ReactionID;

	// Token: 0x04002866 RID: 10342
	public bool Flicker;
}
