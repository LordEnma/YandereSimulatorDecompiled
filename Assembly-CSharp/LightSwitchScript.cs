using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x06001940 RID: 6464 RVA: 0x000FC8F7 File Offset: 0x000FAAF7
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001941 RID: 6465 RVA: 0x000FC910 File Offset: 0x000FAB10
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

	// Token: 0x040027C3 RID: 10179
	public ToiletEventScript ToiletEvent;

	// Token: 0x040027C4 RID: 10180
	public YandereScript Yandere;

	// Token: 0x040027C5 RID: 10181
	public PromptScript Prompt;

	// Token: 0x040027C6 RID: 10182
	public Transform ElectrocutionSpot;

	// Token: 0x040027C7 RID: 10183
	public GameObject BathroomLight;

	// Token: 0x040027C8 RID: 10184
	public GameObject Electricity;

	// Token: 0x040027C9 RID: 10185
	public Rigidbody Panel;

	// Token: 0x040027CA RID: 10186
	public Transform Wires;

	// Token: 0x040027CB RID: 10187
	public AudioClip[] ReactionClips;

	// Token: 0x040027CC RID: 10188
	public string[] ReactionTexts;

	// Token: 0x040027CD RID: 10189
	public AudioClip[] Flick;

	// Token: 0x040027CE RID: 10190
	public float SubtitleTimer;

	// Token: 0x040027CF RID: 10191
	public float FlickerTimer;

	// Token: 0x040027D0 RID: 10192
	public int ReactionID;

	// Token: 0x040027D1 RID: 10193
	public bool Flicker;
}
