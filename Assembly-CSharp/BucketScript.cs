using System;
using UnityEngine;

// Token: 0x020000FF RID: 255
public class BucketScript : MonoBehaviour
{
	// Token: 0x06000A8A RID: 2698 RVA: 0x0005D58C File Offset: 0x0005B78C
	private void Start()
	{
		this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, 0f, this.Water.transform.localPosition.z);
		this.Water.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, 0f);
		this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, 0f);
		this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, 0f, this.Gas.transform.localPosition.z);
		this.Gas.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, 0f);
		this.Brown.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		this.Brown.material.color = new Color(this.Brown.material.color.r, this.Brown.material.color.g, this.Brown.material.color.b, 0f);
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06000A8B RID: 2699 RVA: 0x0005D808 File Offset: 0x0005BA08
	private void Update()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (this.PickUp.Clock != null)
		{
			if (this.PickUp.Clock.Period == 5)
			{
				this.PickUp.Suspicious = false;
			}
			else
			{
				this.PickUp.Suspicious = true;
			}
		}
		if (this.Yandere.CanMove)
		{
			this.Distance = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			if (this.Distance < 1f)
			{
				if (this.Yandere.Bucket == null)
				{
					RaycastHit raycastHit;
					if (base.transform.position.y > this.Yandere.transform.position.y - 0.1f && base.transform.position.y < this.Yandere.transform.position.y + 0.1f && Physics.Linecast(base.transform.position, this.Yandere.transform.position + Vector3.up, out raycastHit) && raycastHit.collider.gameObject == this.Yandere.gameObject)
					{
						this.Yandere.Bucket = this;
					}
				}
				else
				{
					RaycastHit raycastHit;
					if (Physics.Linecast(base.transform.position, this.Yandere.transform.position + Vector3.up, out raycastHit) && raycastHit.collider.gameObject != this.Yandere.gameObject)
					{
						this.Yandere.Bucket = null;
					}
					if (base.transform.position.y < this.Yandere.transform.position.y - 0.1f || base.transform.position.y > this.Yandere.transform.position.y + 0.1f)
					{
						this.Yandere.Bucket = null;
					}
				}
			}
			else if (this.Yandere.Bucket == this)
			{
				this.Yandere.Bucket = null;
			}
		}
		if (this.Yandere.Bucket == this && this.Yandere.Dipping)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.55f, Time.deltaTime * 10f);
			Quaternion b = Quaternion.LookRotation(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
		}
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.Mop != null)
			{
				if (!this.Yandere.Chased && this.Yandere.Chasers == 0 && this.Full && !this.Gasoline && this.Bleached && this.Bloodiness < 100f)
				{
					this.Prompt.Label[3].text = "     Dip";
					this.Dippable = true;
				}
				else
				{
					this.Prompt.Label[3].text = "     Carry";
					this.Dippable = false;
				}
			}
			else if (this.Yandere.PickUp.JerryCan)
			{
				if (!this.Full)
				{
					if (!this.Yandere.PickUp.Empty)
					{
						this.Prompt.Label[0].text = "     Pour Gasoline";
						this.Prompt.HideButton[0] = false;
						flag3 = true;
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
			else if (this.Yandere.PickUp.Bleach)
			{
				if (this.Full && !this.Gasoline && !this.Bleached)
				{
					this.Prompt.Label[0].text = "     Pour Bleach";
					this.Prompt.HideButton[0] = false;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else if (this.Yandere.PickUp.BrownPaint)
			{
				if (this.Full && !this.Gasoline && this.Bloodiness == 0f)
				{
					this.Prompt.Label[0].text = "     Add Brown Paint";
					this.Prompt.HideButton[0] = false;
					flag4 = true;
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else if (this.Dippable)
			{
				this.Prompt.Label[3].text = "     Carry";
				this.Dippable = false;
			}
			if (this.Yandere.PickUp == this.PickUp && this.Full)
			{
				this.Prompt.HideButton[0] = false;
			}
		}
		else
		{
			if (this.Dippable)
			{
				this.Prompt.Label[3].text = "     Carry";
				this.Dippable = false;
			}
			if (this.Yandere.Equipped > 0 && this.Yandere.EquippedWeapon != null)
			{
				if (!this.Full)
				{
					if (this.Yandere.EquippedWeapon.WeaponID == 12)
					{
						if (this.Dumbbells < 5)
						{
							this.Prompt.Label[0].text = "     Place Dumbbell";
							this.Prompt.HideButton[0] = false;
							flag = true;
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
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else if (!this.Full)
			{
				if (this.Dumbbells == 0)
				{
					this.Prompt.HideButton[0] = true;
				}
				else
				{
					this.Prompt.Label[0].text = "     Remove Dumbbell";
					this.Prompt.HideButton[0] = false;
					flag2 = true;
				}
			}
		}
		if (this.Yandere.Mop != null && this.Dippable && this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			this.Yandere.Bucket = this;
			this.Yandere.Mop.Dip();
		}
		if (this.Dumbbells > 0)
		{
			if (this.Prompt.Yandere.Class.PhysicalGrade + this.Prompt.Yandere.Class.PhysicalBonus == 0)
			{
				this.Prompt.Label[3].text = "     Physical Stat Too Low";
				this.Prompt.Circle[3].fillAmount = 1f;
			}
			else
			{
				this.Prompt.Label[3].text = "     Carry";
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (flag)
			{
				this.Dumbbells++;
				this.Dumbbell[this.Dumbbells] = this.Yandere.EquippedWeapon.gameObject;
				this.Yandere.EmptyHands();
				this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = false;
				this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = false;
				this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().Hide();
				this.Dumbbell[this.Dumbbells].GetComponent<Collider>().enabled = false;
				Rigidbody component = this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>();
				component.useGravity = false;
				component.isKinematic = true;
				this.Dumbbell[this.Dumbbells].transform.parent = base.transform;
				this.Dumbbell[this.Dumbbells].transform.localPosition = this.Positions[this.Dumbbells].localPosition;
				this.Dumbbell[this.Dumbbells].transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			else if (flag2)
			{
				this.Yandere.EmptyHands();
				this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = true;
				this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = true;
				this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().Prompt.Circle[3].fillAmount = 0f;
				this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>().isKinematic = false;
				this.Dumbbell[this.Dumbbells] = null;
				this.Dumbbells--;
			}
			else if (flag3)
			{
				this.Gasoline = true;
				this.Fill();
			}
			else if (flag4)
			{
				this.DyedBrown = true;
				this.Fill();
			}
			else if (this.Yandere.PickUp == this.PickUp)
			{
				this.Spill();
			}
			else
			{
				this.Sparkles.Play();
				this.Bleached = true;
			}
		}
		if (this.UpdateAppearance)
		{
			if (this.Full)
			{
				if (this.Gasoline)
				{
					this.Gas.transform.localScale = Vector3.Lerp(this.Gas.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * this.FillSpeed);
					this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, Mathf.Lerp(this.Gas.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * this.FillSpeed), this.Gas.transform.localPosition.z);
					this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, Mathf.Lerp(this.Gas.material.color.a, 1f, Time.deltaTime * 5f));
				}
				else if (this.DyedBrown)
				{
					this.Brown.transform.localScale = Vector3.Lerp(this.Brown.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * this.FillSpeed);
					this.Brown.transform.localPosition = new Vector3(this.Brown.transform.localPosition.x, Mathf.Lerp(this.Brown.transform.localPosition.y, 0.21f, Time.deltaTime * 5f * this.FillSpeed), this.Brown.transform.localPosition.z);
					this.Brown.material.color = new Color(this.Brown.material.color.r, this.Brown.material.color.g, this.Brown.material.color.b, Mathf.Lerp(this.Brown.material.color.a, 1f, Time.deltaTime * 5f));
				}
				else
				{
					this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * this.FillSpeed);
					this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, Mathf.Lerp(this.Water.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * this.FillSpeed), this.Water.transform.localPosition.z);
					this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, Mathf.Lerp(this.Water.material.color.a, 1f, Time.deltaTime * 5f));
				}
			}
			else
			{
				this.Water.transform.localScale = Vector3.Lerp(this.Water.transform.localScale, new Vector3(0.9f, 1f, 0.9f), Time.deltaTime * 5f);
				this.Water.transform.localPosition = new Vector3(this.Water.transform.localPosition.x, Mathf.Lerp(this.Water.transform.localPosition.y, 0f, Time.deltaTime * 5f), this.Water.transform.localPosition.z);
				this.Water.material.color = new Color(this.Water.material.color.r, this.Water.material.color.g, this.Water.material.color.b, Mathf.Lerp(this.Water.material.color.a, 0f, Time.deltaTime * 5f));
				this.Gas.transform.localScale = Vector3.Lerp(this.Gas.transform.localScale, new Vector3(0.9f, 1f, 0.9f), Time.deltaTime * 5f);
				this.Gas.transform.localPosition = new Vector3(this.Gas.transform.localPosition.x, Mathf.Lerp(this.Gas.transform.localPosition.y, 0f, Time.deltaTime * 5f), this.Gas.transform.localPosition.z);
				this.Gas.material.color = new Color(this.Gas.material.color.r, this.Gas.material.color.g, this.Gas.material.color.b, Mathf.Lerp(this.Gas.material.color.a, 0f, Time.deltaTime * 5f));
				this.Brown.transform.localPosition = new Vector3(this.Brown.transform.localPosition.x, Mathf.Lerp(this.Brown.transform.localPosition.y, 0f, Time.deltaTime * 5f), this.Brown.transform.localPosition.z);
				this.Brown.material.color = new Color(this.Brown.material.color.r, this.Brown.material.color.g, this.Brown.material.color.b, Mathf.Lerp(this.Brown.material.color.a, 0f, Time.deltaTime * 5f));
			}
			this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, Mathf.Lerp(this.Blood.material.color.a, this.Bloodiness / 100f, Time.deltaTime));
			this.Blood.transform.localPosition = new Vector3(this.Blood.transform.localPosition.x, this.Water.transform.localPosition.y + 0.001f, this.Blood.transform.localPosition.z);
			this.Blood.transform.localScale = this.Water.transform.localScale;
			this.Timer = Mathf.MoveTowards(this.Timer, 5f, Time.deltaTime);
			if (this.Timer == 5f)
			{
				this.UpdateAppearance = false;
				this.Timer = 0f;
			}
		}
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket == this)
			{
				this.Prompt.HideButton[3] = true;
				if (!this.Full)
				{
					this.Prompt.HideButton[0] = true;
				}
				else
				{
					this.Prompt.HideButton[0] = false;
				}
			}
			else if (!this.Trap)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (!this.Trap)
		{
			this.Prompt.enabled = true;
		}
		if (this.Fly)
		{
			if (this.Rotate < 360f)
			{
				if (this.Rotate == 0f)
				{
					if (this.Bloodiness < 50f)
					{
						if (this.Gasoline)
						{
							this.Effect = UnityEngine.Object.Instantiate<GameObject>(this.GasSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							this.Gasoline = false;
							Debug.Log("Spilled Gas");
						}
						else if (this.DyedBrown)
						{
							this.Effect = UnityEngine.Object.Instantiate<GameObject>(this.BrownSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							this.DyedBrown = false;
							Debug.Log("Spilled Mud");
						}
						else
						{
							this.Effect = UnityEngine.Object.Instantiate<GameObject>(this.SpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							Debug.Log("Spilled Water");
						}
					}
					else
					{
						this.Effect = UnityEngine.Object.Instantiate<GameObject>(this.BloodSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
						this.Bloodiness = 0f;
						Debug.Log("Spilled Blood");
					}
					if (this.Trap)
					{
						this.Effect.transform.LookAt(this.Effect.transform.position - Vector3.up);
					}
					else
					{
						Rigidbody component2 = base.GetComponent<Rigidbody>();
						component2.AddRelativeForce(Vector3.forward * 150f);
						component2.AddRelativeForce(Vector3.up * 250f);
						base.transform.Translate(Vector3.forward * 0.5f);
					}
					this.UpdateAppearance = true;
					this.Bloodiness = 0f;
					this.Bleached = false;
					this.Gasoline = false;
					this.Sparkles.Stop();
					this.Full = false;
				}
				this.Rotate += Time.deltaTime * 360f;
				base.transform.Rotate(Vector3.right * Time.deltaTime * 360f);
			}
			else
			{
				this.Sparkles.Stop();
				this.Rotate = 0f;
				this.Trap = false;
				this.Fly = false;
			}
		}
		if (this.Dropped && base.transform.position.y < 0.5f)
		{
			base.gameObject.layer = 15;
			this.Dropped = false;
		}
	}

	// Token: 0x06000A8C RID: 2700 RVA: 0x0005EE28 File Offset: 0x0005D028
	public void Empty()
	{
		if (SchemeGlobals.GetSchemeStage(1) == 2)
		{
			SchemeGlobals.SetSchemeStage(1, 1);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		AudioSource.PlayClipAtPoint(this.EmptyBucket, base.transform.position);
		this.UpdateAppearance = true;
		this.Bloodiness = 0f;
		this.Bleached = false;
		this.Gasoline = false;
		this.Sparkles.Stop();
		this.Full = false;
		this.Prompt.HideButton[0] = true;
		this.Prompt.OffsetY[0] = 0.5f;
		this.PickUp.Usable = false;
	}

	// Token: 0x06000A8D RID: 2701 RVA: 0x0005EED0 File Offset: 0x0005D0D0
	public void Fill()
	{
		if (SchemeGlobals.GetSchemeStage(1) == 1)
		{
			SchemeGlobals.SetSchemeStage(1, 2);
			this.Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		AudioSource.PlayClipAtPoint(this.FillBucket, base.transform.position);
		this.Prompt.Label[0].text = "     Spill";
		this.Prompt.HideButton[0] = false;
		this.Prompt.OffsetY[0] = 0.125f;
		this.Prompt.Carried = true;
		this.Prompt.enabled = true;
		this.PickUp.Usable = true;
		this.UpdateAppearance = true;
		this.Full = true;
	}

	// Token: 0x06000A8E RID: 2702 RVA: 0x0005EF84 File Offset: 0x0005D184
	private void OnCollisionEnter(Collision other)
	{
		if (this.Dropped)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				base.GetComponent<AudioSource>().Play();
				while (this.Dumbbells > 0)
				{
					this.Dumbbell[this.Dumbbells].GetComponent<WeaponScript>().enabled = true;
					this.Dumbbell[this.Dumbbells].GetComponent<PromptScript>().enabled = true;
					this.Dumbbell[this.Dumbbells].GetComponent<Collider>().enabled = true;
					Rigidbody component2 = this.Dumbbell[this.Dumbbells].GetComponent<Rigidbody>();
					component2.constraints = RigidbodyConstraints.None;
					component2.isKinematic = false;
					component2.useGravity = true;
					this.Dumbbell[this.Dumbbells].transform.parent = null;
					this.Dumbbell[this.Dumbbells] = null;
					this.Dumbbells--;
				}
				component.DeathType = DeathType.Weight;
				component.BecomeRagdoll();
				this.Dropped = false;
				GameObjectUtils.SetLayerRecursively(base.gameObject, 15);
				component.MapMarker.gameObject.layer = 10;
				Debug.Log(component.Name + "'s ''Alive'' variable is: " + component.Alive.ToString());
			}
		}
	}

	// Token: 0x06000A8F RID: 2703 RVA: 0x0005F0CC File Offset: 0x0005D2CC
	public void Spill()
	{
		GameObject original;
		if (this.DyedBrown)
		{
			original = this.Yandere.StudentManager.WaterCooler.Tripwire.BrownPaintPuddle;
		}
		else if (this.Bloodiness > 50f)
		{
			original = this.Yandere.StudentManager.WaterCooler.Tripwire.BloodPuddle;
		}
		else if (this.Gasoline)
		{
			original = this.Yandere.StudentManager.WaterCooler.Tripwire.GasolinePuddle;
		}
		else
		{
			original = this.Yandere.StudentManager.WaterCooler.Tripwire.WaterPuddle;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original, this.Yandere.transform.position + this.Yandere.transform.forward * 0.5f + new Vector3(0f, 0.0001f, 0f), Quaternion.identity);
		gameObject.transform.eulerAngles = new Vector3(90f, 0f, 0f);
		if (this.Bloodiness > 50f)
		{
			gameObject.transform.parent = this.Yandere.StudentManager.BloodParent.transform;
		}
		else
		{
			gameObject.transform.parent = this.Yandere.StudentManager.PuddleParent.transform;
		}
		this.Empty();
		this.Yandere.SuspiciousActionTimer = 1f;
	}

	// Token: 0x04000C4E RID: 3150
	public PhoneEventScript PhoneEvent;

	// Token: 0x04000C4F RID: 3151
	public ParticleSystem PourEffect;

	// Token: 0x04000C50 RID: 3152
	public ParticleSystem Sparkles;

	// Token: 0x04000C51 RID: 3153
	public YandereScript Yandere;

	// Token: 0x04000C52 RID: 3154
	public PickUpScript PickUp;

	// Token: 0x04000C53 RID: 3155
	public PromptScript Prompt;

	// Token: 0x04000C54 RID: 3156
	public GameObject WaterCollider;

	// Token: 0x04000C55 RID: 3157
	public GameObject BloodCollider;

	// Token: 0x04000C56 RID: 3158
	public GameObject GasCollider;

	// Token: 0x04000C57 RID: 3159
	[SerializeField]
	private GameObject BloodSpillEffect;

	// Token: 0x04000C58 RID: 3160
	[SerializeField]
	private GameObject BrownSpillEffect;

	// Token: 0x04000C59 RID: 3161
	[SerializeField]
	private GameObject GasSpillEffect;

	// Token: 0x04000C5A RID: 3162
	[SerializeField]
	private GameObject SpillEffect;

	// Token: 0x04000C5B RID: 3163
	[SerializeField]
	private GameObject Effect;

	// Token: 0x04000C5C RID: 3164
	[SerializeField]
	private GameObject[] Dumbbell;

	// Token: 0x04000C5D RID: 3165
	[SerializeField]
	private Transform[] Positions;

	// Token: 0x04000C5E RID: 3166
	public Renderer Water;

	// Token: 0x04000C5F RID: 3167
	public Renderer Blood;

	// Token: 0x04000C60 RID: 3168
	public Renderer Brown;

	// Token: 0x04000C61 RID: 3169
	public Renderer Gas;

	// Token: 0x04000C62 RID: 3170
	public float Bloodiness;

	// Token: 0x04000C63 RID: 3171
	public float FillSpeed = 1f;

	// Token: 0x04000C64 RID: 3172
	public float Timer;

	// Token: 0x04000C65 RID: 3173
	[SerializeField]
	private float Distance;

	// Token: 0x04000C66 RID: 3174
	[SerializeField]
	private float Rotate;

	// Token: 0x04000C67 RID: 3175
	public int Dumbbells;

	// Token: 0x04000C68 RID: 3176
	public bool UpdateAppearance;

	// Token: 0x04000C69 RID: 3177
	public bool DyedBrown;

	// Token: 0x04000C6A RID: 3178
	public bool Bleached;

	// Token: 0x04000C6B RID: 3179
	public bool Dippable;

	// Token: 0x04000C6C RID: 3180
	public bool Gasoline;

	// Token: 0x04000C6D RID: 3181
	public bool Dropped;

	// Token: 0x04000C6E RID: 3182
	public bool Poured;

	// Token: 0x04000C6F RID: 3183
	public bool Full;

	// Token: 0x04000C70 RID: 3184
	public bool Trap;

	// Token: 0x04000C71 RID: 3185
	public bool Fly;

	// Token: 0x04000C72 RID: 3186
	public AudioClip EmptyBucket;

	// Token: 0x04000C73 RID: 3187
	public AudioClip FillBucket;

	// Token: 0x04000C74 RID: 3188
	public AudioClip CrackSkull;
}
