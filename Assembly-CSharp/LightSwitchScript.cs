using System;
using UnityEngine;

// Token: 0x02000353 RID: 851
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x0600197B RID: 6523 RVA: 0x00100383 File Offset: 0x000FE583
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x0600197C RID: 6524 RVA: 0x0010039C File Offset: 0x000FE59C
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

	// Token: 0x0400286C RID: 10348
	public ToiletEventScript ToiletEvent;

	// Token: 0x0400286D RID: 10349
	public YandereScript Yandere;

	// Token: 0x0400286E RID: 10350
	public PromptScript Prompt;

	// Token: 0x0400286F RID: 10351
	public Transform ElectrocutionSpot;

	// Token: 0x04002870 RID: 10352
	public GameObject BathroomLight;

	// Token: 0x04002871 RID: 10353
	public GameObject Electricity;

	// Token: 0x04002872 RID: 10354
	public Rigidbody Panel;

	// Token: 0x04002873 RID: 10355
	public Transform Wires;

	// Token: 0x04002874 RID: 10356
	public AudioClip[] ReactionClips;

	// Token: 0x04002875 RID: 10357
	public string[] ReactionTexts;

	// Token: 0x04002876 RID: 10358
	public AudioClip[] Flick;

	// Token: 0x04002877 RID: 10359
	public float SubtitleTimer;

	// Token: 0x04002878 RID: 10360
	public float FlickerTimer;

	// Token: 0x04002879 RID: 10361
	public int ReactionID;

	// Token: 0x0400287A RID: 10362
	public bool Flicker;
}
