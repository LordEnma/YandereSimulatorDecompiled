using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x06001960 RID: 6496 RVA: 0x000FECA3 File Offset: 0x000FCEA3
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001961 RID: 6497 RVA: 0x000FECBC File Offset: 0x000FCEBC
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

	// Token: 0x04002828 RID: 10280
	public ToiletEventScript ToiletEvent;

	// Token: 0x04002829 RID: 10281
	public YandereScript Yandere;

	// Token: 0x0400282A RID: 10282
	public PromptScript Prompt;

	// Token: 0x0400282B RID: 10283
	public Transform ElectrocutionSpot;

	// Token: 0x0400282C RID: 10284
	public GameObject BathroomLight;

	// Token: 0x0400282D RID: 10285
	public GameObject Electricity;

	// Token: 0x0400282E RID: 10286
	public Rigidbody Panel;

	// Token: 0x0400282F RID: 10287
	public Transform Wires;

	// Token: 0x04002830 RID: 10288
	public AudioClip[] ReactionClips;

	// Token: 0x04002831 RID: 10289
	public string[] ReactionTexts;

	// Token: 0x04002832 RID: 10290
	public AudioClip[] Flick;

	// Token: 0x04002833 RID: 10291
	public float SubtitleTimer;

	// Token: 0x04002834 RID: 10292
	public float FlickerTimer;

	// Token: 0x04002835 RID: 10293
	public int ReactionID;

	// Token: 0x04002836 RID: 10294
	public bool Flicker;
}
