﻿using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class KnifeDetectorScript : MonoBehaviour
{
	// Token: 0x0600193F RID: 6463 RVA: 0x000FCE3E File Offset: 0x000FB03E
	private void Start()
	{
		this.Disable();
	}

	// Token: 0x06001940 RID: 6464 RVA: 0x000FCE48 File Offset: 0x000FB048
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

	// Token: 0x06001941 RID: 6465 RVA: 0x000FD118 File Offset: 0x000FB318
	private void Disable()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
	}

	// Token: 0x040027CA RID: 10186
	public BlowtorchScript[] Blowtorches;

	// Token: 0x040027CB RID: 10187
	public Transform HeatingSpot;

	// Token: 0x040027CC RID: 10188
	public Transform Torches;

	// Token: 0x040027CD RID: 10189
	public YandereScript Yandere;

	// Token: 0x040027CE RID: 10190
	public PromptScript Prompt;

	// Token: 0x040027CF RID: 10191
	public float Timer;
}
