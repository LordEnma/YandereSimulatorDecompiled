using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x06001960 RID: 6496 RVA: 0x000FE963 File Offset: 0x000FCB63
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001961 RID: 6497 RVA: 0x000FE97C File Offset: 0x000FCB7C
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

	// Token: 0x04002812 RID: 10258
	public ToiletEventScript ToiletEvent;

	// Token: 0x04002813 RID: 10259
	public YandereScript Yandere;

	// Token: 0x04002814 RID: 10260
	public PromptScript Prompt;

	// Token: 0x04002815 RID: 10261
	public Transform ElectrocutionSpot;

	// Token: 0x04002816 RID: 10262
	public GameObject BathroomLight;

	// Token: 0x04002817 RID: 10263
	public GameObject Electricity;

	// Token: 0x04002818 RID: 10264
	public Rigidbody Panel;

	// Token: 0x04002819 RID: 10265
	public Transform Wires;

	// Token: 0x0400281A RID: 10266
	public AudioClip[] ReactionClips;

	// Token: 0x0400281B RID: 10267
	public string[] ReactionTexts;

	// Token: 0x0400281C RID: 10268
	public AudioClip[] Flick;

	// Token: 0x0400281D RID: 10269
	public float SubtitleTimer;

	// Token: 0x0400281E RID: 10270
	public float FlickerTimer;

	// Token: 0x0400281F RID: 10271
	public int ReactionID;

	// Token: 0x04002820 RID: 10272
	public bool Flicker;
}
