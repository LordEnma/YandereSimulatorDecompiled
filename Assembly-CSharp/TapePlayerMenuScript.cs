using UnityEngine;

public class TapePlayerMenuScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public TapePlayerScript TapePlayer;

	public PromptBarScript PromptBar;

	public Animation TapePlayerAnim;

	public AudioSource MyAudio;

	public GameObject Jukebox;

	public Transform TapePlayerCamera;

	public Transform Highlight;

	public Transform TimeBar;

	public Transform List;

	public AudioClip[] Recordings;

	public AudioClip[] BasementRecordings;

	public AudioClip[] HeadmasterRecordings;

	public UILabel[] TapeLabels;

	public GameObject[] NewIcons;

	public AudioClip TapeStop;

	public string CurrentTime;

	public string ClipLength;

	public bool ButtonPressed;

	public bool Listening;

	public bool Show;

	public UILabel HeaderLabel;

	public UILabel Subtitle;

	public UILabel Label;

	public UISprite Bar;

	public int TotalTapes = 10;

	public int Category = 1;

	public int Selected = 1;

	public int Phase = 1;

	public float RoundedTime;

	public float ResumeTime;

	public float Timer;

	public float[] Cues1;

	public float[] Cues2;

	public float[] Cues3;

	public float[] Cues4;

	public float[] Cues5;

	public float[] Cues6;

	public float[] Cues7;

	public float[] Cues8;

	public float[] Cues9;

	public float[] Cues10;

	public string[] Subs1;

	public string[] Subs2;

	public string[] Subs3;

	public string[] Subs4;

	public string[] Subs5;

	public string[] Subs6;

	public string[] Subs7;

	public string[] Subs8;

	public string[] Subs9;

	public string[] Subs10;

	public float[] BasementCues1;

	public float[] BasementCues10;

	public string[] BasementSubs1;

	public string[] BasementSubs10;

	public float[] HeadmasterCues1;

	public float[] HeadmasterCues2;

	public float[] HeadmasterCues3;

	public float[] HeadmasterCues4;

	public float[] HeadmasterCues5;

	public float[] HeadmasterCues6;

	public float[] HeadmasterCues7;

	public float[] HeadmasterCues8;

	public float[] HeadmasterCues9;

	public float[] HeadmasterCues10;

	public string[] HeadmasterSubs1;

	public string[] HeadmasterSubs2;

	public string[] HeadmasterSubs3;

	public string[] HeadmasterSubs4;

	public string[] HeadmasterSubs5;

	public string[] HeadmasterSubs6;

	public string[] HeadmasterSubs7;

	public string[] HeadmasterSubs8;

	public string[] HeadmasterSubs9;

	public string[] HeadmasterSubs10;

	private void Start()
	{
		List.transform.localPosition = new Vector3(-955f, List.transform.localPosition.y, List.transform.localPosition.z);
		TimeBar.localPosition = new Vector3(TimeBar.localPosition.x, 100f, TimeBar.localPosition.z);
		Subtitle.text = string.Empty;
		TapePlayerCamera.position = new Vector3(-26.15f, TapePlayerCamera.position.y, 5.35f);
	}

	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (Input.GetKeyDown("="))
		{
			MyAudio.pitch++;
		}
		if (Input.GetKeyDown("-"))
		{
			MyAudio.pitch--;
		}
		if (!Show)
		{
			if (List.localPosition.x > -955f)
			{
				List.localPosition = new Vector3(Mathf.Lerp(List.localPosition.x, -956f, t), List.localPosition.y, List.localPosition.z);
				TimeBar.localPosition = new Vector3(TimeBar.localPosition.x, Mathf.Lerp(TimeBar.localPosition.y, 100f, t), TimeBar.localPosition.z);
			}
			else
			{
				TimeBar.gameObject.SetActive(value: false);
				List.gameObject.SetActive(value: false);
			}
			return;
		}
		if (Listening)
		{
			List.localPosition = new Vector3(Mathf.Lerp(List.localPosition.x, -955f, t), List.localPosition.y, List.localPosition.z);
			TimeBar.localPosition = new Vector3(TimeBar.localPosition.x, Mathf.Lerp(TimeBar.localPosition.y, 0f, t), TimeBar.localPosition.z);
			TapePlayerCamera.position = new Vector3(Mathf.Lerp(TapePlayerCamera.position.x, -26.15f, t), TapePlayerCamera.position.y, Mathf.Lerp(TapePlayerCamera.position.z, 5.35f, t));
			if (Phase == 1)
			{
				TapePlayerAnim["InsertTape"].time += Time.unscaledDeltaTime * 3.33333f;
				if (TapePlayerAnim["InsertTape"].time >= TapePlayerAnim["InsertTape"].length)
				{
					TapePlayerAnim.Play("PressPlay");
					MyAudio.pitch = 1f;
					MyAudio.Play();
					PromptBar.Label[0].text = "PAUSE";
					PromptBar.Label[1].text = "STOP";
					PromptBar.Label[5].text = "REWIND / FAST FORWARD";
					PromptBar.UpdateButtons();
					Phase++;
				}
			}
			else if (Phase == 2)
			{
				Timer += Time.unscaledDeltaTime;
				ButtonPressed = false;
				if (MyAudio.isPlaying)
				{
					if (Timer > 0.1f)
					{
						TapePlayerAnim["PressPlay"].time += Time.unscaledDeltaTime;
						if (TapePlayerAnim["PressPlay"].time > TapePlayerAnim["PressPlay"].length)
						{
							TapePlayerAnim["PressPlay"].time = TapePlayerAnim["PressPlay"].length;
						}
					}
				}
				else
				{
					TapePlayerAnim["PressPlay"].time -= Time.unscaledDeltaTime;
					if (TapePlayerAnim["PressPlay"].time < 0f)
					{
						TapePlayerAnim["PressPlay"].time = 0f;
					}
					if (Input.GetButtonDown("A"))
					{
						Debug.Log("The player just pressed the ''A'' button to pause it.");
						PromptBar.Label[0].text = "PAUSE";
						TapePlayer.Spin = true;
						MyAudio.time = ResumeTime;
						MyAudio.Play();
						ButtonPressed = true;
					}
				}
				if (TapePlayerAnim["PressPlay"].time >= TapePlayerAnim["PressPlay"].length)
				{
					TapePlayer.Spin = true;
					if (MyAudio.time >= MyAudio.clip.length - 3f)
					{
						MyAudio.pitch = 1f;
						Time.timeScale = 1f;
					}
					if (MyAudio.time >= MyAudio.clip.length - 1f)
					{
						TapePlayerAnim.Play("PressEject");
						TapePlayer.Spin = false;
						if (!MyAudio.isPlaying)
						{
							MyAudio.clip = TapeStop;
							MyAudio.Play();
						}
						Subtitle.text = string.Empty;
						Phase++;
					}
					if (!ButtonPressed && Input.GetButtonDown("A"))
					{
						Debug.Log("The player just pressed the ''A'' button to unpause it.");
						if (MyAudio.isPlaying)
						{
							PromptBar.Label[0].text = "PLAY";
							TapePlayer.Spin = false;
							ResumeTime = MyAudio.time;
							MyAudio.Stop();
						}
					}
				}
				if (Input.GetButtonDown("B"))
				{
					TapePlayerAnim.Play("PressEject");
					TapePlayer.Spin = false;
					MyAudio.clip = TapeStop;
					MyAudio.time = 0f;
					MyAudio.Play();
					PromptBar.Label[0].text = string.Empty;
					PromptBar.Label[1].text = string.Empty;
					PromptBar.Label[5].text = string.Empty;
					PromptBar.UpdateButtons();
					Subtitle.text = string.Empty;
					Phase++;
				}
			}
			else if (Phase == 3)
			{
				TapePlayerAnim["PressEject"].time += Time.unscaledDeltaTime;
				if (TapePlayerAnim["PressEject"].time >= TapePlayerAnim["PressEject"].length)
				{
					TapePlayerAnim.Play("InsertTape");
					TapePlayerAnim["InsertTape"].time = TapePlayerAnim["InsertTape"].length;
					TapePlayer.FastForward = false;
					Phase++;
				}
			}
			else if (Phase == 4)
			{
				if (TapePlayerAnim["InsertTape"].time > TapePlayerAnim["InsertTape"].length)
				{
					TapePlayerAnim["InsertTape"].time = TapePlayerAnim["InsertTape"].length;
				}
				TapePlayerAnim["InsertTape"].time -= Time.unscaledDeltaTime * 3.33333f;
				if (TapePlayerAnim["InsertTape"].time <= 0f)
				{
					TapePlayer.Tape.SetActive(value: false);
					Jukebox.SetActive(value: true);
					Listening = false;
					Timer = 0f;
					PromptBar.Label[0].text = "PLAY";
					PromptBar.Label[1].text = "BACK";
					PromptBar.Label[4].text = "CHOOSE";
					PromptBar.Label[5].text = "CATEGORY";
					PromptBar.UpdateButtons();
					if (Category == 1)
					{
						CheckJournalistCompletion();
					}
					else if (Category == 2)
					{
						CheckBasementCompletion();
					}
					else if (Category == 3)
					{
						CheckHeadmasterCompletion();
					}
				}
			}
			if (Phase == 2)
			{
				if (InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
				{
					ResumeTime += 1.6666666f;
					MyAudio.time += 1.6666666f;
					TapePlayer.FastForward = true;
				}
				else
				{
					TapePlayer.FastForward = false;
				}
				if (InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
				{
					ResumeTime -= 1.6666666f;
					MyAudio.time -= 1.6666666f;
					TapePlayer.Rewind = true;
				}
				else
				{
					TapePlayer.Rewind = false;
				}
				int num = 0;
				int num2 = 0;
				if (MyAudio.isPlaying)
				{
					num = Mathf.FloorToInt(MyAudio.time / 60f);
					num2 = Mathf.FloorToInt(MyAudio.time - (float)num * 60f);
					Bar.fillAmount = MyAudio.time / MyAudio.clip.length;
				}
				else
				{
					num = Mathf.FloorToInt(ResumeTime / 60f);
					num2 = Mathf.FloorToInt(ResumeTime - (float)num * 60f);
					Bar.fillAmount = ResumeTime / MyAudio.clip.length;
				}
				CurrentTime = $"{num:00}:{num2:00}";
				Label.text = CurrentTime + " / " + ClipLength;
				if (Category == 1)
				{
					if (Selected == 1)
					{
						for (int i = 0; i < Cues1.Length; i++)
						{
							if (MyAudio.time > Cues1[i])
							{
								Subtitle.text = Subs1[i];
							}
						}
					}
					else if (Selected == 2)
					{
						for (int j = 0; j < Cues2.Length; j++)
						{
							if (MyAudio.time > Cues2[j])
							{
								Subtitle.text = Subs2[j];
							}
						}
					}
					else if (Selected == 3)
					{
						for (int k = 0; k < Cues3.Length; k++)
						{
							if (MyAudio.time > Cues3[k])
							{
								Subtitle.text = Subs3[k];
							}
						}
					}
					else if (Selected == 4)
					{
						for (int l = 0; l < Cues4.Length; l++)
						{
							if (MyAudio.time > Cues4[l])
							{
								Subtitle.text = Subs4[l];
							}
						}
					}
					else if (Selected == 5)
					{
						for (int m = 0; m < Cues5.Length; m++)
						{
							if (MyAudio.time > Cues5[m])
							{
								Subtitle.text = Subs5[m];
							}
						}
					}
					else if (Selected == 6)
					{
						for (int n = 0; n < Cues6.Length; n++)
						{
							if (MyAudio.time > Cues6[n])
							{
								Subtitle.text = Subs6[n];
							}
						}
					}
					else if (Selected == 7)
					{
						for (int num3 = 0; num3 < Cues7.Length; num3++)
						{
							if (MyAudio.time > Cues7[num3])
							{
								Subtitle.text = Subs7[num3];
							}
						}
					}
					else if (Selected == 8)
					{
						for (int num4 = 0; num4 < Cues8.Length; num4++)
						{
							if (MyAudio.time > Cues8[num4])
							{
								Subtitle.text = Subs8[num4];
							}
						}
					}
					else if (Selected == 9)
					{
						for (int num5 = 0; num5 < Cues9.Length; num5++)
						{
							if (MyAudio.time > Cues9[num5])
							{
								Subtitle.text = Subs9[num5];
							}
						}
					}
					else
					{
						if (Selected != 10)
						{
							return;
						}
						for (int num6 = 0; num6 < Cues10.Length; num6++)
						{
							if (MyAudio.time > Cues10[num6])
							{
								Subtitle.text = Subs10[num6];
							}
						}
					}
				}
				else if (Category == 2)
				{
					if (Selected == 1)
					{
						for (int num7 = 0; num7 < BasementCues1.Length; num7++)
						{
							if (MyAudio.time > BasementCues1[num7])
							{
								Subtitle.text = BasementSubs1[num7];
							}
						}
					}
					if (Selected != 10)
					{
						return;
					}
					for (int num8 = 0; num8 < BasementCues10.Length; num8++)
					{
						if (MyAudio.time > BasementCues10[num8])
						{
							Subtitle.text = BasementSubs10[num8];
						}
					}
				}
				else
				{
					if (Category != 3)
					{
						return;
					}
					if (Selected == 1)
					{
						for (int num9 = 0; num9 < HeadmasterCues1.Length; num9++)
						{
							if (MyAudio.time > HeadmasterCues1[num9])
							{
								Subtitle.text = HeadmasterSubs1[num9];
							}
						}
					}
					else if (Selected == 2)
					{
						for (int num10 = 0; num10 < HeadmasterCues2.Length; num10++)
						{
							if (MyAudio.time > HeadmasterCues2[num10])
							{
								Subtitle.text = HeadmasterSubs2[num10];
							}
						}
					}
					else if (Selected == 3)
					{
						for (int num11 = 0; num11 < HeadmasterCues3.Length; num11++)
						{
							if (MyAudio.time > HeadmasterCues3[num11])
							{
								Subtitle.text = HeadmasterSubs3[num11];
							}
						}
					}
					else if (Selected == 4)
					{
						for (int num12 = 0; num12 < HeadmasterCues4.Length; num12++)
						{
							if (MyAudio.time > HeadmasterCues4[num12])
							{
								Subtitle.text = HeadmasterSubs4[num12];
							}
						}
					}
					else if (Selected == 5)
					{
						for (int num13 = 0; num13 < HeadmasterCues5.Length; num13++)
						{
							if (MyAudio.time > HeadmasterCues5[num13])
							{
								Subtitle.text = HeadmasterSubs5[num13];
							}
						}
					}
					else if (Selected == 6)
					{
						for (int num14 = 0; num14 < HeadmasterCues6.Length; num14++)
						{
							if (MyAudio.time > HeadmasterCues6[num14])
							{
								Subtitle.text = HeadmasterSubs6[num14];
							}
						}
					}
					else if (Selected == 7)
					{
						for (int num15 = 0; num15 < HeadmasterCues7.Length; num15++)
						{
							if (MyAudio.time > HeadmasterCues7[num15])
							{
								Subtitle.text = HeadmasterSubs7[num15];
							}
						}
					}
					else if (Selected == 8)
					{
						for (int num16 = 0; num16 < HeadmasterCues8.Length; num16++)
						{
							if (MyAudio.time > HeadmasterCues8[num16])
							{
								Subtitle.text = HeadmasterSubs8[num16];
							}
						}
					}
					else if (Selected == 9)
					{
						for (int num17 = 0; num17 < HeadmasterCues9.Length; num17++)
						{
							if (MyAudio.time > HeadmasterCues9[num17])
							{
								Subtitle.text = HeadmasterSubs9[num17];
							}
						}
					}
					else
					{
						if (Selected != 10)
						{
							return;
						}
						for (int num18 = 0; num18 < HeadmasterCues10.Length; num18++)
						{
							if (MyAudio.time > HeadmasterCues10[num18])
							{
								Subtitle.text = HeadmasterSubs10[num18];
							}
						}
					}
				}
			}
			else
			{
				Label.text = "00:00 / 00:00";
				Bar.fillAmount = 0f;
			}
			return;
		}
		TapePlayerAnim.Stop();
		TapePlayerCamera.position = new Vector3(Mathf.Lerp(TapePlayerCamera.position.x, -26.2125f, t), TapePlayerCamera.position.y, Mathf.Lerp(TapePlayerCamera.position.z, 5.4125f, t));
		List.transform.localPosition = new Vector3(Mathf.Lerp(List.transform.localPosition.x, 0f, t), List.transform.localPosition.y, List.transform.localPosition.z);
		TimeBar.localPosition = new Vector3(TimeBar.localPosition.x, Mathf.Lerp(TimeBar.localPosition.y, 100f, t), TimeBar.localPosition.z);
		if (InputManager.TappedRight)
		{
			Category++;
			if (Category > 3)
			{
				Category = 1;
			}
			UpdateLabels();
		}
		else if (InputManager.TappedLeft)
		{
			Category--;
			if (Category < 1)
			{
				Category = 3;
			}
			UpdateLabels();
		}
		if (InputManager.TappedUp)
		{
			Selected--;
			if (Selected < 1)
			{
				Selected = 10;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 440f - 80f * (float)Selected, Highlight.localPosition.z);
			CheckSelection();
		}
		else if (InputManager.TappedDown)
		{
			Selected++;
			if (Selected > 10)
			{
				Selected = 1;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 440f - 80f * (float)Selected, Highlight.localPosition.z);
			CheckSelection();
		}
		else if (Input.GetButtonDown("A"))
		{
			bool flag = false;
			if (Category == 1)
			{
				if (StudentManager.TapesCollected[Selected])
				{
					CollectibleGlobals.SetTapeListened(Selected, value: true);
					flag = true;
				}
			}
			else if (Category == 2)
			{
				if (CollectibleGlobals.GetBasementTapeCollected(Selected))
				{
					CollectibleGlobals.SetBasementTapeListened(Selected, value: true);
					flag = true;
				}
			}
			else if (Category == 3 && StudentManager.HeadmasterTapesCollected[Selected])
			{
				CollectibleGlobals.SetHeadmasterTapeListened(Selected, value: true);
				flag = true;
			}
			if (flag)
			{
				NewIcons[Selected].SetActive(value: false);
				Jukebox.SetActive(value: false);
				Listening = true;
				Phase = 1;
				PromptBar.Label[0].text = string.Empty;
				PromptBar.Label[1].text = string.Empty;
				PromptBar.Label[4].text = string.Empty;
				PromptBar.UpdateButtons();
				TapePlayerAnim["InsertTape"].time = 0f;
				TapePlayerAnim.Play("InsertTape");
				TapePlayer.Tape.SetActive(value: true);
				if (Category == 1)
				{
					MyAudio.clip = Recordings[Selected];
				}
				else if (Category == 2)
				{
					MyAudio.clip = BasementRecordings[Selected];
				}
				else
				{
					MyAudio.clip = HeadmasterRecordings[Selected];
				}
				MyAudio.time = 0f;
				RoundedTime = Mathf.CeilToInt(MyAudio.clip.length);
				int num19 = (int)(RoundedTime / 60f);
				int num20 = (int)(RoundedTime % 60f);
				ClipLength = $"{num19:00}:{num20:00}";
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			TapePlayer.Yandere.HeartCamera.enabled = true;
			TapePlayer.Yandere.RPGCamera.enabled = true;
			TapePlayer.TapePlayerCamera.enabled = false;
			TapePlayer.NoteWindow.SetActive(value: true);
			TapePlayer.PromptBar.ClearButtons();
			TapePlayer.Yandere.CanMove = true;
			TapePlayer.PromptBar.Show = false;
			TapePlayer.Prompt.enabled = true;
			TapePlayer.Yandere.HUD.alpha = 1f;
			Time.timeScale = 1f;
			Show = false;
		}
	}

	public void UpdateLabels()
	{
		int num = 0;
		while (num < TotalTapes)
		{
			num++;
			if (Category == 1)
			{
				HeaderLabel.text = "Mysterious Tapes";
				if (StudentManager.TapesCollected[num])
				{
					TapeLabels[num].text = "Mysterious Tape " + num;
					NewIcons[num].SetActive(!CollectibleGlobals.GetTapeListened(num));
				}
				else
				{
					TapeLabels[num].text = "?????";
					NewIcons[num].SetActive(value: false);
				}
			}
			else if (Category == 2)
			{
				HeaderLabel.text = "Basement Tapes";
				if (CollectibleGlobals.GetBasementTapeCollected(num))
				{
					TapeLabels[num].text = "Basement Tape " + num;
					NewIcons[num].SetActive(!CollectibleGlobals.GetBasementTapeListened(num));
				}
				else
				{
					TapeLabels[num].text = "?????";
					NewIcons[num].SetActive(value: false);
				}
			}
			else
			{
				HeaderLabel.text = "Headmaster Tapes";
				if (StudentManager.HeadmasterTapesCollected[num])
				{
					TapeLabels[num].text = "Headmaster Tape " + num;
					NewIcons[num].SetActive(!CollectibleGlobals.GetHeadmasterTapeListened(num));
				}
				else
				{
					TapeLabels[num].text = "?????";
					NewIcons[num].SetActive(value: false);
				}
			}
		}
	}

	public void CheckSelection()
	{
		if (Category == 1)
		{
			TapePlayer.PromptBar.Label[0].text = (StudentManager.TapesCollected[Selected] ? "PLAY" : string.Empty);
			TapePlayer.PromptBar.UpdateButtons();
		}
		else if (Category == 2)
		{
			TapePlayer.PromptBar.Label[0].text = (CollectibleGlobals.GetBasementTapeCollected(Selected) ? "PLAY" : string.Empty);
			TapePlayer.PromptBar.UpdateButtons();
		}
		else
		{
			TapePlayer.PromptBar.Label[0].text = (StudentManager.HeadmasterTapesCollected[Selected] ? "PLAY" : string.Empty);
			TapePlayer.PromptBar.UpdateButtons();
		}
	}

	public void CheckBasementCompletion()
	{
		int num = 0;
		for (int i = 1; i < 11; i++)
		{
			if (CollectibleGlobals.GetBasementTapeCollected(i) && CollectibleGlobals.GetBasementTapeListened(i))
			{
				num++;
				if (num == 2 && !GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Basement", 1);
					PlayerPrefs.SetInt("a", 1);
				}
			}
		}
	}

	public void CheckHeadmasterCompletion()
	{
		int num = 0;
		for (int i = 1; i < 11; i++)
		{
			if ((CollectibleGlobals.GetHeadmasterTapeCollected(i) && CollectibleGlobals.GetHeadmasterTapeListened(i)) || (StudentManager.HeadmasterTapesCollected[i] && CollectibleGlobals.GetHeadmasterTapeListened(i)))
			{
				num++;
				if (num == 10 && !GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Headmaster", 1);
					PlayerPrefs.SetInt("a", 1);
				}
			}
		}
	}

	public void CheckJournalistCompletion()
	{
		int num = 0;
		for (int i = 1; i < 11; i++)
		{
			if ((CollectibleGlobals.GetTapeCollected(i) && CollectibleGlobals.GetTapeListened(i)) || (StudentManager.TapesCollected[i] && CollectibleGlobals.GetTapeListened(i)))
			{
				num++;
				if (num == 10 && !GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Journalist", 1);
					PlayerPrefs.SetInt("a", 1);
				}
			}
		}
	}
}
