using System;
using UnityEngine;

// Token: 0x02000118 RID: 280
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood On Screen")]
public class CameraFilterPack_AAA_BloodOnScreen : MonoBehaviour
{
	// Token: 0x1700021C RID: 540
	// (get) Token: 0x06000B0E RID: 2830 RVA: 0x0006AB7C File Offset: 0x00068D7C
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

	// Token: 0x06000B0F RID: 2831 RVA: 0x0006ABB0 File Offset: 0x00068DB0
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

	// Token: 0x06000B10 RID: 2832 RVA: 0x0006ABE8 File Offset: 0x00068DE8
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

	// Token: 0x06000B11 RID: 2833 RVA: 0x0006AD40 File Offset: 0x00068F40
	private void Update()
	{
	}

	// Token: 0x06000B12 RID: 2834 RVA: 0x0006AD42 File Offset: 0x00068F42
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EF6 RID: 3830
	public Shader SCShader;

	// Token: 0x04000EF7 RID: 3831
	private float TimeX = 1f;

	// Token: 0x04000EF8 RID: 3832
	[Range(0.02f, 1.6f)]
	public float Blood_On_Screen = 1f;

	// Token: 0x04000EF9 RID: 3833
	public Color Blood_Color = Color.red;

	// Token: 0x04000EFA RID: 3834
	[Range(0f, 2f)]
	public float Blood_Intensify = 0.7f;

	// Token: 0x04000EFB RID: 3835
	[Range(0f, 2f)]
	public float Blood_Darkness = 0.5f;

	// Token: 0x04000EFC RID: 3836
	[Range(0f, 1f)]
	public float Blood_Distortion_Speed = 0.25f;

	// Token: 0x04000EFD RID: 3837
	[Range(0f, 1f)]
	public float Blood_Fade = 1f;

	// Token: 0x04000EFE RID: 3838
	private Material SCMaterial;

	// Token: 0x04000EFF RID: 3839
	private Texture2D Texture2;
}
