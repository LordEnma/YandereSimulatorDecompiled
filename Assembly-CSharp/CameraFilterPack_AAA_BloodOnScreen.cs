using System;
using UnityEngine;

// Token: 0x02000118 RID: 280
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood On Screen")]
public class CameraFilterPack_AAA_BloodOnScreen : MonoBehaviour
{
	// Token: 0x1700021C RID: 540
	// (get) Token: 0x06000B10 RID: 2832 RVA: 0x0006AFF8 File Offset: 0x000691F8
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000B11 RID: 2833 RVA: 0x0006B02C File Offset: 0x0006922C
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_AAA_BloodOnScreen1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_BloodOnScreen");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B12 RID: 2834 RVA: 0x0006B064 File Offset: 0x00069264
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", Mathf.Clamp(this.Blood_On_Screen, 0.02f, 1.6f));
			this.material.SetFloat("_Value2", Mathf.Clamp(this.Blood_Intensify, 0f, 2f));
			this.material.SetFloat("_Value3", Mathf.Clamp(this.Blood_Darkness, 0f, 2f));
			this.material.SetFloat("_Value4", Mathf.Clamp(this.Blood_Fade, 0f, 1f));
			this.material.SetFloat("_Value5", Mathf.Clamp(this.Blood_Distortion_Speed, 0f, 2f));
			this.material.SetColor("_Color2", this.Blood_Color);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B13 RID: 2835 RVA: 0x0006B1BC File Offset: 0x000693BC
	private void Update()
	{
	}

	// Token: 0x06000B14 RID: 2836 RVA: 0x0006B1BE File Offset: 0x000693BE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EFD RID: 3837
	public Shader SCShader;

	// Token: 0x04000EFE RID: 3838
	private float TimeX = 1f;

	// Token: 0x04000EFF RID: 3839
	[Range(0.02f, 1.6f)]
	public float Blood_On_Screen = 1f;

	// Token: 0x04000F00 RID: 3840
	public Color Blood_Color = Color.red;

	// Token: 0x04000F01 RID: 3841
	[Range(0f, 2f)]
	public float Blood_Intensify = 0.7f;

	// Token: 0x04000F02 RID: 3842
	[Range(0f, 2f)]
	public float Blood_Darkness = 0.5f;

	// Token: 0x04000F03 RID: 3843
	[Range(0f, 1f)]
	public float Blood_Distortion_Speed = 0.25f;

	// Token: 0x04000F04 RID: 3844
	[Range(0f, 1f)]
	public float Blood_Fade = 1f;

	// Token: 0x04000F05 RID: 3845
	private Material SCMaterial;

	// Token: 0x04000F06 RID: 3846
	private Texture2D Texture2;
}
