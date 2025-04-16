using UnityEngine;
using UnityEngine.SceneManagement;

public class VisualNovelScript : MonoBehaviour
{
	public Camera BasementCamera;

	public Camera MainCamera;

	public Camera UiCamera;

	public Transform[] CharacterParent;

	public Transform[] CharacterTarget;

	public StudentScript[] Character;

	public Animation[] CharAnim;

	public CameraFilterPack_FX_Drunk Drunk;

	public TypewriterEffect Typewriter;

	public AudioSource Jukebox;

	public UIPanel VisualNovelPanel;

	public UIPanel OptionPanel;

	public UILabel DialogueLabel;

	public UILabel NameLabel;

	public UITexture Background;

	public UISprite Darkness;

	public Texture Blonde;

	public string[] Dialogue;

	public string[] AltDialogue;

	public string[] Anims;

	public string[] AltAnims;

	public string[] IdleAnims;

	public string[] AltIdleAnims;

	public int[] SpecialCase;

	public int[] AltSpecialCase;

	public int[] Speaker;

	public int[] AltSpeaker;

	public string[] CurrentIdleAnim;

	public string[] Names;

	public Color[] Colors;

	public int[] SkipDestinations;

	public Renderer Backdrop;

	public float ChangeTimer;

	public float ScreenShake;

	public float FadeTimer;

	public bool ChangeAppearance;

	public bool DrunkEffect;

	public bool ShowOption;

	public bool Betrayed;

	public bool FadeOut;

	public int SkipID;

	public int Week;

	public int ID;

	public VisualNovelDataScript KizanaMeetData;

	public SkinnedMeshRenderer MaleRenderer;

	public StudentScript MaleCharacter;

	public GameObject KizanaClothing;

	public Texture CasualClothes;

	public Transform EyeTarget;

	public Renderer Painting;

	public Mesh CasualMesh;

	public bool CasualClothing;

	public bool MeetingRival;

	public bool ShowPainting;

	public bool SkipToEnd;

	public VisualNovelDataScript[] BasementTapeData;

	public GameObject Basement;

	public UITexture[] Graphics;

	public int[] GraphicIDs;

	public VisualNovelDataScript SisterData;

	public GameObject[] SuccubusAttachers;

	public GameObject[] DramaticEnding;

	public GameObject[] TeleportEffect;

	public GameObject[] MagicFlame;

	public GameObject[] Wings;

	public Texture SecondBackground;

	public UISprite SecondDarkness;

	public GameObject HeartRender;

	public Transform[] RightArm;

	public Transform Eyebrows;

	public int EndingPhase;

	public float EndingTimer;

	public bool FadeToBlack;

	public bool FixEyebrows;

	public bool SisterScene;

	public bool LockArm;

	public GameObject FailSafeWindow;

	public float FailSafeTimer;

	private void Start()
	{
		Time.timeScale = 1f;
		HeartRender.SetActive(value: false);
		MagicFlame[0].SetActive(value: false);
		MagicFlame[1].SetActive(value: false);
		MagicFlame[2].SetActive(value: false);
		if (GameGlobals.SisterCutscene)
		{
			Dialogue = SisterData.Dialogue;
			Anims = SisterData.Anims;
			IdleAnims = SisterData.IdleAnims;
			SpecialCase = SisterData.SpecialCase;
			Speaker = SisterData.Speaker;
			CurrentIdleAnim = SisterData.CurrentIdleAnim;
			Names = SisterData.Names;
			Colors = SisterData.Colors;
			GraphicIDs = SisterData.GraphicIDs;
			Backdrop.material.mainTexture = SisterData.Backdrop;
			Jukebox.clip = SisterData.BGM;
			DialogueLabel.transform.localPosition = new Vector3(0f, -350f, 0f);
			MaleCharacter.gameObject.SetActive(value: false);
			Character[3].gameObject.SetActive(value: true);
			for (int i = 0; i < Graphics.Length; i++)
			{
				Graphics[i].mainTexture = SisterData.Graphics[i];
			}
			HeartRender.SetActive(value: true);
			LockArm = true;
			Character[2].Cosmetic.RightTemple.name = "temple_Right";
			Character[2].Cosmetic.LeftTemple.name = "temple_Left";
			Character[2].Cosmetic.StudentID = 2;
			Character[2].StudentID = 2;
			Character[2].Cosmetic.Initialized = false;
			Character[2].Cosmetic.Start();
			Character[2].Cosmetic.ResetBlendshapes();
			Character[2].Cosmetic.EyeType = "Smug";
			Character[2].Cosmetic.EyeTypeCheck();
			Character[2].Cosmetic.CharacterAnimation["f02_magic_00"].speed = 0.1f;
			ReplaceIdleElegant(ref IdleAnims);
			Character[3].Cosmetic.StudentID = 3;
			Character[3].StudentID = 3;
			Character[3].Cosmetic.Initialized = false;
			Character[3].Cosmetic.Start();
			Character[3].Cosmetic.ResetBlendshapes();
			Character[3].Cosmetic.EyeType = "Default";
			Character[3].Cosmetic.EyeTypeCheck();
			DestroyComponentsInChildren(Character[1].transform);
			DestroyComponentsInChildren(Character[2].transform);
			DestroyComponentsInChildren(Character[3].transform);
			CharAnim[1].CrossFade(CurrentIdleAnim[1]);
			CharAnim[2].CrossFade(CurrentIdleAnim[2]);
			CharAnim[3].CrossFade(CurrentIdleAnim[3]);
			Character[1].DisableProps();
			Character[2].DisableProps();
			Character[3].DisableProps();
			SisterScene = true;
			SkipDestinations[0] = 13;
			SkipDestinations[1] = 56;
			SkipToEnd = true;
		}
		else if (GameGlobals.BasementTape > 0)
		{
			Dialogue = BasementTapeData[GameGlobals.BasementTape].Dialogue;
			Anims = BasementTapeData[GameGlobals.BasementTape].Anims;
			IdleAnims = BasementTapeData[GameGlobals.BasementTape].IdleAnims;
			SpecialCase = BasementTapeData[GameGlobals.BasementTape].SpecialCase;
			Speaker = BasementTapeData[GameGlobals.BasementTape].Speaker;
			CurrentIdleAnim = BasementTapeData[GameGlobals.BasementTape].CurrentIdleAnim;
			Names = BasementTapeData[GameGlobals.BasementTape].Names;
			Colors = BasementTapeData[GameGlobals.BasementTape].Colors;
			GraphicIDs = BasementTapeData[GameGlobals.BasementTape].GraphicIDs;
			Jukebox.clip = BasementTapeData[GameGlobals.BasementTape].BGM;
			DialogueLabel.transform.localPosition = new Vector3(0f, -350f, 0f);
			MaleCharacter.gameObject.SetActive(value: false);
			Character[1].gameObject.SetActive(value: false);
			Character[2].gameObject.SetActive(value: false);
			Backdrop.gameObject.SetActive(value: false);
			MainCamera.enabled = false;
			UiCamera.enabled = false;
			Basement.SetActive(value: true);
			for (int j = 0; j < Graphics.Length; j++)
			{
				Graphics[j].mainTexture = BasementTapeData[GameGlobals.BasementTape].Graphics[j];
			}
			SkipToEnd = true;
		}
		else
		{
			Debug.Log("The visual novel scene believes that the current week is: " + DateGlobals.Week);
			if (GameGlobals.BlondeHair)
			{
				Character[1].Cosmetic.FemaleHairRenderers[1].material.mainTexture = Blonde;
			}
			if (GameGlobals.SenpaiMeetsNewRival)
			{
				MeetingRival = true;
				Debug.Log("Now attempting to turn the characters into Taro and Kizana.");
				Dialogue = KizanaMeetData.Dialogue;
				Anims = KizanaMeetData.Anims;
				IdleAnims = KizanaMeetData.IdleAnims;
				SpecialCase = KizanaMeetData.SpecialCase;
				Speaker = KizanaMeetData.Speaker;
				CurrentIdleAnim = KizanaMeetData.CurrentIdleAnim;
				Names = KizanaMeetData.Names;
				Colors = KizanaMeetData.Colors;
				Backdrop.material.mainTexture = KizanaMeetData.Backdrop;
				Jukebox.clip = KizanaMeetData.BGM;
				Week = 2;
				Character[1].gameObject.SetActive(value: false);
				Character[1] = MaleCharacter;
				CharAnim[1] = Character[1].CharacterAnimation;
				CasualClothing = true;
				Character[2].Cosmetic.StudentID = 13;
				Character[2].StudentID = 13;
				Character[2].Cosmetic.RightTemple.name = "temple_Right";
				Character[2].Cosmetic.LeftTemple.name = "temple_Left";
				Character[2].Cosmetic.Initialized = false;
				Character[2].Cosmetic.Start();
				Character[2].Cosmetic.RightEyeRenderer.gameObject.SetActive(value: false);
				Character[2].Cosmetic.LeftEyeRenderer.gameObject.SetActive(value: false);
				Character[2].MyRenderer.enabled = false;
				Character[2].CharacterAnimation["f02_smile_01"].layer = 1;
				Character[2].CharacterAnimation.Play("f02_smile_01");
				Character[2].CharacterAnimation["f02_smile_01"].weight = 1f;
				Character[2].CharacterAnimation["f02_smugEyes_00"].layer = 2;
				Character[2].CharacterAnimation.Play("f02_smugEyes_00");
				Character[2].CharacterAnimation["f02_smugEyes_00"].weight = 1f;
				KizanaClothing.SetActive(value: true);
				Character[2].RightBreast.transform.localScale = new Vector3(1f, 1f, 1f);
				Character[2].LeftBreast.transform.localScale = new Vector3(1f, 1f, 1f);
				SkipToEnd = true;
			}
			else
			{
				MaleCharacter.gameObject.SetActive(value: false);
			}
			DestroyComponentsInChildren(Character[1].transform);
			DestroyComponentsInChildren(Character[2].transform);
			CharAnim[1].CrossFade(CurrentIdleAnim[1]);
			CharAnim[2].CrossFade(CurrentIdleAnim[2]);
			Character[1].DisableProps();
			Character[2].DisableProps();
		}
		DialogueLabel.gameObject.SetActive(value: false);
		VisualNovelPanel.alpha = 0f;
		OptionPanel.alpha = 0f;
		Darkness.alpha = 1f;
		UpdateLabels();
	}

	private void Update()
	{
		if (DialogueLabel.text == "")
		{
			FailSafeTimer += Time.deltaTime;
			if (FailSafeTimer > 10f)
			{
				FailSafeWindow.SetActive(value: true);
				if (Input.GetKeyDown("z"))
				{
					Debug.Log("Failsafe triggered. Exiting scene.");
					FadeOut = true;
				}
			}
		}
		else
		{
			FailSafeTimer = 0f;
		}
		if (ChangeAppearance)
		{
			ChangeTimer += Time.deltaTime;
			if (ChangeTimer > 1.2f)
			{
				if (Character[2].MyRenderer.enabled)
				{
					Character[2].MyRenderer.enabled = false;
					Character[3].MyRenderer.enabled = false;
					Character[2].RightBreast.localScale = new Vector3(1f, 1f, 1f);
					Character[2].LeftBreast.localScale = new Vector3(1f, 1f, 1f);
					SuccubusAttachers[0].SetActive(value: true);
					SuccubusAttachers[1].SetActive(value: true);
					Wings[0].SetActive(value: true);
					Wings[1].SetActive(value: true);
				}
				else
				{
					SkinnedMeshRenderer newRenderer = SuccubusAttachers[0].GetComponent<RiggedAccessoryAttacher>().newRenderer;
					if (newRenderer != null)
					{
						newRenderer.SetBlendShapeWeight(0, 100f);
						newRenderer.SetBlendShapeWeight(5, 25f);
						ChangeAppearance = false;
					}
					newRenderer = SuccubusAttachers[1].GetComponent<RiggedAccessoryAttacher>().newRenderer;
					_ = newRenderer != null;
				}
			}
		}
		if (!FadeOut)
		{
			if (FadeToBlack)
			{
				SecondDarkness.alpha = Mathf.MoveTowards(SecondDarkness.alpha, 1f, Time.deltaTime);
			}
			else
			{
				SecondDarkness.alpha = Mathf.MoveTowards(SecondDarkness.alpha, 0f, Time.deltaTime);
			}
			if (ScreenShake > 0.0001f)
			{
				BasementCamera.transform.localPosition = new Vector3(1f + Random.RandomRange(ScreenShake * -1f, ScreenShake * 1f), 1f + Random.RandomRange(ScreenShake * -1f, ScreenShake * 1f), 0f + Random.RandomRange(ScreenShake * -1f, ScreenShake * 1f));
				ScreenShake = Mathf.Lerp(ScreenShake, 0f, Time.deltaTime * 10f);
			}
			if (GraphicIDs.Length != 0)
			{
				for (int i = 0; i < Graphics.Length; i++)
				{
					if (GraphicIDs[ID] != i)
					{
						Graphics[i].alpha = Mathf.MoveTowards(Graphics[i].alpha, 0f, Time.deltaTime);
					}
					else
					{
						Graphics[i].alpha = Mathf.MoveTowards(Graphics[i].alpha, 0.5f, Time.deltaTime);
					}
				}
			}
			FadeTimer += Time.deltaTime;
			if (FadeTimer > 1f)
			{
				if (!Jukebox.isPlaying)
				{
					Character[2].Cosmetic.Armband.SetActive(value: false);
					if (CasualClothing)
					{
						MaleRenderer.sharedMesh = CasualMesh;
						MaleRenderer.materials[0].mainTexture = CasualClothes;
						MaleRenderer.materials[1].mainTexture = Character[1].Cosmetic.FaceTextures[Character[1].Cosmetic.SkinColor];
						MaleRenderer.materials[2].mainTexture = Character[1].Cosmetic.SkinTextures[Character[1].Cosmetic.SkinColor];
					}
					if (Week == 2)
					{
						Character[2].RightBreast.transform.localScale = new Vector3(1f, 1f, 1f);
						Character[2].LeftBreast.transform.localScale = new Vector3(1f, 1f, 1f);
					}
					Jukebox.Play();
				}
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
				Jukebox.volume = 1f - Darkness.alpha;
				if (Darkness.alpha < 0.0001f)
				{
					VisualNovelPanel.alpha = Mathf.MoveTowards(VisualNovelPanel.alpha, 1f, Time.deltaTime);
					if (VisualNovelPanel.alpha > 0.999f)
					{
						if (!DialogueLabel.gameObject.activeInHierarchy)
						{
							DialogueLabel.gameObject.SetActive(value: true);
							DialogueLabel.alpha = 0f;
							CharAnim[1].CrossFade(CurrentIdleAnim[1], 1f);
							CharAnim[2].CrossFade(CurrentIdleAnim[2], 1f);
							if (CurrentIdleAnim.Length > 3)
							{
								CharAnim[3].CrossFade(CurrentIdleAnim[3], 1f);
							}
							CharAnim[Speaker[ID]].CrossFade(Anims[ID], 1f);
						}
						else
						{
							DialogueLabel.alpha = 1f;
						}
						if (Speaker[ID] > 0 && CharAnim[Speaker[ID]][Anims[ID]].time >= CharAnim[Speaker[ID]][Anims[ID]].length - 0.5f)
						{
							CharAnim[Speaker[ID]].CrossFade(CurrentIdleAnim[Speaker[ID]], 0.5f);
						}
						CharacterParent[1].position = Vector3.Lerp(CharacterParent[1].position, CharacterTarget[1].position, Time.deltaTime * 10f);
						if (ShowOption)
						{
							OptionPanel.alpha = Mathf.MoveTowards(OptionPanel.alpha, 1f, Time.deltaTime * 10f);
							if (OptionPanel.alpha > 0.999f && Input.GetButtonDown(InputNames.Xbox_B))
							{
								for (int j = 28; j < 33; j++)
								{
									SpecialCase[j] = AltSpecialCase[j];
									IdleAnims[j] = AltIdleAnims[j];
									Dialogue[j] = AltDialogue[j];
									Speaker[j] = AltSpeaker[j];
									Anims[j] = AltAnims[j];
								}
								ShowOption = false;
								Betrayed = true;
							}
						}
						else
						{
							OptionPanel.alpha = Mathf.MoveTowards(OptionPanel.alpha, 0f, Time.deltaTime * 10f);
						}
						if (DrunkEffect)
						{
							Drunk.Fade = Mathf.MoveTowards(Drunk.Fade, 1f, Time.deltaTime);
						}
						bool flag = false;
						if (Input.GetButtonDown(InputNames.Xbox_X))
						{
							if (SkipToEnd)
							{
								Debug.Log("The player just tapped the Skip button, so we skipped to the end of the dialogue.");
								if (SkipDestinations[SkipID] == 0)
								{
									ID = Dialogue.Length;
								}
								else if (ID < SkipDestinations[SkipID])
								{
									ID = SkipDestinations[SkipID];
									SkipID++;
								}
								else
								{
									ID = SkipDestinations[SkipID + 1];
									SkipID += 2;
								}
							}
							else if (ID < 12)
							{
								Debug.Log("The player just held down the Skip button, so we skipped to ID 12.");
								ID = 12;
							}
							else if (ID < 22)
							{
								Debug.Log("The player just held down the Skip button, so we skipped to ID 22.");
								ID = 22;
							}
							else
							{
								Debug.Log("The player just held down the Skip button, so we skipped to the end of the dialogue.");
								ID = Dialogue.Length;
							}
							Typewriter.ResetToBeginning();
							Typewriter.Finish();
							flag = true;
						}
						if (Input.GetButtonDown(InputNames.Xbox_A) || flag)
						{
							if (ID < Dialogue.Length)
							{
								if (Typewriter.mCurrentOffset < Typewriter.mFullText.Length)
								{
									Typewriter.ResetToBeginning();
									Typewriter.Finish();
								}
								else
								{
									ID++;
									if (ID < Dialogue.Length)
									{
										Typewriter.ResetToBeginning();
										Typewriter.mFullText = Dialogue[ID];
										if (Speaker[ID] > 0)
										{
											if (Speaker[ID] == 1)
											{
												CharAnim[2].CrossFade(CurrentIdleAnim[2], 1f);
												if (CurrentIdleAnim.Length > 3)
												{
													CharAnim[3].CrossFade(CurrentIdleAnim[3], 1f);
												}
											}
											else if (Speaker[ID] == 2)
											{
												CharAnim[1].CrossFade(CurrentIdleAnim[1], 1f);
												if (CurrentIdleAnim.Length > 3)
												{
													CharAnim[3].CrossFade(CurrentIdleAnim[3], 1f);
												}
											}
											else if (Speaker[ID] == 3)
											{
												CharAnim[1].CrossFade(CurrentIdleAnim[1], 1f);
												CharAnim[2].CrossFade(CurrentIdleAnim[2], 1f);
											}
											CharAnim[Speaker[ID]].CrossFade(Anims[ID]);
											CurrentIdleAnim[Speaker[ID]] = IdleAnims[ID];
										}
										else
										{
											CharAnim[1].CrossFade(CurrentIdleAnim[1], 1f);
											CharAnim[2].CrossFade(CurrentIdleAnim[2], 1f);
											if (CurrentIdleAnim.Length > 3)
											{
												CharAnim[3].CrossFade(CurrentIdleAnim[3], 1f);
											}
										}
										if (SpecialCase[ID] > 0)
										{
											if (SpecialCase[ID] == 1)
											{
												CharacterTarget[1].position = new Vector3(-1.4f, -1.25f, 1f);
												ShowOption = true;
											}
											else if (SpecialCase[ID] == 2)
											{
												CharacterTarget[1].position = new Vector3(-0.5f, -1.25f, 1f);
												ShowOption = false;
											}
											else if (SpecialCase[ID] == 3)
											{
												DrunkEffect = true;
											}
											else if (SpecialCase[ID] == 4)
											{
												CurrentIdleAnim[1] = "f02_evilWitnessIdle_00";
												CurrentIdleAnim[2] = "f02_down_23";
												CharAnim[1].CrossFade("f02_evilWitness_00", 1f);
												CharAnim[2].CrossFade("f02_down_22", 1f);
											}
											else if (SpecialCase[ID] == 5)
											{
												FadeOut = true;
											}
											else if (SpecialCase[ID] == 6)
											{
												ShowPainting = true;
											}
											else if (SpecialCase[ID] == 7)
											{
												ShowPainting = false;
											}
											else if (SpecialCase[ID] == 8)
											{
												DialogueLabel.fontSize = 125;
												ScreenShake = 1f;
											}
											else if (SpecialCase[ID] == 9)
											{
												DialogueLabel.fontSize = 50;
											}
											else if (SpecialCase[ID] == 10)
											{
												TeleportEffect[0].SetActive(value: true);
												TeleportEffect[1].SetActive(value: true);
												ChangeAppearance = true;
												FixEyebrows = true;
											}
											else if (SpecialCase[ID] == 11)
											{
												CurrentIdleAnim[1] = "f02_heroicIdle_00";
												CharAnim[1].CrossFade(CurrentIdleAnim[1], 1f);
												FixEyebrows = false;
											}
											else if (SpecialCase[ID] == 12)
											{
												CurrentIdleAnim[2] = "f02_magic_00";
												CharAnim[2].CrossFade(CurrentIdleAnim[2], 0.5f);
												FixEyebrows = false;
											}
											else if (SpecialCase[ID] == 13)
											{
												FadeToBlack = true;
											}
											else if (SpecialCase[ID] == 14)
											{
												CharacterParent[3].transform.position = new Vector3(0.9f, -1.25f, 1.2f);
												Character[3].CharacterAnimation["f02_smile_01"].layer = 1;
												Character[3].CharacterAnimation.Play("f02_smile_01");
												Character[3].CharacterAnimation["f02_smile_01"].weight = 1f;
												Backdrop.material.mainTexture = SecondBackground;
												CurrentIdleAnim[3] = "succubus_b_idle_01";
												CharAnim[3].CrossFade(CurrentIdleAnim[3], 1f);
												FixEyebrows = false;
												FadeToBlack = false;
											}
											else if (SpecialCase[ID] == 15)
											{
												MagicFlame[0].SetActive(value: true);
											}
											else if (SpecialCase[ID] == 16)
											{
												SecondDarkness.alpha = 1f;
												Jukebox.enabled = false;
												FadeToBlack = true;
											}
										}
										UpdateLabels();
									}
									else
									{
										if (SisterScene)
										{
											VisualNovelPanel.alpha = 0f;
											Darkness.alpha = 1f;
										}
										FadeOut = true;
									}
								}
							}
							else
							{
								FadeOut = true;
							}
						}
					}
				}
			}
		}
		else
		{
			VisualNovelPanel.alpha = Mathf.MoveTowards(VisualNovelPanel.alpha, 0f, Time.deltaTime);
			if (VisualNovelPanel.alpha < 0.0001f)
			{
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
				Jukebox.volume = 1f - Darkness.alpha;
				if (Darkness.alpha > 0.999f)
				{
					if (SisterScene)
					{
						if (EndingPhase == 0)
						{
							DramaticEnding[0].SetActive(value: true);
							EndingPhase++;
						}
						else if (EndingPhase == 1)
						{
							if (EndingTimer > 1.5f)
							{
								DramaticEnding[1].SetActive(value: true);
								DramaticEnding[1].transform.localScale += new Vector3(Time.deltaTime * 0.01f, Time.deltaTime * 0.01f, Time.deltaTime * 0.01f);
							}
							if (EndingTimer > 8.5f)
							{
								DramaticEnding[1].SetActive(value: false);
								DramaticEnding[2].SetActive(value: true);
								EndingPhase++;
							}
						}
						else if (EndingPhase < 9)
						{
							EndingPhase++;
						}
						else if (EndingPhase == 9)
						{
							DramaticEnding[2].SetActive(value: false);
							EndingPhase++;
						}
						else if (EndingTimer > 10f)
						{
							GameGlobals.DarkEnding = true;
							SceneManager.LoadScene("CreditsScene");
						}
						EndingTimer += Time.deltaTime;
					}
					else if (GameGlobals.BasementTape > 0)
					{
						Debug.Log("We reached the part of the code reserved for exiting Basement Tapes.");
						ExitBasementTape();
					}
					else
					{
						Debug.Log("We reached the part of the code reserved for exiting non-Basement Tape visual novel scenes.");
						if (MeetingRival)
						{
							SceneManager.LoadScene("BusStopScene");
						}
						else if (!Betrayed)
						{
							BefriendRival();
						}
						else
						{
							BetrayRival();
						}
					}
				}
			}
		}
		if (ShowPainting)
		{
			float a = Painting.material.color.a;
			a = Mathf.MoveTowards(a, 1f, Time.deltaTime);
			Painting.material.color = new Color(1f, 1f, 1f, a);
		}
		else
		{
			float a2 = Painting.material.color.a;
			a2 = Mathf.MoveTowards(a2, 0f, Time.deltaTime);
			Painting.material.color = new Color(1f, 1f, 1f, a2);
		}
	}

	private void LateUpdate()
	{
		if (LockArm)
		{
			RightArm[0].localEulerAngles = new Vector3(0f, 0f, 0f);
			RightArm[1].localEulerAngles = new Vector3(0f, 0f, -75f);
			RightArm[2].localEulerAngles = new Vector3(0f, 0f, 0f);
			RightArm[3].localEulerAngles = new Vector3(0f, -24f, 0f);
			RightArm[4].localEulerAngles = new Vector3(0f, 0f, 0f);
			RightArm[5].localEulerAngles = new Vector3(0f, -24f, 0f);
		}
		if (FixEyebrows)
		{
			Eyebrows.localPosition = new Vector3(-0.1092865f, 0.015f, 0f);
		}
	}

	private void DestroyComponentsInChildren(Transform parentTransform)
	{
		foreach (Transform item in parentTransform)
		{
			Collider component = item.GetComponent<Collider>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			CharacterJoint component2 = item.GetComponent<CharacterJoint>();
			if (component2 != null)
			{
				Object.Destroy(component2);
			}
			Rigidbody component3 = item.GetComponent<Rigidbody>();
			if (component3 != null)
			{
				Object.Destroy(component3);
			}
			DestroyComponentsInChildren(item);
		}
	}

	private void UpdateLabels()
	{
		if (ID == 1)
		{
			DialogueLabel.text = Dialogue[ID];
		}
		DialogueLabel.gradientBottom = Colors[Speaker[ID]];
		NameLabel.gradientBottom = Colors[Speaker[ID]];
		Background.color = Colors[Speaker[ID]];
		NameLabel.text = Names[Speaker[ID]];
	}

	private void BefriendRival()
	{
		GameGlobals.RivalEliminationID = 4;
		StudentGlobals.SetStudentFriendship(10 + DateGlobals.Week, 100);
		GameGlobals.NonlethalElimination = true;
		GameGlobals.SpecificEliminationID = 2;
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Befriend", 1);
		}
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("a", 1);
		}
		SceneManager.LoadScene("CalendarScene");
		EventGlobals.OsanaConversation = false;
	}

	private void BetrayRival()
	{
		StudentGlobals.SetStudentKidnapped(10 + DateGlobals.Week, value: true);
		StudentGlobals.SetStudentHealth(10 + DateGlobals.Week, 100);
		StudentGlobals.SetStudentSanity(10 + DateGlobals.Week, 100);
		int num = 10 + DateGlobals.Week;
		Debug.Log("The player had " + StudentGlobals.Prisoners + " prisoners in their basement before betraying their rival.");
		StudentGlobals.Prisoners++;
		if (StudentGlobals.Prisoners == 1)
		{
			StudentGlobals.Prisoner1 = num;
		}
		else if (StudentGlobals.Prisoners == 2)
		{
			StudentGlobals.Prisoner2 = num;
		}
		else if (StudentGlobals.Prisoners == 3)
		{
			StudentGlobals.Prisoner3 = num;
		}
		else if (StudentGlobals.Prisoners == 4)
		{
			StudentGlobals.Prisoner4 = num;
		}
		else if (StudentGlobals.Prisoners == 5)
		{
			StudentGlobals.Prisoner5 = num;
		}
		else if (StudentGlobals.Prisoners == 6)
		{
			StudentGlobals.Prisoner6 = num;
		}
		else if (StudentGlobals.Prisoners == 7)
		{
			StudentGlobals.Prisoner7 = num;
		}
		else if (StudentGlobals.Prisoners == 8)
		{
			StudentGlobals.Prisoner8 = num;
		}
		else if (StudentGlobals.Prisoners == 9)
		{
			StudentGlobals.Prisoner9 = num;
		}
		else if (StudentGlobals.Prisoners == 10)
		{
			StudentGlobals.Prisoner10 = num;
		}
		Debug.Log("Now that we have betrayed the rival, there should be " + StudentGlobals.Prisoners + " prisoners in the basement, and the rival should be Prisoner #" + StudentGlobals.Prisoners);
		GameGlobals.RivalEliminationID = 11;
		GameGlobals.NonlethalElimination = true;
		GameGlobals.SpecificEliminationID = 3;
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Betray", 1);
		}
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("a", 1);
		}
		EventGlobals.OsanaConversation = true;
		SceneManager.LoadScene("GenocideScene");
	}

	public void ExitBasementTape()
	{
		GameGlobals.BasementTape = 0;
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			rootGameObjects[i].SetActive(value: true);
		}
		SceneManager.UnloadSceneAsync(56);
		Time.timeScale = 0.0001f;
	}

	private void ReplaceIdleElegant(ref string[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == "f02_idleElegant_00")
			{
				array[i] = "f02_snobIdle_00";
			}
		}
	}
}
