using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x06001957 RID: 6487 RVA: 0x000FE033 File Offset: 0x000FC233
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001958 RID: 6488 RVA: 0x000FE04C File Offset: 0x000FC24C
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

	// Token: 0x04002803 RID: 10243
	public ToiletEventScript ToiletEvent;

	// Token: 0x04002804 RID: 10244
	public YandereScript Yandere;

	// Token: 0x04002805 RID: 10245
	public PromptScript Prompt;

	// Token: 0x04002806 RID: 10246
	public Transform ElectrocutionSpot;

	// Token: 0x04002807 RID: 10247
	public GameObject BathroomLight;

	// Token: 0x04002808 RID: 10248
	public GameObject Electricity;

	// Token: 0x04002809 RID: 10249
	public Rigidbody Panel;

	// Token: 0x0400280A RID: 10250
	public Transform Wires;

	// Token: 0x0400280B RID: 10251
	public AudioClip[] ReactionClips;

	// Token: 0x0400280C RID: 10252
	public string[] ReactionTexts;

	// Token: 0x0400280D RID: 10253
	public AudioClip[] Flick;

	// Token: 0x0400280E RID: 10254
	public float SubtitleTimer;

	// Token: 0x0400280F RID: 10255
	public float FlickerTimer;

	// Token: 0x04002810 RID: 10256
	public int ReactionID;

	// Token: 0x04002811 RID: 10257
	public bool Flicker;
}
