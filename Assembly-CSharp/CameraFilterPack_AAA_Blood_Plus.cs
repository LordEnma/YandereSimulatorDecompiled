using System;
using UnityEngine;

// Token: 0x0200011A RID: 282
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood_Plus")]
public class CameraFilterPack_AAA_Blood_Plus : MonoBehaviour
{
	// Token: 0x1700021E RID: 542
	// (get) Token: 0x06000B1A RID: 2842 RVA: 0x0006B0C8 File Offset: 0x000692C8
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

	// Token: 0x06000B1B RID: 2843 RVA: 0x0006B0FC File Offset: 0x000692FC
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

	// Token: 0x06000B1C RID: 2844 RVA: 0x0006B134 File Offset: 0x00069334
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

	// Token: 0x06000B1D RID: 2845 RVA: 0x0006B38F File Offset: 0x0006958F
	private void Update()
	{
	}

	// Token: 0x06000B1E RID: 2846 RVA: 0x0006B391 File Offset: 0x00069591
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F11 RID: 3857
	public Shader SCShader;

	// Token: 0x04000F12 RID: 3858
	private float TimeX = 1f;

	// Token: 0x04000F13 RID: 3859
	[Range(0f, 1f)]
	public float Blood_1 = 1f;

	// Token: 0x04000F14 RID: 3860
	[Range(0f, 1f)]
	public float Blood_2;

	// Token: 0x04000F15 RID: 3861
	[Range(0f, 1f)]
	public float Blood_3;

	// Token: 0x04000F16 RID: 3862
	[Range(0f, 1f)]
	public float Blood_4;

	// Token: 0x04000F17 RID: 3863
	[Range(0f, 1f)]
	public float Blood_5;

	// Token: 0x04000F18 RID: 3864
	[Range(0f, 1f)]
	public float Blood_6;

	// Token: 0x04000F19 RID: 3865
	[Range(0f, 1f)]
	public float Blood_7;

	// Token: 0x04000F1A RID: 3866
	[Range(0f, 1f)]
	public float Blood_8;

	// Token: 0x04000F1B RID: 3867
	[Range(0f, 1f)]
	public float Blood_9;

	// Token: 0x04000F1C RID: 3868
	[Range(0f, 1f)]
	public float Blood_10;

	// Token: 0x04000F1D RID: 3869
	[Range(0f, 1f)]
	public float Blood_11;

	// Token: 0x04000F1E RID: 3870
	[Range(0f, 1f)]
	public float Blood_12;

	// Token: 0x04000F1F RID: 3871
	[Range(0f, 1f)]
	public float LightReflect = 0.5f;

	// Token: 0x04000F20 RID: 3872
	private Material SCMaterial;

	// Token: 0x04000F21 RID: 3873
	private Texture2D Texture2;
}
