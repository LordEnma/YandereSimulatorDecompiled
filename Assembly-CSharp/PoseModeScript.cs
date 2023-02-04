using UnityEngine;

public class PoseModeScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public ParticleSystem Marker;

	public StudentScript Student;

	public YandereScript Yandere;

	public UIPanel Panel;

	public UILabel[] OptionLabels;

	public UILabel HeaderLabel;

	public Transform Highlight;

	public Transform Bone;

	public GameObject Warning;

	public Camera PoseModeCamera;

	public bool ChoosingBodyRegion;

	public bool ChoosingAction = true;

	public bool ChoosingBone = true;

	public bool SavingLoading;

	public bool Customizing;

	public bool EditingFace;

	public bool Animating;

	public bool Placing;

	public bool Posing;

	public bool Show;

	public int SaveSlot = 1;

	public int Selected = 1;

	public int Region = 1;

	public int AnimID = 1;

	public int Degree = 1;

	public int Offset;

	public int Limit;

	public int Value;

	public string[] StockingNames;

	public int StockingID;

	public string[] AnimationArray;

	private void Start()
	{
		PoseModeCamera.gameObject.SetActive(value: false);
		base.transform.localScale = Vector3.zero;
		Panel.enabled = false;
	}

	private void Update()
	{
		if (Show)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (InputManager.TappedUp)
			{
				Selected--;
				UpdateHighlight();
			}
			else if (InputManager.TappedDown)
			{
				Selected++;
				UpdateHighlight();
			}
			if (ChoosingAction)
			{
				if (Input.GetButtonDown("A") && OptionLabels[Selected].color.a == 1f)
				{
					ChoosingAction = false;
					if (Selected == 1)
					{
						ChoosingBodyRegion = true;
						UpdateLabels();
					}
					else if (Selected == 2)
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Place";
						PromptBar.Label[1].text = "Cancel";
						PromptBar.UpdateButtons();
						ParticleSystem.EmissionModule emission = Marker.emission;
						emission.enabled = true;
						Marker.Play();
						Yandere.CanMove = true;
						ChoosingAction = true;
						Placing = true;
						Show = false;
						Selected = 1;
						UpdateHighlight();
					}
					else if (Selected == 3)
					{
						Customizing = true;
						UpdateLabels();
						Selected = 1;
						UpdateHighlight();
					}
					else if (Selected == 4)
					{
						PromptBar.Label[2].text = "Page Down";
						PromptBar.Label[3].text = "Page Up";
						PromptBar.UpdateButtons();
						CreateAnimationArray();
						Animating = true;
						UpdateLabels();
						Selected = 1;
						UpdateHighlight();
					}
					else if (Selected == 5)
					{
						Student.CharacterAnimation.Stop();
						ChoosingAction = true;
					}
					else if (Selected == 6)
					{
						PoseModeCamera.gameObject.SetActive(value: true);
						PoseModeCamera.transform.parent = Student.Head;
						PoseModeCamera.transform.localPosition = new Vector3(0f, 0f, 0.5f);
						PoseModeCamera.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						PromptBar.Label[2].text = "Set to 0";
						PromptBar.Label[3].text = "Set to 100";
						PromptBar.UpdateButtons();
						EditingFace = true;
						UpdateLabels();
						Selected = 1;
						UpdateHighlight();
					}
					else if (Selected == 7)
					{
						SavingLoading = true;
						UpdateLabels();
						Selected = 1;
						UpdateHighlight();
					}
					else if (Selected == 8)
					{
						Student.MyController.enabled = true;
						Student.Pathfinding.canSearch = true;
						Student.Pathfinding.canMove = true;
						Student.Posing = false;
						Student.Stop = false;
						Exit();
					}
					else if (Selected == 9)
					{
						ChoosingAction = true;
						for (int i = 1; i < 100; i++)
						{
							if (Student.StudentManager.Students[i] != null)
							{
								Student.StudentManager.Students[i].Pathfinding.canSearch = false;
								Student.StudentManager.Students[i].Pathfinding.canMove = false;
								Student.StudentManager.Students[i].MyController.enabled = false;
								Student.StudentManager.Students[i].Posing = true;
								Student.StudentManager.Students[i].Stop = true;
							}
						}
					}
				}
				if (Input.GetButtonDown("B"))
				{
					Exit();
				}
			}
			else if (ChoosingBodyRegion)
			{
				if (Input.GetButtonDown("A") && OptionLabels[Selected].color.a == 1f)
				{
					ChoosingBodyRegion = false;
					if (Selected == 1)
					{
						Bone = Student.transform;
						RememberPose();
						Posing = true;
						UpdateLabels();
					}
					else
					{
						ChoosingBone = true;
						Region = Selected;
						UpdateLabels();
						Selected = 1;
						UpdateHighlight();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					ChoosingBodyRegion = false;
					ChoosingAction = true;
					Region = 1;
					UpdateLabels();
					Selected = 1;
					UpdateHighlight();
				}
			}
			else if (ChoosingBone)
			{
				if (Input.GetButtonDown("A"))
				{
					ChoosingBone = false;
					Posing = true;
					if (Region == 2)
					{
						Bone = Student.BoneSets.BoneSet1[Selected];
					}
					else if (Region == 3)
					{
						Bone = Student.BoneSets.BoneSet2[Selected];
					}
					else if (Region == 4)
					{
						Bone = Student.BoneSets.BoneSet3[Selected];
					}
					else if (Region == 5)
					{
						Bone = Student.BoneSets.BoneSet4[Selected];
					}
					else if (Region == 6)
					{
						Bone = Student.BoneSets.BoneSet5[Selected];
					}
					else if (Region == 7)
					{
						Bone = Student.BoneSets.BoneSet6[Selected];
					}
					else if (Region == 8)
					{
						Bone = Student.BoneSets.BoneSet7[Selected];
					}
					else if (Region == 9)
					{
						Bone = Student.BoneSets.BoneSet8[Selected];
					}
					else if (Region == 10)
					{
						Bone = Student.BoneSets.BoneSet9[Selected];
					}
					RememberPose();
					UpdateLabels();
				}
				if (Input.GetButtonDown("B"))
				{
					ChoosingBodyRegion = true;
					ChoosingBone = false;
					Region = 1;
					UpdateLabels();
					Selected = 1;
					UpdateHighlight();
				}
			}
			else if (Posing)
			{
				if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
				{
					CalculateValue();
					if (Selected == 1)
					{
						Bone.localPosition = new Vector3(Bone.localPosition.x + Time.deltaTime * (float)Value * (float)Degree * 0.1f, Bone.localPosition.y, Bone.localPosition.z);
					}
					else if (Selected == 2)
					{
						Bone.localPosition = new Vector3(Bone.localPosition.x, Bone.localPosition.y + Time.deltaTime * (float)Value * (float)Degree * 0.1f, Bone.localPosition.z);
					}
					else if (Selected == 3)
					{
						Bone.localPosition = new Vector3(Bone.localPosition.x, Bone.localPosition.y, Bone.localPosition.z + Time.deltaTime * (float)Value * (float)Degree * 0.1f);
					}
					else if (Selected == 4)
					{
						Bone.Rotate(Vector3.right * (Time.deltaTime * (float)Value * (float)Degree * 36f));
					}
					else if (Selected == 5)
					{
						Bone.Rotate(Vector3.up * (Time.deltaTime * (float)Value * (float)Degree * 36f));
					}
					else if (Selected == 6)
					{
						Bone.Rotate(Vector3.forward * (Time.deltaTime * (float)Value * (float)Degree * 36f));
					}
					else if (Selected == 7)
					{
						Bone.localScale = new Vector3(Bone.localScale.x + Time.deltaTime * (float)Value * (float)Degree * 0.1f, Bone.localScale.y, Bone.localScale.z);
					}
					else if (Selected == 8)
					{
						Bone.localScale = new Vector3(Bone.localScale.x, Bone.localScale.y + Time.deltaTime * (float)Value * (float)Degree * 0.1f, Bone.localScale.z);
					}
					else if (Selected == 9)
					{
						Bone.localScale = new Vector3(Bone.localScale.x, Bone.localScale.y, Bone.localScale.z + Time.deltaTime * (float)Value * (float)Degree * 0.1f);
					}
				}
				if (Selected == 10)
				{
					if (InputManager.TappedRight)
					{
						if (Degree < 10)
						{
							Degree++;
						}
						UpdateLabels();
					}
					else if (InputManager.TappedLeft)
					{
						if (Degree > 1)
						{
							Degree--;
						}
						UpdateLabels();
					}
				}
				else if (Selected == 11 && Input.GetButtonDown("A"))
				{
					ResetPose();
				}
				if (Input.GetButtonDown("B"))
				{
					if (Region == 1)
					{
						ChoosingBodyRegion = true;
					}
					else
					{
						ChoosingBone = true;
					}
					Posing = false;
					UpdateLabels();
					Selected = 1;
					UpdateHighlight();
				}
			}
			else if (Customizing)
			{
				if (Selected == 1)
				{
					if (InputManager.TappedRight)
					{
						Student.Cosmetic.Direction = 1;
						Student.Cosmetic.Hairstyle++;
						if (!Student.Male)
						{
							if (!Student.Teacher)
							{
								if (Student.Cosmetic.Hairstyle == Student.Cosmetic.FemaleHair.Length)
								{
									Student.Cosmetic.Hairstyle = 1;
								}
							}
							else if (Student.Cosmetic.Hairstyle == Student.Cosmetic.TeacherHair.Length)
							{
								Student.Cosmetic.Hairstyle = 1;
							}
						}
						else if (Student.Cosmetic.Hairstyle == Student.Cosmetic.MaleHair.Length)
						{
							Student.Cosmetic.Hairstyle = 1;
						}
						Student.Cosmetic.Start();
						UpdateLabels();
					}
					if (InputManager.TappedLeft)
					{
						Student.Cosmetic.Direction = -1;
						Student.Cosmetic.Hairstyle--;
						if (Student.Cosmetic.Hairstyle == 0)
						{
							if (!Student.Male)
							{
								if (!Student.Teacher)
								{
									Student.Cosmetic.Hairstyle = Student.Cosmetic.FemaleHair.Length - 1;
								}
								else
								{
									Student.Cosmetic.Hairstyle = Student.Cosmetic.TeacherHair.Length - 1;
								}
							}
							else
							{
								Student.Cosmetic.Hairstyle = Student.Cosmetic.MaleHair.Length - 1;
							}
						}
						Student.Cosmetic.Start();
						UpdateLabels();
					}
				}
				else if (Selected == 2)
				{
					if (InputManager.TappedRight)
					{
						Student.Cosmetic.Accessory++;
						if (!Student.Male)
						{
							if (Student.Cosmetic.Accessory == Student.Cosmetic.FemaleAccessories.Length)
							{
								Student.Cosmetic.Accessory = 0;
							}
						}
						else if (Student.Cosmetic.Accessory == Student.Cosmetic.MaleAccessories.Length)
						{
							Student.Cosmetic.Accessory = 0;
						}
						Student.Cosmetic.Start();
						UpdateLabels();
					}
					if (InputManager.TappedLeft)
					{
						Student.Cosmetic.Accessory--;
						if (Student.Cosmetic.Accessory < 0)
						{
							Student.Cosmetic.Accessory = (Student.Male ? (Student.Cosmetic.MaleAccessories.Length - 1) : (Student.Cosmetic.FemaleAccessories.Length - 1));
						}
						Student.Cosmetic.Start();
						UpdateLabels();
					}
				}
				else if (Selected == 3)
				{
					if (InputManager.TappedRight)
					{
						Student.Schoolwear++;
						if (Student.Schoolwear > 3)
						{
							Student.Schoolwear = 1;
						}
						Student.ChangeSchoolwear();
						UpdateLabels();
					}
					if (InputManager.TappedLeft)
					{
						Student.Schoolwear--;
						if (Student.Schoolwear < 1)
						{
							Student.Schoolwear = 3;
						}
						Student.ChangeSchoolwear();
						UpdateLabels();
					}
				}
				else if (Selected == 10)
				{
					if (InputManager.TappedRight)
					{
						if (Degree < 10)
						{
							Degree++;
						}
						UpdateLabels();
					}
					else if (InputManager.TappedLeft)
					{
						if (Degree > 1)
						{
							Degree--;
						}
						UpdateLabels();
					}
				}
				else if (Selected == 11)
				{
					if (!Student.Male)
					{
						if (InputManager.TappedRight)
						{
							StockingID++;
							if (StockingID == StockingNames.Length)
							{
								StockingID = 0;
							}
							Student.Cosmetic.Stockings = StockingNames[StockingID];
							StartCoroutine(Student.Cosmetic.PutOnStockings());
							UpdateLabels();
						}
						else if (InputManager.TappedLeft)
						{
							StockingID--;
							if (StockingID < 0)
							{
								StockingID = StockingNames.Length - 1;
							}
							Student.Cosmetic.Stockings = StockingNames[StockingID];
							StartCoroutine(Student.Cosmetic.PutOnStockings());
							UpdateLabels();
						}
					}
				}
				else if (Selected == 12)
				{
					if (InputManager.TappedRight || InputManager.TappedLeft)
					{
						Student.LiquidProjector.material.mainTexture = Student.BloodTexture;
						Student.LiquidProjector.enabled = !Student.LiquidProjector.enabled;
						Student.LiquidProjector.gameObject.SetActive(Student.LiquidProjector.enabled);
						UpdateLabels();
					}
				}
				else if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
				{
					CalculateValue();
					Material material = Student.Cosmetic.HairRenderer.material;
					Material material2 = Student.Cosmetic.RightEyeRenderer.material;
					if (Selected == 4)
					{
						material.color = new Color(material.color.r + (float)Degree * 0.003921569f * (float)Value, material.color.g, material.color.b, material.color.a);
					}
					else if (Selected == 5)
					{
						material.color = new Color(material.color.r, material.color.g + (float)Degree * 0.003921569f * (float)Value, material.color.b, material.color.a);
					}
					else if (Selected == 6)
					{
						material.color = new Color(material.color.r, material.color.g, material.color.b + (float)Degree * 0.003921569f * (float)Value, material.color.a);
					}
					else if (Selected == 7)
					{
						material2.color = new Color(material2.color.r + (float)Degree * 0.003921569f * (float)Value, material2.color.g, material2.color.b, material2.color.a);
					}
					else if (Selected == 8)
					{
						material2.color = new Color(material2.color.r, material2.color.g + (float)Degree * 0.003921569f * (float)Value, material2.color.b, material2.color.a);
					}
					else if (Selected == 9)
					{
						material2.color = new Color(material2.color.r, material2.color.g, material2.color.b + (float)Degree * 0.003921569f * (float)Value, material2.color.a);
					}
					CapColors();
					UpdateLabels();
				}
				if (Input.GetButtonDown("B"))
				{
					ChoosingAction = true;
					Customizing = false;
					UpdateLabels();
					Selected = 1;
					UpdateHighlight();
				}
			}
			else if (Animating)
			{
				if (Input.GetButtonDown("X"))
				{
					Offset += 16;
					UpdateHighlight();
				}
				if (Input.GetButtonDown("Y"))
				{
					Offset -= 16;
					UpdateHighlight();
				}
				if (Input.GetButtonDown("A"))
				{
					Student.CharacterAnimation.Stop();
					Student.CharacterAnimation.CrossFade(AnimationArray[Selected + Offset]);
				}
				if (Input.GetButtonDown("B"))
				{
					PromptBar.Label[2].text = string.Empty;
					PromptBar.Label[3].text = string.Empty;
					PromptBar.UpdateButtons();
					ChoosingAction = true;
					Animating = false;
					UpdateLabels();
					Selected = 1;
					UpdateHighlight();
				}
			}
			else if (EditingFace)
			{
				if (Selected == 18)
				{
					if (InputManager.TappedRight)
					{
						if (Degree < 10)
						{
							Degree++;
						}
						UpdateLabels();
					}
					else if (InputManager.TappedLeft)
					{
						if (Degree > 1)
						{
							Degree--;
						}
						UpdateLabels();
					}
				}
				else
				{
					if (InputManager.TappedRight)
					{
						Student.MyRenderer.SetBlendShapeWeight(Selected - 1, Student.MyRenderer.GetBlendShapeWeight(Selected - 1) + (float)Degree);
						if (Student.MyRenderer.GetBlendShapeWeight(Selected - 1) > 100f)
						{
							Student.MyRenderer.SetBlendShapeWeight(Selected - 1, 100f);
						}
						UpdateLabels();
					}
					else if (InputManager.TappedLeft)
					{
						Student.MyRenderer.SetBlendShapeWeight(Selected - 1, Student.MyRenderer.GetBlendShapeWeight(Selected - 1) - (float)Degree);
						if (Student.MyRenderer.GetBlendShapeWeight(Selected - 1) < 0f)
						{
							Student.MyRenderer.SetBlendShapeWeight(Selected - 1, 0f);
						}
						UpdateLabels();
					}
					if (Input.GetButtonDown("X"))
					{
						Student.MyRenderer.SetBlendShapeWeight(Selected - 1, 0f);
						UpdateLabels();
					}
					if (Input.GetButtonDown("Y"))
					{
						Student.MyRenderer.SetBlendShapeWeight(Selected - 1, 100f);
						UpdateLabels();
					}
				}
				if (Input.GetButtonDown("B"))
				{
					PromptBar.Label[2].text = string.Empty;
					PromptBar.Label[3].text = string.Empty;
					PromptBar.UpdateButtons();
					PoseModeCamera.gameObject.SetActive(value: false);
					ChoosingAction = true;
					EditingFace = false;
					UpdateLabels();
					Selected = 1;
					UpdateHighlight();
				}
			}
			else
			{
				if (!SavingLoading)
				{
					return;
				}
				if (Selected == 1)
				{
					if (InputManager.TappedRight)
					{
						SaveSlot++;
						UpdateLabels();
					}
					else if (InputManager.TappedLeft)
					{
						if (SaveSlot > 1)
						{
							SaveSlot--;
						}
						UpdateLabels();
					}
				}
				if (Input.GetButtonDown("A"))
				{
					if (Selected == 2)
					{
						PoseSerializer.SerializePose(Student.Cosmetic, Student.transform, SaveSlot.ToString() ?? "");
						Yandere.NotificationManager.CustomText = "Pose Saved!";
						Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else if (Selected == 3)
					{
						Debug.Log("Our intention is to change the Cosmetic data for: " + Student.Name);
						PoseSerializer.DeserializePose(Student.Cosmetic, Student.transform, SaveSlot.ToString() ?? "");
					}
				}
				if (Input.GetButtonDown("B"))
				{
					PromptBar.Label[2].text = string.Empty;
					PromptBar.Label[3].text = string.Empty;
					PromptBar.UpdateButtons();
					PoseModeCamera.gameObject.SetActive(value: false);
					ChoosingAction = true;
					SavingLoading = false;
					UpdateLabels();
					Selected = 1;
					UpdateHighlight();
				}
			}
			return;
		}
		if (base.transform.localScale.x > 0.1f)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (Panel.enabled)
		{
			base.transform.localScale = Vector3.zero;
			Panel.enabled = false;
		}
		if (Placing && (Input.GetButtonDown("A") || Input.GetButtonDown("B")))
		{
			if (Input.GetButtonDown("A"))
			{
				Student.transform.position = Marker.transform.position;
			}
			ParticleSystem.EmissionModule emission2 = Marker.emission;
			emission2.enabled = false;
			Placing = false;
			PromptBar.ClearButtons();
			PromptBar.Show = false;
		}
	}

	private void UpdateHighlight()
	{
		if (!Animating)
		{
			if (Selected > Limit)
			{
				Selected = 1;
			}
			else if (Selected < 1)
			{
				Selected = Limit;
			}
		}
		else
		{
			if (Selected > Limit)
			{
				Selected = Limit;
				Offset++;
			}
			else if (Selected < 1)
			{
				Selected = 1;
				Offset--;
			}
			if (Offset < 0)
			{
				Offset = AnimID - Limit;
				Selected = Limit;
			}
			else if (Offset > AnimID - Limit)
			{
				Offset = 0;
				Selected = 1;
			}
			UpdateLabels();
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 400f - (float)Selected * 50f, Highlight.localPosition.z);
	}

	public void UpdateLabels()
	{
		for (int i = 1; i < OptionLabels.Length; i++)
		{
			UILabel uILabel = OptionLabels[i];
			uILabel.color = new Color(uILabel.color.r, uILabel.color.g, uILabel.color.b, 1f);
			uILabel.text = string.Empty;
		}
		Warning.SetActive(value: false);
		if (ChoosingAction)
		{
			Warning.SetActive(value: true);
			HeaderLabel.text = "Choose Action";
			OptionLabels[1].text = "Pose";
			OptionLabels[2].text = "Re-Position";
			OptionLabels[3].text = "Customize Appearance";
			OptionLabels[4].text = "Perform Animation";
			OptionLabels[5].text = "Stop Animation";
			OptionLabels[6].text = "Edit Face";
			OptionLabels[7].text = "Save/Load Pose";
			OptionLabels[8].text = "Release Student";
			OptionLabels[9].text = "Freeze All Students";
			Limit = 9;
			if (Student.Male)
			{
				OptionLabels[6].color = new Color(1f, 1f, 1f, 0.5f);
			}
		}
		else if (ChoosingBodyRegion)
		{
			HeaderLabel.text = "Choose Body Region";
			OptionLabels[1].text = "Root";
			OptionLabels[2].text = "Spine";
			OptionLabels[3].text = "Right Leg";
			OptionLabels[4].text = "Left Leg";
			OptionLabels[5].text = "Right Arm";
			OptionLabels[6].text = "Left Arm";
			OptionLabels[7].text = "Right Fingers";
			OptionLabels[8].text = "Left Fingers";
			OptionLabels[9].text = "Face";
			OptionLabels[10].text = "Female Only";
			Limit = 10;
			UILabel uILabel2 = OptionLabels[10];
			uILabel2.color = new Color(uILabel2.color.r, uILabel2.color.g, uILabel2.color.b, Student.Male ? 0.5f : 1f);
		}
		else if (ChoosingBone)
		{
			HeaderLabel.text = "Choose Bone";
			if (Region == 2)
			{
				OptionLabels[1].text = "Hips";
				OptionLabels[2].text = "Spine 1";
				OptionLabels[3].text = "Spine 2";
				OptionLabels[4].text = "Spine 3";
				OptionLabels[5].text = "Spine 4";
				OptionLabels[6].text = "Neck";
				OptionLabels[7].text = "Head";
				Limit = 7;
			}
			else if (Region == 3)
			{
				OptionLabels[1].text = "Right Leg";
				OptionLabels[2].text = "Right Knee";
				OptionLabels[3].text = "Right Foot";
				OptionLabels[4].text = "Right Toe";
				Limit = 4;
			}
			else if (Region == 4)
			{
				OptionLabels[1].text = "Left Leg";
				OptionLabels[2].text = "Left Knee";
				OptionLabels[3].text = "Left Foot";
				OptionLabels[4].text = "Left Toe";
				Limit = 4;
			}
			else if (Region == 5)
			{
				OptionLabels[1].text = "Right Clavicle";
				OptionLabels[2].text = "Right Arm";
				OptionLabels[3].text = "Right Elbow";
				OptionLabels[4].text = "Right Wrist";
				Limit = 4;
			}
			else if (Region == 6)
			{
				OptionLabels[1].text = "Left Clavicle";
				OptionLabels[2].text = "Left Arm";
				OptionLabels[3].text = "Left Elbow";
				OptionLabels[4].text = "Left Wrist";
				Limit = 4;
			}
			else if (Region == 7)
			{
				OptionLabels[1].text = "Right Pinky 1";
				OptionLabels[2].text = "Right Pinky 2";
				OptionLabels[3].text = "Right Pinky 3";
				OptionLabels[4].text = "Right Ring 1";
				OptionLabels[5].text = "Right Ring 2";
				OptionLabels[6].text = "Right Ring 3";
				OptionLabels[7].text = "Right Middle 1";
				OptionLabels[8].text = "Right Middle 2";
				OptionLabels[9].text = "Right Middle 3";
				OptionLabels[10].text = "Right Index 1";
				OptionLabels[11].text = "Right Index 2";
				OptionLabels[12].text = "Right Index 3";
				OptionLabels[13].text = "Right Thumb 1";
				OptionLabels[14].text = "Right Thumb 2";
				OptionLabels[15].text = "Right Thumb 3";
				Limit = 15;
			}
			else if (Region == 8)
			{
				OptionLabels[1].text = "Left Pinky 1";
				OptionLabels[2].text = "Left Pinky 2";
				OptionLabels[3].text = "Left Pinky 3";
				OptionLabels[4].text = "Left Ring 1";
				OptionLabels[5].text = "Left Ring 2";
				OptionLabels[6].text = "Left Ring 3";
				OptionLabels[7].text = "Left Middle 1";
				OptionLabels[8].text = "Left Middle 2";
				OptionLabels[9].text = "Left Middle 3";
				OptionLabels[10].text = "Left Index 1";
				OptionLabels[11].text = "Left Index 2";
				OptionLabels[12].text = "Left Index 3";
				OptionLabels[13].text = "Left Thumb 1";
				OptionLabels[14].text = "Left Thumb 2";
				OptionLabels[15].text = "Left Thumb 3";
				Limit = 15;
			}
			else if (Region == 9)
			{
				OptionLabels[1].text = "Right Eye";
				OptionLabels[2].text = "Left Eye";
				OptionLabels[3].text = "Right Eyebrow";
				OptionLabels[4].text = "Left Eyebrow";
				OptionLabels[5].text = "Jaw";
				Limit = 5;
			}
			else if (Region == 10)
			{
				OptionLabels[1].text = "Front Skirt 1";
				OptionLabels[2].text = "Front Skirt 2";
				OptionLabels[3].text = "Front Skirt 3";
				OptionLabels[4].text = "Back Skirt 1";
				OptionLabels[5].text = "Back Skirt 2";
				OptionLabels[6].text = "Back Skirt 3";
				OptionLabels[7].text = "Right Skirt 1";
				OptionLabels[8].text = "Right Skirt 2";
				OptionLabels[9].text = "Right Skirt 3";
				OptionLabels[10].text = "Left Skirt 1";
				OptionLabels[11].text = "Left Skirt 2";
				OptionLabels[12].text = "Left Skirt 3";
				OptionLabels[13].text = "Right Breast";
				OptionLabels[14].text = "Right Nipple";
				OptionLabels[15].text = "Left Breast";
				OptionLabels[16].text = "Left Nipple";
				Limit = 16;
			}
		}
		else if (Posing)
		{
			HeaderLabel.text = "Pose Bone";
			OptionLabels[1].text = "Position X";
			OptionLabels[2].text = "Position Y";
			OptionLabels[3].text = "Position Z";
			OptionLabels[4].text = "Rotation X";
			OptionLabels[5].text = "Rotation Y";
			OptionLabels[6].text = "Rotation Z";
			OptionLabels[7].text = "Scale X";
			OptionLabels[8].text = "Scale Y";
			OptionLabels[9].text = "Scale Z";
			OptionLabels[10].text = "Degree of Change: " + Degree;
			OptionLabels[11].text = "Reset";
			Limit = 11;
		}
		else if (Customizing)
		{
			HeaderLabel.text = "Customize";
			OptionLabels[1].text = "Hairstyle: " + Student.Cosmetic.Hairstyle;
			OptionLabels[2].text = "Accessory: " + Student.Cosmetic.Accessory;
			OptionLabels[3].text = "Clothing: " + Student.Schoolwear;
			OptionLabels[4].text = "Hair R: " + Student.Cosmetic.HairRenderer.material.color.r * 255f;
			OptionLabels[5].text = "Hair G: " + Student.Cosmetic.HairRenderer.material.color.g * 255f;
			OptionLabels[6].text = "Hair B: " + Student.Cosmetic.HairRenderer.material.color.b * 255f;
			OptionLabels[7].text = "Eye R: " + Student.Cosmetic.RightEyeRenderer.material.color.r * 255f;
			OptionLabels[8].text = "Eye G: " + Student.Cosmetic.RightEyeRenderer.material.color.g * 255f;
			OptionLabels[9].text = "Eye B: " + Student.Cosmetic.RightEyeRenderer.material.color.b * 255f;
			OptionLabels[10].text = "Degree of Change: " + Degree;
			OptionLabels[11].text = "Stockings: " + Student.Cosmetic.Stockings;
			OptionLabels[12].text = "Blood: " + Student.LiquidProjector.enabled;
			Limit = 12;
			UILabel uILabel3 = OptionLabels[3];
			UILabel uILabel4 = OptionLabels[11];
			if (!Student.Male)
			{
				uILabel3.color = new Color(uILabel3.color.r, uILabel3.color.g, uILabel3.color.b, 1f);
				uILabel4.color = new Color(uILabel4.color.r, uILabel4.color.g, uILabel4.color.b, 1f);
			}
			else
			{
				uILabel4.color = new Color(uILabel4.color.r, uILabel4.color.g, uILabel4.color.b, 0.5f);
			}
		}
		else if (Animating)
		{
			HeaderLabel.text = "Choose Animation";
			for (int j = 1; j < 19; j++)
			{
				OptionLabels[j].text = "(" + (j + Offset) + "/" + AnimID + ") " + AnimationArray[j + Offset];
			}
			Limit = 18;
		}
		else if (EditingFace)
		{
			HeaderLabel.text = "Edit Face";
			OptionLabels[1].text = "Smile Mouth (" + Student.MyRenderer.GetBlendShapeWeight(0) + ")";
			OptionLabels[2].text = "Angry Eyebrows (" + Student.MyRenderer.GetBlendShapeWeight(1) + ")";
			OptionLabels[3].text = "Open Mouth (" + Student.MyRenderer.GetBlendShapeWeight(2) + ")";
			OptionLabels[4].text = "Ear Size (" + Student.MyRenderer.GetBlendShapeWeight(3) + ")";
			OptionLabels[5].text = "Nose Size (" + Student.MyRenderer.GetBlendShapeWeight(4) + ")";
			OptionLabels[6].text = "Close Eyes (" + Student.MyRenderer.GetBlendShapeWeight(5) + ")";
			OptionLabels[7].text = "Sad Face (" + Student.MyRenderer.GetBlendShapeWeight(6) + ")";
			OptionLabels[8].text = "(Unavailable) (" + Student.MyRenderer.GetBlendShapeWeight(7) + ")";
			OptionLabels[9].text = "Thin Eyes (" + Student.MyRenderer.GetBlendShapeWeight(8) + ")";
			OptionLabels[10].text = "Round Eyes (" + Student.MyRenderer.GetBlendShapeWeight(9) + ")";
			OptionLabels[11].text = "Evil Face (" + Student.MyRenderer.GetBlendShapeWeight(10) + ")";
			OptionLabels[12].text = "Naughty Face (" + Student.MyRenderer.GetBlendShapeWeight(11) + ")";
			OptionLabels[13].text = "Gentle Face (" + Student.MyRenderer.GetBlendShapeWeight(12) + ")";
			OptionLabels[14].text = "Thick Body (" + Student.MyRenderer.GetBlendShapeWeight(13) + ")";
			OptionLabels[15].text = "Slim Body (" + Student.MyRenderer.GetBlendShapeWeight(14) + ")";
			OptionLabels[16].text = "Long Skirt (" + Student.MyRenderer.GetBlendShapeWeight(15) + ")";
			OptionLabels[17].text = "Short Skirt (" + Student.MyRenderer.GetBlendShapeWeight(16) + ")";
			OptionLabels[18].text = "Degree of Change: " + Degree;
			Limit = 18;
		}
		else if (SavingLoading)
		{
			HeaderLabel.text = "Save / Load";
			OptionLabels[1].text = "Save Slot: " + SaveSlot;
			OptionLabels[2].text = "Save";
			OptionLabels[3].text = "Load";
			Limit = 3;
		}
	}

	private void RememberPose()
	{
		PoseModeGlobals.PosePosition = Bone.localPosition;
		PoseModeGlobals.PoseRotation = Bone.localEulerAngles;
		PoseModeGlobals.PoseScale = Bone.localScale;
	}

	private void ResetPose()
	{
		Bone.localPosition = PoseModeGlobals.PosePosition;
		Bone.localEulerAngles = PoseModeGlobals.PoseRotation;
		Bone.localScale = PoseModeGlobals.PoseScale;
	}

	private void CapColors()
	{
		Material material = Student.Cosmetic.HairRenderer.material;
		if (material.color.r < 0f)
		{
			material.color = new Color(0f, material.color.g, material.color.b, material.color.a);
		}
		if (material.color.g < 0f)
		{
			material.color = new Color(material.color.r, 0f, material.color.b, material.color.a);
		}
		if (material.color.b < 0f)
		{
			material.color = new Color(material.color.r, material.color.g, 0f, material.color.a);
		}
		if (material.color.r > 1f)
		{
			material.color = new Color(1f, material.color.g, material.color.b, material.color.a);
		}
		if (material.color.g > 1f)
		{
			material.color = new Color(material.color.r, 1f, material.color.b, material.color.a);
		}
		if (material.color.b > 1f)
		{
			material.color = new Color(material.color.r, material.color.g, 1f, material.color.a);
		}
		Material material2 = Student.Cosmetic.RightEyeRenderer.material;
		if (material2.color.r < 0f)
		{
			material2.color = new Color(0f, material2.color.g, material2.color.b, material2.color.a);
		}
		if (material2.color.g < 0f)
		{
			material2.color = new Color(material2.color.r, 0f, material2.color.b, material2.color.a);
		}
		if (material2.color.b < 0f)
		{
			material2.color = new Color(material2.color.r, material2.color.g, 0f, material2.color.a);
		}
		if (material2.color.r > 1f)
		{
			material2.color = new Color(1f, material2.color.g, material2.color.b, material2.color.a);
		}
		if (material2.color.g > 1f)
		{
			material2.color = new Color(material2.color.r, 1f, material2.color.b, material2.color.a);
		}
		if (material2.color.b > 1f)
		{
			material2.color = new Color(material2.color.r, material2.color.g, 1f, material2.color.a);
		}
		Student.Cosmetic.LeftEyeRenderer.material.color = material2.color;
	}

	private void CreateAnimationArray()
	{
		AnimID = 1;
		foreach (AnimationState item in Student.CharacterAnimation)
		{
			AnimationArray[AnimID] = item.name;
			AnimID++;
		}
		AnimID--;
	}

	private void CalculateValue()
	{
		if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f)
		{
			if (Input.GetAxis("Horizontal") > 0.5f)
			{
				Value = 1;
			}
			else
			{
				Value = -1;
			}
		}
		else if (Input.GetAxis("DpadX") > 0.5f || Input.GetAxis("DpadX") < -0.5f)
		{
			if (Input.GetAxis("DpadX") > 0.5f)
			{
				Value = 1;
			}
			else
			{
				Value = -1;
			}
		}
		else
		{
			Value = (Input.GetKey(KeyCode.RightArrow) ? 1 : (-1));
		}
	}

	private void Exit()
	{
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		Yandere.CanMove = true;
		Show = false;
		Selected = 1;
		UpdateHighlight();
	}
}
