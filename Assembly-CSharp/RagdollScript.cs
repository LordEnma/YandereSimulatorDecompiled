using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RagdollScript : MonoBehaviour
{
	// Token: 0x06001B6E RID: 7022 RVA: 0x00133BDC File Offset: 0x00131DDC
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
		this.Student.Prompt.enabled = false;
		this.Student.Prompt.Hide();
		this.Prompt.enabled = true;
		if (!this.Tranquil)
		{
			this.Prompt.HideButton[3] = false;
		}
		if (this.Tutorial)
		{
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[3] = true;
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

	// Token: 0x06001B6F RID: 7023 RVA: 0x00133DD0 File Offset: 0x00131FD0
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
						this.TeleportNextFrame = false;
					}
				}
				if (this.Yandere.Running && this.Yandere.CanMove && this.Dragged)
				{
					this.StopDragging();
				}
				if (Vector3.Distance(this.Yandere.transform.position, this.Prompt.transform.position) < 2f)
				{
					if (!this.Suicide && !this.Concealed && !this.AddingToCount)
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
					if (this.Concealed)
					{
						this.Incinerator.HiddenCorpses++;
					}
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
					if (this.Concealed)
					{
						this.WoodChipper.HiddenCorpses++;
					}
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

	// Token: 0x06001B70 RID: 7024 RVA: 0x00135150 File Offset: 0x00133350
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

	// Token: 0x06001B71 RID: 7025 RVA: 0x00135570 File Offset: 0x00133770
	public void StopDragging()
	{
		this.Student.Prompt.enabled = false;
		this.Student.Prompt.Hide();
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

	// Token: 0x06001B72 RID: 7026 RVA: 0x00135680 File Offset: 0x00133880
	private void PickNearestLimb()
	{
		if (this.Concealed)
		{
			this.LimbID = 3;
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

	// Token: 0x06001B73 RID: 7027 RVA: 0x00135714 File Offset: 0x00133914
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

	// Token: 0x06001B74 RID: 7028 RVA: 0x001357F4 File Offset: 0x001339F4
	public void Fall()
	{
		this.Student.Prompt.enabled = false;
		this.Student.Prompt.Hide();
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

	// Token: 0x06001B75 RID: 7029 RVA: 0x0013596C File Offset: 0x00133B6C
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

	// Token: 0x06001B76 RID: 7030 RVA: 0x00135AE4 File Offset: 0x00133CE4
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
			if (this.MyTarp == null)
			{
				for (int i = 0; i < this.BodyParts.Length; i++)
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
						gameObject.transform.position += new Vector3(0f, 1f, 0f);
						if (!this.Student.StudentManager.NEStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.NWStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.SEStairs.bounds.Contains(this.BloodPoolSpawner.transform.position) && !this.Student.StudentManager.SWStairs.bounds.Contains(this.BloodPoolSpawner.transform.position))
						{
							this.BloodPoolSpawner.SpawnBigPool();
							if (this.BloodPoolSpawner.BloodParent == null)
							{
								this.BloodPoolSpawner.Start();
							}
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
				}
			}
			else
			{
				for (int j = 0; j < 6; j++)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.TarpBag, this.Student.Hips.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
					if (j == 0)
					{
						gameObject2.transform.position = this.Student.Hips.position + new Vector3(0f, 0.5f, 0f);
					}
					else if (j == 1)
					{
						gameObject2.transform.position = this.Student.Hips.position + new Vector3(0.5f, 0.5f, 0f);
					}
					else if (j == 2)
					{
						gameObject2.transform.position = this.Student.Hips.position + new Vector3(-0.5f, 0.5f, 0f);
					}
					else if (j == 3)
					{
						gameObject2.transform.position = this.Student.Hips.position + new Vector3(0f, 0.5f, 0.5f);
					}
					else if (j == 4)
					{
						gameObject2.transform.position = this.Student.Hips.position + new Vector3(0f, 0.5f, -0.5f);
					}
					else if (j == 5)
					{
						gameObject2.transform.position = this.Student.Hips.position + new Vector3(0.5f, 0.5f, 0.5f);
					}
					gameObject2.GetComponent<BodyPartScript>().StudentID = this.StudentID;
					gameObject2.transform.parent = this.Prompt.Yandere.Police.GarbageParent;
					this.Student.StudentManager.GarbageBagList[this.Student.StudentManager.GarbageBags] = gameObject2;
					this.Student.StudentManager.GarbageBags++;
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

	// Token: 0x06001B77 RID: 7031 RVA: 0x00136488 File Offset: 0x00134688
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

	// Token: 0x06001B78 RID: 7032 RVA: 0x001364E8 File Offset: 0x001346E8
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

	// Token: 0x06001B79 RID: 7033 RVA: 0x00136584 File Offset: 0x00134784
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

	// Token: 0x06001B7A RID: 7034 RVA: 0x001365D0 File Offset: 0x001347D0
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

	// Token: 0x06001B7B RID: 7035 RVA: 0x0013663C File Offset: 0x0013483C
	public void HideAccessories()
	{
		this.Student.Cosmetic.RightStockings[0].SetActive(false);
		this.Student.Cosmetic.LeftStockings[0].SetActive(false);
		this.Student.Cosmetic.RightWristband.SetActive(false);
		this.Student.Cosmetic.LeftWristband.SetActive(false);
		this.Student.Cosmetic.Bookbag.SetActive(false);
		this.Student.Cosmetic.Hoodie.SetActive(false);
	}

	// Token: 0x06001B7C RID: 7036 RVA: 0x001366D4 File Offset: 0x001348D4
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
		if (this.Student.Attacher.enabled && this.Student.Attacher.newRenderer != null)
		{
			this.Student.Attacher.newRenderer.enabled = false;
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
		if (this.Student.EightiesTeacherAttacher != null && this.Student.EightiesTeacherAttacher.activeInHierarchy)
		{
			this.Student.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.enabled = false;
		}
		if (this.Student.Cosmetic.BurlapSack != null && this.Student.Cosmetic.BurlapSack.newRenderer != null)
		{
			this.Student.Cosmetic.BurlapSack.newRenderer.enabled = false;
		}
		this.Student.SpeechLines.Stop();
		this.Student.DisableProps();
		if (this.Student.Male)
		{
			this.Student.DisableMaleProps();
			return;
		}
		this.Student.DisableFemaleProps();
	}

	// Token: 0x04002EDE RID: 11998
	public BloodPoolSpawnerScript BloodPoolSpawner;

	// Token: 0x04002EDF RID: 11999
	public DetectionMarkerScript DetectionMarker;

	// Token: 0x04002EE0 RID: 12000
	public IncineratorScript Incinerator;

	// Token: 0x04002EE1 RID: 12001
	public WoodChipperScript WoodChipper;

	// Token: 0x04002EE2 RID: 12002
	public TranqCaseScript TranqCase;

	// Token: 0x04002EE3 RID: 12003
	public StudentScript Student;

	// Token: 0x04002EE4 RID: 12004
	public YandereScript Yandere;

	// Token: 0x04002EE5 RID: 12005
	public PoliceScript Police;

	// Token: 0x04002EE6 RID: 12006
	public PromptScript Prompt;

	// Token: 0x04002EE7 RID: 12007
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04002EE8 RID: 12008
	public Collider BloodSpawnerCollider;

	// Token: 0x04002EE9 RID: 12009
	public Animation CharacterAnimation;

	// Token: 0x04002EEA RID: 12010
	public Collider HideCollider;

	// Token: 0x04002EEB RID: 12011
	public Rigidbody[] AllRigidbodies;

	// Token: 0x04002EEC RID: 12012
	public Collider[] AllColliders;

	// Token: 0x04002EED RID: 12013
	public Rigidbody[] Rigidbodies;

	// Token: 0x04002EEE RID: 12014
	public Transform[] SpawnPoints;

	// Token: 0x04002EEF RID: 12015
	public GameObject[] BodyParts;

	// Token: 0x04002EF0 RID: 12016
	public Transform NearestLimb;

	// Token: 0x04002EF1 RID: 12017
	public Transform RightBreast;

	// Token: 0x04002EF2 RID: 12018
	public Transform LeftBreast;

	// Token: 0x04002EF3 RID: 12019
	public Transform PelvisRoot;

	// Token: 0x04002EF4 RID: 12020
	public Transform Ponytail;

	// Token: 0x04002EF5 RID: 12021
	public Transform RightEye;

	// Token: 0x04002EF6 RID: 12022
	public Transform LeftEye;

	// Token: 0x04002EF7 RID: 12023
	public Transform HairR;

	// Token: 0x04002EF8 RID: 12024
	public Transform HairL;

	// Token: 0x04002EF9 RID: 12025
	public Transform[] Limb;

	// Token: 0x04002EFA RID: 12026
	public Transform Head;

	// Token: 0x04002EFB RID: 12027
	public Vector3 RightEyeOrigin;

	// Token: 0x04002EFC RID: 12028
	public Vector3 LeftEyeOrigin;

	// Token: 0x04002EFD RID: 12029
	public Vector3[] LimbAnchor;

	// Token: 0x04002EFE RID: 12030
	public GameObject Character;

	// Token: 0x04002EFF RID: 12031
	public GameObject TarpBag;

	// Token: 0x04002F00 RID: 12032
	public GameObject MyTarp;

	// Token: 0x04002F01 RID: 12033
	public GameObject Zs;

	// Token: 0x04002F02 RID: 12034
	public bool ElectrocutionAnimation;

	// Token: 0x04002F03 RID: 12035
	public bool MurderSuicideAnimation;

	// Token: 0x04002F04 RID: 12036
	public bool BurningAnimation;

	// Token: 0x04002F05 RID: 12037
	public bool ChokingAnimation;

	// Token: 0x04002F06 RID: 12038
	public bool RigidbodiesManuallyDisabled;

	// Token: 0x04002F07 RID: 12039
	public bool TeleportNextFrame;

	// Token: 0x04002F08 RID: 12040
	public bool ColoredOutline;

	// Token: 0x04002F09 RID: 12041
	public bool AddingToCount;

	// Token: 0x04002F0A RID: 12042
	public bool MurderSuicide;

	// Token: 0x04002F0B RID: 12043
	public bool AddedOutline;

	// Token: 0x04002F0C RID: 12044
	public bool Cauterizable;

	// Token: 0x04002F0D RID: 12045
	public bool Electrocuted;

	// Token: 0x04002F0E RID: 12046
	public bool StopAnimation = true;

	// Token: 0x04002F0F RID: 12047
	public bool Decapitated;

	// Token: 0x04002F10 RID: 12048
	public bool Dismembered;

	// Token: 0x04002F11 RID: 12049
	public bool NeckSnapped;

	// Token: 0x04002F12 RID: 12050
	public bool Cauterized;

	// Token: 0x04002F13 RID: 12051
	public bool Disturbing;

	// Token: 0x04002F14 RID: 12052
	public bool Concealed;

	// Token: 0x04002F15 RID: 12053
	public bool Sacrifice;

	// Token: 0x04002F16 RID: 12054
	public bool Wrappable;

	// Token: 0x04002F17 RID: 12055
	public bool Disposed;

	// Token: 0x04002F18 RID: 12056
	public bool Poisoned;

	// Token: 0x04002F19 RID: 12057
	public bool Tranquil;

	// Token: 0x04002F1A RID: 12058
	public bool Tutorial;

	// Token: 0x04002F1B RID: 12059
	public bool Burning;

	// Token: 0x04002F1C RID: 12060
	public bool Carried;

	// Token: 0x04002F1D RID: 12061
	public bool Choking;

	// Token: 0x04002F1E RID: 12062
	public bool Dragged;

	// Token: 0x04002F1F RID: 12063
	public bool Drowned;

	// Token: 0x04002F20 RID: 12064
	public bool Falling;

	// Token: 0x04002F21 RID: 12065
	public bool Nemesis;

	// Token: 0x04002F22 RID: 12066
	public bool Settled;

	// Token: 0x04002F23 RID: 12067
	public bool Suicide;

	// Token: 0x04002F24 RID: 12068
	public bool Burned;

	// Token: 0x04002F25 RID: 12069
	public bool Dumped;

	// Token: 0x04002F26 RID: 12070
	public bool Hidden;

	// Token: 0x04002F27 RID: 12071
	public bool Pushed;

	// Token: 0x04002F28 RID: 12072
	public bool Male;

	// Token: 0x04002F29 RID: 12073
	public float AnimStartTime;

	// Token: 0x04002F2A RID: 12074
	public float SettleTimer;

	// Token: 0x04002F2B RID: 12075
	public float BreastSize;

	// Token: 0x04002F2C RID: 12076
	public float DumpTimer;

	// Token: 0x04002F2D RID: 12077
	public float EyeShrink;

	// Token: 0x04002F2E RID: 12078
	public float FallTimer;

	// Token: 0x04002F2F RID: 12079
	public int StudentID;

	// Token: 0x04002F30 RID: 12080
	public RagdollDumpType DumpType;

	// Token: 0x04002F31 RID: 12081
	public int LimbID;

	// Token: 0x04002F32 RID: 12082
	public int Frame;

	// Token: 0x04002F33 RID: 12083
	public string DumpedAnim = string.Empty;

	// Token: 0x04002F34 RID: 12084
	public string LiftAnim = string.Empty;

	// Token: 0x04002F35 RID: 12085
	public string IdleAnim = string.Empty;

	// Token: 0x04002F36 RID: 12086
	public string WalkAnim = string.Empty;

	// Token: 0x04002F37 RID: 12087
	public string RunAnim = string.Empty;

	// Token: 0x04002F38 RID: 12088
	public bool UpdateNextFrame;

	// Token: 0x04002F39 RID: 12089
	public Vector3 NextPosition;

	// Token: 0x04002F3A RID: 12090
	public Quaternion NextRotation;

	// Token: 0x04002F3B RID: 12091
	public int Frames;
}
