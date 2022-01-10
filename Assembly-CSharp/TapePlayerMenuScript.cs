using System;
using UnityEngine;

// Token: 0x02000463 RID: 1123
public class TapePlayerMenuScript : MonoBehaviour
{
	// Token: 0x06001E70 RID: 7792 RVA: 0x001A94B4 File Offset: 0x001A76B4
	private void Start()
	{
		this.List.transform.localPosition = new Vector3(-955f, this.List.transform.localPosition.y, this.List.transform.localPosition.z);
		this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, 100f, this.TimeBar.localPosition.z);
		this.Subtitle.text = string.Empty;
		this.TapePlayerCamera.position = new Vector3(-26.15f, this.TapePlayerCamera.position.y, 5.35f);
	}

	// Token: 0x06001E71 RID: 7793 RVA: 0x001A9574 File Offset: 0x001A7774
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

	// Token: 0x06001E72 RID: 7794 RVA: 0x001AABCC File Offset: 0x001A8DCC
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

	// Token: 0x06001E73 RID: 7795 RVA: 0x001AAD68 File Offset: 0x001A8F68
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

	// Token: 0x04003E82 RID: 16002
	public StudentManagerScript StudentManager;

	// Token: 0x04003E83 RID: 16003
	public InputManagerScript InputManager;

	// Token: 0x04003E84 RID: 16004
	public TapePlayerScript TapePlayer;

	// Token: 0x04003E85 RID: 16005
	public PromptBarScript PromptBar;

	// Token: 0x04003E86 RID: 16006
	public Animation TapePlayerAnim;

	// Token: 0x04003E87 RID: 16007
	public AudioSource MyAudio;

	// Token: 0x04003E88 RID: 16008
	public GameObject Jukebox;

	// Token: 0x04003E89 RID: 16009
	public Transform TapePlayerCamera;

	// Token: 0x04003E8A RID: 16010
	public Transform Highlight;

	// Token: 0x04003E8B RID: 16011
	public Transform TimeBar;

	// Token: 0x04003E8C RID: 16012
	public Transform List;

	// Token: 0x04003E8D RID: 16013
	public AudioClip[] Recordings;

	// Token: 0x04003E8E RID: 16014
	public AudioClip[] BasementRecordings;

	// Token: 0x04003E8F RID: 16015
	public AudioClip[] HeadmasterRecordings;

	// Token: 0x04003E90 RID: 16016
	public UILabel[] TapeLabels;

	// Token: 0x04003E91 RID: 16017
	public GameObject[] NewIcons;

	// Token: 0x04003E92 RID: 16018
	public AudioClip TapeStop;

	// Token: 0x04003E93 RID: 16019
	public string CurrentTime;

	// Token: 0x04003E94 RID: 16020
	public string ClipLength;

	// Token: 0x04003E95 RID: 16021
	public bool Listening;

	// Token: 0x04003E96 RID: 16022
	public bool Show;

	// Token: 0x04003E97 RID: 16023
	public UILabel HeaderLabel;

	// Token: 0x04003E98 RID: 16024
	public UILabel Subtitle;

	// Token: 0x04003E99 RID: 16025
	public UILabel Label;

	// Token: 0x04003E9A RID: 16026
	public UISprite Bar;

	// Token: 0x04003E9B RID: 16027
	public int TotalTapes = 10;

	// Token: 0x04003E9C RID: 16028
	public int Category = 1;

	// Token: 0x04003E9D RID: 16029
	public int Selected = 1;

	// Token: 0x04003E9E RID: 16030
	public int Phase = 1;

	// Token: 0x04003E9F RID: 16031
	public float RoundedTime;

	// Token: 0x04003EA0 RID: 16032
	public float ResumeTime;

	// Token: 0x04003EA1 RID: 16033
	public float Timer;

	// Token: 0x04003EA2 RID: 16034
	public float[] Cues1;

	// Token: 0x04003EA3 RID: 16035
	public float[] Cues2;

	// Token: 0x04003EA4 RID: 16036
	public float[] Cues3;

	// Token: 0x04003EA5 RID: 16037
	public float[] Cues4;

	// Token: 0x04003EA6 RID: 16038
	public float[] Cues5;

	// Token: 0x04003EA7 RID: 16039
	public float[] Cues6;

	// Token: 0x04003EA8 RID: 16040
	public float[] Cues7;

	// Token: 0x04003EA9 RID: 16041
	public float[] Cues8;

	// Token: 0x04003EAA RID: 16042
	public float[] Cues9;

	// Token: 0x04003EAB RID: 16043
	public float[] Cues10;

	// Token: 0x04003EAC RID: 16044
	public string[] Subs1;

	// Token: 0x04003EAD RID: 16045
	public string[] Subs2;

	// Token: 0x04003EAE RID: 16046
	public string[] Subs3;

	// Token: 0x04003EAF RID: 16047
	public string[] Subs4;

	// Token: 0x04003EB0 RID: 16048
	public string[] Subs5;

	// Token: 0x04003EB1 RID: 16049
	public string[] Subs6;

	// Token: 0x04003EB2 RID: 16050
	public string[] Subs7;

	// Token: 0x04003EB3 RID: 16051
	public string[] Subs8;

	// Token: 0x04003EB4 RID: 16052
	public string[] Subs9;

	// Token: 0x04003EB5 RID: 16053
	public string[] Subs10;

	// Token: 0x04003EB6 RID: 16054
	public float[] BasementCues1;

	// Token: 0x04003EB7 RID: 16055
	public float[] BasementCues10;

	// Token: 0x04003EB8 RID: 16056
	public string[] BasementSubs1;

	// Token: 0x04003EB9 RID: 16057
	public string[] BasementSubs10;

	// Token: 0x04003EBA RID: 16058
	public float[] HeadmasterCues1;

	// Token: 0x04003EBB RID: 16059
	public float[] HeadmasterCues2;

	// Token: 0x04003EBC RID: 16060
	public float[] HeadmasterCues3;

	// Token: 0x04003EBD RID: 16061
	public float[] HeadmasterCues4;

	// Token: 0x04003EBE RID: 16062
	public float[] HeadmasterCues5;

	// Token: 0x04003EBF RID: 16063
	public float[] HeadmasterCues6;

	// Token: 0x04003EC0 RID: 16064
	public float[] HeadmasterCues7;

	// Token: 0x04003EC1 RID: 16065
	public float[] HeadmasterCues8;

	// Token: 0x04003EC2 RID: 16066
	public float[] HeadmasterCues9;

	// Token: 0x04003EC3 RID: 16067
	public float[] HeadmasterCues10;

	// Token: 0x04003EC4 RID: 16068
	public string[] HeadmasterSubs1;

	// Token: 0x04003EC5 RID: 16069
	public string[] HeadmasterSubs2;

	// Token: 0x04003EC6 RID: 16070
	public string[] HeadmasterSubs3;

	// Token: 0x04003EC7 RID: 16071
	public string[] HeadmasterSubs4;

	// Token: 0x04003EC8 RID: 16072
	public string[] HeadmasterSubs5;

	// Token: 0x04003EC9 RID: 16073
	public string[] HeadmasterSubs6;

	// Token: 0x04003ECA RID: 16074
	public string[] HeadmasterSubs7;

	// Token: 0x04003ECB RID: 16075
	public string[] HeadmasterSubs8;

	// Token: 0x04003ECC RID: 16076
	public string[] HeadmasterSubs9;

	// Token: 0x04003ECD RID: 16077
	public string[] HeadmasterSubs10;
}
