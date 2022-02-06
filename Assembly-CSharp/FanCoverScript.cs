using System;
using UnityEngine;

// Token: 0x020002C7 RID: 711
public class FanCoverScript : MonoBehaviour
{
	// Token: 0x06001491 RID: 5265 RVA: 0x000C98BC File Offset: 0x000C7ABC
	private void Start()
	{
		if (this.StudentManager.Eighties || this.StudentManager.Students[this.RivalID] == null)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
			return;
		}
		this.Rival = this.StudentManager.Students[this.RivalID];
	}

	// Token: 0x06001492 RID: 5266 RVA: 0x000C9928 File Offset: 0x000C7B28
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 2f)
		{
			if (this.Yandere.Armed)
			{
				if (this.Yandere.EquippedWeapon.WeaponID == 6 && this.Rival.Meeting && this.Rival.DistanceToDestination < 0.1f && this.NoteWindow.MeetID == 9)
				{
					this.Prompt.HideButton[0] = false;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.CharacterAnimation.CrossFade("f02_fanMurderA_00");
			this.Rival.CharacterAnimation.CrossFade("f02_fanMurderB_00");
			this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("fanMurderHair");
			this.Rival.enabled = false;
			this.Yandere.EmptyHands();
			this.Rival.OsanaHair.transform.parent = this.Rival.transform;
			this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
			this.Rival.OsanaHair.transform.localPosition = Vector3.zero;
			this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
			this.Rival.OsanaHairL.enabled = false;
			this.Rival.OsanaHairR.enabled = false;
			this.Rival.Distracted = true;
			this.Yandere.CanMove = false;
			this.Rival.Meeting = false;
			this.Rival.Blind = true;
			this.FanSFX.enabled = false;
			base.GetComponent<AudioSource>().Play();
			base.transform.localPosition = new Vector3(-1.733f, 0.465f, 0.952f);
			base.transform.localEulerAngles = new Vector3(-90f, 165f, 0f);
			Physics.SyncTransforms();
			Rigidbody component = base.GetComponent<Rigidbody>();
			component.isKinematic = false;
			component.useGravity = true;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.Phase++;
			if (GameGlobals.CensorBlood)
			{
				this.YandereBloodTextures = this.Yandere.FlowerTextures;
				this.BloodTexture = this.Yandere.FlowerTextures;
				this.Particles[1].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = this.Yandere.FlowerTextures[1];
				this.Particles[2].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = this.Yandere.FlowerTextures[1];
				this.Particles[3].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = this.Yandere.FlowerTextures[1];
				this.Particles[1].colorOverLifetime.enabled = false;
				this.Particles[2].colorOverLifetime.enabled = false;
				this.Particles[3].colorOverLifetime.enabled = false;
				this.Yandere.Blur.enabled = true;
				this.Yandere.Blur.Size = 1f;
			}
		}
		if (this.Phase > 0)
		{
			this.Yandere.Sanity -= Time.deltaTime * 10f * this.Yandere.Numbness;
			if (this.Phase == 1)
			{
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.MurderSpot.rotation, Time.deltaTime * 10f);
				this.Yandere.MoveTowardsTarget(this.MurderSpot.position);
				if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 3.5f && !this.Reacted)
				{
					AudioSource.PlayClipAtPoint(this.RivalReaction, this.Rival.transform.position + new Vector3(0f, 1f, 0f));
					this.Yandere.MurderousActionTimer = 999f;
					this.Reacted = true;
				}
				if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 5f)
				{
					this.Rival.LiquidProjector.material.mainTexture = this.Rival.BloodTexture;
					this.Rival.LiquidProjector.enabled = true;
					this.Rival.EyeShrink = 1f;
					this.Yandere.BloodTextures = this.YandereBloodTextures;
					this.Yandere.Bloodiness += 20f;
					if (!this.Yandere.NoStainGloves)
					{
						if (this.Yandere.Gloved && !this.Yandere.Gloves.Blood.enabled)
						{
							this.Yandere.GloveAttacher.newRenderer.material.mainTexture = this.Yandere.BloodyGloveTexture;
							this.Yandere.Gloves.PickUp.Evidence = true;
							this.Yandere.Gloves.Blood.enabled = true;
							this.Yandere.GloveBlood = 1;
							this.Yandere.Police.BloodyClothing++;
						}
						if (this.Yandere.Mask != null && !this.Yandere.Mask.Blood.enabled)
						{
							this.Yandere.Mask.PickUp.Evidence = true;
							this.Yandere.Mask.Blood.enabled = true;
							this.Yandere.Police.BloodyClothing++;
						}
					}
					this.BloodProjector.gameObject.SetActive(true);
					this.BloodProjector.material.mainTexture = this.BloodTexture[1];
					this.BloodEffects.transform.parent = this.Rival.Head;
					this.BloodEffects.transform.localPosition = new Vector3(0f, 0.1f, 0f);
					this.BloodEffects.Play();
					this.Phase++;
				}
				if (this.Yandere.Blur.enabled)
				{
					this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 10f, Time.deltaTime * 2f);
					return;
				}
			}
			else if (this.Phase < 10)
			{
				if (this.Phase < 6)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						this.Phase++;
						if (this.Phase - 1 < 5)
						{
							this.BloodProjector.material.mainTexture = this.BloodTexture[this.Phase - 1];
							this.Yandere.Bloodiness += 20f;
							this.Timer = 0f;
						}
					}
				}
				if (this.Rival.CharacterAnimation["f02_fanMurderB_00"].time >= this.Rival.CharacterAnimation["f02_fanMurderB_00"].length)
				{
					this.BloodProjector.material.mainTexture = this.BloodTexture[5];
					this.Yandere.Bloodiness += 20f;
					this.Rival.Ragdoll.Decapitated = true;
					this.Rival.OsanaHair.SetActive(false);
					this.Rival.DeathType = DeathType.Weapon;
					this.Rival.BecomeRagdoll();
					this.BloodEffects.Stop();
					this.Explosion.SetActive(true);
					this.Smoke.SetActive(true);
					this.Fan.enabled = false;
					this.Phase = 10;
					return;
				}
			}
			else
			{
				if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length)
				{
					this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 0f, Time.deltaTime);
					this.Yandere.MurderousActionTimer = 0f;
					this.OfferHelp.SetActive(false);
					this.Yandere.CanMove = true;
					this.Yandere.Blur.Size = 0f;
					base.enabled = false;
					return;
				}
				if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length - 5f && this.Yandere.Blur.enabled)
				{
					this.Yandere.Blur.Size = Mathf.MoveTowards(this.Yandere.Blur.Size, 0f, Time.deltaTime * 2f);
				}
			}
		}
	}

	// Token: 0x0400200B RID: 8203
	public StudentManagerScript StudentManager;

	// Token: 0x0400200C RID: 8204
	public NoteWindowScript NoteWindow;

	// Token: 0x0400200D RID: 8205
	public YandereScript Yandere;

	// Token: 0x0400200E RID: 8206
	public PromptScript Prompt;

	// Token: 0x0400200F RID: 8207
	public StudentScript Rival;

	// Token: 0x04002010 RID: 8208
	public SM_rotateThis Fan;

	// Token: 0x04002011 RID: 8209
	public ParticleSystem BloodEffects;

	// Token: 0x04002012 RID: 8210
	public Projector BloodProjector;

	// Token: 0x04002013 RID: 8211
	public Rigidbody MyRigidbody;

	// Token: 0x04002014 RID: 8212
	public Transform MurderSpot;

	// Token: 0x04002015 RID: 8213
	public GameObject Explosion;

	// Token: 0x04002016 RID: 8214
	public GameObject OfferHelp;

	// Token: 0x04002017 RID: 8215
	public GameObject Smoke;

	// Token: 0x04002018 RID: 8216
	public AudioClip RivalReaction;

	// Token: 0x04002019 RID: 8217
	public AudioSource FanSFX;

	// Token: 0x0400201A RID: 8218
	public Texture[] YandereBloodTextures;

	// Token: 0x0400201B RID: 8219
	public Texture[] BloodTexture;

	// Token: 0x0400201C RID: 8220
	public ParticleSystem[] Particles;

	// Token: 0x0400201D RID: 8221
	public bool Reacted;

	// Token: 0x0400201E RID: 8222
	public float Timer;

	// Token: 0x0400201F RID: 8223
	public int RivalID = 11;

	// Token: 0x04002020 RID: 8224
	public int Phase;
}
