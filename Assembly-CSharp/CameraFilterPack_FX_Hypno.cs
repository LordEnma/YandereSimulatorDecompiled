using System;
using UnityEngine;

// Token: 0x020001B8 RID: 440
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hypno")]
public class CameraFilterPack_FX_Hypno : MonoBehaviour
{
	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06000F12 RID: 3858 RVA: 0x0007C7B4 File Offset: 0x0007A9B4
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

	// Token: 0x06000F13 RID: 3859 RVA: 0x0007C7E8 File Offset: 0x0007A9E8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hypno");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F14 RID: 3860 RVA: 0x0007C80C File Offset: 0x0007AA0C
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Red);
			this.material.SetFloat("_Value3", this.Green);
			this.material.SetFloat("_Value4", this.Blue);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F15 RID: 3861 RVA: 0x0007C904 File Offset: 0x0007AB04
	private void Update()
	{
	}

	// Token: 0x06000F16 RID: 3862 RVA: 0x0007C906 File Offset: 0x0007AB06
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001358 RID: 4952
	public Shader SCShader;

	// Token: 0x04001359 RID: 4953
	private float TimeX = 1f;

	// Token: 0x0400135A RID: 4954
	private Material SCMaterial;

	// Token: 0x0400135B RID: 4955
	[Range(0f, 1f)]
	public float Speed = 1f;

	// Token: 0x0400135C RID: 4956
	[Range(-2f, 2f)]
	public float Red;

	// Token: 0x0400135D RID: 4957
	[Range(-2f, 2f)]
	public float Green = 1f;

	// Token: 0x0400135E RID: 4958
	[Range(-2f, 2f)]
	public float Blue = 1f;
}
