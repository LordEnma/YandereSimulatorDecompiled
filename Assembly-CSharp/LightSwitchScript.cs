using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x06001967 RID: 6503 RVA: 0x000FF45F File Offset: 0x000FD65F
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001968 RID: 6504 RVA: 0x000FF478 File Offset: 0x000FD678
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

	// Token: 0x04002845 RID: 10309
	public ToiletEventScript ToiletEvent;

	// Token: 0x04002846 RID: 10310
	public YandereScript Yandere;

	// Token: 0x04002847 RID: 10311
	public PromptScript Prompt;

	// Token: 0x04002848 RID: 10312
	public Transform ElectrocutionSpot;

	// Token: 0x04002849 RID: 10313
	public GameObject BathroomLight;

	// Token: 0x0400284A RID: 10314
	public GameObject Electricity;

	// Token: 0x0400284B RID: 10315
	public Rigidbody Panel;

	// Token: 0x0400284C RID: 10316
	public Transform Wires;

	// Token: 0x0400284D RID: 10317
	public AudioClip[] ReactionClips;

	// Token: 0x0400284E RID: 10318
	public string[] ReactionTexts;

	// Token: 0x0400284F RID: 10319
	public AudioClip[] Flick;

	// Token: 0x04002850 RID: 10320
	public float SubtitleTimer;

	// Token: 0x04002851 RID: 10321
	public float FlickerTimer;

	// Token: 0x04002852 RID: 10322
	public int ReactionID;

	// Token: 0x04002853 RID: 10323
	public bool Flicker;
}
