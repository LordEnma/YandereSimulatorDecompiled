using System;
using UnityEngine;

// Token: 0x0200034E RID: 846
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x06001949 RID: 6473 RVA: 0x000FD3C7 File Offset: 0x000FB5C7
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x0600194A RID: 6474 RVA: 0x000FD3E0 File Offset: 0x000FB5E0
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

	// Token: 0x040027EC RID: 10220
	public ToiletEventScript ToiletEvent;

	// Token: 0x040027ED RID: 10221
	public YandereScript Yandere;

	// Token: 0x040027EE RID: 10222
	public PromptScript Prompt;

	// Token: 0x040027EF RID: 10223
	public Transform ElectrocutionSpot;

	// Token: 0x040027F0 RID: 10224
	public GameObject BathroomLight;

	// Token: 0x040027F1 RID: 10225
	public GameObject Electricity;

	// Token: 0x040027F2 RID: 10226
	public Rigidbody Panel;

	// Token: 0x040027F3 RID: 10227
	public Transform Wires;

	// Token: 0x040027F4 RID: 10228
	public AudioClip[] ReactionClips;

	// Token: 0x040027F5 RID: 10229
	public string[] ReactionTexts;

	// Token: 0x040027F6 RID: 10230
	public AudioClip[] Flick;

	// Token: 0x040027F7 RID: 10231
	public float SubtitleTimer;

	// Token: 0x040027F8 RID: 10232
	public float FlickerTimer;

	// Token: 0x040027F9 RID: 10233
	public int ReactionID;

	// Token: 0x040027FA RID: 10234
	public bool Flicker;
}
