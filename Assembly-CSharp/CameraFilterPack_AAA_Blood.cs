using System;
using UnityEngine;

// Token: 0x02000117 RID: 279
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood")]
public class CameraFilterPack_AAA_Blood : MonoBehaviour
{
	// Token: 0x1700021B RID: 539
	// (get) Token: 0x06000B0A RID: 2826 RVA: 0x0006AE52 File Offset: 0x00069052
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

	// Token: 0x06000B0B RID: 2827 RVA: 0x0006AE86 File Offset: 0x00069086
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_AAA_Blood1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x0006AEBC File Offset: 0x000690BC
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
			this.material.SetFloat("_Value2", this.Blood1);
			this.material.SetFloat("_Value3", this.Blood2);
			this.material.SetFloat("_Value4", this.Blood3);
			this.material.SetFloat("_Value5", this.Blood4);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B0D RID: 2829 RVA: 0x0006AFB3 File Offset: 0x000691B3
	private void Update()
	{
	}

	// Token: 0x06000B0E RID: 2830 RVA: 0x0006AFB5 File Offset: 0x000691B5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EF4 RID: 3828
	public Shader SCShader;

	// Token: 0x04000EF5 RID: 3829
	private float TimeX = 1f;

	// Token: 0x04000EF6 RID: 3830
	[Range(0f, 128f)]
	public float Blood1;

	// Token: 0x04000EF7 RID: 3831
	[Range(0f, 128f)]
	public float Blood2;

	// Token: 0x04000EF8 RID: 3832
	[Range(0f, 128f)]
	public float Blood3;

	// Token: 0x04000EF9 RID: 3833
	[Range(0f, 128f)]
	public float Blood4 = 1f;

	// Token: 0x04000EFA RID: 3834
	[Range(0f, 0.004f)]
	public float LightReflect = 0.002f;

	// Token: 0x04000EFB RID: 3835
	private Material SCMaterial;

	// Token: 0x04000EFC RID: 3836
	private Texture2D Texture2;
}
