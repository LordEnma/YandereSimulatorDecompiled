﻿using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class KnifeDetectorScript : MonoBehaviour
{
	// Token: 0x0600193C RID: 6460 RVA: 0x000FC83E File Offset: 0x000FAA3E
	private void Start()
	{
		this.Disable();
	}

	// Token: 0x0600193D RID: 6461 RVA: 0x000FC848 File Offset: 0x000FAA48
	private void Update()
	{
		if (this.Blowtorches[1].transform.parent != this.Torches || this.Blowtorches[2].transform.parent != this.Torches || this.Blowtorches[3].transform.parent != this.Torches)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = true;
			base.enabled = false;
		}
		if (this.Yandere.Armed)
		{
			if (this.Yandere.EquippedWeapon.WeaponID == 8)
			{
				this.Prompt.MyCollider.enabled = true;
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
					{
						this.Yandere.CharacterAnimation.CrossFade("f02_heating_00");
						this.Yandere.CanMove = false;
						this.Timer = 5f;
						this.Blowtorches[1].enabled = true;
						this.Blowtorches[2].enabled = true;
						this.Blowtorches[3].enabled = true;
						this.Blowtorches[1].GetComponent<AudioSource>().Play();
						this.Blowtorches[2].GetComponent<AudioSource>().Play();
						this.Blowtorches[3].GetComponent<AudioSource>().Play();
					}
				}
			}
			else
			{
				this.Disable();
			}
		}
		else
		{
			this.Disable();
		}
		if (this.Timer > 0f)
		{
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.HeatingSpot.rotation, Time.deltaTime * 10f);
			this.Yandere.MoveTowardsTarget(this.HeatingSpot.position);
			WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
			Material material = equippedWeapon.MyRenderer.material;
			material.color = new Color(material.color.r, Mathf.MoveTowards(material.color.g, 0.5f, Time.deltaTime * 0.2f), Mathf.MoveTowards(material.color.b, 0.5f, Time.deltaTime * 0.2f), material.color.a);
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Timer == 0f)
			{
				equippedWeapon.Heated = true;
				base.enabled = false;
				this.Disable();
			}
		}
	}

	// Token: 0x0600193E RID: 6462 RVA: 0x000FCB18 File Offset: 0x000FAD18
	private void Disable()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
	}

	// Token: 0x040027C0 RID: 10176
	public BlowtorchScript[] Blowtorches;

	// Token: 0x040027C1 RID: 10177
	public Transform HeatingSpot;

	// Token: 0x040027C2 RID: 10178
	public Transform Torches;

	// Token: 0x040027C3 RID: 10179
	public YandereScript Yandere;

	// Token: 0x040027C4 RID: 10180
	public PromptScript Prompt;

	// Token: 0x040027C5 RID: 10181
	public float Timer;
}
