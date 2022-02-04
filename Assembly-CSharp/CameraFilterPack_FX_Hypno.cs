using System;
using UnityEngine;

// Token: 0x020001B9 RID: 441
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hypno")]
public class CameraFilterPack_FX_Hypno : MonoBehaviour
{
	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06000F15 RID: 3861 RVA: 0x0007C9AC File Offset: 0x0007ABAC
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

	// Token: 0x06000F16 RID: 3862 RVA: 0x0007C9E0 File Offset: 0x0007ABE0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hypno");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F17 RID: 3863 RVA: 0x0007CA04 File Offset: 0x0007AC04
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

	// Token: 0x06000F18 RID: 3864 RVA: 0x0007CAFC File Offset: 0x0007ACFC
	private void Update()
	{
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x0007CAFE File Offset: 0x0007ACFE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400135D RID: 4957
	public Shader SCShader;

	// Token: 0x0400135E RID: 4958
	private float TimeX = 1f;

	// Token: 0x0400135F RID: 4959
	private Material SCMaterial;

	// Token: 0x04001360 RID: 4960
	[Range(0f, 1f)]
	public float Speed = 1f;

	// Token: 0x04001361 RID: 4961
	[Range(-2f, 2f)]
	public float Red;

	// Token: 0x04001362 RID: 4962
	[Range(-2f, 2f)]
	public float Green = 1f;

	// Token: 0x04001363 RID: 4963
	[Range(-2f, 2f)]
	public float Blue = 1f;
}
