using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200026C RID: 620
public class CustomizationScript : MonoBehaviour
{
	// Token: 0x0600130E RID: 4878 RVA: 0x000A8E18 File Offset: 0x000A7018
	private void Awake()
	{
		this.Data = new CustomizationScript.CustomizationData();
		this.Data.skinColor = new global::RangeInt(3, this.MinSkinColor, this.MaxSkinColor);
		this.Data.hairstyle = new global::RangeInt(1, this.MinHairstyle, this.MaxHairstyle);
		this.Data.hairColor = new global::RangeInt(1, this.MinHairColor, this.MaxHairColor);
		this.Data.eyeColor = new global::RangeInt(1, this.MinEyeColor, this.MaxEyeColor);
		this.Data.eyewear = new global::RangeInt(0, this.MinEyewear, this.MaxEyewear);
		this.Data.facialHair = new global::RangeInt(0, this.MinFacialHair, this.MaxFacialHair);
		this.Data.maleUniform = new global::RangeInt(1, this.MinMaleUniform, this.MaxMaleUniform);
		this.Data.femaleUniform = new global::RangeInt(1, this.MinFemaleUniform, this.MaxFemaleUniform);
	}

	// Token: 0x0600130F RID: 4879 RVA: 0x000A8F18 File Offset: 0x000A7118
	private void Start()
	{
		this.OriginalDOFStatus = this.Profile.depthOfField.enabled;
		this.Profile.depthOfField.enabled = false;
		Cursor.visible = false;
		Time.timeScale = 1f;
		this.LoveSick = GameGlobals.LoveSick;
		this.ApologyWindow.localPosition = new Vector3(1555f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
		this.CustomizePanel.alpha = 0f;
		this.UniformPanel.alpha = 0f;
		this.FinishPanel.alpha = 0f;
		this.GenderPanel.alpha = 0f;
		this.WhitePanel.alpha = 1f;
		this.UpdateFacialHair(this.Data.facialHair.Value);
		this.UpdateHairStyle(this.Data.hairstyle.Value);
		this.UpdateEyes(this.Data.eyeColor.Value);
		this.UpdateSkin(this.Data.skinColor.Value);
		if (this.LoveSick)
		{
			this.LoveSickColorSwap();
			this.WhitePanel.alpha = 0f;
			this.Data.femaleUniform.Value = 5;
			this.Data.maleUniform.Value = 5;
			RenderSettings.fogColor = new Color(0f, 0f, 0f, 1f);
			this.LoveSickCamera.SetActive(true);
			this.Black.color = Color.black;
			this.MyAudio.loop = false;
			this.MyAudio.clip = this.LoveSickIntro;
			this.MyAudio.Play();
		}
		else
		{
			this.Data.femaleUniform.Value = this.MinFemaleUniform;
			this.Data.maleUniform.Value = this.MinMaleUniform;
			RenderSettings.fogColor = new Color(1f, 0.5f, 1f, 1f);
			this.Black.color = new Color(0f, 0f, 0f, 0f);
			this.LoveSickCamera.SetActive(false);
		}
		this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
		this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
		this.Senpai.position = new Vector3(0f, -1f, 2f);
		this.Senpai.gameObject.SetActive(true);
		this.Senpai.GetComponent<Animation>().Play("newWalk_00");
		this.Yandere.position = new Vector3(1f, -1f, 4.5f);
		this.Yandere.gameObject.SetActive(true);
		this.Yandere.GetComponent<Animation>().Play("f02_newWalk_00");
		this.CensorCloud.SetActive(false);
		this.Hearts.SetActive(false);
		if (GameGlobals.VtuberID > 0)
		{
			this.YandereHair.SetActive(false);
			this.VtuberHair[GameGlobals.VtuberID].SetActive(true);
			this.FemaleFace = this.VtuberFace[GameGlobals.VtuberID];
			this.UpdateFemaleUniform(1);
			for (int i = 0; i < 13; i++)
			{
				this.YandereRenderer.SetBlendShapeWeight(i, 0f);
			}
			this.YandereRenderer.SetBlendShapeWeight(0, 100f);
			this.YandereRenderer.SetBlendShapeWeight(9, 100f);
			return;
		}
		this.VtuberHair[1].SetActive(false);
	}

	// Token: 0x17000339 RID: 825
	// (get) Token: 0x06001310 RID: 4880 RVA: 0x000A92D4 File Offset: 0x000A74D4
	private int MinSkinColor
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x1700033A RID: 826
	// (get) Token: 0x06001311 RID: 4881 RVA: 0x000A92D7 File Offset: 0x000A74D7
	private int MaxSkinColor
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x1700033B RID: 827
	// (get) Token: 0x06001312 RID: 4882 RVA: 0x000A92DA File Offset: 0x000A74DA
	private int MinHairstyle
	{
		get
		{
			return 0;
		}
	}

	// Token: 0x1700033C RID: 828
	// (get) Token: 0x06001313 RID: 4883 RVA: 0x000A92DD File Offset: 0x000A74DD
	private int MaxHairstyle
	{
		get
		{
			return this.Hairstyles.Length - 1;
		}
	}

	// Token: 0x1700033D RID: 829
	// (get) Token: 0x06001314 RID: 4884 RVA: 0x000A92E9 File Offset: 0x000A74E9
	private int MinHairColor
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x1700033E RID: 830
	// (get) Token: 0x06001315 RID: 4885 RVA: 0x000A92EC File Offset: 0x000A74EC
	private int MaxHairColor
	{
		get
		{
			return CustomizationScript.ColorPairs.Length - 1;
		}
	}

	// Token: 0x1700033F RID: 831
	// (get) Token: 0x06001316 RID: 4886 RVA: 0x000A92F7 File Offset: 0x000A74F7
	private int MinEyeColor
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x17000340 RID: 832
	// (get) Token: 0x06001317 RID: 4887 RVA: 0x000A92FA File Offset: 0x000A74FA
	private int MaxEyeColor
	{
		get
		{
			return CustomizationScript.ColorPairs.Length - 1;
		}
	}

	// Token: 0x17000341 RID: 833
	// (get) Token: 0x06001318 RID: 4888 RVA: 0x000A9305 File Offset: 0x000A7505
	private int MinEyewear
	{
		get
		{
			return 0;
		}
	}

	// Token: 0x17000342 RID: 834
	// (get) Token: 0x06001319 RID: 4889 RVA: 0x000A9308 File Offset: 0x000A7508
	private int MaxEyewear
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x17000343 RID: 835
	// (get) Token: 0x0600131A RID: 4890 RVA: 0x000A930B File Offset: 0x000A750B
	private int MinFacialHair
	{
		get
		{
			return 0;
		}
	}

	// Token: 0x17000344 RID: 836
	// (get) Token: 0x0600131B RID: 4891 RVA: 0x000A930E File Offset: 0x000A750E
	private int MaxFacialHair
	{
		get
		{
			return this.FacialHairstyles.Length - 1;
		}
	}

	// Token: 0x17000345 RID: 837
	// (get) Token: 0x0600131C RID: 4892 RVA: 0x000A931A File Offset: 0x000A751A
	private int MinMaleUniform
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x17000346 RID: 838
	// (get) Token: 0x0600131D RID: 4893 RVA: 0x000A931D File Offset: 0x000A751D
	private int MaxMaleUniform
	{
		get
		{
			return this.MaleUniforms.Length - 1;
		}
	}

	// Token: 0x17000347 RID: 839
	// (get) Token: 0x0600131E RID: 4894 RVA: 0x000A9329 File Offset: 0x000A7529
	private int MinFemaleUniform
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x17000348 RID: 840
	// (get) Token: 0x0600131F RID: 4895 RVA: 0x000A932C File Offset: 0x000A752C
	private int MaxFemaleUniform
	{
		get
		{
			return this.FemaleUniforms.Length - 1;
		}
	}

	// Token: 0x17000349 RID: 841
	// (get) Token: 0x06001320 RID: 4896 RVA: 0x000A9338 File Offset: 0x000A7538
	private float CameraSpeed
	{
		get
		{
			return Time.deltaTime * 10f;
		}
	}

	// Token: 0x06001321 RID: 4897 RVA: 0x000A9348 File Offset: 0x000A7548
	private void Update()
	{
		if (!this.MyAudio.loop && !this.MyAudio.isPlaying)
		{
			this.MyAudio.loop = true;
			this.MyAudio.clip = this.LoveSickLoop;
			this.MyAudio.Play();
		}
		for (int i = 1; i < 3; i++)
		{
			Transform transform = this.Corridor[i];
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * this.ScrollSpeed);
			if (transform.position.z > 36f)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 72f);
			}
		}
		if (this.Phase == 1)
		{
			if (this.WhitePanel.alpha == 0f)
			{
				this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 1f, Time.deltaTime * 2f);
				if (this.GenderPanel.alpha == 1f)
				{
					if (Input.GetButtonDown("A"))
					{
						this.Phase++;
					}
					if (Input.GetButtonDown("B"))
					{
						this.Apologize = true;
					}
					if (Input.GetButtonDown("X"))
					{
						this.White.color = new Color(0f, 0f, 0f, 1f);
						this.FadeOut = true;
						this.Phase = 0;
					}
					if (Input.GetButtonDown("Y"))
					{
						this.White.color = new Color(0f, 0f, 0f, 1f);
						this.SkipToCalendar = true;
						this.FadeOut = true;
						this.Phase = 0;
					}
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 0f, Time.deltaTime * 2f);
			this.Black.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.color.a, 0f, Time.deltaTime * 2f));
			if (this.GenderPanel.alpha == 0f)
			{
				this.Senpai.gameObject.SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.Adjustment += Input.GetAxis("Mouse X") * Time.deltaTime * 10f;
			if (this.Adjustment > 3f)
			{
				this.Adjustment = 3f;
			}
			else if (this.Adjustment < 0f)
			{
				this.Adjustment = 0f;
			}
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.CustomizePanel.alpha == 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
					this.Phase++;
				}
				bool tappedDown = this.InputManager.TappedDown;
				bool tappedUp = this.InputManager.TappedUp;
				if (tappedDown || tappedUp)
				{
					if (tappedDown)
					{
						this.Selected = ((this.Selected >= 6) ? 1 : (this.Selected + 1));
					}
					else if (tappedUp)
					{
						this.Selected = ((this.Selected <= 1) ? 6 : (this.Selected - 1));
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 650f - (float)this.Selected * 150f, this.Highlight.localPosition.z);
				}
				if (this.InputManager.TappedRight)
				{
					if (this.Selected == 1)
					{
						this.Data.skinColor.Value = this.Data.skinColor.Next;
						this.UpdateSkin(this.Data.skinColor.Value);
					}
					else if (this.Selected == 2)
					{
						this.Data.hairstyle.Value = this.Data.hairstyle.Next;
						this.UpdateHairStyle(this.Data.hairstyle.Value);
					}
					else if (this.Selected == 3)
					{
						this.Data.hairColor.Value = this.Data.hairColor.Next;
						this.UpdateColor(this.Data.hairColor.Value);
					}
					else if (this.Selected == 4)
					{
						this.Data.eyeColor.Value = this.Data.eyeColor.Next;
						this.UpdateEyes(this.Data.eyeColor.Value);
					}
					else if (this.Selected == 5)
					{
						this.Data.eyewear.Value = this.Data.eyewear.Next;
						this.UpdateEyewear(this.Data.eyewear.Value);
					}
					else if (this.Selected == 6)
					{
						this.Data.facialHair.Value = this.Data.facialHair.Next;
						this.UpdateFacialHair(this.Data.facialHair.Value);
					}
				}
				if (this.InputManager.TappedLeft)
				{
					if (this.Selected == 1)
					{
						this.Data.skinColor.Value = this.Data.skinColor.Previous;
						this.UpdateSkin(this.Data.skinColor.Value);
					}
					else if (this.Selected == 2)
					{
						this.Data.hairstyle.Value = this.Data.hairstyle.Previous;
						this.UpdateHairStyle(this.Data.hairstyle.Value);
					}
					else if (this.Selected == 3)
					{
						this.Data.hairColor.Value = this.Data.hairColor.Previous;
						this.UpdateColor(this.Data.hairColor.Value);
					}
					else if (this.Selected == 4)
					{
						this.Data.eyeColor.Value = this.Data.eyeColor.Previous;
						this.UpdateEyes(this.Data.eyeColor.Value);
					}
					else if (this.Selected == 5)
					{
						this.Data.eyewear.Value = this.Data.eyewear.Previous;
						this.UpdateEyewear(this.Data.eyewear.Value);
					}
					else if (this.Selected == 6)
					{
						this.Data.facialHair.Value = this.Data.facialHair.Previous;
						this.UpdateFacialHair(this.Data.facialHair.Value);
					}
				}
			}
			this.Rotation = Mathf.Lerp(this.Rotation, 45f - this.Adjustment * 30f, Time.deltaTime * 10f);
			this.AbsoluteRotation = 45f - Mathf.Abs(this.Rotation);
			if (this.Selected == 1)
			{
				this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f + this.Adjustment, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f - this.AbsoluteRotation * 0.015f, this.CameraSpeed));
			}
			else
			{
				this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -0.5f + this.Adjustment * 0.33333f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 1.5f - this.AbsoluteRotation * 0.015f * 0.33333f, this.CameraSpeed));
			}
			this.LoveSickCamera.transform.eulerAngles = new Vector3(0f, this.Rotation, 0f);
			base.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
			base.transform.position = this.LoveSickCamera.transform.position;
		}
		else if (this.Phase == 4)
		{
			this.Adjustment = Mathf.Lerp(this.Adjustment, 0f, Time.deltaTime * 10f);
			this.Rotation = Mathf.Lerp(this.Rotation, 45f, Time.deltaTime * 10f);
			this.AbsoluteRotation = 45f - Mathf.Abs(this.Rotation);
			this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f + this.Adjustment, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f - this.AbsoluteRotation * 0.015f, this.CameraSpeed));
			this.LoveSickCamera.transform.eulerAngles = new Vector3(0f, this.Rotation, 0f);
			base.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
			base.transform.position = this.LoveSickCamera.transform.position;
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.CustomizePanel.alpha == 0f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Selected = 1;
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 650f - (float)this.Selected * 150f, this.Highlight.localPosition.z);
					this.Phase = 100;
				}
			}
		}
		else if (this.Phase == 6)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 0f)
			{
				this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
				this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
				this.CensorCloud.SetActive(false);
				this.Yandere.gameObject.SetActive(true);
				this.Selected = 1;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.UniformPanel.alpha == 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Yandere.localEulerAngles = new Vector3(this.Yandere.localEulerAngles.x, 180f, this.Yandere.localEulerAngles.z);
					this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
					this.Phase++;
				}
				if (this.InputManager.TappedDown || this.InputManager.TappedUp)
				{
					this.Selected = ((this.Selected == 1) ? 2 : 1);
					this.UniformHighlight.localPosition = new Vector3(this.UniformHighlight.localPosition.x, 650f - (float)this.Selected * 150f, this.UniformHighlight.localPosition.z);
				}
				if (this.InputManager.TappedRight)
				{
					if (this.Selected == 1)
					{
						this.Data.maleUniform.Value = this.Data.maleUniform.Next;
						this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
					}
					else if (this.Selected == 2)
					{
						this.Data.femaleUniform.Value = this.Data.femaleUniform.Next;
						this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
					}
				}
				if (this.InputManager.TappedLeft)
				{
					if (this.Selected == 1)
					{
						this.Data.maleUniform.Value = this.Data.maleUniform.Previous;
						this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
					}
					else if (this.Selected == 2)
					{
						this.Data.femaleUniform.Value = this.Data.femaleUniform.Previous;
						this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
					}
				}
			}
		}
		else if (this.Phase == 8)
		{
			this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.UniformPanel.alpha == 0f)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 9)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 1f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Selected = 1;
					this.UniformHighlight.localPosition = new Vector3(this.UniformHighlight.localPosition.x, 650f - (float)this.Selected * 150f, this.UniformHighlight.localPosition.z);
					this.Phase = 99;
				}
			}
		}
		else if (this.Phase == 10)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 0f)
			{
				this.White.color = new Color(0f, 0f, 0f, 1f);
				this.FadeOut = true;
				this.Phase = 0;
			}
		}
		else if (this.Phase == 99)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 0f)
			{
				this.Phase = 7;
			}
		}
		else if (this.Phase == 100)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
			if (this.FinishPanel.alpha == 0f)
			{
				this.Phase = 3;
			}
		}
		if (this.Phase > 3 && this.Phase < 100)
		{
			if (this.Phase < 6)
			{
				this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f, this.CameraSpeed));
				base.transform.position = this.LoveSickCamera.transform.position;
			}
			else
			{
				this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0f, this.CameraSpeed));
				this.LoveSickCamera.transform.eulerAngles = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.x, 15f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.z, 0f, this.CameraSpeed));
				base.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
				base.transform.position = this.LoveSickCamera.transform.position;
				this.Yandere.position = new Vector3(Mathf.Lerp(this.Yandere.position.x, 1f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.y, -1f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.z, 3.5f, Time.deltaTime * 10f));
			}
		}
		if (this.FadeOut)
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 1f, Time.deltaTime);
			base.GetComponent<AudioSource>().volume = 1f - this.WhitePanel.alpha;
			if (this.WhitePanel.alpha == 1f)
			{
				SenpaiGlobals.CustomSenpai = true;
				SenpaiGlobals.SenpaiSkinColor = this.Data.skinColor.Value;
				SenpaiGlobals.SenpaiHairStyle = this.Data.hairstyle.Value;
				SenpaiGlobals.SenpaiHairColor = this.HairColorName;
				SenpaiGlobals.SenpaiEyeColor = this.EyeColorName;
				SenpaiGlobals.SenpaiEyeWear = this.Data.eyewear.Value;
				SenpaiGlobals.SenpaiFacialHair = this.Data.facialHair.Value;
				StudentGlobals.MaleUniform = this.Data.maleUniform.Value;
				StudentGlobals.FemaleUniform = this.Data.femaleUniform.Value;
				this.Profile.depthOfField.enabled = this.OriginalDOFStatus;
				if (this.SkipToCalendar)
				{
					SceneManager.LoadScene("CalendarScene");
				}
				else
				{
					SceneManager.LoadScene("NewIntroScene");
				}
			}
		}
		else
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 0f, Time.deltaTime);
		}
		if (this.Apologize)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < 1f)
			{
				this.ApologyWindow.localPosition = new Vector3(Mathf.Lerp(this.ApologyWindow.localPosition.x, 0f, Time.deltaTime * 10f), this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
				return;
			}
			this.ApologyWindow.localPosition = new Vector3(Mathf.Abs((this.ApologyWindow.localPosition.x - Time.deltaTime) * 0.01f) * (Time.deltaTime * 1000f), this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
			if (this.ApologyWindow.localPosition.x < -1555f)
			{
				this.ApologyWindow.localPosition = new Vector3(1555f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
				this.Apologize = false;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x06001322 RID: 4898 RVA: 0x000AA9DA File Offset: 0x000A8BDA
	private void LateUpdate()
	{
		this.YandereHead.LookAt(this.SenpaiHead.position);
	}

	// Token: 0x06001323 RID: 4899 RVA: 0x000AA9F2 File Offset: 0x000A8BF2
	private void UpdateSkin(int skinColor)
	{
		this.UpdateMaleUniform(this.Data.maleUniform.Value, skinColor);
		this.SkinColorLabel.text = "Skin Color " + skinColor.ToString();
	}

	// Token: 0x06001324 RID: 4900 RVA: 0x000AAA28 File Offset: 0x000A8C28
	private void UpdateHairStyle(int hairstyle)
	{
		for (int i = 1; i < this.Hairstyles.Length; i++)
		{
			this.Hairstyles[i].SetActive(false);
		}
		if (hairstyle > 0)
		{
			this.HairRenderer = this.Hairstyles[hairstyle].GetComponent<Renderer>();
			this.Hairstyles[hairstyle].SetActive(true);
		}
		this.HairStyleLabel.text = "Hair Style " + hairstyle.ToString();
		this.UpdateColor(this.Data.hairColor.Value);
	}

	// Token: 0x06001325 RID: 4901 RVA: 0x000AAAB0 File Offset: 0x000A8CB0
	private void UpdateFacialHair(int facialHair)
	{
		for (int i = 1; i < this.FacialHairstyles.Length; i++)
		{
			this.FacialHairstyles[i].SetActive(false);
		}
		if (facialHair > 0)
		{
			this.FacialHairRenderer = this.FacialHairstyles[facialHair].GetComponent<Renderer>();
			this.FacialHairstyles[facialHair].SetActive(true);
		}
		this.FacialHairStyleLabel.text = "Facial Hair " + facialHair.ToString();
		this.UpdateColor(this.Data.hairColor.Value);
	}

	// Token: 0x06001326 RID: 4902 RVA: 0x000AAB38 File Offset: 0x000A8D38
	private void UpdateColor(int hairColor)
	{
		KeyValuePair<Color, string> keyValuePair = CustomizationScript.ColorPairs[hairColor];
		Color key = keyValuePair.Key;
		this.HairColorName = keyValuePair.Value;
		if (this.Data.hairstyle.Value > 0)
		{
			this.HairRenderer = this.Hairstyles[this.Data.hairstyle.Value].GetComponent<Renderer>();
			this.HairRenderer.material.color = key;
		}
		if (this.Data.facialHair.Value > 0)
		{
			this.FacialHairRenderer = this.FacialHairstyles[this.Data.facialHair.Value].GetComponent<Renderer>();
			this.FacialHairRenderer.material.color = key;
			if (this.FacialHairRenderer.materials.Length > 1)
			{
				this.FacialHairRenderer.materials[1].color = key;
			}
		}
		this.HairColorLabel.text = "Hair Color " + hairColor.ToString();
	}

	// Token: 0x06001327 RID: 4903 RVA: 0x000AAC34 File Offset: 0x000A8E34
	private void UpdateEyes(int eyeColor)
	{
		KeyValuePair<Color, string> keyValuePair = CustomizationScript.ColorPairs[eyeColor];
		Color key = keyValuePair.Key;
		this.EyeColorName = keyValuePair.Value;
		this.EyeR.material.color = key;
		this.EyeL.material.color = key;
		this.EyeColorLabel.text = "Eye Color " + eyeColor.ToString();
	}

	// Token: 0x06001328 RID: 4904 RVA: 0x000AACA0 File Offset: 0x000A8EA0
	private void UpdateEyewear(int eyewear)
	{
		for (int i = 1; i < this.Eyewears.Length; i++)
		{
			this.Eyewears[i].SetActive(false);
		}
		if (eyewear > 0)
		{
			this.Eyewears[eyewear].SetActive(true);
		}
		this.EyeWearLabel.text = "Eye Wear " + eyewear.ToString();
	}

	// Token: 0x06001329 RID: 4905 RVA: 0x000AACFC File Offset: 0x000A8EFC
	private void UpdateMaleUniform(int maleUniform, int skinColor)
	{
		this.SenpaiRenderer.sharedMesh = this.MaleUniforms[maleUniform];
		if (maleUniform == 1)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[skinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.MaleUniformTextures[maleUniform];
			this.SenpaiRenderer.materials[2].mainTexture = this.FaceTextures[skinColor];
		}
		else if (maleUniform == 2)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[maleUniform];
			this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[skinColor];
		}
		else if (maleUniform == 3)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[maleUniform];
			this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[skinColor];
		}
		else if (maleUniform == 4)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
		}
		else if (maleUniform == 5)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
		}
		else if (maleUniform == 6)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
		}
		this.MaleUniformLabel.text = "Male Uniform " + maleUniform.ToString();
	}

	// Token: 0x0600132A RID: 4906 RVA: 0x000AAF3C File Offset: 0x000A913C
	private void UpdateFemaleUniform(int femaleUniform)
	{
		this.YandereRenderer.sharedMesh = this.FemaleUniforms[femaleUniform];
		this.YandereRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
		this.YandereRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
		this.YandereRenderer.materials[2].mainTexture = this.FemaleFace;
		this.YandereRenderer.materials[3].mainTexture = this.FemaleFace;
		this.FemaleUniformLabel.text = "Female Uniform " + femaleUniform.ToString();
	}

	// Token: 0x0600132B RID: 4907 RVA: 0x000AAFDC File Offset: 0x000A91DC
	private void LoveSickColorSwap()
	{
		foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
		{
			UISprite component = gameObject.GetComponent<UISprite>();
			if (component != null && component.color != Color.black && component.transform.parent != this.Highlight && component.transform.parent != this.UniformHighlight)
			{
				component.color = new Color(1f, 0f, 0f, component.color.a);
			}
			UITexture component2 = gameObject.GetComponent<UITexture>();
			if (component2 != null)
			{
				component2.color = new Color(1f, 0f, 0f, component2.color.a);
			}
			UILabel component3 = gameObject.GetComponent<UILabel>();
			if (component3 != null && component3.color != Color.black)
			{
				component3.color = new Color(1f, 0f, 0f, component3.color.a);
			}
		}
	}

	// Token: 0x04001B2E RID: 6958
	[SerializeField]
	private CustomizationScript.CustomizationData Data;

	// Token: 0x04001B2F RID: 6959
	[SerializeField]
	private InputManagerScript InputManager;

	// Token: 0x04001B30 RID: 6960
	[SerializeField]
	private Renderer FacialHairRenderer;

	// Token: 0x04001B31 RID: 6961
	[SerializeField]
	private SkinnedMeshRenderer YandereRenderer;

	// Token: 0x04001B32 RID: 6962
	[SerializeField]
	private SkinnedMeshRenderer SenpaiRenderer;

	// Token: 0x04001B33 RID: 6963
	[SerializeField]
	private Renderer HairRenderer;

	// Token: 0x04001B34 RID: 6964
	[SerializeField]
	private AudioSource MyAudio;

	// Token: 0x04001B35 RID: 6965
	[SerializeField]
	private Renderer EyeR;

	// Token: 0x04001B36 RID: 6966
	[SerializeField]
	private Renderer EyeL;

	// Token: 0x04001B37 RID: 6967
	[SerializeField]
	private Transform UniformHighlight;

	// Token: 0x04001B38 RID: 6968
	[SerializeField]
	private Transform ApologyWindow;

	// Token: 0x04001B39 RID: 6969
	[SerializeField]
	private Transform YandereHead;

	// Token: 0x04001B3A RID: 6970
	[SerializeField]
	private Transform YandereNeck;

	// Token: 0x04001B3B RID: 6971
	[SerializeField]
	private Transform SenpaiHead;

	// Token: 0x04001B3C RID: 6972
	[SerializeField]
	private Transform Highlight;

	// Token: 0x04001B3D RID: 6973
	[SerializeField]
	private Transform Yandere;

	// Token: 0x04001B3E RID: 6974
	[SerializeField]
	private Transform Senpai;

	// Token: 0x04001B3F RID: 6975
	[SerializeField]
	private Transform[] Corridor;

	// Token: 0x04001B40 RID: 6976
	[SerializeField]
	private UIPanel CustomizePanel;

	// Token: 0x04001B41 RID: 6977
	[SerializeField]
	private UIPanel UniformPanel;

	// Token: 0x04001B42 RID: 6978
	[SerializeField]
	private UIPanel FinishPanel;

	// Token: 0x04001B43 RID: 6979
	[SerializeField]
	private UIPanel GenderPanel;

	// Token: 0x04001B44 RID: 6980
	[SerializeField]
	private UIPanel WhitePanel;

	// Token: 0x04001B45 RID: 6981
	[SerializeField]
	private UILabel FacialHairStyleLabel;

	// Token: 0x04001B46 RID: 6982
	[SerializeField]
	private UILabel FemaleUniformLabel;

	// Token: 0x04001B47 RID: 6983
	[SerializeField]
	private UILabel MaleUniformLabel;

	// Token: 0x04001B48 RID: 6984
	[SerializeField]
	private UILabel SkinColorLabel;

	// Token: 0x04001B49 RID: 6985
	[SerializeField]
	private UILabel HairStyleLabel;

	// Token: 0x04001B4A RID: 6986
	[SerializeField]
	private UILabel HairColorLabel;

	// Token: 0x04001B4B RID: 6987
	[SerializeField]
	private UILabel EyeColorLabel;

	// Token: 0x04001B4C RID: 6988
	[SerializeField]
	private UILabel EyeWearLabel;

	// Token: 0x04001B4D RID: 6989
	[SerializeField]
	private GameObject LoveSickCamera;

	// Token: 0x04001B4E RID: 6990
	[SerializeField]
	private GameObject CensorCloud;

	// Token: 0x04001B4F RID: 6991
	[SerializeField]
	private GameObject BigCloud;

	// Token: 0x04001B50 RID: 6992
	[SerializeField]
	private GameObject Hearts;

	// Token: 0x04001B51 RID: 6993
	[SerializeField]
	private GameObject Cloud;

	// Token: 0x04001B52 RID: 6994
	[SerializeField]
	private UISprite Black;

	// Token: 0x04001B53 RID: 6995
	[SerializeField]
	private UISprite White;

	// Token: 0x04001B54 RID: 6996
	private bool SkipToCalendar;

	// Token: 0x04001B55 RID: 6997
	private bool Apologize;

	// Token: 0x04001B56 RID: 6998
	private bool LoveSick;

	// Token: 0x04001B57 RID: 6999
	private bool FadeOut;

	// Token: 0x04001B58 RID: 7000
	[SerializeField]
	private float ScrollSpeed;

	// Token: 0x04001B59 RID: 7001
	[SerializeField]
	private float Timer;

	// Token: 0x04001B5A RID: 7002
	[SerializeField]
	private int Selected = 1;

	// Token: 0x04001B5B RID: 7003
	[SerializeField]
	private int Phase = 1;

	// Token: 0x04001B5C RID: 7004
	[SerializeField]
	private Texture[] FemaleUniformTextures;

	// Token: 0x04001B5D RID: 7005
	[SerializeField]
	private Texture[] MaleUniformTextures;

	// Token: 0x04001B5E RID: 7006
	[SerializeField]
	private Texture[] FaceTextures;

	// Token: 0x04001B5F RID: 7007
	[SerializeField]
	private Texture[] SkinTextures;

	// Token: 0x04001B60 RID: 7008
	[SerializeField]
	private GameObject[] FacialHairstyles;

	// Token: 0x04001B61 RID: 7009
	[SerializeField]
	private GameObject[] Hairstyles;

	// Token: 0x04001B62 RID: 7010
	[SerializeField]
	private GameObject[] Eyewears;

	// Token: 0x04001B63 RID: 7011
	[SerializeField]
	private Mesh[] FemaleUniforms;

	// Token: 0x04001B64 RID: 7012
	[SerializeField]
	private Mesh[] MaleUniforms;

	// Token: 0x04001B65 RID: 7013
	[SerializeField]
	private Texture FemaleFace;

	// Token: 0x04001B66 RID: 7014
	[SerializeField]
	private string HairColorName = string.Empty;

	// Token: 0x04001B67 RID: 7015
	[SerializeField]
	private string EyeColorName = string.Empty;

	// Token: 0x04001B68 RID: 7016
	[SerializeField]
	private AudioClip LoveSickIntro;

	// Token: 0x04001B69 RID: 7017
	[SerializeField]
	private AudioClip LoveSickLoop;

	// Token: 0x04001B6A RID: 7018
	public float AbsoluteRotation;

	// Token: 0x04001B6B RID: 7019
	public float Adjustment;

	// Token: 0x04001B6C RID: 7020
	public float Rotation;

	// Token: 0x04001B6D RID: 7021
	public PostProcessingProfile Profile;

	// Token: 0x04001B6E RID: 7022
	public GameObject YandereHair;

	// Token: 0x04001B6F RID: 7023
	public GameObject[] VtuberHair;

	// Token: 0x04001B70 RID: 7024
	public Texture[] VtuberFace;

	// Token: 0x04001B71 RID: 7025
	public bool OriginalDOFStatus;

	// Token: 0x04001B72 RID: 7026
	private static readonly KeyValuePair<Color, string>[] ColorPairs = new KeyValuePair<Color, string>[]
	{
		new KeyValuePair<Color, string>(default(Color), string.Empty),
		new KeyValuePair<Color, string>(new Color(0.5f, 0.5f, 0.5f), "Black"),
		new KeyValuePair<Color, string>(new Color(1f, 0f, 0f), "Red"),
		new KeyValuePair<Color, string>(new Color(1f, 1f, 0f), "Yellow"),
		new KeyValuePair<Color, string>(new Color(0f, 1f, 0f), "Green"),
		new KeyValuePair<Color, string>(new Color(0f, 1f, 1f), "Cyan"),
		new KeyValuePair<Color, string>(new Color(0f, 0f, 1f), "Blue"),
		new KeyValuePair<Color, string>(new Color(1f, 0f, 1f), "Purple"),
		new KeyValuePair<Color, string>(new Color(1f, 0.5f, 0f), "Orange"),
		new KeyValuePair<Color, string>(new Color(0.5f, 0.25f, 0f), "Brown"),
		new KeyValuePair<Color, string>(new Color(1f, 1f, 1f), "White")
	};

	// Token: 0x02000655 RID: 1621
	private class CustomizationData
	{
		// Token: 0x04004F7F RID: 20351
		public global::RangeInt skinColor;

		// Token: 0x04004F80 RID: 20352
		public global::RangeInt hairstyle;

		// Token: 0x04004F81 RID: 20353
		public global::RangeInt hairColor;

		// Token: 0x04004F82 RID: 20354
		public global::RangeInt eyeColor;

		// Token: 0x04004F83 RID: 20355
		public global::RangeInt eyewear;

		// Token: 0x04004F84 RID: 20356
		public global::RangeInt facialHair;

		// Token: 0x04004F85 RID: 20357
		public global::RangeInt maleUniform;

		// Token: 0x04004F86 RID: 20358
		public global::RangeInt femaleUniform;
	}
}
