using System;
using UnityEngine;

// Token: 0x02000460 RID: 1120
public class TapePlayerMenuScript : MonoBehaviour
{
	// Token: 0x06001E59 RID: 7769 RVA: 0x001A78F4 File Offset: 0x001A5AF4
	private void Start()
	{
		this.List.transform.localPosition = new Vector3(-955f, this.List.transform.localPosition.y, this.List.transform.localPosition.z);
		this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, 100f, this.TimeBar.localPosition.z);
		this.Subtitle.text = string.Empty;
		this.TapePlayerCamera.position = new Vector3(-26.15f, this.TapePlayerCamera.position.y, 5.35f);
	}

	// Token: 0x06001E5A RID: 7770 RVA: 0x001A79B4 File Offset: 0x001A5BB4
	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (Input.GetKeyDown("="))
		{
			AudioSource myAudio = this.MyAudio;
			float pitch = myAudio.pitch;
			myAudio.pitch = pitch + 1f;
		}
		if (Input.GetKeyDown("-"))
		{
			AudioSource myAudio2 = this.MyAudio;
			float pitch = myAudio2.pitch;
			myAudio2.pitch = pitch - 1f;
		}
		if (this.Show)
		{
			if (this.Listening)
			{
				this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -955f, t), this.List.localPosition.y, this.List.localPosition.z);
				this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 0f, t), this.TimeBar.localPosition.z);
				this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.15f, t), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.35f, t));
				if (this.Phase == 1)
				{
					this.TapePlayerAnim["InsertTape"].time += Time.unscaledDeltaTime * 3.33333f;
					if (this.TapePlayerAnim["InsertTape"].time >= this.TapePlayerAnim["InsertTape"].length)
					{
						this.TapePlayerAnim.Play("PressPlay");
						this.MyAudio.pitch = 1f;
						this.MyAudio.Play();
						this.PromptBar.Label[0].text = "PAUSE";
						this.PromptBar.Label[1].text = "STOP";
						this.PromptBar.Label[5].text = "REWIND / FAST FORWARD";
						this.PromptBar.UpdateButtons();
						this.Phase++;
					}
				}
				else if (this.Phase == 2)
				{
					this.Timer += Time.unscaledDeltaTime;
					if (this.MyAudio.isPlaying)
					{
						if (this.Timer > 0.1f)
						{
							this.TapePlayerAnim["PressPlay"].time += Time.unscaledDeltaTime;
							if (this.TapePlayerAnim["PressPlay"].time > this.TapePlayerAnim["PressPlay"].length)
							{
								this.TapePlayerAnim["PressPlay"].time = this.TapePlayerAnim["PressPlay"].length;
							}
						}
					}
					else
					{
						this.TapePlayerAnim["PressPlay"].time -= Time.unscaledDeltaTime;
						if (this.TapePlayerAnim["PressPlay"].time < 0f)
						{
							this.TapePlayerAnim["PressPlay"].time = 0f;
						}
						if (Input.GetButtonDown("A"))
						{
							this.PromptBar.Label[0].text = "PAUSE";
							this.TapePlayer.Spin = true;
							this.MyAudio.time = this.ResumeTime;
							this.MyAudio.Play();
						}
					}
					if (this.TapePlayerAnim["PressPlay"].time >= this.TapePlayerAnim["PressPlay"].length)
					{
						this.TapePlayer.Spin = true;
						if (this.MyAudio.time >= this.MyAudio.clip.length - 3f)
						{
							this.MyAudio.pitch = 1f;
							Time.timeScale = 1f;
						}
						if (this.MyAudio.time >= this.MyAudio.clip.length - 1f)
						{
							this.TapePlayerAnim.Play("PressEject");
							this.TapePlayer.Spin = false;
							if (!this.MyAudio.isPlaying)
							{
								this.MyAudio.clip = this.TapeStop;
								this.MyAudio.Play();
							}
							this.Subtitle.text = string.Empty;
							this.Phase++;
						}
						if (Input.GetButtonDown("A") && this.MyAudio.isPlaying)
						{
							this.PromptBar.Label[0].text = "PLAY";
							this.TapePlayer.Spin = false;
							this.ResumeTime = this.MyAudio.time;
							this.MyAudio.Stop();
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.TapePlayerAnim.Play("PressEject");
						this.TapePlayer.Spin = false;
						this.MyAudio.clip = this.TapeStop;
						this.MyAudio.time = 0f;
						this.MyAudio.Play();
						this.PromptBar.Label[0].text = string.Empty;
						this.PromptBar.Label[1].text = string.Empty;
						this.PromptBar.Label[5].text = string.Empty;
						this.PromptBar.UpdateButtons();
						this.Subtitle.text = string.Empty;
						this.Phase++;
					}
				}
				else if (this.Phase == 3)
				{
					this.TapePlayerAnim["PressEject"].time += Time.unscaledDeltaTime;
					if (this.TapePlayerAnim["PressEject"].time >= this.TapePlayerAnim["PressEject"].length)
					{
						this.TapePlayerAnim.Play("InsertTape");
						this.TapePlayerAnim["InsertTape"].time = this.TapePlayerAnim["InsertTape"].length;
						this.TapePlayer.FastForward = false;
						this.Phase++;
					}
				}
				else if (this.Phase == 4)
				{
					if (this.TapePlayerAnim["InsertTape"].time > this.TapePlayerAnim["InsertTape"].length)
					{
						this.TapePlayerAnim["InsertTape"].time = this.TapePlayerAnim["InsertTape"].length;
					}
					this.TapePlayerAnim["InsertTape"].time -= Time.unscaledDeltaTime * 3.33333f;
					if (this.TapePlayerAnim["InsertTape"].time <= 0f)
					{
						this.TapePlayer.Tape.SetActive(false);
						this.Jukebox.SetActive(true);
						this.Listening = false;
						this.Timer = 0f;
						this.PromptBar.Label[0].text = "PLAY";
						this.PromptBar.Label[1].text = "BACK";
						this.PromptBar.Label[4].text = "CHOOSE";
						this.PromptBar.Label[5].text = "CATEGORY";
						this.PromptBar.UpdateButtons();
					}
				}
				if (this.Phase != 2)
				{
					this.Label.text = "00:00 / 00:00";
					this.Bar.fillAmount = 0f;
					return;
				}
				if (this.InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
				{
					this.ResumeTime += 1.6666666f;
					this.MyAudio.time += 1.6666666f;
					this.TapePlayer.FastForward = true;
				}
				else
				{
					this.TapePlayer.FastForward = false;
				}
				if (this.InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
				{
					this.ResumeTime -= 1.6666666f;
					this.MyAudio.time -= 1.6666666f;
					this.TapePlayer.Rewind = true;
				}
				else
				{
					this.TapePlayer.Rewind = false;
				}
				int num;
				int num2;
				if (this.MyAudio.isPlaying)
				{
					num = Mathf.FloorToInt(this.MyAudio.time / 60f);
					num2 = Mathf.FloorToInt(this.MyAudio.time - (float)num * 60f);
					this.Bar.fillAmount = this.MyAudio.time / this.MyAudio.clip.length;
				}
				else
				{
					num = Mathf.FloorToInt(this.ResumeTime / 60f);
					num2 = Mathf.FloorToInt(this.ResumeTime - (float)num * 60f);
					this.Bar.fillAmount = this.ResumeTime / this.MyAudio.clip.length;
				}
				this.CurrentTime = string.Format("{00:00}:{1:00}", num, num2);
				this.Label.text = this.CurrentTime + " / " + this.ClipLength;
				if (this.Category == 1)
				{
					if (this.Selected == 1)
					{
						for (int i = 0; i < this.Cues1.Length; i++)
						{
							if (this.MyAudio.time > this.Cues1[i])
							{
								this.Subtitle.text = this.Subs1[i];
							}
						}
						return;
					}
					if (this.Selected == 2)
					{
						for (int j = 0; j < this.Cues2.Length; j++)
						{
							if (this.MyAudio.time > this.Cues2[j])
							{
								this.Subtitle.text = this.Subs2[j];
							}
						}
						return;
					}
					if (this.Selected == 3)
					{
						for (int k = 0; k < this.Cues3.Length; k++)
						{
							if (this.MyAudio.time > this.Cues3[k])
							{
								this.Subtitle.text = this.Subs3[k];
							}
						}
						return;
					}
					if (this.Selected == 4)
					{
						for (int l = 0; l < this.Cues4.Length; l++)
						{
							if (this.MyAudio.time > this.Cues4[l])
							{
								this.Subtitle.text = this.Subs4[l];
							}
						}
						return;
					}
					if (this.Selected == 5)
					{
						for (int m = 0; m < this.Cues5.Length; m++)
						{
							if (this.MyAudio.time > this.Cues5[m])
							{
								this.Subtitle.text = this.Subs5[m];
							}
						}
						return;
					}
					if (this.Selected == 6)
					{
						for (int n = 0; n < this.Cues6.Length; n++)
						{
							if (this.MyAudio.time > this.Cues6[n])
							{
								this.Subtitle.text = this.Subs6[n];
							}
						}
						return;
					}
					if (this.Selected == 7)
					{
						for (int num3 = 0; num3 < this.Cues7.Length; num3++)
						{
							if (this.MyAudio.time > this.Cues7[num3])
							{
								this.Subtitle.text = this.Subs7[num3];
							}
						}
						return;
					}
					if (this.Selected == 8)
					{
						for (int num4 = 0; num4 < this.Cues8.Length; num4++)
						{
							if (this.MyAudio.time > this.Cues8[num4])
							{
								this.Subtitle.text = this.Subs8[num4];
							}
						}
						return;
					}
					if (this.Selected == 9)
					{
						for (int num5 = 0; num5 < this.Cues9.Length; num5++)
						{
							if (this.MyAudio.time > this.Cues9[num5])
							{
								this.Subtitle.text = this.Subs9[num5];
							}
						}
						return;
					}
					if (this.Selected == 10)
					{
						for (int num6 = 0; num6 < this.Cues10.Length; num6++)
						{
							if (this.MyAudio.time > this.Cues10[num6])
							{
								this.Subtitle.text = this.Subs10[num6];
							}
						}
						return;
					}
				}
				else if (this.Category == 2)
				{
					if (this.Selected == 1)
					{
						for (int num7 = 0; num7 < this.BasementCues1.Length; num7++)
						{
							if (this.MyAudio.time > this.BasementCues1[num7])
							{
								this.Subtitle.text = this.BasementSubs1[num7];
							}
						}
					}
					if (this.Selected == 10)
					{
						for (int num8 = 0; num8 < this.BasementCues10.Length; num8++)
						{
							if (this.MyAudio.time > this.BasementCues10[num8])
							{
								this.Subtitle.text = this.BasementSubs10[num8];
							}
						}
						return;
					}
				}
				else if (this.Category == 3)
				{
					if (this.Selected == 1)
					{
						for (int num9 = 0; num9 < this.HeadmasterCues1.Length; num9++)
						{
							if (this.MyAudio.time > this.HeadmasterCues1[num9])
							{
								this.Subtitle.text = this.HeadmasterSubs1[num9];
							}
						}
						return;
					}
					if (this.Selected == 2)
					{
						for (int num10 = 0; num10 < this.HeadmasterCues2.Length; num10++)
						{
							if (this.MyAudio.time > this.HeadmasterCues2[num10])
							{
								this.Subtitle.text = this.HeadmasterSubs2[num10];
							}
						}
						return;
					}
					if (this.Selected == 3)
					{
						for (int num11 = 0; num11 < this.HeadmasterCues3.Length; num11++)
						{
							if (this.MyAudio.time > this.HeadmasterCues3[num11])
							{
								this.Subtitle.text = this.HeadmasterSubs3[num11];
							}
						}
						return;
					}
					if (this.Selected == 4)
					{
						for (int num12 = 0; num12 < this.HeadmasterCues4.Length; num12++)
						{
							if (this.MyAudio.time > this.HeadmasterCues4[num12])
							{
								this.Subtitle.text = this.HeadmasterSubs4[num12];
							}
						}
						return;
					}
					if (this.Selected == 5)
					{
						for (int num13 = 0; num13 < this.HeadmasterCues5.Length; num13++)
						{
							if (this.MyAudio.time > this.HeadmasterCues5[num13])
							{
								this.Subtitle.text = this.HeadmasterSubs5[num13];
							}
						}
						return;
					}
					if (this.Selected == 6)
					{
						for (int num14 = 0; num14 < this.HeadmasterCues6.Length; num14++)
						{
							if (this.MyAudio.time > this.HeadmasterCues6[num14])
							{
								this.Subtitle.text = this.HeadmasterSubs6[num14];
							}
						}
						return;
					}
					if (this.Selected == 7)
					{
						for (int num15 = 0; num15 < this.HeadmasterCues7.Length; num15++)
						{
							if (this.MyAudio.time > this.HeadmasterCues7[num15])
							{
								this.Subtitle.text = this.HeadmasterSubs7[num15];
							}
						}
						return;
					}
					if (this.Selected == 8)
					{
						for (int num16 = 0; num16 < this.HeadmasterCues8.Length; num16++)
						{
							if (this.MyAudio.time > this.HeadmasterCues8[num16])
							{
								this.Subtitle.text = this.HeadmasterSubs8[num16];
							}
						}
						return;
					}
					if (this.Selected == 9)
					{
						for (int num17 = 0; num17 < this.HeadmasterCues9.Length; num17++)
						{
							if (this.MyAudio.time > this.HeadmasterCues9[num17])
							{
								this.Subtitle.text = this.HeadmasterSubs9[num17];
							}
						}
						return;
					}
					if (this.Selected == 10)
					{
						for (int num18 = 0; num18 < this.HeadmasterCues10.Length; num18++)
						{
							if (this.MyAudio.time > this.HeadmasterCues10[num18])
							{
								this.Subtitle.text = this.HeadmasterSubs10[num18];
							}
						}
						return;
					}
				}
			}
			else
			{
				this.TapePlayerAnim.Stop();
				this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.2125f, t), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.4125f, t));
				this.List.transform.localPosition = new Vector3(Mathf.Lerp(this.List.transform.localPosition.x, 0f, t), this.List.transform.localPosition.y, this.List.transform.localPosition.z);
				this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, t), this.TimeBar.localPosition.z);
				if (this.InputManager.TappedRight)
				{
					this.Category++;
					if (this.Category > 3)
					{
						this.Category = 1;
					}
					this.UpdateLabels();
				}
				else if (this.InputManager.TappedLeft)
				{
					this.Category--;
					if (this.Category < 1)
					{
						this.Category = 3;
					}
					this.UpdateLabels();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 10;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
					this.CheckSelection();
					return;
				}
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 10)
					{
						this.Selected = 1;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
					this.CheckSelection();
					return;
				}
				if (Input.GetButtonDown("A"))
				{
					bool flag = false;
					if (this.Category == 1)
					{
						if (this.StudentManager.TapesCollected[this.Selected])
						{
							CollectibleGlobals.SetTapeListened(this.Selected, true);
							flag = true;
						}
					}
					else if (this.Category == 2)
					{
						if (CollectibleGlobals.GetBasementTapeCollected(this.Selected))
						{
							CollectibleGlobals.SetBasementTapeListened(this.Selected, true);
							flag = true;
						}
					}
					else if (this.Category == 3 && this.StudentManager.HeadmasterTapesCollected[this.Selected])
					{
						CollectibleGlobals.SetHeadmasterTapeListened(this.Selected, true);
						flag = true;
					}
					if (flag)
					{
						this.NewIcons[this.Selected].SetActive(false);
						this.Jukebox.SetActive(false);
						this.Listening = true;
						this.Phase = 1;
						this.PromptBar.Label[0].text = string.Empty;
						this.PromptBar.Label[1].text = string.Empty;
						this.PromptBar.Label[4].text = string.Empty;
						this.PromptBar.UpdateButtons();
						this.TapePlayerAnim["InsertTape"].time = 0f;
						this.TapePlayerAnim.Play("InsertTape");
						this.TapePlayer.Tape.SetActive(true);
						if (this.Category == 1)
						{
							this.MyAudio.clip = this.Recordings[this.Selected];
						}
						else if (this.Category == 2)
						{
							this.MyAudio.clip = this.BasementRecordings[this.Selected];
						}
						else
						{
							this.MyAudio.clip = this.HeadmasterRecordings[this.Selected];
						}
						this.MyAudio.time = 0f;
						this.RoundedTime = (float)Mathf.CeilToInt(this.MyAudio.clip.length);
						int num19 = (int)(this.RoundedTime / 60f);
						int num20 = (int)(this.RoundedTime % 60f);
						this.ClipLength = string.Format("{0:00}:{1:00}", num19, num20);
						return;
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					this.TapePlayer.Yandere.HeartCamera.enabled = true;
					this.TapePlayer.Yandere.RPGCamera.enabled = true;
					this.TapePlayer.TapePlayerCamera.enabled = false;
					this.TapePlayer.NoteWindow.SetActive(true);
					this.TapePlayer.PromptBar.ClearButtons();
					this.TapePlayer.Yandere.CanMove = true;
					this.TapePlayer.PromptBar.Show = false;
					this.TapePlayer.Prompt.enabled = true;
					this.TapePlayer.Yandere.HUD.alpha = 1f;
					Time.timeScale = 1f;
					this.Show = false;
				}
			}
			return;
		}
		if (this.List.localPosition.x > -955f)
		{
			this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -956f, t), this.List.localPosition.y, this.List.localPosition.z);
			this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, t), this.TimeBar.localPosition.z);
			return;
		}
		this.TimeBar.gameObject.SetActive(false);
		this.List.gameObject.SetActive(false);
	}

	// Token: 0x06001E5B RID: 7771 RVA: 0x001A900C File Offset: 0x001A720C
	public void UpdateLabels()
	{
		int i = 0;
		while (i < this.TotalTapes)
		{
			i++;
			if (this.Category == 1)
			{
				this.HeaderLabel.text = "Mysterious Tapes";
				if (this.StudentManager.TapesCollected[i])
				{
					this.TapeLabels[i].text = "Mysterious Tape " + i.ToString();
					this.NewIcons[i].SetActive(!CollectibleGlobals.GetTapeListened(i));
				}
				else
				{
					this.TapeLabels[i].text = "?????";
					this.NewIcons[i].SetActive(false);
				}
			}
			else if (this.Category == 2)
			{
				this.HeaderLabel.text = "Basement Tapes";
				if (CollectibleGlobals.GetBasementTapeCollected(i))
				{
					this.TapeLabels[i].text = "Basement Tape " + i.ToString();
					this.NewIcons[i].SetActive(!CollectibleGlobals.GetBasementTapeListened(i));
				}
				else
				{
					this.TapeLabels[i].text = "?????";
					this.NewIcons[i].SetActive(false);
				}
			}
			else
			{
				this.HeaderLabel.text = "Headmaster Tapes";
				if (this.StudentManager.HeadmasterTapesCollected[i])
				{
					this.TapeLabels[i].text = "Headmaster Tape " + i.ToString();
					this.NewIcons[i].SetActive(!CollectibleGlobals.GetHeadmasterTapeListened(i));
				}
				else
				{
					this.TapeLabels[i].text = "?????";
					this.NewIcons[i].SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001E5C RID: 7772 RVA: 0x001A91A8 File Offset: 0x001A73A8
	public void CheckSelection()
	{
		if (this.Category == 1)
		{
			this.TapePlayer.PromptBar.Label[0].text = (this.StudentManager.TapesCollected[this.Selected] ? "PLAY" : string.Empty);
			this.TapePlayer.PromptBar.UpdateButtons();
			return;
		}
		if (this.Category == 2)
		{
			this.TapePlayer.PromptBar.Label[0].text = (CollectibleGlobals.GetBasementTapeCollected(this.Selected) ? "PLAY" : string.Empty);
			this.TapePlayer.PromptBar.UpdateButtons();
			return;
		}
		this.TapePlayer.PromptBar.Label[0].text = (this.StudentManager.HeadmasterTapesCollected[this.Selected] ? "PLAY" : string.Empty);
		this.TapePlayer.PromptBar.UpdateButtons();
	}

	// Token: 0x04003E37 RID: 15927
	public StudentManagerScript StudentManager;

	// Token: 0x04003E38 RID: 15928
	public InputManagerScript InputManager;

	// Token: 0x04003E39 RID: 15929
	public TapePlayerScript TapePlayer;

	// Token: 0x04003E3A RID: 15930
	public PromptBarScript PromptBar;

	// Token: 0x04003E3B RID: 15931
	public Animation TapePlayerAnim;

	// Token: 0x04003E3C RID: 15932
	public AudioSource MyAudio;

	// Token: 0x04003E3D RID: 15933
	public GameObject Jukebox;

	// Token: 0x04003E3E RID: 15934
	public Transform TapePlayerCamera;

	// Token: 0x04003E3F RID: 15935
	public Transform Highlight;

	// Token: 0x04003E40 RID: 15936
	public Transform TimeBar;

	// Token: 0x04003E41 RID: 15937
	public Transform List;

	// Token: 0x04003E42 RID: 15938
	public AudioClip[] Recordings;

	// Token: 0x04003E43 RID: 15939
	public AudioClip[] BasementRecordings;

	// Token: 0x04003E44 RID: 15940
	public AudioClip[] HeadmasterRecordings;

	// Token: 0x04003E45 RID: 15941
	public UILabel[] TapeLabels;

	// Token: 0x04003E46 RID: 15942
	public GameObject[] NewIcons;

	// Token: 0x04003E47 RID: 15943
	public AudioClip TapeStop;

	// Token: 0x04003E48 RID: 15944
	public string CurrentTime;

	// Token: 0x04003E49 RID: 15945
	public string ClipLength;

	// Token: 0x04003E4A RID: 15946
	public bool Listening;

	// Token: 0x04003E4B RID: 15947
	public bool Show;

	// Token: 0x04003E4C RID: 15948
	public UILabel HeaderLabel;

	// Token: 0x04003E4D RID: 15949
	public UILabel Subtitle;

	// Token: 0x04003E4E RID: 15950
	public UILabel Label;

	// Token: 0x04003E4F RID: 15951
	public UISprite Bar;

	// Token: 0x04003E50 RID: 15952
	public int TotalTapes = 10;

	// Token: 0x04003E51 RID: 15953
	public int Category = 1;

	// Token: 0x04003E52 RID: 15954
	public int Selected = 1;

	// Token: 0x04003E53 RID: 15955
	public int Phase = 1;

	// Token: 0x04003E54 RID: 15956
	public float RoundedTime;

	// Token: 0x04003E55 RID: 15957
	public float ResumeTime;

	// Token: 0x04003E56 RID: 15958
	public float Timer;

	// Token: 0x04003E57 RID: 15959
	public float[] Cues1;

	// Token: 0x04003E58 RID: 15960
	public float[] Cues2;

	// Token: 0x04003E59 RID: 15961
	public float[] Cues3;

	// Token: 0x04003E5A RID: 15962
	public float[] Cues4;

	// Token: 0x04003E5B RID: 15963
	public float[] Cues5;

	// Token: 0x04003E5C RID: 15964
	public float[] Cues6;

	// Token: 0x04003E5D RID: 15965
	public float[] Cues7;

	// Token: 0x04003E5E RID: 15966
	public float[] Cues8;

	// Token: 0x04003E5F RID: 15967
	public float[] Cues9;

	// Token: 0x04003E60 RID: 15968
	public float[] Cues10;

	// Token: 0x04003E61 RID: 15969
	public string[] Subs1;

	// Token: 0x04003E62 RID: 15970
	public string[] Subs2;

	// Token: 0x04003E63 RID: 15971
	public string[] Subs3;

	// Token: 0x04003E64 RID: 15972
	public string[] Subs4;

	// Token: 0x04003E65 RID: 15973
	public string[] Subs5;

	// Token: 0x04003E66 RID: 15974
	public string[] Subs6;

	// Token: 0x04003E67 RID: 15975
	public string[] Subs7;

	// Token: 0x04003E68 RID: 15976
	public string[] Subs8;

	// Token: 0x04003E69 RID: 15977
	public string[] Subs9;

	// Token: 0x04003E6A RID: 15978
	public string[] Subs10;

	// Token: 0x04003E6B RID: 15979
	public float[] BasementCues1;

	// Token: 0x04003E6C RID: 15980
	public float[] BasementCues10;

	// Token: 0x04003E6D RID: 15981
	public string[] BasementSubs1;

	// Token: 0x04003E6E RID: 15982
	public string[] BasementSubs10;

	// Token: 0x04003E6F RID: 15983
	public float[] HeadmasterCues1;

	// Token: 0x04003E70 RID: 15984
	public float[] HeadmasterCues2;

	// Token: 0x04003E71 RID: 15985
	public float[] HeadmasterCues3;

	// Token: 0x04003E72 RID: 15986
	public float[] HeadmasterCues4;

	// Token: 0x04003E73 RID: 15987
	public float[] HeadmasterCues5;

	// Token: 0x04003E74 RID: 15988
	public float[] HeadmasterCues6;

	// Token: 0x04003E75 RID: 15989
	public float[] HeadmasterCues7;

	// Token: 0x04003E76 RID: 15990
	public float[] HeadmasterCues8;

	// Token: 0x04003E77 RID: 15991
	public float[] HeadmasterCues9;

	// Token: 0x04003E78 RID: 15992
	public float[] HeadmasterCues10;

	// Token: 0x04003E79 RID: 15993
	public string[] HeadmasterSubs1;

	// Token: 0x04003E7A RID: 15994
	public string[] HeadmasterSubs2;

	// Token: 0x04003E7B RID: 15995
	public string[] HeadmasterSubs3;

	// Token: 0x04003E7C RID: 15996
	public string[] HeadmasterSubs4;

	// Token: 0x04003E7D RID: 15997
	public string[] HeadmasterSubs5;

	// Token: 0x04003E7E RID: 15998
	public string[] HeadmasterSubs6;

	// Token: 0x04003E7F RID: 15999
	public string[] HeadmasterSubs7;

	// Token: 0x04003E80 RID: 16000
	public string[] HeadmasterSubs8;

	// Token: 0x04003E81 RID: 16001
	public string[] HeadmasterSubs9;

	// Token: 0x04003E82 RID: 16002
	public string[] HeadmasterSubs10;
}
