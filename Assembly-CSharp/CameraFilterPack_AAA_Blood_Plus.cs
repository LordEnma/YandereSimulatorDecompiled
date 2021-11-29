using System;
using UnityEngine;

// Token: 0x02000119 RID: 281
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood_Plus")]
public class CameraFilterPack_AAA_Blood_Plus : MonoBehaviour
{
	// Token: 0x1700021E RID: 542
	// (get) Token: 0x06000B16 RID: 2838 RVA: 0x0006AB24 File Offset: 0x00068D24
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

	// Token: 0x06000B17 RID: 2839 RVA: 0x0006AB58 File Offset: 0x00068D58
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_AAA_Blood2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Blood_Plus");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x0006AB90 File Offset: 0x00068D90
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
			this.material.SetFloat("_Value", this.LightReflect);
			this.material.SetFloat("_Value2", Mathf.Clamp(this.Blood_1, 0f, 1f));
			this.material.SetFloat("_Value3", Mathf.Clamp(this.Blood_2, 0f, 1f));
			this.material.SetFloat("_Value4", Mathf.Clamp(this.Blood_3, 0f, 1f));
			this.material.SetFloat("_Value5", Mathf.Clamp(this.Blood_4, 0f, 1f));
			this.material.SetFloat("_Value6", Mathf.Clamp(this.Blood_5, 0f, 1f));
			this.material.SetFloat("_Value7", Mathf.Clamp(this.Blood_6, 0f, 1f));
			this.material.SetFloat("_Value8", Mathf.Clamp(this.Blood_7, 0f, 1f));
			this.material.SetFloat("_Value9", Mathf.Clamp(this.Blood_8, 0f, 1f));
			this.material.SetFloat("_Value10", Mathf.Clamp(this.Blood_9, 0f, 1f));
			this.material.SetFloat("_Value11", Mathf.Clamp(this.Blood_10, 0f, 1f));
			this.material.SetFloat("_Value12", Mathf.Clamp(this.Blood_11, 0f, 1f));
			this.material.SetFloat("_Value13", Mathf.Clamp(this.Blood_12, 0f, 1f));
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B19 RID: 2841 RVA: 0x0006ADEB File Offset: 0x00068FEB
	private void Update()
	{
	}

	// Token: 0x06000B1A RID: 2842 RVA: 0x0006ADED File Offset: 0x00068FED
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F00 RID: 3840
	public Shader SCShader;

	// Token: 0x04000F01 RID: 3841
	private float TimeX = 1f;

	// Token: 0x04000F02 RID: 3842
	[Range(0f, 1f)]
	public float Blood_1 = 1f;

	// Token: 0x04000F03 RID: 3843
	[Range(0f, 1f)]
	public float Blood_2;

	// Token: 0x04000F04 RID: 3844
	[Range(0f, 1f)]
	public float Blood_3;

	// Token: 0x04000F05 RID: 3845
	[Range(0f, 1f)]
	public float Blood_4;

	// Token: 0x04000F06 RID: 3846
	[Range(0f, 1f)]
	public float Blood_5;

	// Token: 0x04000F07 RID: 3847
	[Range(0f, 1f)]
	public float Blood_6;

	// Token: 0x04000F08 RID: 3848
	[Range(0f, 1f)]
	public float Blood_7;

	// Token: 0x04000F09 RID: 3849
	[Range(0f, 1f)]
	public float Blood_8;

	// Token: 0x04000F0A RID: 3850
	[Range(0f, 1f)]
	public float Blood_9;

	// Token: 0x04000F0B RID: 3851
	[Range(0f, 1f)]
	public float Blood_10;

	// Token: 0x04000F0C RID: 3852
	[Range(0f, 1f)]
	public float Blood_11;

	// Token: 0x04000F0D RID: 3853
	[Range(0f, 1f)]
	public float Blood_12;

	// Token: 0x04000F0E RID: 3854
	[Range(0f, 1f)]
	public float LightReflect = 0.5f;

	// Token: 0x04000F0F RID: 3855
	private Material SCMaterial;

	// Token: 0x04000F10 RID: 3856
	private Texture2D Texture2;
}
