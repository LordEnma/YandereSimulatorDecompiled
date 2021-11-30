using System;
using UnityEngine;

// Token: 0x020002C5 RID: 709
public class FanCoverScript : MonoBehaviour
{
	// Token: 0x06001485 RID: 5253 RVA: 0x000C87DC File Offset: 0x000C69DC
	private void Start()
	{
		if (this.StudentManager.Students[this.RivalID] == null)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
			return;
		}
		this.Rival = this.StudentManager.Students[this.RivalID];
	}

	// Token: 0x06001486 RID: 5254 RVA: 0x000C883C File Offset: 0x000C6A3C
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
			else if (this.Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= this.Yandere.CharacterAnimation["f02_fanMurderA_00"].length)
			{
				this.Yandere.MurderousActionTimer = 0f;
				this.OfferHelp.SetActive(false);
				this.Yandere.CanMove = true;
				base.enabled = false;
			}
		}
	}

	// Token: 0x04001FDA RID: 8154
	public StudentManagerScript StudentManager;

	// Token: 0x04001FDB RID: 8155
	public NoteWindowScript NoteWindow;

	// Token: 0x04001FDC RID: 8156
	public YandereScript Yandere;

	// Token: 0x04001FDD RID: 8157
	public PromptScript Prompt;

	// Token: 0x04001FDE RID: 8158
	public StudentScript Rival;

	// Token: 0x04001FDF RID: 8159
	public SM_rotateThis Fan;

	// Token: 0x04001FE0 RID: 8160
	public ParticleSystem BloodEffects;

	// Token: 0x04001FE1 RID: 8161
	public Projector BloodProjector;

	// Token: 0x04001FE2 RID: 8162
	public Rigidbody MyRigidbody;

	// Token: 0x04001FE3 RID: 8163
	public Transform MurderSpot;

	// Token: 0x04001FE4 RID: 8164
	public GameObject Explosion;

	// Token: 0x04001FE5 RID: 8165
	public GameObject OfferHelp;

	// Token: 0x04001FE6 RID: 8166
	public GameObject Smoke;

	// Token: 0x04001FE7 RID: 8167
	public AudioClip RivalReaction;

	// Token: 0x04001FE8 RID: 8168
	public AudioSource FanSFX;

	// Token: 0x04001FE9 RID: 8169
	public Texture[] YandereBloodTextures;

	// Token: 0x04001FEA RID: 8170
	public Texture[] BloodTexture;

	// Token: 0x04001FEB RID: 8171
	public bool Reacted;

	// Token: 0x04001FEC RID: 8172
	public float Timer;

	// Token: 0x04001FED RID: 8173
	public int RivalID = 11;

	// Token: 0x04001FEE RID: 8174
	public int Phase;
}
