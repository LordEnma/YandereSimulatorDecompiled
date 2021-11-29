using System;
using UnityEngine;
using XInputDotNetPure;

// Token: 0x0200030C RID: 780
public class HeartbrokenScript : MonoBehaviour
{
	// Token: 0x0600182C RID: 6188 RVA: 0x000E6680 File Offset: 0x000E4880
	private void Start()
	{
		this.Week = DateGlobals.Week;
		if (GameGlobals.MostRecentSlot == 0)
		{
			this.TargetAlpha[2] = 0.5f;
		}
		if (!this.Caught && !this.Noticed && this.Yandere.Bloodiness > 0f && !this.Yandere.RedPaint && !this.Yandere.Unmasked)
		{
			this.Arrested = true;
		}
		if (this.Caught)
		{
			this.Letters[0].text = "";
			this.Letters[1].text = "";
			this.Letters[2].text = "C";
			this.Letters[3].text = "A";
			this.Letters[4].text = "U";
			this.Letters[5].text = "G";
			this.Letters[6].text = "H";
			this.Letters[7].text = "T";
			this.Letters[8].text = "";
			this.Letters[9].text = "";
			this.Letters[10].text = "";
			foreach (UILabel uilabel in this.Letters)
			{
				uilabel.transform.localPosition = new Vector3(uilabel.transform.localPosition.x + 125f, uilabel.transform.localPosition.y, uilabel.transform.localPosition.z);
			}
			this.LetterID = 1;
			this.StopID = 8;
			this.NoSnap = true;
			this.SNAP.SetActive(false);
			this.Cursor.Options = 3;
		}
		else if (this.Confessed)
		{
			this.Letters[0].text = "S";
			this.Letters[1].text = "E";
			this.Letters[2].text = "N";
			this.Letters[3].text = "P";
			this.Letters[4].text = "A";
			this.Letters[5].text = "I";
			this.Letters[6].text = string.Empty;
			this.Letters[7].text = "L";
			this.Letters[8].text = "O";
			this.Letters[9].text = "S";
			this.Letters[10].text = "T";
			this.LetterID = 0;
			this.StopID = 11;
			this.NoSnap = true;
		}
		else if (this.Yandere.Attacked)
		{
			if (!this.Headmaster)
			{
				this.Letters[0].text = string.Empty;
				this.Letters[1].text = "C";
				this.Letters[2].text = "O";
				this.Letters[3].text = "M";
				this.Letters[4].text = "A";
				this.Letters[5].text = "T";
				this.Letters[6].text = "O";
				this.Letters[7].text = "S";
				this.Letters[8].text = "E";
				this.Letters[9].text = string.Empty;
				this.Letters[10].text = string.Empty;
				this.Letters[3].fontSize = 250;
				this.LetterID = 1;
				this.StopID = 9;
			}
			else
			{
				this.Letters[0].text = "?";
				this.Letters[1].text = "?";
				this.Letters[2].text = "?";
				this.Letters[3].text = "?";
				this.Letters[4].text = "?";
				this.Letters[5].text = "?";
				this.Letters[6].text = "?";
				this.Letters[7].text = "?";
				this.Letters[8].text = "?";
				this.Letters[9].text = "?";
				this.Letters[10].text = string.Empty;
				this.LetterID = 0;
				this.StopID = 10;
			}
			foreach (UILabel uilabel2 in this.Letters)
			{
				uilabel2.transform.localPosition = new Vector3(uilabel2.transform.localPosition.x + 100f, uilabel2.transform.localPosition.y, uilabel2.transform.localPosition.z);
			}
			this.SNAP.SetActive(false);
			this.Cursor.Options = 4;
			this.NoSnap = true;
		}
		else if (this.Yandere.Lost || this.ShoulderCamera.LookDown || this.ShoulderCamera.Counter || this.ShoulderCamera.ObstacleCounter)
		{
			this.Letters[0].text = "A";
			this.Letters[1].text = "P";
			this.Letters[2].text = "P";
			this.Letters[3].text = "R";
			this.Letters[4].text = "E";
			this.Letters[5].text = "H";
			this.Letters[6].text = "E";
			this.Letters[7].text = "N";
			this.Letters[8].text = "D";
			this.Letters[9].text = "E";
			this.Letters[10].text = "D";
			this.LetterID = 0;
			this.StopID = 11;
			this.NoSnap = true;
		}
		else if (this.Exposed)
		{
			this.Letters[0].text = string.Empty;
			this.Letters[1].text = string.Empty;
			this.Letters[2].text = "E";
			this.Letters[3].text = "X";
			this.Letters[4].text = "P";
			this.Letters[5].text = "O";
			this.Letters[6].text = "S";
			this.Letters[7].text = "E";
			this.Letters[8].text = "D";
			this.Letters[9].text = string.Empty;
			this.Letters[10].text = string.Empty;
			foreach (UILabel uilabel3 in this.Letters)
			{
				uilabel3.transform.localPosition = new Vector3(uilabel3.transform.localPosition.x + 100f, uilabel3.transform.localPosition.y, uilabel3.transform.localPosition.z);
			}
			this.LetterID = 1;
			this.StopID = 9;
			this.NoSnap = true;
		}
		else if (this.Arrested || (this.Yandere.Sprayed && this.Yandere.Bloodiness > 0f && !this.Yandere.RedPaint) || this.Yandere.SprayedByJournalist)
		{
			this.Letters[0].text = string.Empty;
			this.Letters[1].text = "A";
			this.Letters[2].text = "R";
			this.Letters[3].text = "R";
			this.Letters[4].text = "E";
			this.Letters[5].text = "S";
			this.Letters[6].text = "T";
			this.Letters[7].text = "E";
			this.Letters[8].text = "D";
			this.Letters[9].text = string.Empty;
			this.Letters[10].text = string.Empty;
			foreach (UILabel uilabel4 in this.Letters)
			{
				uilabel4.transform.localPosition = new Vector3(uilabel4.transform.localPosition.x + 100f, uilabel4.transform.localPosition.y, uilabel4.transform.localPosition.z);
			}
			this.LetterID = 1;
			this.StopID = 9;
			this.NoSnap = true;
		}
		else if (this.Counselor.Expelled || this.Yandere.Sprayed)
		{
			this.Letters[0].text = string.Empty;
			this.Letters[1].text = "E";
			this.Letters[2].text = "X";
			this.Letters[3].text = "P";
			this.Letters[4].text = "E";
			this.Letters[5].text = "L";
			this.Letters[6].text = "L";
			this.Letters[7].text = "E";
			this.Letters[8].text = "D";
			this.Letters[9].text = string.Empty;
			this.Letters[10].text = string.Empty;
			foreach (UILabel uilabel5 in this.Letters)
			{
				uilabel5.transform.localPosition = new Vector3(uilabel5.transform.localPosition.x + 100f, uilabel5.transform.localPosition.y, uilabel5.transform.localPosition.z);
			}
			this.LetterID = 1;
			this.StopID = 9;
			this.NoSnap = true;
		}
		else
		{
			this.LetterID = 0;
			this.StopID = 11;
		}
		this.ID = 0;
		while (this.ID < this.Letters.Length)
		{
			UILabel uilabel6 = this.Letters[this.ID];
			uilabel6.transform.localScale = new Vector3(10f, 10f, 1f);
			uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 0f);
			this.Origins[this.ID] = uilabel6.transform.localPosition;
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.Options.Length)
		{
			UILabel uilabel7 = this.Options[this.ID];
			uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, 0f);
			this.ID++;
		}
		this.ID = 0;
		this.Subtitle.color = new Color(this.Subtitle.color.r, this.Subtitle.color.g, this.Subtitle.color.b, 0f);
		if (this.Noticed)
		{
			this.Background.color = new Color(this.Background.color.r, this.Background.color.g, this.Background.color.b, 0f);
			this.Ground.color = new Color(this.Ground.color.r, this.Ground.color.g, this.Ground.color.b, 0f);
		}
		else
		{
			base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, 100f, base.transform.parent.transform.position.z);
		}
		if (this.Cursor.SnappedYandere != null)
		{
			int num = 0;
			WeaponScript[] weapons = this.Cursor.SnappedYandere.Weapons;
			for (int i = 0; i < weapons.Length; i++)
			{
				if (weapons[i] != null)
				{
					num++;
				}
			}
			if (num == 0 || this.NoSnap || this.Yandere.Police.GameOver || this.Yandere.StudentManager.Clock.HourTime >= 18f || this.Yandere.transform.position.y < -1f)
			{
				this.SNAP.SetActive(false);
				this.Cursor.Options = 4;
			}
			this.Clock.StopTime = true;
		}
		if (GameGlobals.Eighties)
		{
			base.gameObject.GetComponent<AudioSource>().clip = this.EightiesGameOver;
			if (this.Arial != null)
			{
				this.Subtitle.trueTypeFont = this.Arial;
				this.Subtitle.applyGradient = false;
				this.Subtitle.color = new Color(1f, 1f, 0f, 1f);
				this.Subtitle.fontStyle = FontStyle.Bold;
			}
		}
	}

	// Token: 0x0600182D RID: 6189 RVA: 0x000E7498 File Offset: 0x000E5698
	private void Update()
	{
		if (Input.GetKeyDown("m"))
		{
			base.gameObject.GetComponent<AudioSource>().Stop();
		}
		this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0f, Time.deltaTime);
		if (this.VibrationTimer == 0f)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
		}
		if (this.Noticed)
		{
			this.Ground.transform.eulerAngles = new Vector3(90f, 0f, 0f);
			this.Ground.transform.position = new Vector3(this.Ground.transform.position.x, this.Yandere.transform.position.y, this.Ground.transform.position.z);
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 3f)
		{
			if (this.Phase == 1)
			{
				if (this.Noticed)
				{
					this.UpdateSubtitle();
				}
				this.Phase += ((this.Subtitle.color.a > 0f) ? 1 : 2);
			}
			else if (this.Phase == 2)
			{
				if (Input.GetButtonDown("A"))
				{
					this.AudioTimer = 100f;
				}
				this.AudioTimer += Time.deltaTime;
				if (this.AudioTimer > this.Subtitle.GetComponent<AudioSource>().clip.length)
				{
					this.Phase++;
				}
			}
		}
		else if (this.Yandere != null && this.Yandere.Unmasked)
		{
			this.Yandere.ShoulderCamera.transform.position = Vector3.Lerp(this.Yandere.ShoulderCamera.transform.position, this.Yandere.ShoulderCamera.NoticedPOV.position, Time.deltaTime * 1f);
			this.Yandere.ShoulderCamera.transform.LookAt(this.Yandere.ShoulderCamera.NoticedFocus);
			if (Vector3.Distance(this.Yandere.transform.position, this.Yandere.Senpai.position) < 1.25f)
			{
				this.Yandere.MyController.Move(this.Yandere.transform.forward * (Time.deltaTime * -1f));
			}
			if (this.Yandere.CharacterAnimation["f02_down_22"].time >= this.Yandere.CharacterAnimation["f02_down_22"].length)
			{
				this.Yandere.CharacterAnimation.CrossFade("f02_down_23");
			}
		}
		if (this.Background.color.a < 1f)
		{
			this.Background.color = new Color(this.Background.color.r, this.Background.color.g, this.Background.color.b, this.Background.color.a + Time.deltaTime);
			this.Ground.color = new Color(this.Ground.color.r, this.Ground.color.g, this.Ground.color.b, this.Ground.color.a + Time.deltaTime);
			if (this.Background.color.a >= 1f)
			{
				this.ConfessionUICamera.enabled = false;
				this.MainCamera.enabled = false;
			}
		}
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.LetterID < this.StopID)
		{
			UILabel uilabel = this.Letters[this.LetterID];
			uilabel.transform.localScale = Vector3.MoveTowards(uilabel.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 100f);
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, uilabel.color.a + Time.deltaTime * 10f);
			if (uilabel.transform.localScale == new Vector3(1f, 1f, 1f))
			{
				component.PlayOneShot(this.Slam);
				GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
				this.VibrationTimer = 0.1f;
				this.LetterID++;
				if (this.LetterID == this.StopID)
				{
					this.ID = 0;
				}
			}
		}
		else if (this.Phase == 3)
		{
			if (this.Options[0].color.a == 0f)
			{
				this.Subtitle.color = new Color(this.Subtitle.color.r, this.Subtitle.color.g, this.Subtitle.color.b, 0f);
				component.Play();
			}
			if (this.ID < this.Options.Length)
			{
				UILabel uilabel2 = this.Options[this.ID];
				uilabel2.alpha += Time.deltaTime * 5f;
				if (uilabel2.color.a >= this.TargetAlpha[this.ID])
				{
					uilabel2.alpha = this.TargetAlpha[this.ID];
					this.ID++;
				}
			}
		}
		if (!this.Freeze)
		{
			this.ShakeID = 0;
			while (this.ShakeID < this.Letters.Length)
			{
				UILabel uilabel3 = this.Letters[this.ShakeID];
				Vector3 vector = this.Origins[this.ShakeID];
				uilabel3.transform.localPosition = new Vector3(vector.x + UnityEngine.Random.Range(-5f, 5f), vector.y + UnityEngine.Random.Range(-5f, 5f), uilabel3.transform.localPosition.z);
				this.ShakeID++;
			}
		}
		this.GrowID = 0;
		while (this.GrowID < 5)
		{
			UILabel uilabel4 = this.Options[this.GrowID];
			uilabel4.transform.localScale = Vector3.Lerp(uilabel4.transform.localScale, (this.Cursor.Selected - 1 != this.GrowID) ? new Vector3(0.5f, 0.5f, 0.5f) : new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.GrowID++;
		}
	}

	// Token: 0x0600182E RID: 6190 RVA: 0x000E7BB8 File Offset: 0x000E5DB8
	private void UpdateSubtitle()
	{
		StudentScript component = this.Yandere.Senpai.GetComponent<StudentScript>();
		if (component != null && !component.Teacher && this.Yandere.Noticed)
		{
			this.Subtitle.color = new Color(this.Subtitle.color.r, this.Subtitle.color.g, this.Subtitle.color.b, 1f);
			GameOverType gameOverCause = component.GameOverCause;
			int num = 0;
			if (gameOverCause == GameOverType.Stalking)
			{
				num = 4;
			}
			else if (gameOverCause == GameOverType.Insanity)
			{
				num = 3;
			}
			else if (gameOverCause == GameOverType.Weapon)
			{
				num = 1;
			}
			else if (gameOverCause == GameOverType.Murder)
			{
				num = 5;
			}
			else if (gameOverCause == GameOverType.Blood)
			{
				num = 2;
			}
			else if (gameOverCause == GameOverType.Lewd)
			{
				num = 6;
			}
			this.Subtitle.text = this.NoticedLines[num];
			this.Subtitle.GetComponent<AudioSource>().clip = this.NoticedClips[num];
			this.Subtitle.GetComponent<AudioSource>().Play();
			return;
		}
		if (this.Headmaster)
		{
			this.Subtitle.color = new Color(this.Subtitle.color.r, this.Subtitle.color.g, this.Subtitle.color.b, 1f);
			if (!this.Yandere.StudentManager.Eighties)
			{
				this.Subtitle.text = this.NoticedLines[8];
				this.Subtitle.GetComponent<AudioSource>().clip = this.NoticedClips[8];
			}
			else
			{
				this.Subtitle.text = this.NoticedLines[9];
				this.Subtitle.GetComponent<AudioSource>().clip = this.NoticedClips[9];
			}
			this.Subtitle.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x000E7D84 File Offset: 0x000E5F84
	public void Darken()
	{
		for (int i = 0; i < this.Letters.Length; i++)
		{
			if (this.Letters[i].color.a > 1f)
			{
				this.Letters[i].color = new Color(1f, 0f, 0f, 1f);
			}
			this.Letters[i].color = new Color(1f, 0f, 0f, this.Letters[i].color.a - 0.05882353f);
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.Options[i].color.a > 1f)
			{
				this.Options[i].color = new Color(this.Options[i].color.r, this.Options[i].color.g, this.Options[i].color.b, 1f);
			}
			this.Options[i].color = new Color(this.Options[i].color.r, this.Options[i].color.g, this.Options[i].color.b, this.Options[i].color.a - 0.05882353f);
		}
	}

	// Token: 0x04002377 RID: 9079
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x04002378 RID: 9080
	public HeartbrokenCursorScript Cursor;

	// Token: 0x04002379 RID: 9081
	public CounselorScript Counselor;

	// Token: 0x0400237A RID: 9082
	public YandereScript Yandere;

	// Token: 0x0400237B RID: 9083
	public ClockScript Clock;

	// Token: 0x0400237C RID: 9084
	public AudioListener Listener;

	// Token: 0x0400237D RID: 9085
	public AudioClip[] NoticedClips;

	// Token: 0x0400237E RID: 9086
	public string[] NoticedLines;

	// Token: 0x0400237F RID: 9087
	public UILabel[] Letters;

	// Token: 0x04002380 RID: 9088
	public UILabel[] Options;

	// Token: 0x04002381 RID: 9089
	public Vector3[] Origins;

	// Token: 0x04002382 RID: 9090
	public UISprite Background;

	// Token: 0x04002383 RID: 9091
	public UISprite Ground;

	// Token: 0x04002384 RID: 9092
	public Camera ConfessionUICamera;

	// Token: 0x04002385 RID: 9093
	public Camera MainCamera;

	// Token: 0x04002386 RID: 9094
	public UILabel Subtitle;

	// Token: 0x04002387 RID: 9095
	public GameObject SNAP;

	// Token: 0x04002388 RID: 9096
	public AudioClip EightiesGameOver;

	// Token: 0x04002389 RID: 9097
	public AudioClip Slam;

	// Token: 0x0400238A RID: 9098
	public bool Headmaster;

	// Token: 0x0400238B RID: 9099
	public bool Confessed;

	// Token: 0x0400238C RID: 9100
	public bool Arrested;

	// Token: 0x0400238D RID: 9101
	public bool Exposed;

	// Token: 0x0400238E RID: 9102
	public bool Noticed = true;

	// Token: 0x0400238F RID: 9103
	public bool Freeze;

	// Token: 0x04002390 RID: 9104
	public bool NoSnap;

	// Token: 0x04002391 RID: 9105
	public bool Caught;

	// Token: 0x04002392 RID: 9106
	public float VibrationTimer;

	// Token: 0x04002393 RID: 9107
	public float AudioTimer;

	// Token: 0x04002394 RID: 9108
	public float Timer;

	// Token: 0x04002395 RID: 9109
	public int Phase = 1;

	// Token: 0x04002396 RID: 9110
	public int Week;

	// Token: 0x04002397 RID: 9111
	public int LetterID;

	// Token: 0x04002398 RID: 9112
	public int ShakeID;

	// Token: 0x04002399 RID: 9113
	public int GrowID;

	// Token: 0x0400239A RID: 9114
	public int StopID;

	// Token: 0x0400239B RID: 9115
	public int ID;

	// Token: 0x0400239C RID: 9116
	public float[] TargetAlpha;

	// Token: 0x0400239D RID: 9117
	public Font Arial;
}
