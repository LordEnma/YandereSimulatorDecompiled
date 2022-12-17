using UnityEngine;

public class BucketScript : MonoBehaviour
{
	public PhoneEventScript PhoneEvent;

	public ParticleSystem PourEffect;

	public ParticleSystem Sparkles;

	public YandereScript Yandere;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public GameObject BrownPaintCollider;

	public GameObject WaterCollider;

	public GameObject BloodCollider;

	public GameObject GasCollider;

	public GameObject NewestPuddle;

	[SerializeField]
	private GameObject BloodSpillEffect;

	[SerializeField]
	private GameObject BrownSpillEffect;

	[SerializeField]
	private GameObject GasSpillEffect;

	[SerializeField]
	private GameObject SpillEffect;

	[SerializeField]
	private GameObject Effect;

	[SerializeField]
	private GameObject[] Dumbbell;

	[SerializeField]
	private Transform[] Positions;

	public Renderer Water;

	public Renderer Blood;

	public Renderer Brown;

	public Renderer Gas;

	public float Bloodiness;

	public float FillSpeed = 1f;

	public float Timer;

	[SerializeField]
	private float Distance;

	[SerializeField]
	private float Rotate;

	public int StudentBloodID;

	public int Dumbbells;

	public bool UpdateAppearance;

	public bool DyedBrown;

	public bool Bleached;

	public bool Dippable;

	public bool Gasoline;

	public bool Dropped;

	public bool Poured;

	public bool Full;

	public bool Trap;

	public bool Fly;

	public AudioClip EmptyBucket;

	public AudioClip FillBucket;

	public AudioClip CrackSkull;

	private void Start()
	{
		Water.transform.localPosition = new Vector3(Water.transform.localPosition.x, 0f, Water.transform.localPosition.z);
		Water.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		Water.material.color = new Color(Water.material.color.r, Water.material.color.g, Water.material.color.b, 0f);
		Blood.material.color = new Color(Blood.material.color.r, Blood.material.color.g, Blood.material.color.b, 0f);
		Gas.transform.localPosition = new Vector3(Gas.transform.localPosition.x, 0f, Gas.transform.localPosition.z);
		Gas.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		Gas.material.color = new Color(Gas.material.color.r, Gas.material.color.g, Gas.material.color.b, 0f);
		Brown.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
		Brown.material.color = new Color(Brown.material.color.r, Brown.material.color.g, Brown.material.color.b, 0f);
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
		Yandere.StudentManager.AllBuckets[Yandere.StudentManager.BucketID] = this;
		Yandere.StudentManager.BucketID++;
	}

	private void Update()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (PickUp.Clock != null)
		{
			if (PickUp.Clock.Period == 5)
			{
				PickUp.Suspicious = false;
			}
			else
			{
				PickUp.Suspicious = true;
			}
		}
		if (Yandere.CanMove)
		{
			Distance = Vector3.Distance(base.transform.position, Yandere.transform.position);
			if (Distance < 1f)
			{
				RaycastHit hitInfo;
				if (Yandere.Bucket == null)
				{
					if (base.transform.position.y > Yandere.transform.position.y - 0.1f && base.transform.position.y < Yandere.transform.position.y + 0.1f && Physics.Linecast(base.transform.position, Yandere.transform.position + Vector3.up, out hitInfo) && hitInfo.collider.gameObject == Yandere.gameObject)
					{
						Yandere.Bucket = this;
					}
				}
				else
				{
					if (Physics.Linecast(base.transform.position, Yandere.transform.position + Vector3.up, out hitInfo) && hitInfo.collider.gameObject != Yandere.gameObject)
					{
						Yandere.Bucket = null;
					}
					if (base.transform.position.y < Yandere.transform.position.y - 0.1f || base.transform.position.y > Yandere.transform.position.y + 0.1f)
					{
						Yandere.Bucket = null;
					}
				}
			}
			else if (Yandere.Bucket == this)
			{
				Yandere.Bucket = null;
			}
		}
		if (Yandere.Bucket == this && Yandere.Dipping)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, Yandere.transform.position + Yandere.transform.forward * 0.55f, Time.deltaTime * 10f);
			Quaternion b = Quaternion.LookRotation(new Vector3(Yandere.transform.position.x, base.transform.position.y, Yandere.transform.position.z) - base.transform.position);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
		}
		if (Yandere.PickUp != null)
		{
			if (Yandere.Mop != null)
			{
				if (!Yandere.Chased && Yandere.Chasers == 0 && Full && !Gasoline && Bleached && !DyedBrown && Bloodiness < 100f)
				{
					Prompt.Label[3].text = "     Dip";
					Dippable = true;
				}
				else
				{
					Prompt.Label[3].text = "     Carry";
					Dippable = false;
				}
			}
			else if (Yandere.PickUp.JerryCan)
			{
				if (!Full)
				{
					if (!Yandere.PickUp.Empty)
					{
						Prompt.Label[0].text = "     Pour Gasoline";
						Prompt.HideButton[0] = false;
						flag3 = true;
					}
					else
					{
						Prompt.HideButton[0] = true;
					}
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (Yandere.PickUp.Bleach)
			{
				if (Full && !Gasoline && !Bleached)
				{
					Prompt.Label[0].text = "     Pour Bleach";
					Prompt.HideButton[0] = false;
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (Yandere.PickUp.BrownPaint)
			{
				if (Full && !Gasoline && Bloodiness == 0f)
				{
					Prompt.Label[0].text = "     Add Brown Paint";
					Prompt.HideButton[0] = false;
					flag4 = true;
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (Dippable)
			{
				Prompt.Label[3].text = "     Carry";
				Dippable = false;
			}
			if (Yandere.PickUp == PickUp && Full)
			{
				Prompt.HideButton[0] = false;
			}
		}
		else
		{
			if (Dippable)
			{
				Prompt.Label[3].text = "     Carry";
				Dippable = false;
			}
			if (Yandere.Equipped > 0 && Yandere.EquippedWeapon != null)
			{
				if (!Full)
				{
					if (Yandere.EquippedWeapon.WeaponID == 12)
					{
						if (Dumbbells < 5)
						{
							Prompt.Label[0].text = "     Place Dumbbell";
							Prompt.HideButton[0] = false;
							flag = true;
						}
						else
						{
							Prompt.HideButton[0] = true;
						}
					}
					else
					{
						Prompt.HideButton[0] = true;
					}
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (!Full)
			{
				if (Dumbbells == 0)
				{
					Prompt.Label[3].text = "     Carry";
					Prompt.HideButton[0] = true;
				}
				else
				{
					Prompt.Label[0].text = "     Remove Dumbbell";
					Prompt.HideButton[0] = false;
					flag2 = true;
				}
			}
		}
		if (Yandere.Mop != null && Dippable && Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			if (base.transform.position.y < Yandere.transform.position.y + 0.1f)
			{
				Yandere.Bucket = this;
				Yandere.Mop.Dip();
			}
			else
			{
				Debug.Log("Cannot Dip Now.");
				Yandere.NotificationManager.CustomText = "Lower Bucket First";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (Dumbbells > 1)
		{
			if (Prompt.Yandere.Class.PhysicalGrade + Prompt.Yandere.Class.PhysicalBonus == 0)
			{
				Prompt.Label[3].text = "     Physical Stat Too Low";
				Prompt.Circle[3].fillAmount = 1f;
			}
			else
			{
				Prompt.Label[3].text = "     Carry";
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (flag)
			{
				Dumbbells++;
				Dumbbell[Dumbbells] = Yandere.EquippedWeapon.gameObject;
				Yandere.EmptyHands();
				Dumbbell[Dumbbells].GetComponent<WeaponScript>().enabled = false;
				Dumbbell[Dumbbells].GetComponent<PromptScript>().enabled = false;
				Dumbbell[Dumbbells].GetComponent<PromptScript>().Hide();
				Dumbbell[Dumbbells].GetComponent<Collider>().enabled = false;
				Rigidbody component = Dumbbell[Dumbbells].GetComponent<Rigidbody>();
				component.useGravity = false;
				component.isKinematic = true;
				Dumbbell[Dumbbells].transform.parent = base.transform;
				Dumbbell[Dumbbells].transform.localPosition = Positions[Dumbbells].localPosition;
				Dumbbell[Dumbbells].transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			}
			else if (flag2)
			{
				Yandere.EmptyHands();
				Dumbbell[Dumbbells].GetComponent<WeaponScript>().enabled = true;
				Dumbbell[Dumbbells].GetComponent<PromptScript>().enabled = true;
				Dumbbell[Dumbbells].GetComponent<WeaponScript>().Prompt.Circle[3].fillAmount = 0f;
				Dumbbell[Dumbbells].GetComponent<Rigidbody>().isKinematic = false;
				Dumbbell[Dumbbells] = null;
				Dumbbells--;
				if (Dumbbells == 0)
				{
					Prompt.Label[3].text = "     Carry";
				}
			}
			else if (flag3)
			{
				Gasoline = true;
				Fill();
			}
			else if (flag4)
			{
				DyedBrown = true;
				Fill();
			}
			else if (Yandere.PickUp == PickUp)
			{
				Spill();
			}
			else
			{
				Sparkles.Play();
				Bleached = true;
			}
		}
		if (UpdateAppearance)
		{
			if (Full)
			{
				if (Gasoline)
				{
					Gas.transform.localScale = Vector3.Lerp(Gas.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * FillSpeed);
					Gas.transform.localPosition = new Vector3(Gas.transform.localPosition.x, Mathf.Lerp(Gas.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * FillSpeed), Gas.transform.localPosition.z);
					Gas.material.color = new Color(Gas.material.color.r, Gas.material.color.g, Gas.material.color.b, Mathf.Lerp(Gas.material.color.a, 1f, Time.deltaTime * 5f));
				}
				else if (DyedBrown)
				{
					Brown.transform.localScale = Vector3.Lerp(Brown.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * FillSpeed);
					Brown.transform.localPosition = new Vector3(Brown.transform.localPosition.x, Mathf.Lerp(Brown.transform.localPosition.y, 0.21f, Time.deltaTime * 5f * FillSpeed), Brown.transform.localPosition.z);
					Brown.material.color = new Color(Brown.material.color.r, Brown.material.color.g, Brown.material.color.b, Mathf.Lerp(Brown.material.color.a, 1f, Time.deltaTime * 5f));
				}
				else
				{
					Water.transform.localScale = Vector3.Lerp(Water.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f * FillSpeed);
					Water.transform.localPosition = new Vector3(Water.transform.localPosition.x, Mathf.Lerp(Water.transform.localPosition.y, 0.2f, Time.deltaTime * 5f * FillSpeed), Water.transform.localPosition.z);
					Water.material.color = new Color(Water.material.color.r, Water.material.color.g, Water.material.color.b, Mathf.Lerp(Water.material.color.a, 1f, Time.deltaTime * 5f));
				}
			}
			else
			{
				Water.transform.localScale = Vector3.Lerp(Water.transform.localScale, new Vector3(0.9f, 1f, 0.9f), Time.deltaTime * 5f);
				Water.transform.localPosition = new Vector3(Water.transform.localPosition.x, Mathf.Lerp(Water.transform.localPosition.y, 0f, Time.deltaTime * 5f), Water.transform.localPosition.z);
				Water.material.color = new Color(Water.material.color.r, Water.material.color.g, Water.material.color.b, Mathf.Lerp(Water.material.color.a, 0f, Time.deltaTime * 5f));
				Gas.transform.localScale = Vector3.Lerp(Gas.transform.localScale, new Vector3(0.9f, 1f, 0.9f), Time.deltaTime * 5f);
				Gas.transform.localPosition = new Vector3(Gas.transform.localPosition.x, Mathf.Lerp(Gas.transform.localPosition.y, 0f, Time.deltaTime * 5f), Gas.transform.localPosition.z);
				Gas.material.color = new Color(Gas.material.color.r, Gas.material.color.g, Gas.material.color.b, Mathf.Lerp(Gas.material.color.a, 0f, Time.deltaTime * 5f));
				Brown.transform.localPosition = new Vector3(Brown.transform.localPosition.x, Mathf.Lerp(Brown.transform.localPosition.y, 0f, Time.deltaTime * 5f), Brown.transform.localPosition.z);
				Brown.material.color = new Color(Brown.material.color.r, Brown.material.color.g, Brown.material.color.b, Mathf.Lerp(Brown.material.color.a, 0f, Time.deltaTime * 5f));
			}
			Blood.material.color = new Color(Blood.material.color.r, Blood.material.color.g, Blood.material.color.b, Mathf.Lerp(Blood.material.color.a, Bloodiness / 100f, Time.deltaTime));
			Blood.transform.localPosition = new Vector3(Blood.transform.localPosition.x, Water.transform.localPosition.y + 0.001f, Blood.transform.localPosition.z);
			Blood.transform.localScale = Water.transform.localScale;
			Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
			if (Timer == 5f)
			{
				if (!Full)
				{
					Blood.material.color = new Color(Blood.material.color.r, Blood.material.color.g, Blood.material.color.b, 0f);
					Brown.material.color = new Color(Brown.material.color.r, Brown.material.color.g, Brown.material.color.b, 0f);
					Water.material.color = new Color(Water.material.color.r, Water.material.color.g, Water.material.color.b, 0f);
					Gas.material.color = new Color(Gas.material.color.r, Gas.material.color.g, Gas.material.color.b, 0f);
				}
				UpdateAppearance = false;
				Timer = 0f;
			}
		}
		if (Yandere.PickUp != null)
		{
			if (Yandere.PickUp.Bucket == this)
			{
				Prompt.HideButton[3] = true;
				if (!Full)
				{
					Prompt.HideButton[0] = true;
				}
				else
				{
					Prompt.HideButton[0] = false;
				}
			}
			else if (!Trap)
			{
				Prompt.enabled = true;
			}
		}
		else if (!Trap)
		{
			Prompt.enabled = true;
		}
		if (Fly)
		{
			if (Rotate < 360f)
			{
				if (Rotate == 0f)
				{
					if (Bloodiness < 50f)
					{
						if (Gasoline)
						{
							Effect = Object.Instantiate(GasSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							Gasoline = false;
							Debug.Log("Spilled Gas");
						}
						else if (DyedBrown)
						{
							Effect = Object.Instantiate(BrownSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							DyedBrown = false;
							Debug.Log("Spilled Mud");
						}
						else
						{
							Effect = Object.Instantiate(SpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
							Debug.Log("Spilled Water");
						}
					}
					else
					{
						Effect = Object.Instantiate(BloodSpillEffect, base.transform.position + base.transform.forward * 0.5f + base.transform.up * 0.5f, base.transform.rotation);
						Bloodiness = 0f;
						Debug.Log("Spilled Blood");
					}
					if (Trap)
					{
						Effect.transform.LookAt(Effect.transform.position - Vector3.up);
					}
					else
					{
						Rigidbody component2 = GetComponent<Rigidbody>();
						component2.AddRelativeForce(Vector3.forward * 150f);
						component2.AddRelativeForce(Vector3.up * 250f);
						base.transform.Translate(Vector3.forward * 0.5f);
					}
					UpdateAppearance = true;
					Bloodiness = 0f;
					Bleached = false;
					Gasoline = false;
					Sparkles.Stop();
					Full = false;
				}
				Rotate += Time.deltaTime * 360f;
				base.transform.Rotate(Vector3.right * Time.deltaTime * 360f);
			}
			else
			{
				Sparkles.Stop();
				Rotate = 0f;
				Trap = false;
				Fly = false;
			}
		}
		if (Dropped && base.transform.position.y < 0.5f)
		{
			base.gameObject.layer = 15;
			Dropped = false;
		}
	}

	public void Empty()
	{
		if (SchemeGlobals.GetSchemeStage(1) == 2)
		{
			SchemeGlobals.SetSchemeStage(1, 1);
			Yandere.PauseScreen.Schemes.UpdateInstructions();
		}
		if (!Yandere.StudentManager.KokonaTutorial)
		{
			AudioSource.PlayClipAtPoint(EmptyBucket, base.transform.position);
		}
		UpdateAppearance = true;
		StudentBloodID = 0;
		Bloodiness = 0f;
		DyedBrown = false;
		Bleached = false;
		Gasoline = false;
		Sparkles.Stop();
		Full = false;
		Prompt.HideButton[0] = true;
		Prompt.OffsetY[0] = 0.5f;
		PickUp.Usable = false;
		PickUp.Outline[0].color = new Color(0f, 1f, 1f, 1f);
	}

	public void Fill()
	{
		AudioSource.PlayClipAtPoint(FillBucket, base.transform.position);
		Prompt.Label[0].text = "     Spill";
		Prompt.HideButton[0] = false;
		Prompt.OffsetY[0] = 0.125f;
		Prompt.Carried = true;
		Prompt.enabled = true;
		PickUp.Usable = true;
		UpdateAppearance = true;
		Full = true;
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!Dropped)
		{
			return;
		}
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null)
		{
			GetComponent<AudioSource>().Play();
			while (Dumbbells > 0)
			{
				Debug.Log("Setting a Dumbbell's ''isTrigger'' boolean to ''true''...");
				Dumbbell[Dumbbells].GetComponent<WeaponScript>().enabled = true;
				Dumbbell[Dumbbells].GetComponent<PromptScript>().enabled = true;
				Dumbbell[Dumbbells].GetComponent<Collider>().isTrigger = false;
				Dumbbell[Dumbbells].GetComponent<Collider>().enabled = true;
				Rigidbody component2 = Dumbbell[Dumbbells].GetComponent<Rigidbody>();
				component2.constraints = RigidbodyConstraints.None;
				component2.isKinematic = false;
				component2.useGravity = true;
				Dumbbell[Dumbbells].transform.parent = null;
				Dumbbell[Dumbbells] = null;
				Dumbbells--;
			}
			component.DeathType = DeathType.Weight;
			component.BecomeRagdoll();
			Dropped = false;
			GameObjectUtils.SetLayerRecursively(base.gameObject, 15);
			component.MapMarker.gameObject.layer = 10;
			Debug.Log(component.Name + "'s ''Alive'' variable is: " + component.Alive);
			Object.Instantiate(component.AlarmDisc, new Vector3(component.Hips.position.x, 1f, component.Hips.position.z), Quaternion.identity).transform.localScale = new Vector3(1000f, 1f, 1000f);
		}
	}

	public void Spill()
	{
		if (Yandere.StudentManager.GardenArea.bounds.Contains(Yandere.transform.position) || Yandere.StudentManager.NEStairs.bounds.Contains(Yandere.transform.position) || Yandere.StudentManager.NWStairs.bounds.Contains(Yandere.transform.position) || Yandere.StudentManager.SEStairs.bounds.Contains(Yandere.transform.position) || Yandere.StudentManager.SWStairs.bounds.Contains(Yandere.transform.position) || Yandere.StudentManager.PoolStairs.bounds.Contains(Yandere.transform.position))
		{
			Yandere.NotificationManager.CustomText = "Not here!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		gameObject = (DyedBrown ? Yandere.StudentManager.WaterCooler.Tripwire.BrownPaintPuddle : ((Bloodiness > 50f) ? Yandere.StudentManager.WaterCooler.Tripwire.BloodPuddle : ((!Gasoline) ? Yandere.StudentManager.WaterCooler.Tripwire.WaterPuddle : Yandere.StudentManager.WaterCooler.Tripwire.GasolinePuddle)));
		gameObject2 = Object.Instantiate(gameObject, Yandere.transform.position + Yandere.transform.forward * 0.5f + new Vector3(0f, 0.001f, 0f), Quaternion.identity);
		gameObject2.transform.eulerAngles = new Vector3(90f, 0f, 0f);
		if (Bloodiness > 50f)
		{
			gameObject2.transform.parent = Yandere.StudentManager.BloodParent.transform;
		}
		else
		{
			gameObject2.transform.parent = Yandere.StudentManager.PuddleParent.transform;
		}
		Empty();
		Yandere.SuspiciousActionTimer = 1f;
		NewestPuddle = gameObject2;
	}
}
