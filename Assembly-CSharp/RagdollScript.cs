using System;
using UnityEngine;

// Token: 0x020003C5 RID: 965
public class RagdollScript : MonoBehaviour
{
	// Token: 0x06001B30 RID: 6960 RVA: 0x0012F9BC File Offset: 0x0012DBBC
	private void Start()
	{
		this.ElectrocutionAnimation = false;
		this.MurderSuicideAnimation = false;
		this.BurningAnimation = false;
		this.ChokingAnimation = false;
		this.Disturbing = false;
		this.Yandere = this.Student.StudentManager.Yandere;
		Physics.IgnoreLayerCollision(11, 13, true);
		this.Zs.SetActive(this.Tranquil);
		if (!this.Tranquil && !this.Poisoned && !this.Drowned && !this.Electrocuted && !this.Burning && !this.NeckSnapped)
		{
			this.Student.StudentManager.TutorialWindow.ShowPoolMessage = true;
			this.BloodPoolSpawner.gameObject.SetActive(true);
			this.BloodPoolSpawner.StudentManager = this.Student.StudentManager;
			if (this.Pushed)
			{
				this.BloodPoolSpawner.Timer = 5f;
			}
		}
		if (!this.RigidbodiesManuallyDisabled)
		{
			for (int i = 0; i < this.AllRigidbodies.Length; i++)
			{
				this.AllRigidbodies[i].isKinematic = false;
				this.AllColliders[i].enabled = true;
				if (this.Yandere != null && this.Yandere.StudentManager.NoGravity)
				{
					this.AllRigidbodies[i].useGravity = false;
				}
			}
		}
		else
		{
			this.AllColliders[0].enabled = true;
		}
		this.Prompt.enabled = true;
		if (!this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
		if (this.Yandere != null && this.Yandere.BlackHole)
		{
			this.DestroyRigidbodies();
		}
		if (this.Concealed)
		{
			this.ConcealInTrashBag();
		}
	}

	// Token: 0x06001B31 RID: 6961 RVA: 0x0012FB68 File Offset: 0x0012DD68
	private void Update()
	{
		if (this.UpdateNextFrame)
		{
			this.Student.Hips.localPosition = this.NextPosition;
			this.Student.Hips.localRotation = this.NextRotation;
			Physics.SyncTransforms();
			this.UpdateNextFrame = false;
		}
		if (!this.Dragged && !this.Carried && !this.Settled && !this.Yandere.PK && !this.Yandere.StudentManager.NoGravity)
		{
			this.SettleTimer += Time.deltaTime;
			if (this.SettleTimer > 5f)
			{
				this.Settled = true;
				for (int i = 0; i < this.AllRigidbodies.Length; i++)
				{
					this.AllRigidbodies[i].isKinematic = true;
					this.AllColliders[i].enabled = false;
				}
			}
		}
		if (this.DetectionMarker != null)
		{
			if (this.DetectionMarker.Tex.color.a > 0.1f)
			{
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, Mathf.MoveTowards(this.DetectionMarker.Tex.color.a, 0f, Time.deltaTime * 10f));
			}
			else
			{
				this.DetectionMarker.Tex.color = new Color(this.DetectionMarker.Tex.color.r, this.DetectionMarker.Tex.color.g, this.DetectionMarker.Tex.color.b, 0f);
				this.DetectionMarker = null;
			}
		}
		if (this.Yandere != null)
		{
			if (!this.Dumped)
			{
				if (this.StopAnimation)
				{
					if (this.Student.CharacterAnimation.isPlaying)
					{
						this.Student.CharacterAnimation.Stop();
					}
					else
					{
						if (this.TeleportNextFrame)
						{
							this.Student.transform.position = new Vector3(-28.78f, 4f, 10.386f);
							this.TeleportNextFrame = false;
						}
						if (this.Student.DeathType == DeathType.Weight && this.RigidbodiesManuallyDisabled)
						{
							Debug.Log("Forcing the ''crushed'' animation to play.");
							if (!this.Student.Male)
							{
								this.Student.CharacterAnimation.Play("f02_crushed_00");
							}
							else
							{
								this.Student.CharacterAnimation.Play("crushed_00");
							}
							this.TeleportNextFrame = true;
						}
					}
				}
				if (this.Yandere.PickUp != null)
				{
					if (this.Yandere.PickUp.GarbageBagBox)
					{
						if (!this.Concealed)
						{
							this.Prompt.Label[0].text = "     Conceal";
							this.Cauterizable = false;
							this.Wrappable = true;
						}
					}
					else if (this.Yandere.PickUp.Tarp)
					{
						this.Prompt.Label[0].text = "     Place Tarp";
					}
					else if (this.Yandere.PickUp.Blowtorch)
					{
						if (this.Concealed)
						{
							this.Prompt.HideButton[0] = true;
						}
						else if (this.BloodPoolSpawner.enabled)
						{
							this.Prompt.Label[0].text = "     Cauterize";
							this.Cauterizable = true;
							this.Wrappable = false;
						}
					}
					else
					{
						this.Prompt.Label[0].text = "     Dismember";
						this.Cauterizable = false;
						this.Wrappable = false;
					}
				}
				else if (this.Cauterizable)
				{
					this.Prompt.Label[0].text = "     Dismember";
					this.Cauterizable = false;
					this.Wrappable = false;
				}
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					if (this.Yandere.PickUp != null && this.Yandere.PickUp.Tarp)
					{
						UnityEngine.Object gameObject = this.Yandere.PickUp.gameObject;
						GameObject myTarp = UnityEngine.Object.Instantiate<GameObject>(this.Yandere.PickUp.TarpObject, new Vector3(this.Student.Hips.position.x, this.Yandere.transform.position.y, this.Student.Hips.position.z), this.Yandere.transform.rotation);
						this.MyTarp = myTarp;
						this.Yandere.EmptyHands();
						UnityEngine.Object.Destroy(gameObject);
					}
					else if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
					{
						if (this.Wrappable)
						{
							this.ConcealInTrashBag();
						}
						else if (this.Cauterizable)
						{
							this.Prompt.Label[0].text = "     Dismember";
							this.BloodPoolSpawner.enabled = false;
							this.Cauterizable = false;
							this.Cauterized = true;
							this.Yandere.CharacterAnimation.CrossFade("f02_cauterize_00");
							this.Yandere.Cauterizing = true;
							this.Yandere.CanMove = false;
							this.Yandere.PickUp.GetComponent<BlowtorchScript>().enabled = true;
							this.Yandere.PickUp.GetComponent<AudioSource>().Play();
						}
						else if (this.Yandere.StudentManager.OriginalUniforms + this.Yandere.StudentManager.NewUniforms > 0)
						{
							this.Yandere.CharacterAnimation.CrossFade("f02_dismember_00");
							this.Yandere.transform.LookAt(base.transform);
							this.Yandere.RPGCamera.transform.position = this.Yandere.DismemberSpot.position;
							this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DismemberSpot.eulerAngles;
							this.Yandere.EquippedWeapon.Dismember();
							this.Yandere.RPGCamera.enabled = false;
							this.Yandere.TargetStudent = this.Student;
							this.Yandere.Ragdoll = base.gameObject;
							this.Yandere.Dismembering = true;
							this.Yandere.CanMove = false;
						}
						else if (!this.Yandere.ClothingWarning)
						{
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Clothing);
							this.Yandere.StudentManager.TutorialWindow.ShowClothingMessage = true;
							this.Yandere.ClothingWarning = true;
						}
					}
				}
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					this.Prompt.Circle[1].fillAmount = 1f;
					if (!this.Student.FireEmitters[1].isPlaying)
					{
						if (!this.Dragged)
						{
							this.Yandere.EmptyHands();
							this.Prompt.AcceptingInput[1] = false;
							this.Prompt.Label[1].text = "     Drop";
							this.PickNearestLimb();
							this.Yandere.RagdollDragger.connectedBody = this.Rigidbodies[this.LimbID];
							this.Yandere.RagdollDragger.connectedAnchor = this.LimbAnchor[this.LimbID];
							this.Yandere.Dragging = true;
							this.Yandere.Running = false;
							this.Yandere.DragState = 0;
							this.Yandere.Ragdoll = base.gameObject;
							this.Yandere.CurrentRagdoll = this;
							this.Dragged = true;
							this.Yandere.StudentManager.UpdateStudents(0);
							if (this.MurderSuicide)
							{
								this.Police.MurderSuicideScene = false;
								this.MurderSuicide = false;
							}
							if (this.Suicide)
							{
								this.Police.Suicide = false;
								this.Suicide = false;
							}
							for (int j = 0; j < this.Student.Ragdoll.AllRigidbodies.Length; j++)
							{
								this.Student.Ragdoll.AllRigidbodies[j].drag = 2f;
							}
							for (int k = 0; k < this.AllRigidbodies.Length; k++)
							{
								this.AllRigidbodies[k].isKinematic = false;
								this.AllColliders[k].enabled = true;
								if (this.Yandere.StudentManager.NoGravity)
								{
									this.AllRigidbodies[k].useGravity = false;
								}
							}
							this.RigidbodiesManuallyDisabled = false;
						}
						else
						{
							this.StopDragging();
						}
					}
				}
				if (this.Prompt.Circle[3].fillAmount == 0f)
				{
					this.Prompt.Circle[3].fillAmount = 1f;
					if (!this.Student.FireEmitters[1].isPlaying)
					{
						this.Yandere.EmptyHands();
						this.Prompt.Label[1].text = "     Drop";
						this.Prompt.HideButton[1] = true;
						this.Prompt.HideButton[3] = true;
						this.Prompt.enabled = false;
						this.Prompt.Hide();
						for (int l = 0; l < this.AllRigidbodies.Length; l++)
						{
							this.AllRigidbodies[l].isKinematic = true;
							this.AllColliders[l].enabled = false;
						}
						if (this.Male)
						{
							Rigidbody rigidbody = this.AllRigidbodies[0];
							rigidbody.transform.parent.transform.localPosition = new Vector3(rigidbody.transform.parent.transform.localPosition.x, 0.2f, rigidbody.transform.parent.transform.localPosition.z);
						}
						this.Yandere.CharacterAnimation["f02_carryLiftA_00"].speed = 1f + (float)(this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus) * 0.2f;
						this.Student.CharacterAnimation[this.LiftAnim].speed = 1f + (float)(this.Yandere.Class.PhysicalGrade + this.Yandere.Class.PhysicalBonus) * 0.2f;
						this.Yandere.CharacterAnimation.Play("f02_carryLiftA_00");
						this.Student.CharacterAnimation.enabled = true;
						this.Student.CharacterAnimation.Play(this.LiftAnim);
						this.BloodSpawnerCollider.enabled = false;
						this.PelvisRoot.localEulerAngles = new Vector3(this.PelvisRoot.localEulerAngles.x, 0f, this.PelvisRoot.localEulerAngles.z);
						this.Prompt.MyCollider.enabled = false;
						this.PelvisRoot.localPosition = new Vector3(this.PelvisRoot.localPosition.x, this.PelvisRoot.localPosition.y, 0f);
						this.Yandere.Ragdoll = base.gameObject;
						this.Yandere.CurrentRagdoll = this;
						this.Yandere.CanMove = false;
						this.Yandere.Lifting = true;
						this.StopAnimation = false;
						this.Carried = true;
						this.Falling = false;
						this.FallTimer = 0f;
						this.RigidbodiesManuallyDisabled = false;
					}
				}
				if (this.Yandere.Running && this.Yandere.CanMove && this.Dragged)
				{
					this.StopDragging();
				}
				if (Vector3.Distance(this.Yandere.transform.position, this.Prompt.transform.position) < 2f)
				{
					if (!this.Suicide && !this.AddingToCount)
					{
						this.Yandere.NearestCorpseID = this.StudentID;
						this.Yandere.NearBodies++;
						this.AddingToCount = true;
					}
				}
				else if (this.AddingToCount)
				{
					this.Yandere.NearBodies--;
					this.AddingToCount = false;
				}
				if (!this.Prompt.AcceptingInput[1] && Input.GetButtonUp("B"))
				{
					this.Prompt.AcceptingInput[1] = true;
				}
				bool flag = false;
				if (this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 7 && !this.Student.Nemesis)
				{
					this.Prompt.Label[0].text = "     Dismember";
					this.Cauterizable = false;
					this.Wrappable = false;
					flag = true;
				}
				if ((this.Yandere.PickUp != null && this.Yandere.PickUp.Blowtorch && !this.Cauterized) || (this.Yandere.PickUp != null && this.Yandere.PickUp.Tarp) || (this.Yandere.PickUp != null && this.Yandere.PickUp.GarbageBagBox && !this.Concealed))
				{
					flag = true;
				}
				this.Prompt.HideButton[0] = (this.Dragged || this.Carried || this.Tranquil || this.Concealed || !flag);
			}
			else if (this.DumpType == RagdollDumpType.Incinerator)
			{
				if (this.DumpTimer == 0f && this.Yandere.Carrying)
				{
					this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
				}
				this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
				this.DumpTimer += Time.deltaTime;
				if (this.Student.CharacterAnimation[this.DumpedAnim].time >= this.Student.CharacterAnimation[this.DumpedAnim].length)
				{
					this.Incinerator.Corpses++;
					this.Incinerator.CorpseList[this.Incinerator.Corpses] = this.StudentID;
					this.Remove();
					base.enabled = false;
				}
			}
			else if (this.DumpType == RagdollDumpType.TranqCase)
			{
				if (this.DumpTimer == 0f && this.Yandere.Carrying)
				{
					this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
				}
				this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
				this.DumpTimer += Time.deltaTime;
				if (this.Student.CharacterAnimation[this.DumpedAnim].time >= this.Student.CharacterAnimation[this.DumpedAnim].length)
				{
					this.TranqCase.Open = false;
					if (this.AddingToCount)
					{
						this.Yandere.NearBodies--;
					}
					base.enabled = false;
				}
			}
			else if (this.DumpType == RagdollDumpType.WoodChipper)
			{
				if (this.DumpTimer == 0f && this.Yandere.Carrying)
				{
					this.Student.CharacterAnimation[this.DumpedAnim].time = 2.5f;
				}
				this.Student.CharacterAnimation.CrossFade(this.DumpedAnim);
				this.DumpTimer += Time.deltaTime;
				if (this.Student.CharacterAnimation[this.DumpedAnim].time >= this.Student.CharacterAnimation[this.DumpedAnim].length)
				{
					this.WoodChipper = this.Yandere.WoodChipper;
					Debug.Log(string.Concat(new string[]
					{
						"Student #",
						this.StudentID.ToString(),
						" is now updating ",
						this.WoodChipper.gameObject.name,
						" with an ID number."
					}));
					this.WoodChipper.VictimID = this.StudentID;
					this.Remove();
					base.enabled = false;
				}
			}
		}
		if (this.Hidden && this.HideCollider == null)
		{
			if (!this.Concealed)
			{
				this.Police.HiddenCorpses--;
			}
			this.Hidden = false;
		}
		if (this.Falling)
		{
			this.FallTimer += Time.deltaTime;
			if (this.FallTimer > 2f)
			{
				this.BloodSpawnerCollider.enabled = true;
				this.FallTimer = 0f;
				this.Falling = false;
			}
		}
		if (this.Burning)
		{
			for (int m = 0; m < 3; m++)
			{
				Material material = this.MyRenderer.materials[m];
				material.color = Vector4.MoveTowards(material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
			}
			this.Student.Cosmetic.HairRenderer.material.color = Vector4.MoveTowards(this.Student.Cosmetic.HairRenderer.material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
			if (this.MyRenderer.materials[0].color == new Color(0.1f, 0.1f, 0.1f, 1f))
			{
				this.Burning = false;
				this.Burned = true;
			}
		}
		if (this.Burned)
		{
			this.Sacrifice = (Vector3.Distance(this.Prompt.transform.position, this.Yandere.StudentManager.SacrificeSpot.position) < 1.5f);
		}
		if (this.Concealed && this.Student.GarbageBag.activeInHierarchy)
		{
			RiggedAccessoryAttacher component = this.Student.GarbageBag.GetComponent<RiggedAccessoryAttacher>();
			if (!this.AddedOutline && component != null && component.newRenderer != null)
			{
				component.newRenderer.gameObject.AddComponent<OutlineScript>();
				this.AddedOutline = true;
			}
			if (this.AddedOutline && !this.ColoredOutline)
			{
				component.newRenderer.gameObject.GetComponent<OutlineScript>().color = new Color(1f, 0.5f, 0f);
				this.ColoredOutline = true;
			}
		}
	}

	// Token: 0x06001B32 RID: 6962 RVA: 0x00130EA0 File Offset: 0x0012F0A0
	private void LateUpdate()
	{
		if (!this.Male)
		{
			if (this.LeftEye != null)
			{
				this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x, this.LeftEye.localPosition.y, this.LeftEyeOrigin.z - this.EyeShrink * 0.01f);
				this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x, this.RightEye.localPosition.y, this.RightEyeOrigin.z + this.EyeShrink * 0.01f);
				this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
				this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
			}
			if (this.StudentID == 81)
			{
				for (int i = 0; i < 4; i++)
				{
					Transform transform = this.Student.Skirt[i];
					transform.transform.localScale = new Vector3(transform.transform.localScale.x, 0.6666667f, transform.transform.localScale.z);
				}
			}
		}
		if (this.Decapitated)
		{
			this.Head.localScale = Vector3.zero;
		}
		if (this.Yandere != null && this.Yandere.Ragdoll == base.gameObject)
		{
			if (this.Yandere.DumpTimer < 1f)
			{
				if (this.Yandere.Lifting)
				{
					base.transform.position = this.Yandere.transform.position;
					base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
				}
				else if (this.Carried)
				{
					base.transform.position = this.Yandere.transform.position;
					base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
					float axis = Input.GetAxis("Vertical");
					float axis2 = Input.GetAxis("Horizontal");
					if (axis != 0f || axis2 != 0f)
					{
						this.Student.CharacterAnimation.CrossFade(this.Yandere.Running ? this.RunAnim : this.WalkAnim);
					}
					else
					{
						this.Student.CharacterAnimation.CrossFade(this.IdleAnim);
					}
					this.Student.CharacterAnimation[this.IdleAnim].time = this.Yandere.CharacterAnimation["f02_carryIdleA_00"].time;
					this.Student.CharacterAnimation[this.WalkAnim].time = this.Yandere.CharacterAnimation["f02_carryWalkA_00"].time;
					this.Student.CharacterAnimation[this.RunAnim].time = this.Yandere.CharacterAnimation["f02_carryRunA_00"].time;
				}
			}
			if (this.Carried)
			{
				if (this.Male)
				{
					Rigidbody rigidbody = this.AllRigidbodies[0];
					rigidbody.transform.parent.transform.localPosition = new Vector3(rigidbody.transform.parent.transform.localPosition.x, 0.2f, rigidbody.transform.parent.transform.localPosition.z);
				}
				if (this.Yandere.Struggling || this.Yandere.DelinquentFighting || this.Yandere.Sprayed)
				{
					this.Fall();
				}
			}
		}
	}

	// Token: 0x06001B33 RID: 6963 RVA: 0x001312C0 File Offset: 0x0012F4C0
	public void StopDragging()
	{
		Rigidbody[] allRigidbodies = this.Student.Ragdoll.AllRigidbodies;
		for (int i = 0; i < allRigidbodies.Length; i++)
		{
			allRigidbodies[i].drag = 0f;
		}
		if (!this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
		this.Prompt.AcceptingInput[1] = true;
		this.Prompt.Circle[1].fillAmount = 1f;
		this.Prompt.Label[1].text = "     Drag";
		this.Yandere.RagdollDragger.connectedBody = null;
		this.Yandere.RagdollPK.connectedBody = null;
		this.Yandere.Dragging = false;
		this.Yandere.Ragdoll = null;
		this.Yandere.StudentManager.UpdateStudents(0);
		this.SettleTimer = 0f;
		this.Settled = false;
		this.Dragged = false;
	}

	// Token: 0x06001B34 RID: 6964 RVA: 0x001313B0 File Offset: 0x0012F5B0
	private void PickNearestLimb()
	{
		if (this.Concealed)
		{
			this.LimbID = 2;
			return;
		}
		this.NearestLimb = this.Limb[0];
		this.LimbID = 0;
		for (int i = 1; i < 4; i++)
		{
			Transform transform = this.Limb[i];
			if (Vector3.Distance(transform.position, this.Yandere.transform.position) < Vector3.Distance(this.NearestLimb.position, this.Yandere.transform.position))
			{
				this.NearestLimb = transform;
				this.LimbID = i;
			}
		}
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x00131444 File Offset: 0x0012F644
	public void Dump()
	{
		if (this.DumpType == RagdollDumpType.Incinerator)
		{
			base.transform.eulerAngles = this.Yandere.transform.eulerAngles;
			base.transform.position = this.Yandere.transform.position;
			this.Incinerator = this.Yandere.Incinerator;
			this.BloodPoolSpawner.enabled = false;
		}
		else if (this.DumpType == RagdollDumpType.TranqCase)
		{
			this.TranqCase = this.Yandere.TranqCase;
		}
		else if (this.DumpType == RagdollDumpType.WoodChipper)
		{
			this.WoodChipper = this.Yandere.WoodChipper;
		}
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Dumped = true;
		Rigidbody[] allRigidbodies = this.AllRigidbodies;
		for (int i = 0; i < allRigidbodies.Length; i++)
		{
			allRigidbodies[i].isKinematic = true;
		}
	}

	// Token: 0x06001B36 RID: 6966 RVA: 0x00131524 File Offset: 0x0012F724
	public void Fall()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.0001f, base.transform.position.z);
		this.Prompt.Label[1].text = "     Drag";
		this.Prompt.HideButton[1] = false;
		this.Prompt.enabled = true;
		if (!this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
		if (this.Dragged)
		{
			this.Yandere.RagdollDragger.connectedBody = null;
			this.Yandere.RagdollPK.connectedBody = null;
			this.Yandere.Dragging = false;
			this.Dragged = false;
		}
		this.Yandere.Ragdoll = null;
		this.Prompt.MyCollider.enabled = true;
		this.BloodPoolSpawner.NearbyBlood = 0;
		this.StopAnimation = true;
		this.SettleTimer = 0f;
		this.Carried = false;
		this.Settled = false;
		this.Falling = true;
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = false;
			this.AllColliders[i].enabled = true;
		}
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x0013167C File Offset: 0x0012F87C
	public void QuickDismember()
	{
		Debug.Log("QuickDismember() was called.");
		for (int i = 0; i < this.BodyParts.Length; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BodyParts[i], this.SpawnPoints[i].position, Quaternion.identity);
			gameObject.transform.eulerAngles = this.SpawnPoints[i].eulerAngles;
			gameObject.GetComponent<PromptScript>().enabled = false;
			gameObject.GetComponent<PickUpScript>().enabled = false;
			gameObject.GetComponent<OutlineScript>().enabled = false;
		}
		if (this.BloodPoolSpawner.BloodParent == null)
		{
			this.BloodPoolSpawner.Start();
		}
		if (!this.Student.StudentManager.NEStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.NWStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.SEStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.SWStairs.bounds.Contains(this.BloodPoolSpawner.transform.position))
		{
			this.BloodPoolSpawner.SpawnBigPool();
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x001317F4 File Offset: 0x0012F9F4
	public void Dismember()
	{
		Debug.Log("Dismembering a character.");
		if (!this.Dismembered)
		{
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("HeadHunter", PlayerPrefs.GetInt("HeadHunter") + 1);
			}
			this.Student.LiquidProjector.material.mainTexture = this.Student.BloodTexture;
			for (int i = 0; i < this.BodyParts.Length; i++)
			{
				if (this.MyTarp == null)
				{
					if (this.Decapitated)
					{
						i++;
						this.Decapitated = false;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BodyParts[i], this.SpawnPoints[i].position, Quaternion.identity);
					gameObject.transform.parent = this.Yandere.LimbParent;
					gameObject.transform.eulerAngles = this.SpawnPoints[i].eulerAngles;
					BodyPartScript component = gameObject.GetComponent<BodyPartScript>();
					component.StudentID = this.StudentID;
					component.Sacrifice = this.Sacrifice;
					if (this.Yandere.StudentManager.NoGravity)
					{
						gameObject.GetComponent<Rigidbody>().useGravity = false;
					}
					if (i == 0)
					{
						if (!this.Student.OriginallyTeacher)
						{
							if (!this.Male)
							{
								this.Student.Cosmetic.FemaleHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
								if (this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory] != null && this.Student.Cosmetic.Accessory != 3 && this.Student.Cosmetic.Accessory != 6)
								{
									this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
								}
							}
							else
							{
								Transform transform = this.Student.Cosmetic.MaleHair[this.Student.Cosmetic.Hairstyle].transform;
								transform.parent = gameObject.transform;
								transform.localScale *= 1.0638298f;
								if (transform.transform.localPosition.y < -1f)
								{
									transform.transform.localPosition = new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y - 0.095f, transform.transform.localPosition.z);
								}
								if (this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory] != null)
								{
									this.Student.Cosmetic.MaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
								}
							}
						}
						else
						{
							this.Student.Cosmetic.TeacherHair[this.Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
							if (this.Student.Cosmetic.TeacherAccessories[this.Student.Cosmetic.Accessory] != null)
							{
								this.Student.Cosmetic.TeacherAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
							}
						}
						if (this.Student.Club != ClubType.Photography && this.Student.Club < ClubType.Gaming && this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club] != null)
						{
							this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.parent = gameObject.transform;
							if (this.Student.Club == ClubType.Occult)
							{
								if (!this.Male)
								{
									this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localPosition = new Vector3(0f, -1.5f, 0.01f);
									this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localEulerAngles = Vector3.zero;
								}
								else
								{
									this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localPosition = new Vector3(0f, -1.42f, 0.005f);
									this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.localEulerAngles = Vector3.zero;
								}
							}
						}
						gameObject.GetComponent<Renderer>().materials[0].mainTexture = this.Student.Cosmetic.FaceTexture;
						if (i == 0)
						{
							gameObject.transform.position += new Vector3(0f, 1f, 0f);
						}
					}
					else if (i == 1)
					{
						if (this.Student.Club == ClubType.Photography && this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club] != null)
						{
							this.Student.Cosmetic.ClubAccessories[(int)this.Student.Club].transform.parent = gameObject.transform;
						}
					}
					else if (i == 2 && !this.Student.Male && this.Student.Cosmetic.Accessory == 6)
					{
						this.Student.Cosmetic.FemaleAccessories[this.Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
					}
					if (!this.Student.StudentManager.NEStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.NWStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.SEStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.SWStairs.bounds.Contains(this.BloodPoolSpawner.transform.position))
					{
						this.BloodPoolSpawner.SpawnBigPool();
						if (this.BloodPoolSpawner.BloodParent == null)
						{
							this.BloodPoolSpawner.Start();
						}
					}
				}
				else
				{
					UnityEngine.Object.Instantiate<GameObject>(this.TarpBag, this.Student.Hips.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
				}
			}
			this.Police.PartsIcon.gameObject.SetActive(true);
			this.Police.BodyParts += 6;
			this.Yandere.NearBodies--;
			this.Police.Corpses--;
			base.gameObject.SetActive(false);
			this.Dismembered = true;
			if (this.MyTarp != null)
			{
				UnityEngine.Object.Destroy(this.MyTarp);
			}
		}
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x00131FA4 File Offset: 0x001301A4
	public void Remove()
	{
		this.Student.Removed = true;
		this.BloodPoolSpawner.enabled = false;
		if (this.AddingToCount)
		{
			this.Yandere.NearBodies--;
		}
		if (this.Poisoned)
		{
			this.Police.PoisonScene = false;
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x06001B3A RID: 6970 RVA: 0x00132004 File Offset: 0x00130204
	public void DestroyRigidbodies()
	{
		this.BloodPoolSpawner.gameObject.SetActive(false);
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			if (this.AllRigidbodies[i].gameObject.GetComponent<CharacterJoint>() != null)
			{
				UnityEngine.Object.Destroy(this.AllRigidbodies[i].gameObject.GetComponent<CharacterJoint>());
			}
			UnityEngine.Object.Destroy(this.AllRigidbodies[i]);
			this.AllColliders[i].enabled = false;
		}
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		base.enabled = false;
	}

	// Token: 0x06001B3B RID: 6971 RVA: 0x001320A0 File Offset: 0x001302A0
	public void DisableRigidbodies()
	{
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = true;
			this.AllColliders[i].enabled = false;
		}
		this.RigidbodiesManuallyDisabled = true;
		this.StopAnimation = true;
	}

	// Token: 0x06001B3C RID: 6972 RVA: 0x001320EC File Offset: 0x001302EC
	public void EnableRigidbodies()
	{
		for (int i = 0; i < this.AllRigidbodies.Length; i++)
		{
			this.AllRigidbodies[i].isKinematic = false;
			this.AllColliders[i].enabled = true;
			this.AllRigidbodies[i].useGravity = !this.Yandere.StudentManager.NoGravity;
		}
		this.RigidbodiesManuallyDisabled = false;
		this.StopAnimation = false;
	}

	// Token: 0x06001B3D RID: 6973 RVA: 0x00132158 File Offset: 0x00130358
	public void HideAccessories()
	{
		this.Student.Cosmetic.RightStockings[0].SetActive(false);
		this.Student.Cosmetic.LeftStockings[0].SetActive(false);
		this.Student.Cosmetic.RightWristband.SetActive(false);
		this.Student.Cosmetic.LeftWristband.SetActive(false);
		this.Student.Cosmetic.Bookbag.SetActive(false);
		this.Student.Cosmetic.Hoodie.SetActive(false);
	}

	// Token: 0x06001B3E RID: 6974 RVA: 0x001321F0 File Offset: 0x001303F0
	public void ConcealInTrashBag()
	{
		this.Prompt.Label[0].text = "     Dismember";
		this.Student.StudentManager.Police.HiddenCorpses++;
		this.Concealed = true;
		this.Wrappable = false;
		if (this.AddingToCount)
		{
			this.Yandere.NearBodies--;
			this.AddingToCount = false;
		}
		this.Student.MyRenderer.enabled = false;
		if (this.Student.Cosmetic.HairRenderer != null)
		{
			this.Student.Cosmetic.HairRenderer.gameObject.SetActive(false);
		}
		else if (this.Student.Nemesis)
		{
			this.Student.gameObject.GetComponent<NemesisScript>().NemesisHair.SetActive(false);
		}
		this.Student.GarbageBag.SetActive(true);
		if (!this.Student.Male)
		{
			this.Student.InstrumentBag[1].SetActive(false);
			this.Student.InstrumentBag[2].SetActive(false);
			this.Student.InstrumentBag[3].SetActive(false);
			this.Student.InstrumentBag[4].SetActive(false);
			this.Student.InstrumentBag[5].SetActive(false);
			this.HideAccessories();
		}
		if (this.Student.ApronAttacher.enabled)
		{
			this.Student.ApronAttacher.newRenderer.enabled = false;
		}
		if (this.Student.LabcoatAttacher.enabled)
		{
			this.Student.LabcoatAttacher.newRenderer.enabled = false;
		}
		this.Student.Armband.SetActive(false);
		this.BloodPoolSpawner.enabled = false;
		if (this.Yandere.PickUp != null)
		{
			this.Yandere.PickUp.GetComponent<AudioSource>().Play();
			this.Yandere.MurderousActionTimer = 1f;
		}
		if (this.Student.BikiniAttacher != null && this.Student.BikiniAttacher.newRenderer != null)
		{
			this.Student.BikiniAttacher.newRenderer.enabled = false;
		}
		if (this.Student.Cosmetic)
		{
			this.Student.Cosmetic.DisableAccessories();
		}
	}

	// Token: 0x04002E36 RID: 11830
	public BloodPoolSpawnerScript BloodPoolSpawner;

	// Token: 0x04002E37 RID: 11831
	public DetectionMarkerScript DetectionMarker;

	// Token: 0x04002E38 RID: 11832
	public IncineratorScript Incinerator;

	// Token: 0x04002E39 RID: 11833
	public WoodChipperScript WoodChipper;

	// Token: 0x04002E3A RID: 11834
	public TranqCaseScript TranqCase;

	// Token: 0x04002E3B RID: 11835
	public StudentScript Student;

	// Token: 0x04002E3C RID: 11836
	public YandereScript Yandere;

	// Token: 0x04002E3D RID: 11837
	public PoliceScript Police;

	// Token: 0x04002E3E RID: 11838
	public PromptScript Prompt;

	// Token: 0x04002E3F RID: 11839
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04002E40 RID: 11840
	public Collider BloodSpawnerCollider;

	// Token: 0x04002E41 RID: 11841
	public Animation CharacterAnimation;

	// Token: 0x04002E42 RID: 11842
	public Collider HideCollider;

	// Token: 0x04002E43 RID: 11843
	public Rigidbody[] AllRigidbodies;

	// Token: 0x04002E44 RID: 11844
	public Collider[] AllColliders;

	// Token: 0x04002E45 RID: 11845
	public Rigidbody[] Rigidbodies;

	// Token: 0x04002E46 RID: 11846
	public Transform[] SpawnPoints;

	// Token: 0x04002E47 RID: 11847
	public GameObject[] BodyParts;

	// Token: 0x04002E48 RID: 11848
	public Transform NearestLimb;

	// Token: 0x04002E49 RID: 11849
	public Transform RightBreast;

	// Token: 0x04002E4A RID: 11850
	public Transform LeftBreast;

	// Token: 0x04002E4B RID: 11851
	public Transform PelvisRoot;

	// Token: 0x04002E4C RID: 11852
	public Transform Ponytail;

	// Token: 0x04002E4D RID: 11853
	public Transform RightEye;

	// Token: 0x04002E4E RID: 11854
	public Transform LeftEye;

	// Token: 0x04002E4F RID: 11855
	public Transform HairR;

	// Token: 0x04002E50 RID: 11856
	public Transform HairL;

	// Token: 0x04002E51 RID: 11857
	public Transform[] Limb;

	// Token: 0x04002E52 RID: 11858
	public Transform Head;

	// Token: 0x04002E53 RID: 11859
	public Vector3 RightEyeOrigin;

	// Token: 0x04002E54 RID: 11860
	public Vector3 LeftEyeOrigin;

	// Token: 0x04002E55 RID: 11861
	public Vector3[] LimbAnchor;

	// Token: 0x04002E56 RID: 11862
	public GameObject Character;

	// Token: 0x04002E57 RID: 11863
	public GameObject TarpBag;

	// Token: 0x04002E58 RID: 11864
	public GameObject MyTarp;

	// Token: 0x04002E59 RID: 11865
	public GameObject Zs;

	// Token: 0x04002E5A RID: 11866
	public bool ElectrocutionAnimation;

	// Token: 0x04002E5B RID: 11867
	public bool MurderSuicideAnimation;

	// Token: 0x04002E5C RID: 11868
	public bool BurningAnimation;

	// Token: 0x04002E5D RID: 11869
	public bool ChokingAnimation;

	// Token: 0x04002E5E RID: 11870
	public bool RigidbodiesManuallyDisabled;

	// Token: 0x04002E5F RID: 11871
	public bool TeleportNextFrame;

	// Token: 0x04002E60 RID: 11872
	public bool ColoredOutline;

	// Token: 0x04002E61 RID: 11873
	public bool AddingToCount;

	// Token: 0x04002E62 RID: 11874
	public bool MurderSuicide;

	// Token: 0x04002E63 RID: 11875
	public bool AddedOutline;

	// Token: 0x04002E64 RID: 11876
	public bool Cauterizable;

	// Token: 0x04002E65 RID: 11877
	public bool Electrocuted;

	// Token: 0x04002E66 RID: 11878
	public bool StopAnimation = true;

	// Token: 0x04002E67 RID: 11879
	public bool Decapitated;

	// Token: 0x04002E68 RID: 11880
	public bool Dismembered;

	// Token: 0x04002E69 RID: 11881
	public bool NeckSnapped;

	// Token: 0x04002E6A RID: 11882
	public bool Cauterized;

	// Token: 0x04002E6B RID: 11883
	public bool Disturbing;

	// Token: 0x04002E6C RID: 11884
	public bool Concealed;

	// Token: 0x04002E6D RID: 11885
	public bool Sacrifice;

	// Token: 0x04002E6E RID: 11886
	public bool Wrappable;

	// Token: 0x04002E6F RID: 11887
	public bool Disposed;

	// Token: 0x04002E70 RID: 11888
	public bool Poisoned;

	// Token: 0x04002E71 RID: 11889
	public bool Tranquil;

	// Token: 0x04002E72 RID: 11890
	public bool Burning;

	// Token: 0x04002E73 RID: 11891
	public bool Carried;

	// Token: 0x04002E74 RID: 11892
	public bool Choking;

	// Token: 0x04002E75 RID: 11893
	public bool Dragged;

	// Token: 0x04002E76 RID: 11894
	public bool Drowned;

	// Token: 0x04002E77 RID: 11895
	public bool Falling;

	// Token: 0x04002E78 RID: 11896
	public bool Nemesis;

	// Token: 0x04002E79 RID: 11897
	public bool Settled;

	// Token: 0x04002E7A RID: 11898
	public bool Suicide;

	// Token: 0x04002E7B RID: 11899
	public bool Burned;

	// Token: 0x04002E7C RID: 11900
	public bool Dumped;

	// Token: 0x04002E7D RID: 11901
	public bool Hidden;

	// Token: 0x04002E7E RID: 11902
	public bool Pushed;

	// Token: 0x04002E7F RID: 11903
	public bool Male;

	// Token: 0x04002E80 RID: 11904
	public float AnimStartTime;

	// Token: 0x04002E81 RID: 11905
	public float SettleTimer;

	// Token: 0x04002E82 RID: 11906
	public float BreastSize;

	// Token: 0x04002E83 RID: 11907
	public float DumpTimer;

	// Token: 0x04002E84 RID: 11908
	public float EyeShrink;

	// Token: 0x04002E85 RID: 11909
	public float FallTimer;

	// Token: 0x04002E86 RID: 11910
	public int StudentID;

	// Token: 0x04002E87 RID: 11911
	public RagdollDumpType DumpType;

	// Token: 0x04002E88 RID: 11912
	public int LimbID;

	// Token: 0x04002E89 RID: 11913
	public int Frame;

	// Token: 0x04002E8A RID: 11914
	public string DumpedAnim = string.Empty;

	// Token: 0x04002E8B RID: 11915
	public string LiftAnim = string.Empty;

	// Token: 0x04002E8C RID: 11916
	public string IdleAnim = string.Empty;

	// Token: 0x04002E8D RID: 11917
	public string WalkAnim = string.Empty;

	// Token: 0x04002E8E RID: 11918
	public string RunAnim = string.Empty;

	// Token: 0x04002E8F RID: 11919
	public bool UpdateNextFrame;

	// Token: 0x04002E90 RID: 11920
	public Vector3 NextPosition;

	// Token: 0x04002E91 RID: 11921
	public Quaternion NextRotation;

	// Token: 0x04002E92 RID: 11922
	public int Frames;
}
