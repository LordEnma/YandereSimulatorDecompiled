using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000102 RID: 258
public class BusStopScript : MonoBehaviour
{
	// Token: 0x06000A94 RID: 2708 RVA: 0x0005EE6C File Offset: 0x0005D06C
	private void Start()
	{
		this.Renderer.material.color = new Color(0f, 0f, 0f, 1f);
		base.transform.position = new Vector3(0.375f, 0.5f, 2.5f);
		base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
		this.SecondAmai.gameObject.SetActive(false);
		this.ThirdAmai.gameObject.SetActive(false);
		this.SenpaiAnim["sadFace_00"].layer = 1;
		this.SenpaiAnim.Play("sadFace_00");
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 1.2f;
		settings.aperture = 5.6f;
		this.Profile.depthOfField.settings = settings;
		this.Subtitle.text = "";
		if (GameGlobals.RivalEliminationID == 0)
		{
			GameGlobals.RivalEliminationID = 1;
			GameGlobals.SpecificEliminationID = 1;
			GameGlobals.NonlethalElimination = false;
		}
		this.RivalEliminationID = GameGlobals.RivalEliminationID;
		Debug.Log("GameGlobals.RivalEliminationID is: " + GameGlobals.RivalEliminationID.ToString());
	}

	// Token: 0x06000A95 RID: 2709 RVA: 0x0005EFB4 File Offset: 0x0005D1B4
	private void Update()
	{
		this.SkipTimer += Time.deltaTime;
		if (this.SkipTimer > 5f)
		{
			this.SkipPanel.alpha -= Time.deltaTime;
		}
		if (this.EndEarly)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
			this.SkipPanel.alpha -= Time.deltaTime;
			this.Renderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
			this.Subtitle.text = "";
			if (this.Alpha == 1f)
			{
				this.ExitCutscene();
			}
		}
		else if (Input.GetButton("X"))
		{
			this.SkipPanel.alpha = 1f;
			this.SkipTimer = 0f;
			this.SkipCircle.fillAmount -= Time.deltaTime;
			if (this.SkipCircle.fillAmount == 0f)
			{
				this.EndEarly = true;
			}
		}
		else
		{
			this.SkipCircle.fillAmount = 1f;
		}
		this.Audio.pitch = Time.timeScale;
		if (this.Phase > 1 && this.Phase < 4)
		{
			base.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
			this.Speed += Time.deltaTime * 0.1f;
			this.Rotation = Mathf.Lerp(this.Rotation, -150f, Time.deltaTime * this.Speed);
			base.transform.eulerAngles = new Vector3(0f, this.Rotation, 0f);
		}
		if (this.Phase > 7 && this.Phase < 11)
		{
			base.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
		}
		if (this.Phase == 1)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
			this.Renderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
			this.MeetingJukebox.volume = (1f - this.Alpha) * 0.1f;
			if (this.Alpha == 0f)
			{
				if (this.SpeechID == 0)
				{
					this.Subtitle.text = this.Subtitles[0];
					this.Audio.clip = this.Speech[0];
					this.Audio.Play();
					this.SpeechID++;
				}
				else
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 6f)
					{
						this.Subtitle.text = "";
					}
				}
			}
			if (this.SenpaiRenderer.sharedMesh != this.CasualMesh)
			{
				this.SenpaiRenderer.sharedMesh = this.CasualMesh;
				this.SenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
				this.SenpaiRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.Cosmetic.SkinColor];
				this.SenpaiRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
			}
			if (this.NewSenpaiRenderer.sharedMesh != this.CasualMesh)
			{
				this.NewSenpaiRenderer.sharedMesh = this.CasualMesh;
				this.NewSenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
				this.NewSenpaiRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.Cosmetic.SkinColor];
				this.NewSenpaiRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
			}
			if (this.BakerSenpaiRenderer.sharedMesh != this.CasualMesh)
			{
				this.BakerSenpaiRenderer.sharedMesh = this.CasualMesh;
				this.BakerSenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
				this.BakerSenpaiRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.Cosmetic.SkinColor];
				this.BakerSenpaiRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
			}
			base.transform.position += new Vector3(0f, 0f, this.Speed * Time.deltaTime);
			this.Amai.transform.position -= new Vector3(1f * Time.deltaTime, 0f, 0f);
			if (this.Amai.transform.position.x < -2f)
			{
				this.SecondAmai.gameObject.SetActive(true);
				if (this.SecondAmai["f02_motherRecipe_00"].speed == 1f)
				{
					this.SecondAmai["f02_motherRecipe_00"].speed = 0.66666f;
					this.SecondAmai["f02_motherRecipe_00"].time = 16f;
					this.SecondAmai["f02_carry_00"].layer = 1;
					this.SecondAmai.Play("f02_carry_00");
				}
			}
			if (this.Amai.transform.position.x < -10f)
			{
				this.UpdateDOF(1f);
				base.transform.position = new Vector3(0.55f, 1f, 1.55f);
				base.transform.eulerAngles = new Vector3(0f, -135f, 0f);
				this.SenpaiAnim.transform.parent.gameObject.SetActive(false);
				this.SecondAmai.gameObject.SetActive(false);
				this.NewSenpaiAnim.gameObject.SetActive(true);
				this.NewAmaiAnim.gameObject.SetActive(true);
				this.Amai.gameObject.SetActive(false);
				this.Rotation = -125f;
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[1];
				this.Audio.clip = this.Speech[1];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 5f)
			{
				this.CupcakeBox.transform.localPosition = Vector3.MoveTowards(this.CupcakeBox.transform.localPosition, new Vector3(-0.02f, 0.05f, 0.25f), Time.deltaTime * 0.1f);
			}
			else if (this.Timer > 4f)
			{
				if (this.CupcakeBox.parent != this.Hips)
				{
					this.CupcakeBox.parent = this.Hips;
					this.RotationX = this.CupcakeBox.transform.localEulerAngles.x;
					this.RotationY = this.CupcakeBox.transform.localEulerAngles.y;
					this.RotationZ = this.CupcakeBox.transform.localEulerAngles.z;
				}
				this.CupcakeBox.transform.localPosition = Vector3.MoveTowards(this.CupcakeBox.transform.localPosition, new Vector3(-0.05f, 0.05f, 0.25f), Time.deltaTime * 0.25f);
				this.RotationX = Mathf.MoveTowards(this.RotationX, 375f, Time.deltaTime * 90f);
				this.RotationY = Mathf.MoveTowards(this.RotationY, 360f, Time.deltaTime * 90f);
				this.RotationZ = Mathf.MoveTowards(this.RotationZ, 0f, Time.deltaTime * 90f);
				this.CupcakeBox.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
			}
			if (this.Timer > 6f)
			{
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f)
			{
				this.Subtitle.text = this.Subtitles[2];
			}
			if (this.Timer > 7.5f)
			{
				this.UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, 150f, 0f);
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[3];
				this.Audio.clip = this.Speech[2];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 6f)
			{
				this.UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[4];
				this.Audio.clip = this.Speech[3];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 2f && this.SpeechID == 1)
			{
				this.Subtitle.text = this.Subtitles[5];
				this.SpeechID++;
			}
			if (this.Timer > 6.75f && this.SpeechID == 2)
			{
				this.Subtitle.text = this.Subtitles[6];
				this.SpeechID++;
			}
			if (this.Timer > 16.75f && this.SpeechID == 3)
			{
				this.Subtitle.text = this.Subtitles[7];
				this.SpeechID++;
			}
			if (this.Timer > 20f)
			{
				this.UpdateDOF(0.75f);
				base.transform.position = new Vector3(0f, 1f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				this.UtilityPole.SetActive(false);
				this.NewSenpaiAnim["SenpaiMeet_1"].time = this.NewSenpaiAnim["SenpaiMeet_1"].length - 4f;
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Speed = 0f;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 6)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.EliminationDescriptions[this.RivalEliminationID];
				this.Audio.clip = this.OsanaEliminations[this.RivalEliminationID];
				this.Audio.Play();
				this.TimeLimit = this.OsanaEliminations[this.RivalEliminationID].length;
				this.SpeechID++;
			}
			if (this.NewSenpaiAnim["SenpaiMeet_1"].time >= this.NewSenpaiAnim["SenpaiMeet_1"].length)
			{
				this.NewSenpaiAnim.CrossFade("SenpaiMeet_2");
				this.NewAmaiAnim.CrossFade("AmaiMeet_2");
			}
			if (this.ShockPhase == 0)
			{
				if (this.Timer > 9.5f)
				{
					this.NewAmaiAnim.CrossFade("AmaiShock_1");
					this.ShockPhase++;
				}
			}
			else if (this.ShockPhase == 1)
			{
				if (this.NewAmaiAnim["AmaiShock_1"].time >= this.NewAmaiAnim["AmaiShock_1"].length)
				{
					this.NewAmaiAnim.CrossFade("AmaiShock_2");
					this.ShockPhase = 2;
				}
			}
			else if (this.ShockPhase == 2 && this.Timer > this.TimeLimit + 4f)
			{
				this.NewAmaiAnim["AmaiShock_1"].time = 0f;
				this.NewAmaiAnim["AmaiShock_1"].speed = 0f;
				this.NewAmaiAnim.CrossFade("AmaiShock_1", 2f);
				this.ShockPhase = 3;
			}
			base.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
			if (this.Timer > this.TimeLimit + 6f)
			{
				this.UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				this.CupcakeBox.localPosition = new Vector3(-0.025f, 0.05f, 0.25f);
				this.CupcakeBox.localEulerAngles = new Vector3(15f, 0f, 0f);
				this.CupcakeBox.localScale = new Vector3(0.133333f, 0.15f, 0.15f);
				this.NewSenpaiAnim.CrossFade("SenpaiMeet_3");
				this.NewAmaiAnim.CrossFade("AmaiMeet_3");
				this.UtilityPole.SetActive(true);
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1.5f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[8];
				this.Audio.clip = this.Speech[4];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 13f)
			{
				this.UpdateDOF(1f);
				base.transform.position = new Vector3(0f, 1f, 2f);
				base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				this.NewSenpaiAnim.transform.parent.transform.position = new Vector3(-0.1f, 0f, 0f);
				this.NewSenpaiAnim["SenpaiMeet_3"].time += 0.25f;
				this.NewAmaiAnim["AmaiMeet_3"].time += 0.25f;
				this.Rotation = -90f;
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 8)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[9];
				this.Audio.clip = this.Speech[5];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.NewAmaiAnim["AmaiMeet_3"].time > 15.75f)
			{
				this.Rotation = Mathf.MoveTowards(this.Rotation, -20.5f, Time.deltaTime * 100f);
				this.DonutLid.localEulerAngles = new Vector3(this.Rotation, 180f, 180f);
			}
			if (this.Timer > 8.5f)
			{
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 9)
		{
			base.transform.Translate(0f, 0f, Time.deltaTime * -0.01f);
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[10];
				this.Audio.clip = this.Speech[6];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 5f && this.SpeechID == 1)
			{
				this.Subtitle.text = this.Subtitles[11];
				this.Audio.clip = this.Speech[7];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.NewSenpaiAnim["SenpaiMeet_3"].time > 28f)
			{
				if (this.Cupcake.parent != this.SenpaiLeftHand)
				{
					this.Cupcake.parent = this.SenpaiLeftHand;
				}
				this.Cupcake.localPosition = Vector3.MoveTowards(this.Cupcake.localPosition, new Vector3(-0.02f, -0.02f, 0f), Time.deltaTime);
				this.Cupcake.transform.localEulerAngles = new Vector3(-15f, -15f, 0f);
			}
			if (this.Timer > 8.5f)
			{
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 10)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[12];
				this.Audio.clip = this.Speech[8];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 4.5f && this.SpeechID == 1)
			{
				this.Subtitle.text = this.Subtitles[13];
				this.Audio.clip = this.Speech[9];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.NewAmaiAnim["AmaiMeet_3"].time > 35.75f)
			{
				this.Rotation = Mathf.MoveTowards(this.Rotation, -90f, Time.deltaTime * 100f);
				this.DonutLid.localEulerAngles = new Vector3(this.Rotation, 180f, 180f);
			}
			if (this.Timer > 9.5f)
			{
				this.UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				this.CupcakeBox.localPosition = new Vector3(-0.025f, 0.0375f, 0.25f);
				this.CupcakeBox.localEulerAngles = new Vector3(15f, 0f, 0f);
				this.NewSenpaiAnim.transform.parent.transform.position = new Vector3(0.1f, 0f, 0f);
				this.Subtitle.text = this.Subtitles[14];
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 11)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 9f)
			{
				this.UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, 150f, 0f);
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 12)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[15];
				this.Audio.clip = this.Speech[10];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 7f)
			{
				this.UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 13)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[16];
				this.Audio.clip = this.Speech[11];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 6.5f)
			{
				this.UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, 150f, 0f);
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 14)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f && this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[17];
				this.Audio.clip = this.Speech[12];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.Timer > 11.5f)
			{
				this.UpdateDOF(0.66666f);
				base.transform.position = new Vector3(0f, 1f, 1.5f);
				base.transform.eulerAngles = new Vector3(0f, -150f, 0f);
				this.CupcakeBox.localPosition = new Vector3(-0.025f, 0.0375f, 0.25f);
				this.CupcakeBox.localEulerAngles = new Vector3(15f, 0f, 0f);
				this.Subtitle.text = "";
				this.SpeechID = 0;
				this.Alpha = 0f;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 15)
		{
			if (this.SpeechID == 0)
			{
				this.Subtitle.text = this.Subtitles[18];
				this.Audio.clip = this.Speech[13];
				this.Audio.Play();
				this.SpeechID++;
			}
			if (this.NewAmaiAnim["AmaiMeet_3"].time > this.NewAmaiAnim["AmaiMeet_3"].length - 2f)
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
				this.Renderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
				this.MeetingJukebox.volume = (1f - this.Alpha) * 0.2f;
				this.Subtitle.text = "";
				if (this.Alpha == 1f)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						this.Phase = 20;
					}
				}
			}
		}
		else if (this.Phase == 20)
		{
			base.transform.position = new Vector3(-0.75f, 1.1f, 7.75f);
			base.transform.eulerAngles = new Vector3(0f, 30f, 0f);
			this.Renderer.material.color = new Color(0f, 0f, 0f, 1f);
			this.Alpha = 1f;
			this.InBakery = true;
			this.BakerySenpai.transform.position = new Vector3(-0.5f, 0f, 9f);
			this.BakeryAmai.transform.position = new Vector3(0.5f, 0f, 9f);
			this.InfoChan.transform.position = new Vector3(-1.925f, 0f, 6.4f);
			this.BakerySenpai.Play();
			this.BakeryAmai.Play();
			this.DoomJukebox.Play();
			this.UpdateDOF(1.2f);
			this.Speed = 0f;
			this.Timer = 0f;
			this.Phase++;
		}
		else if (this.Phase == 21)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.5f);
			this.Renderer.material.color = new Color(0f, 0f, 0f, this.Alpha);
			this.Timer += Time.deltaTime;
			if (this.Timer > 13.5f)
			{
				this.LipValue = this.SenpaiLip[0].localPosition.y;
				this.Smile = true;
			}
			if (this.Timer > 15f)
			{
				this.Speed += Time.deltaTime * 0.1f;
			}
			this.BakeryFocus = Mathf.Lerp(this.BakeryFocus, 1.5f, this.Speed * Time.deltaTime);
			this.UpdateDOF(1.2f);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.939f, 1.4f, 5.69f), this.Speed * Time.deltaTime);
			if (this.Speed > 1f)
			{
				this.InfoChan.CrossFade("f02_infoSnapPhoto_00", 1f);
			}
			if (this.Timer > 30.5f)
			{
				this.Alpha = 1f;
			}
			if (this.BakerySenpai["bakeryTalk_00"].time >= this.BakerySenpai["bakeryTalk_00"].length - 1f)
			{
				if (this.Alpha < 1f)
				{
					this.ExtraTimer += Time.deltaTime;
				}
				this.BakerySenpai.CrossFade("carefreeTalk_02", 1f);
				this.BakeryAmai.CrossFade("f02_carefreeTalk_02", 1f);
				this.BakerySenpai["f02_smile_00"].layer = 1;
				this.BakerySenpai.Play("f02_smile_00");
			}
			if (this.Timer > 35f)
			{
				this.ExitCutscene();
			}
		}
		this.MeetingJukebox.pitch = Time.timeScale;
		this.DoomJukebox.pitch = Time.timeScale;
	}

	// Token: 0x06000A96 RID: 2710 RVA: 0x00060EEC File Offset: 0x0005F0EC
	private void LateUpdate()
	{
		this.SenpaiBrow[0].localPosition = new Vector3(-0.025f, 0.025f, 0f);
		this.SenpaiBrow[0].localEulerAngles = new Vector3(0f, 0f, 22.5f);
		this.SenpaiBrow[1].localPosition = new Vector3(0.025f, 0.025f, 0f);
		this.SenpaiBrow[1].localEulerAngles = new Vector3(0f, 0f, -22.5f);
		if (this.Smile)
		{
			this.Strength += Time.deltaTime;
			this.LipValue = Mathf.Lerp(this.LipValue, -0.06f, Time.deltaTime * this.Strength);
			this.SenpaiLip[0].localPosition = new Vector3(this.SenpaiLip[0].localPosition.x, this.LipValue, this.SenpaiLip[0].localPosition.z);
			this.SenpaiLip[1].localPosition = new Vector3(this.SenpaiLip[1].localPosition.x, this.LipValue, this.SenpaiLip[1].localPosition.z);
		}
	}

	// Token: 0x06000A97 RID: 2711 RVA: 0x00061034 File Offset: 0x0005F234
	private void UpdateDOF(float Focus)
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		if (this.CloseUp)
		{
			settings.focusDistance = Focus;
		}
		else if (this.TreeShot)
		{
			settings.focusDistance = Focus;
		}
		else if (this.InBakery)
		{
			settings.focusDistance = Focus;
		}
		else
		{
			settings.focusDistance = Focus;
		}
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06000A98 RID: 2712 RVA: 0x000610A9 File Offset: 0x0005F2A9
	private void ExitCutscene()
	{
		DateGlobals.Week = 2;
		DateGlobals.PassDays = 1;
		DateGlobals.Weekday = DayOfWeek.Saturday;
		SceneManager.LoadScene("CalendarScene");
	}

	// Token: 0x04000C6B RID: 3179
	public PostProcessingProfile Profile;

	// Token: 0x04000C6C RID: 3180
	public RiggedAccessoryAttacher BakerAttacher;

	// Token: 0x04000C6D RID: 3181
	public RiggedAccessoryAttacher Attacher;

	// Token: 0x04000C6E RID: 3182
	public SkinnedMeshRenderer BakerSenpaiRenderer;

	// Token: 0x04000C6F RID: 3183
	public SkinnedMeshRenderer NewSenpaiRenderer;

	// Token: 0x04000C70 RID: 3184
	public SkinnedMeshRenderer SenpaiRenderer;

	// Token: 0x04000C71 RID: 3185
	public CosmeticScript Cosmetic;

	// Token: 0x04000C72 RID: 3186
	public Texture CasualClothes;

	// Token: 0x04000C73 RID: 3187
	public MeshRenderer Renderer;

	// Token: 0x04000C74 RID: 3188
	public Animation SenpaiAnim;

	// Token: 0x04000C75 RID: 3189
	public AudioSource MeetingJukebox;

	// Token: 0x04000C76 RID: 3190
	public AudioSource DoomJukebox;

	// Token: 0x04000C77 RID: 3191
	public UILabel Subtitle;

	// Token: 0x04000C78 RID: 3192
	public UISprite SkipCircle;

	// Token: 0x04000C79 RID: 3193
	public UIPanel SkipPanel;

	// Token: 0x04000C7A RID: 3194
	public Animation BakerySenpai;

	// Token: 0x04000C7B RID: 3195
	public Animation BakeryAmai;

	// Token: 0x04000C7C RID: 3196
	public Animation SecondAmai;

	// Token: 0x04000C7D RID: 3197
	public Animation ThirdAmai;

	// Token: 0x04000C7E RID: 3198
	public Animation InfoChan;

	// Token: 0x04000C7F RID: 3199
	public Animation NewSenpaiAnim;

	// Token: 0x04000C80 RID: 3200
	public Animation NewAmaiAnim;

	// Token: 0x04000C81 RID: 3201
	public Transform SenpaiLeftHand;

	// Token: 0x04000C82 RID: 3202
	public Transform AmaiRightHand;

	// Token: 0x04000C83 RID: 3203
	public Transform AmaiLeftHand;

	// Token: 0x04000C84 RID: 3204
	public Transform CupcakeBox;

	// Token: 0x04000C85 RID: 3205
	public Transform DonutLid;

	// Token: 0x04000C86 RID: 3206
	public Transform Cupcake;

	// Token: 0x04000C87 RID: 3207
	public Transform Target;

	// Token: 0x04000C88 RID: 3208
	public Transform Hips;

	// Token: 0x04000C89 RID: 3209
	public Transform[] SenpaiBrow;

	// Token: 0x04000C8A RID: 3210
	public Transform[] SenpaiLip;

	// Token: 0x04000C8B RID: 3211
	public GameObject UtilityPole;

	// Token: 0x04000C8C RID: 3212
	public GameObject Amai;

	// Token: 0x04000C8D RID: 3213
	public Mesh CasualMesh;

	// Token: 0x04000C8E RID: 3214
	public int RivalEliminationID;

	// Token: 0x04000C8F RID: 3215
	public int ShockPhase;

	// Token: 0x04000C90 RID: 3216
	public int SpeechID;

	// Token: 0x04000C91 RID: 3217
	public int Phase = 1;

	// Token: 0x04000C92 RID: 3218
	public float BakeryFocus;

	// Token: 0x04000C93 RID: 3219
	public float ExtraTimer;

	// Token: 0x04000C94 RID: 3220
	public float AnimTimer;

	// Token: 0x04000C95 RID: 3221
	public float TimeLimit;

	// Token: 0x04000C96 RID: 3222
	public float SkipTimer;

	// Token: 0x04000C97 RID: 3223
	public float Rotation;

	// Token: 0x04000C98 RID: 3224
	public float Alpha;

	// Token: 0x04000C99 RID: 3225
	public float Speed;

	// Token: 0x04000C9A RID: 3226
	public float Timer;

	// Token: 0x04000C9B RID: 3227
	public float DOF;

	// Token: 0x04000C9C RID: 3228
	public float RotationX;

	// Token: 0x04000C9D RID: 3229
	public float RotationY;

	// Token: 0x04000C9E RID: 3230
	public float RotationZ;

	// Token: 0x04000C9F RID: 3231
	public bool EndEarly;

	// Token: 0x04000CA0 RID: 3232
	public bool InBakery;

	// Token: 0x04000CA1 RID: 3233
	public bool TreeShot;

	// Token: 0x04000CA2 RID: 3234
	public bool CloseUp;

	// Token: 0x04000CA3 RID: 3235
	public bool NoAnim;

	// Token: 0x04000CA4 RID: 3236
	public AudioClip[] OsanaEliminations;

	// Token: 0x04000CA5 RID: 3237
	public AudioClip[] Speech;

	// Token: 0x04000CA6 RID: 3238
	public AudioSource Audio;

	// Token: 0x04000CA7 RID: 3239
	public string[] EliminationDescriptions;

	// Token: 0x04000CA8 RID: 3240
	public string[] Subtitles;

	// Token: 0x04000CA9 RID: 3241
	public bool Smile;

	// Token: 0x04000CAA RID: 3242
	public float Strength;

	// Token: 0x04000CAB RID: 3243
	public float LipValue = -0.08f;
}
