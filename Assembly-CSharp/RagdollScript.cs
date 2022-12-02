using UnityEngine;

public class RagdollScript : MonoBehaviour
{
	public BloodPoolSpawnerScript BloodPoolSpawner;

	public DetectionMarkerScript DetectionMarker;

	public IncineratorScript Incinerator;

	public WoodChipperScript WoodChipper;

	public TranqCaseScript TranqCase;

	public StudentScript Student;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PromptScript Prompt;

	public SkinnedMeshRenderer MyRenderer;

	public Collider BloodSpawnerCollider;

	public Animation CharacterAnimation;

	public Collider HideCollider;

	public Rigidbody[] AllRigidbodies;

	public Collider[] AllColliders;

	public Rigidbody[] Rigidbodies;

	public Transform[] SpawnPoints;

	public GameObject[] BodyParts;

	public Transform NearestLimb;

	public Transform RightBreast;

	public Transform LeftBreast;

	public Transform PelvisRoot;

	public Transform Ponytail;

	public Transform RightEye;

	public Transform LeftEye;

	public Transform HairR;

	public Transform HairL;

	public Transform[] Limb;

	public Transform Head;

	public Vector3 RightEyeOrigin;

	public Vector3 LeftEyeOrigin;

	public Vector3[] LimbAnchor;

	public GameObject Character;

	public GameObject TarpBag;

	public GameObject MyTarp;

	public GameObject Zs;

	public bool ElectrocutionAnimation;

	public bool MurderSuicideAnimation;

	public bool BurningAnimation;

	public bool ChokingAnimation;

	public bool RigidbodiesManuallyDisabled;

	public bool DroppedFromRooftop;

	public bool InsideIncinerator;

	public bool InsideWoodchipper;

	public bool TeleportNextFrame;

	public bool ColoredOutline;

	public bool AddingToCount;

	public bool MurderSuicide;

	public bool AddedOutline;

	public bool Cauterizable;

	public bool Electrocuted;

	public bool StruckGround;

	public bool StopAnimation = true;

	public bool Decapitated;

	public bool Dismembered;

	public bool NeckSnapped;

	public bool Cauterized;

	public bool Disturbing;

	public bool Concealed;

	public bool Sacrifice;

	public bool Wrappable;

	public bool Disposed;

	public bool Poisoned;

	public bool Tranquil;

	public bool Tutorial;

	public bool Burning;

	public bool Carried;

	public bool Choking;

	public bool Dragged;

	public bool Drowned;

	public bool Falling;

	public bool Nemesis;

	public bool Settled;

	public bool Suicide;

	public bool Burned;

	public bool Dumped;

	public bool Hidden;

	public bool Pushed;

	public bool Male;

	public float AnimStartTime;

	public float SettleTimer;

	public float BreastSize;

	public float DumpTimer;

	public float EyeShrink;

	public float FallTimer;

	public int StudentID;

	public RagdollDumpType DumpType;

	public int LimbID;

	public int Frame;

	public string DumpedAnim = string.Empty;

	public string LiftAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public string WalkAnim = string.Empty;

	public string RunAnim = string.Empty;

	public bool UpdateNextFrame;

	public Vector3 NextPosition;

	public Quaternion NextRotation;

	public int Frames;

	private void Start()
	{
		ElectrocutionAnimation = false;
		MurderSuicideAnimation = false;
		BurningAnimation = false;
		ChokingAnimation = false;
		Disturbing = false;
		Yandere = Student.StudentManager.Yandere;
		Physics.IgnoreLayerCollision(11, 13, true);
		Zs.SetActive(Tranquil);
		if (!Tranquil && !Poisoned && !Drowned && !Electrocuted && !Burning && !NeckSnapped)
		{
			Student.StudentManager.TutorialWindow.ShowPoolMessage = true;
			BloodPoolSpawner.gameObject.SetActive(true);
			BloodPoolSpawner.StudentManager = Student.StudentManager;
			if (Pushed)
			{
				BloodPoolSpawner.Timer = 5f;
			}
		}
		if (!RigidbodiesManuallyDisabled)
		{
			for (int i = 0; i < AllRigidbodies.Length; i++)
			{
				AllRigidbodies[i].isKinematic = false;
				AllColliders[i].enabled = true;
				if (Yandere != null && Yandere.StudentManager.NoGravity)
				{
					AllRigidbodies[i].useGravity = false;
				}
			}
		}
		else
		{
			AllColliders[0].enabled = true;
		}
		Student.Prompt.enabled = false;
		Student.Prompt.Hide();
		Prompt.enabled = true;
		if (!Tranquil)
		{
			Prompt.HideButton[3] = false;
		}
		if (Tutorial)
		{
			Prompt.HideButton[1] = true;
			Prompt.HideButton[3] = true;
		}
		if (Yandere != null && Yandere.BlackHole)
		{
			DestroyRigidbodies();
		}
		if (Concealed)
		{
			ConcealInTrashBag();
		}
	}

	private void Update()
	{
		if (UpdateNextFrame)
		{
			Student.Hips.localPosition = NextPosition;
			Student.Hips.localRotation = NextRotation;
			Physics.SyncTransforms();
			UpdateNextFrame = false;
		}
		if (!Dragged && !Carried && !Settled && !Yandere.PK && !Yandere.StudentManager.NoGravity)
		{
			SettleTimer += Time.deltaTime;
			if (SettleTimer > 5f)
			{
				Settled = true;
				for (int i = 0; i < AllRigidbodies.Length; i++)
				{
					AllRigidbodies[i].isKinematic = true;
					AllColliders[i].enabled = false;
				}
			}
		}
		if (DetectionMarker != null)
		{
			if (DetectionMarker.Tex.color.a > 0.1f)
			{
				DetectionMarker.Tex.color = new Color(DetectionMarker.Tex.color.r, DetectionMarker.Tex.color.g, DetectionMarker.Tex.color.b, Mathf.MoveTowards(DetectionMarker.Tex.color.a, 0f, Time.deltaTime * 10f));
			}
			else
			{
				DetectionMarker.Tex.color = new Color(DetectionMarker.Tex.color.r, DetectionMarker.Tex.color.g, DetectionMarker.Tex.color.b, 0f);
				DetectionMarker = null;
			}
		}
		if (Yandere != null)
		{
			if (!Dumped)
			{
				if (StopAnimation)
				{
					if (Student.CharacterAnimation.isPlaying)
					{
						Student.CharacterAnimation.Stop();
					}
					else
					{
						if (TeleportNextFrame)
						{
							Student.transform.position = new Vector3(-28.78f, 4f, 10.386f);
							TeleportNextFrame = false;
						}
						if (Student.DeathType == DeathType.Weight && RigidbodiesManuallyDisabled)
						{
							Debug.Log("Forcing the ''crushed'' animation to play.");
							if (!Student.Male)
							{
								Student.CharacterAnimation.Play("f02_crushed_00");
							}
							else
							{
								Student.CharacterAnimation.Play("crushed_00");
							}
							TeleportNextFrame = true;
						}
					}
				}
				if (Yandere.PickUp != null)
				{
					if (Yandere.PickUp.GarbageBagBox)
					{
						if (!Concealed)
						{
							Prompt.Label[0].text = "     Conceal";
							Cauterizable = false;
							Wrappable = true;
						}
					}
					else if (Yandere.PickUp.Tarp)
					{
						Prompt.Label[0].text = "     Place Tarp";
					}
					else if (Yandere.PickUp.Blowtorch)
					{
						if (Concealed)
						{
							Prompt.HideButton[0] = true;
						}
						else if (BloodPoolSpawner.enabled)
						{
							Prompt.Label[0].text = "     Cauterize";
							Cauterizable = true;
							Wrappable = false;
						}
					}
					else
					{
						Prompt.Label[0].text = "     Dismember";
						Cauterizable = false;
						Wrappable = false;
					}
				}
				else if (Cauterizable)
				{
					Prompt.Label[0].text = "     Dismember";
					Cauterizable = false;
					Wrappable = false;
				}
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					Prompt.Circle[0].fillAmount = 1f;
					if (Yandere.PickUp != null && Yandere.PickUp.Tarp)
					{
						GameObject obj = Yandere.PickUp.gameObject;
						GameObject myTarp = Object.Instantiate(Yandere.PickUp.TarpObject, new Vector3(Student.Hips.position.x, Yandere.transform.position.y, Student.Hips.position.z), Yandere.transform.rotation);
						MyTarp = myTarp;
						Yandere.EmptyHands();
						Object.Destroy(obj);
					}
					else if (!Yandere.Chased && Yandere.Chasers == 0)
					{
						if (Wrappable)
						{
							ConcealInTrashBag();
						}
						else if (Cauterizable)
						{
							Prompt.Label[0].text = "     Dismember";
							BloodPoolSpawner.enabled = false;
							Cauterizable = false;
							Cauterized = true;
							Yandere.CharacterAnimation.CrossFade("f02_cauterize_00");
							Yandere.Cauterizing = true;
							Yandere.CanMove = false;
							Yandere.PickUp.GetComponent<BlowtorchScript>().enabled = true;
							Yandere.PickUp.GetComponent<AudioSource>().Play();
						}
						else if (Yandere.StudentManager.OriginalUniforms + Yandere.StudentManager.NewUniforms > 0)
						{
							Yandere.CharacterAnimation.CrossFade("f02_dismember_00");
							Yandere.transform.LookAt(base.transform);
							Yandere.RPGCamera.transform.position = Yandere.DismemberSpot.position;
							Yandere.RPGCamera.transform.eulerAngles = Yandere.DismemberSpot.eulerAngles;
							Yandere.EquippedWeapon.Dismember();
							Yandere.RPGCamera.enabled = false;
							Yandere.TargetStudent = Student;
							Yandere.Ragdoll = base.gameObject;
							Yandere.Dismembering = true;
							Yandere.CanMove = false;
						}
						else if (!Yandere.ClothingWarning)
						{
							Yandere.NotificationManager.DisplayNotification(NotificationType.Clothing);
							Yandere.StudentManager.TutorialWindow.ShowClothingMessage = true;
							Yandere.ClothingWarning = true;
						}
					}
				}
				if (Prompt.Circle[1].fillAmount == 0f)
				{
					Prompt.Circle[1].fillAmount = 1f;
					if (!Student.FireEmitters[1].isPlaying)
					{
						if (!Dragged)
						{
							Yandere.EmptyHands();
							Prompt.AcceptingInput[1] = false;
							Prompt.Label[1].text = "     Drop";
							PickNearestLimb();
							Yandere.RagdollDragger.connectedBody = Rigidbodies[LimbID];
							Yandere.RagdollDragger.connectedAnchor = LimbAnchor[LimbID];
							Yandere.Dragging = true;
							Yandere.Running = false;
							Yandere.DragState = 0;
							Yandere.Ragdoll = base.gameObject;
							Yandere.CurrentRagdoll = this;
							Dragged = true;
							Yandere.StudentManager.UpdateStudents();
							if (MurderSuicide)
							{
								Police.MurderSuicideScene = false;
								MurderSuicide = false;
							}
							if (Suicide)
							{
								Police.Suicide = false;
								Suicide = false;
							}
							for (int j = 0; j < Student.Ragdoll.AllRigidbodies.Length; j++)
							{
								Student.Ragdoll.AllRigidbodies[j].drag = 2f;
							}
							for (int k = 0; k < AllRigidbodies.Length; k++)
							{
								AllRigidbodies[k].isKinematic = false;
								AllColliders[k].enabled = true;
								if (Yandere.StudentManager.NoGravity)
								{
									AllRigidbodies[k].useGravity = false;
								}
							}
							RigidbodiesManuallyDisabled = false;
						}
						else
						{
							StopDragging();
						}
					}
				}
				if (Prompt.Circle[3].fillAmount == 0f)
				{
					Prompt.Circle[3].fillAmount = 1f;
					if (!Student.FireEmitters[1].isPlaying)
					{
						Yandere.EmptyHands();
						Prompt.Label[1].text = "     Drop";
						Prompt.HideButton[1] = true;
						Prompt.HideButton[3] = true;
						Prompt.enabled = false;
						Prompt.Hide();
						for (int l = 0; l < AllRigidbodies.Length; l++)
						{
							AllRigidbodies[l].isKinematic = true;
							AllColliders[l].enabled = false;
						}
						if (Male)
						{
							Rigidbody rigidbody = AllRigidbodies[0];
							rigidbody.transform.parent.transform.localPosition = new Vector3(rigidbody.transform.parent.transform.localPosition.x, 0.2f, rigidbody.transform.parent.transform.localPosition.z);
						}
						Yandere.CharacterAnimation["f02_carryLiftA_00"].speed = 1f + (float)(Yandere.Class.PhysicalGrade + Yandere.Class.PhysicalBonus) * 0.2f;
						Student.CharacterAnimation[LiftAnim].speed = 1f + (float)(Yandere.Class.PhysicalGrade + Yandere.Class.PhysicalBonus) * 0.2f;
						Yandere.CharacterAnimation.Play("f02_carryLiftA_00");
						Student.CharacterAnimation.enabled = true;
						Student.CharacterAnimation.Play(LiftAnim);
						BloodSpawnerCollider.enabled = false;
						PelvisRoot.localEulerAngles = new Vector3(PelvisRoot.localEulerAngles.x, 0f, PelvisRoot.localEulerAngles.z);
						Prompt.MyCollider.enabled = false;
						PelvisRoot.localPosition = new Vector3(PelvisRoot.localPosition.x, PelvisRoot.localPosition.y, 0f);
						Yandere.Ragdoll = base.gameObject;
						Yandere.CurrentRagdoll = this;
						Yandere.CanMove = false;
						Yandere.Lifting = true;
						StopAnimation = false;
						Carried = true;
						Falling = false;
						FallTimer = 0f;
						RigidbodiesManuallyDisabled = false;
						TeleportNextFrame = false;
					}
				}
				if (Yandere.Running && Yandere.CanMove && Dragged)
				{
					StopDragging();
				}
				if (Vector3.Distance(Yandere.transform.position, Prompt.transform.position) < 2f)
				{
					if (!Suicide && !Concealed && !AddingToCount)
					{
						Yandere.NearestCorpseID = StudentID;
						Yandere.NearBodies++;
						AddingToCount = true;
					}
				}
				else if (AddingToCount)
				{
					Yandere.NearBodies--;
					AddingToCount = false;
				}
				if (!Prompt.AcceptingInput[1] && Input.GetButtonUp("B"))
				{
					Prompt.AcceptingInput[1] = true;
				}
				bool flag = false;
				if (Yandere.Armed && Yandere.EquippedWeapon.WeaponID == 7 && !Student.Nemesis)
				{
					Prompt.Label[0].text = "     Dismember";
					Cauterizable = false;
					Wrappable = false;
					flag = true;
				}
				if ((Yandere.PickUp != null && Yandere.PickUp.Blowtorch && !Cauterized) || (Yandere.PickUp != null && Yandere.PickUp.Tarp) || (Yandere.PickUp != null && Yandere.PickUp.GarbageBagBox && !Concealed))
				{
					flag = true;
				}
				Prompt.HideButton[0] = Dragged || Carried || Tranquil || Concealed || !flag;
			}
			else if (DumpType == RagdollDumpType.Incinerator)
			{
				if (DumpTimer == 0f && Yandere.Carrying)
				{
					Student.CharacterAnimation[DumpedAnim].time = 2.5f;
				}
				Student.CharacterAnimation.CrossFade(DumpedAnim);
				DumpTimer += Time.deltaTime;
				if (Student.CharacterAnimation[DumpedAnim].time >= Student.CharacterAnimation[DumpedAnim].length)
				{
					if (Concealed)
					{
						Incinerator.HiddenCorpses++;
						InsideIncinerator = true;
					}
					Incinerator.Corpses++;
					Incinerator.CorpseList[Incinerator.Corpses] = StudentID;
					Remove();
					base.enabled = false;
				}
			}
			else if (DumpType == RagdollDumpType.TranqCase)
			{
				if (DumpTimer == 0f && Yandere.Carrying)
				{
					Student.CharacterAnimation[DumpedAnim].time = 2.5f;
				}
				Student.CharacterAnimation.CrossFade(DumpedAnim);
				DumpTimer += Time.deltaTime;
				if (Student.CharacterAnimation[DumpedAnim].time >= Student.CharacterAnimation[DumpedAnim].length)
				{
					Student.Cosmetic.FemaleHair[Student.Cosmetic.Hairstyle].SetActive(false);
					TranqCase.Open = false;
					if (AddingToCount)
					{
						Yandere.NearBodies--;
					}
					base.enabled = false;
				}
			}
			else if (DumpType == RagdollDumpType.WoodChipper)
			{
				if (DumpTimer == 0f && Yandere.Carrying)
				{
					Student.CharacterAnimation[DumpedAnim].time = 2.5f;
				}
				Student.CharacterAnimation.CrossFade(DumpedAnim);
				DumpTimer += Time.deltaTime;
				if (Student.CharacterAnimation[DumpedAnim].time >= Student.CharacterAnimation[DumpedAnim].length)
				{
					WoodChipper = Yandere.WoodChipper;
					Debug.Log("Student #" + StudentID + " is now updating " + WoodChipper.gameObject.name + " with an ID number.");
					if (Concealed)
					{
						WoodChipper.HiddenCorpses++;
						InsideWoodchipper = true;
					}
					WoodChipper.VictimID = StudentID;
					Remove();
					base.enabled = false;
				}
			}
		}
		if (Hidden && HideCollider == null)
		{
			if (!Concealed)
			{
				Debug.Log("This is the exact moment a corpse was subtracted from the HiddenCorpses count. 2");
				Police.HiddenCorpses--;
			}
			Hidden = false;
		}
		if (Falling)
		{
			FallTimer += Time.deltaTime;
			if (FallTimer > 1.6f)
			{
				if (DroppedFromRooftop)
				{
					Debug.Log("A corpse that was dropped from the school rooftop just hit the ground.");
					SpawnAlarmDisc();
					DroppedFromRooftop = false;
				}
				BloodSpawnerCollider.enabled = true;
				FallTimer = 0f;
				Falling = false;
			}
		}
		if (Pushed && !StruckGround && !Hidden && SettleTimer > 1.5f)
		{
			Debug.Log("A student who was shoved from the school rooftop just hit the ground.");
			SpawnAlarmDisc();
			StruckGround = true;
		}
		if (Burning)
		{
			for (int m = 0; m < 3; m++)
			{
				Material obj2 = MyRenderer.materials[m];
				obj2.color = Vector4.MoveTowards(obj2.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
			}
			Student.Cosmetic.HairRenderer.material.color = Vector4.MoveTowards(Student.Cosmetic.HairRenderer.material.color, new Vector4(0.1f, 0.1f, 0.1f, 1f), Time.deltaTime * 0.1f);
			if (MyRenderer.materials[0].color == new Color(0.1f, 0.1f, 0.1f, 1f))
			{
				Burning = false;
				Burned = true;
			}
		}
		if (Burned)
		{
			Sacrifice = Vector3.Distance(Prompt.transform.position, Yandere.StudentManager.SacrificeSpot.position) < 1.5f;
		}
		if (Concealed && !AddedOutline && !ColoredOutline && Student.GarbageBag.activeInHierarchy)
		{
			RiggedAccessoryAttacher component = Student.GarbageBag.GetComponent<RiggedAccessoryAttacher>();
			if (component != null && component.newRenderer != null && component.newRenderer.gameObject.GetComponent<OutlineScript>() != null)
			{
				component.newRenderer.gameObject.GetComponent<OutlineScript>().color = new Color(1f, 0.5f, 0f);
				component.newRenderer.gameObject.GetComponent<OutlineScript>().enabled = true;
				AddedOutline = true;
				ColoredOutline = true;
			}
		}
	}

	private void LateUpdate()
	{
		if (!Male)
		{
			if (LeftEye != null)
			{
				LeftEye.localPosition = new Vector3(LeftEye.localPosition.x, LeftEye.localPosition.y, LeftEyeOrigin.z - EyeShrink * 0.01f);
				RightEye.localPosition = new Vector3(RightEye.localPosition.x, RightEye.localPosition.y, RightEyeOrigin.z + EyeShrink * 0.01f);
				LeftEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, LeftEye.localScale.z);
				RightEye.localScale = new Vector3(1f - EyeShrink * 0.5f, 1f - EyeShrink * 0.5f, RightEye.localScale.z);
			}
			if (StudentID == 81)
			{
				for (int i = 0; i < 4; i++)
				{
					Transform transform = Student.Skirt[i];
					transform.transform.localScale = new Vector3(transform.transform.localScale.x, 2f / 3f, transform.transform.localScale.z);
				}
			}
		}
		if (Decapitated)
		{
			Head.localScale = Vector3.zero;
		}
		if (!(Yandere != null) || !(Yandere.Ragdoll == base.gameObject))
		{
			return;
		}
		if (Yandere.DumpTimer < 1f)
		{
			if (Yandere.Lifting)
			{
				base.transform.position = Yandere.transform.position;
				base.transform.eulerAngles = Yandere.transform.eulerAngles;
			}
			else if (Carried)
			{
				base.transform.position = Yandere.transform.position;
				base.transform.eulerAngles = Yandere.transform.eulerAngles;
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				if (axis != 0f || axis2 != 0f)
				{
					Student.CharacterAnimation.CrossFade(Yandere.Running ? RunAnim : WalkAnim);
				}
				else
				{
					Student.CharacterAnimation.CrossFade(IdleAnim);
				}
				Student.CharacterAnimation[IdleAnim].time = Yandere.CharacterAnimation["f02_carryIdleA_00"].time;
				Student.CharacterAnimation[WalkAnim].time = Yandere.CharacterAnimation["f02_carryWalkA_00"].time;
				Student.CharacterAnimation[RunAnim].time = Yandere.CharacterAnimation["f02_carryRunA_00"].time;
			}
		}
		if (Carried)
		{
			if (Male)
			{
				Rigidbody rigidbody = AllRigidbodies[0];
				rigidbody.transform.parent.transform.localPosition = new Vector3(rigidbody.transform.parent.transform.localPosition.x, 0.2f, rigidbody.transform.parent.transform.localPosition.z);
			}
			if (Yandere.Struggling || Yandere.DelinquentFighting || Yandere.Sprayed || Yandere.Noticed)
			{
				Fall();
			}
		}
	}

	public void StopDragging()
	{
		Student.Prompt.enabled = false;
		Student.Prompt.Hide();
		Rigidbody[] allRigidbodies = Student.Ragdoll.AllRigidbodies;
		for (int i = 0; i < allRigidbodies.Length; i++)
		{
			allRigidbodies[i].drag = 0f;
		}
		if (!Tranquil)
		{
			Prompt.HideButton[3] = false;
		}
		Prompt.AcceptingInput[1] = true;
		Prompt.Circle[1].fillAmount = 1f;
		Prompt.Label[1].text = "     Drag";
		Yandere.RagdollDragger.connectedBody = null;
		Yandere.RagdollPK.connectedBody = null;
		Yandere.Dragging = false;
		Yandere.Ragdoll = null;
		Yandere.StudentManager.UpdateStudents();
		SettleTimer = 0f;
		Settled = false;
		Dragged = false;
	}

	private void PickNearestLimb()
	{
		if (Concealed)
		{
			LimbID = 3;
			return;
		}
		NearestLimb = Limb[0];
		LimbID = 0;
		for (int i = 1; i < 4; i++)
		{
			Transform transform = Limb[i];
			if (Vector3.Distance(transform.position, Yandere.transform.position) < Vector3.Distance(NearestLimb.position, Yandere.transform.position))
			{
				NearestLimb = transform;
				LimbID = i;
			}
		}
	}

	public void Dump()
	{
		if (DumpType == RagdollDumpType.Incinerator)
		{
			base.transform.eulerAngles = Yandere.transform.eulerAngles;
			base.transform.position = Yandere.transform.position;
			Incinerator = Yandere.Incinerator;
			BloodPoolSpawner.enabled = false;
		}
		else if (DumpType == RagdollDumpType.TranqCase)
		{
			TranqCase = Yandere.TranqCase;
		}
		else if (DumpType == RagdollDumpType.WoodChipper)
		{
			WoodChipper = Yandere.WoodChipper;
		}
		Prompt.Hide();
		Prompt.enabled = false;
		Dumped = true;
		Rigidbody[] allRigidbodies = AllRigidbodies;
		for (int i = 0; i < allRigidbodies.Length; i++)
		{
			allRigidbodies[i].isKinematic = true;
		}
	}

	public void Fall()
	{
		Student.Prompt.enabled = false;
		Student.Prompt.Hide();
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.0001f, base.transform.position.z);
		Prompt.Label[1].text = "     Drag";
		Prompt.HideButton[1] = false;
		Prompt.enabled = true;
		if (!Tranquil)
		{
			Prompt.HideButton[3] = false;
		}
		if (Dragged)
		{
			Yandere.RagdollDragger.connectedBody = null;
			Yandere.RagdollPK.connectedBody = null;
			Yandere.Dragging = false;
			Dragged = false;
		}
		Yandere.Ragdoll = null;
		Prompt.MyCollider.enabled = true;
		BloodPoolSpawner.NearbyBlood = 0;
		StopAnimation = true;
		SettleTimer = 0f;
		Carried = false;
		Settled = false;
		Falling = true;
		for (int i = 0; i < AllRigidbodies.Length; i++)
		{
			AllRigidbodies[i].isKinematic = false;
			AllColliders[i].enabled = true;
		}
		if (Student.Cosmetic.BurlapSack != null && Student.Cosmetic.BurlapSack.newRenderer != null)
		{
			Student.Cosmetic.BurlapSack.newRenderer.updateWhenOffscreen = true;
		}
	}

	public void QuickDismember()
	{
		Debug.Log("QuickDismember() was called.");
		for (int i = 0; i < BodyParts.Length; i++)
		{
			GameObject obj = Object.Instantiate(BodyParts[i], SpawnPoints[i].position, Quaternion.identity);
			obj.transform.eulerAngles = SpawnPoints[i].eulerAngles;
			obj.GetComponent<PromptScript>().enabled = false;
			obj.GetComponent<PickUpScript>().enabled = false;
			obj.GetComponent<OutlineScript>().enabled = false;
		}
		if (BloodPoolSpawner.BloodParent == null)
		{
			BloodPoolSpawner.Start();
		}
		if (!Student.StudentManager.NEStairs.bounds.Contains(BloodPoolSpawner.transform.position) && !Student.StudentManager.NWStairs.bounds.Contains(BloodPoolSpawner.transform.position) && !Student.StudentManager.SEStairs.bounds.Contains(BloodPoolSpawner.transform.position) && !Student.StudentManager.SWStairs.bounds.Contains(BloodPoolSpawner.transform.position))
		{
			BloodPoolSpawner.SpawnBigPool();
		}
		base.gameObject.SetActive(false);
	}

	public void Dismember()
	{
		Debug.Log("Dismembering a character.");
		if (Dismembered)
		{
			return;
		}
		if (!GameGlobals.Debug)
		{
			Debug.Log("Decapitations: " + PlayerPrefs.GetInt("HeadsHunted"));
			PlayerPrefs.SetInt("HeadsHunted", PlayerPrefs.GetInt("HeadsHunted") + 1);
			if (PlayerPrefs.GetInt("HeadsHunted") > 9)
			{
				Debug.Log("Headhunter Achievement should unlock now.");
				PlayerPrefs.SetInt("HeadHunter", 1);
				PlayerPrefs.SetInt("a", 1);
			}
		}
		Student.LiquidProjector.material.mainTexture = Student.BloodTexture;
		if (MyTarp == null)
		{
			for (int i = 0; i < BodyParts.Length; i++)
			{
				if (Decapitated)
				{
					i++;
					Decapitated = false;
				}
				GameObject gameObject = Object.Instantiate(BodyParts[i], SpawnPoints[i].position, Quaternion.identity);
				gameObject.transform.parent = Yandere.LimbParent;
				gameObject.transform.eulerAngles = SpawnPoints[i].eulerAngles;
				BodyPartScript component = gameObject.GetComponent<BodyPartScript>();
				component.StudentID = StudentID;
				component.Sacrifice = Sacrifice;
				if (Yandere.StudentManager.NoGravity)
				{
					gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
				switch (i)
				{
				case 0:
					if (!Student.OriginallyTeacher)
					{
						if (!Male)
						{
							Student.Cosmetic.FemaleHair[Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
							if (Student.Cosmetic.FemaleAccessories[Student.Cosmetic.Accessory] != null && Student.Cosmetic.Accessory != 3 && Student.Cosmetic.Accessory != 6 && Student.Cosmetic.Accessory != 9)
							{
								Student.Cosmetic.FemaleAccessories[Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
							}
						}
						else
						{
							Transform transform = Student.Cosmetic.MaleHair[Student.Cosmetic.Hairstyle].transform;
							transform.parent = gameObject.transform;
							transform.localScale *= 1.0638298f;
							if (transform.transform.localPosition.y < -1f)
							{
								transform.transform.localPosition = new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y - 0.095f, transform.transform.localPosition.z);
							}
							if (Student.Cosmetic.MaleAccessories[Student.Cosmetic.Accessory] != null)
							{
								Student.Cosmetic.MaleAccessories[Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
							}
						}
					}
					else
					{
						Student.Cosmetic.TeacherHair[Student.Cosmetic.Hairstyle].transform.parent = gameObject.transform;
						if (Student.Cosmetic.TeacherAccessories[Student.Cosmetic.Accessory] != null && Student.Cosmetic.Accessory != 7)
						{
							Student.Cosmetic.TeacherAccessories[Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
						}
					}
					if (Student.Club != ClubType.Photography && Student.Club < ClubType.Gaming && Student.Cosmetic.ClubAccessories[(int)Student.Club] != null)
					{
						Student.Cosmetic.ClubAccessories[(int)Student.Club].transform.parent = gameObject.transform;
						if (Student.Club == ClubType.Occult)
						{
							if (!Male)
							{
								Student.Cosmetic.ClubAccessories[(int)Student.Club].transform.localPosition = new Vector3(0f, -1.5f, 0.01f);
								Student.Cosmetic.ClubAccessories[(int)Student.Club].transform.localEulerAngles = Vector3.zero;
							}
							else
							{
								Student.Cosmetic.ClubAccessories[(int)Student.Club].transform.localPosition = new Vector3(0f, -1.42f, 0.005f);
								Student.Cosmetic.ClubAccessories[(int)Student.Club].transform.localEulerAngles = Vector3.zero;
							}
						}
					}
					gameObject.GetComponent<Renderer>().materials[0].mainTexture = Student.Cosmetic.FaceTexture;
					gameObject.transform.position += new Vector3(0f, 1f, 0f);
					if (!Student.StudentManager.NEStairs.bounds.Contains(BloodPoolSpawner.transform.position) && !Student.StudentManager.NWStairs.bounds.Contains(BloodPoolSpawner.transform.position) && !Student.StudentManager.SEStairs.bounds.Contains(BloodPoolSpawner.transform.position) && !Student.StudentManager.SWStairs.bounds.Contains(BloodPoolSpawner.transform.position))
					{
						BloodPoolSpawner.SpawnBigPool();
						if (BloodPoolSpawner.BloodParent == null)
						{
							BloodPoolSpawner.Start();
						}
					}
					break;
				case 1:
					if (Student.Club == ClubType.Photography && Student.Cosmetic.ClubAccessories[(int)Student.Club] != null)
					{
						Student.Cosmetic.ClubAccessories[(int)Student.Club].transform.parent = gameObject.transform;
					}
					break;
				case 2:
					if (!Student.Male && Student.Cosmetic.Accessory == 6)
					{
						Student.Cosmetic.FemaleAccessories[Student.Cosmetic.Accessory].transform.parent = gameObject.transform;
					}
					break;
				}
			}
		}
		else
		{
			for (int j = 0; j < 6; j++)
			{
				GameObject gameObject2 = Object.Instantiate(TarpBag, Student.Hips.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
				switch (j)
				{
				case 0:
					gameObject2.transform.position = Student.Hips.position + new Vector3(0f, 0.5f, 0f);
					break;
				case 1:
					gameObject2.transform.position = Student.Hips.position + new Vector3(0.5f, 0.5f, 0f);
					break;
				case 2:
					gameObject2.transform.position = Student.Hips.position + new Vector3(-0.5f, 0.5f, 0f);
					break;
				case 3:
					gameObject2.transform.position = Student.Hips.position + new Vector3(0f, 0.5f, 0.5f);
					break;
				case 4:
					gameObject2.transform.position = Student.Hips.position + new Vector3(0f, 0.5f, -0.5f);
					break;
				case 5:
					gameObject2.transform.position = Student.Hips.position + new Vector3(0.5f, 0.5f, 0.5f);
					break;
				}
				gameObject2.GetComponent<BodyPartScript>().StudentID = StudentID;
				gameObject2.transform.parent = Prompt.Yandere.Police.GarbageParent;
				Student.StudentManager.GarbageBagList[Student.StudentManager.GarbageBags] = gameObject2;
				Student.StudentManager.GarbageBags++;
			}
		}
		if (Police == null)
		{
			Police = Yandere.Police;
		}
		Police.PartsIcon.gameObject.SetActive(true);
		Police.BodyParts += 6;
		Yandere.NearBodies--;
		Police.Corpses--;
		base.transform.parent = Student.StudentManager.DisabledObjectParent;
		base.gameObject.SetActive(false);
		Dismembered = true;
		if (MyTarp != null)
		{
			Object.Destroy(MyTarp);
		}
	}

	public void Remove()
	{
		Debug.Log("The Remove() function has been called on " + Student.Name + "'s RagdollScript.");
		Student.Removed = true;
		BloodPoolSpawner.enabled = false;
		if (AddingToCount)
		{
			Yandere.NearBodies--;
		}
		if (Poisoned)
		{
			Police.PoisonScene = false;
		}
		if (Concealed && !InsideIncinerator && !InsideWoodchipper)
		{
			Debug.Log("This is the exact moment a corpse was subtracted from the HiddenCorpses count. 1");
			Police.HiddenCorpses--;
		}
		base.gameObject.SetActive(false);
	}

	public void DestroyRigidbodies()
	{
		BloodPoolSpawner.gameObject.SetActive(false);
		for (int i = 0; i < AllRigidbodies.Length; i++)
		{
			if (AllRigidbodies[i].gameObject.GetComponent<CharacterJoint>() != null)
			{
				Object.Destroy(AllRigidbodies[i].gameObject.GetComponent<CharacterJoint>());
			}
			Object.Destroy(AllRigidbodies[i]);
			AllColliders[i].enabled = false;
		}
		Prompt.Hide();
		Prompt.enabled = false;
		base.enabled = false;
	}

	public void DisableRigidbodies()
	{
		for (int i = 0; i < AllRigidbodies.Length; i++)
		{
			AllRigidbodies[i].isKinematic = true;
			AllColliders[i].enabled = false;
		}
		RigidbodiesManuallyDisabled = true;
		StopAnimation = true;
	}

	public void EnableRigidbodies()
	{
		for (int i = 0; i < AllRigidbodies.Length; i++)
		{
			AllRigidbodies[i].isKinematic = false;
			AllColliders[i].enabled = true;
			AllRigidbodies[i].useGravity = !Yandere.StudentManager.NoGravity;
		}
		RigidbodiesManuallyDisabled = false;
		StopAnimation = false;
	}

	public void HideAccessories()
	{
		Student.Cosmetic.RightStockings[0].SetActive(false);
		Student.Cosmetic.LeftStockings[0].SetActive(false);
		Student.Cosmetic.RightWristband.SetActive(false);
		Student.Cosmetic.LeftWristband.SetActive(false);
		Student.Cosmetic.Bookbag.SetActive(false);
		Student.Cosmetic.Hoodie.SetActive(false);
	}

	public void ConcealInTrashBag()
	{
		Prompt.Label[0].text = "     Dismember";
		Student.StudentManager.Police.HiddenCorpses++;
		Concealed = true;
		Wrappable = false;
		if (AddingToCount)
		{
			Yandere.NearBodies--;
			AddingToCount = false;
		}
		Student.MyRenderer.enabled = false;
		if (Student.Cosmetic.HairRenderer != null)
		{
			Student.Cosmetic.HairRenderer.gameObject.SetActive(false);
		}
		else if (Student.Nemesis)
		{
			Student.gameObject.GetComponent<NemesisScript>().NemesisHair.SetActive(false);
		}
		Student.GarbageBag.SetActive(true);
		if (!Student.Male)
		{
			Student.InstrumentBag[1].SetActive(false);
			Student.InstrumentBag[2].SetActive(false);
			Student.InstrumentBag[3].SetActive(false);
			Student.InstrumentBag[4].SetActive(false);
			Student.InstrumentBag[5].SetActive(false);
			HideAccessories();
		}
		if (Student.ApronAttacher.enabled)
		{
			Student.ApronAttacher.newRenderer.enabled = false;
		}
		if (Student.Attacher.enabled && Student.Attacher.newRenderer != null)
		{
			Student.Attacher.newRenderer.enabled = false;
		}
		if (Student.LabcoatAttacher.enabled)
		{
			Student.LabcoatAttacher.newRenderer.enabled = false;
		}
		Student.Armband.SetActive(false);
		BloodPoolSpawner.enabled = false;
		if (Yandere.PickUp != null)
		{
			Yandere.PickUp.GetComponent<AudioSource>().Play();
			Yandere.MurderousActionTimer = 1f;
		}
		if (Student.BikiniAttacher != null && Student.BikiniAttacher.newRenderer != null)
		{
			Student.BikiniAttacher.newRenderer.enabled = false;
		}
		if ((bool)Student.Cosmetic)
		{
			Student.Cosmetic.DisableAccessories();
		}
		if (Student.EightiesTeacherAttacher != null && Student.EightiesTeacherAttacher.activeInHierarchy)
		{
			Student.EightiesTeacherAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.enabled = false;
		}
		if (Student.Cosmetic.BurlapSack != null && Student.Cosmetic.BurlapSack.newRenderer != null)
		{
			Student.Cosmetic.BurlapSack.newRenderer.enabled = false;
		}
		Student.SpeechLines.Stop();
		Student.DisableProps();
		if (Student.Male)
		{
			Student.DisableMaleProps();
		}
		else
		{
			Student.DisableFemaleProps();
		}
		if (!Student.Male)
		{
			Student.Cosmetic.DisableFingernails();
		}
	}

	private void SpawnAlarmDisc()
	{
		Object.Instantiate(Student.AlarmDisc, new Vector3(Student.Hips.position.x, 1f, Student.Hips.position.z), Quaternion.identity).transform.localScale = new Vector3(1000f, 1f, 1000f);
	}
}
