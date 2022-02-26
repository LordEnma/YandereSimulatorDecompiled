using System;
using UnityEngine;

// Token: 0x02000366 RID: 870
public class MetalDetectorScript : MonoBehaviour
{
	// Token: 0x060019A3 RID: 6563 RVA: 0x00105F23 File Offset: 0x00104123
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x060019A4 RID: 6564 RVA: 0x00105F34 File Offset: 0x00104134
	private void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.EquippedWeapon.WeaponID == 6)
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.MyAudio.Play();
					this.MyCollider.enabled = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					base.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Spraying)
		{
			this.SprayTimer += Time.deltaTime;
			if ((double)this.SprayTimer > 0.66666)
			{
				if (this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.Drop();
				}
				this.Yandere.EmptyHands();
				this.PepperSprayEffect.Play();
				this.Spraying = false;
			}
		}
		this.MyAudio.volume -= Time.deltaTime * 0.01f;
	}

	// Token: 0x060019A5 RID: 6565 RVA: 0x00106090 File Offset: 0x00104290
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && (component.FragileSlave || (component.Slave && component.MyWeapon.Metal)) && !this.MyAudio.isPlaying)
			{
				this.MyAudio.clip = this.Alarm;
				this.MyAudio.Play();
				this.MyAudio.volume = 0.1f;
				AudioSource.PlayClipAtPoint(this.PepperSprayNoVoice, base.transform.position);
				this.PepperSprayEffect.transform.position = new Vector3(base.transform.position.x, component.transform.position.y + 1.8f, component.transform.position.z);
				this.PepperSprayEffect.Play();
			}
		}
		if (this.Yandere.enabled)
		{
			bool flag = false;
			if (this.MissionMode.GameOverID == 0 && other.gameObject.layer == 13)
			{
				for (int i = 1; i < 4; i++)
				{
					WeaponScript weaponScript = this.Yandere.Weapon[i];
					flag |= (weaponScript != null && weaponScript.Metal);
					if (!flag)
					{
						if (this.Yandere.Container != null && this.Yandere.Container.Weapon != null)
						{
							weaponScript = this.Yandere.Container.Weapon;
							flag = weaponScript.Metal;
						}
						if (this.Yandere.PickUp != null)
						{
							if (this.Yandere.PickUp.TrashCan != null && this.Yandere.PickUp.TrashCan.Weapon)
							{
								weaponScript = this.Yandere.PickUp.TrashCan.Item.GetComponent<WeaponScript>();
								flag = weaponScript.Metal;
							}
							if (this.Yandere.PickUp.StuckBoxCutter != null)
							{
								weaponScript = this.Yandere.PickUp.StuckBoxCutter;
								flag = true;
							}
						}
					}
				}
				if (flag && !this.Yandere.Inventory.IDCard)
				{
					if (this.MissionMode.enabled)
					{
						this.MissionMode.GameOverID = 16;
						this.MissionMode.GameOver();
						this.MissionMode.Phase = 4;
						base.enabled = false;
						return;
					}
					if (!this.Yandere.Sprayed)
					{
						this.MyAudio.clip = this.Alarm;
						this.MyAudio.loop = true;
						this.MyAudio.Play();
						this.MyAudio.volume = 0.1f;
						AudioSource.PlayClipAtPoint(this.PepperSpraySFX, base.transform.position);
						if (this.Yandere.Aiming)
						{
							this.Yandere.StopAiming();
						}
						this.PepperSprayEffect.transform.position = new Vector3(base.transform.position.x, this.Yandere.transform.position.y + 1.8f, this.Yandere.transform.position.z);
						this.Spraying = true;
						this.Yandere.CharacterAnimation.CrossFade("f02_sprayed_00");
						this.Yandere.FollowHips = true;
						this.Yandere.Punching = false;
						this.Yandere.CanMove = false;
						this.Yandere.Sprayed = true;
						this.Yandere.StudentManager.YandereDying = true;
						this.Yandere.StudentManager.StopMoving();
						this.Yandere.Blur.Size = 1f;
						this.Yandere.Jukebox.Volume = 0f;
						Time.timeScale = 1f;
					}
				}
			}
		}
	}

	// Token: 0x0400290B RID: 10507
	public MissionModeScript MissionMode;

	// Token: 0x0400290C RID: 10508
	public YandereScript Yandere;

	// Token: 0x0400290D RID: 10509
	public PromptScript Prompt;

	// Token: 0x0400290E RID: 10510
	public ParticleSystem PepperSprayEffect;

	// Token: 0x0400290F RID: 10511
	public AudioSource MyAudio;

	// Token: 0x04002910 RID: 10512
	public AudioClip PepperSprayNoVoice;

	// Token: 0x04002911 RID: 10513
	public AudioClip PepperSpraySFX;

	// Token: 0x04002912 RID: 10514
	public AudioClip Alarm;

	// Token: 0x04002913 RID: 10515
	public Collider MyCollider;

	// Token: 0x04002914 RID: 10516
	public float SprayTimer;

	// Token: 0x04002915 RID: 10517
	public bool Spraying;
}
