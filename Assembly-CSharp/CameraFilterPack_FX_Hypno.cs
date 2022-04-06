using System;
using UnityEngine;

// Token: 0x020001B9 RID: 441
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hypno")]
public class CameraFilterPack_FX_Hypno : MonoBehaviour
{
	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06000F18 RID: 3864 RVA: 0x0007D1D4 File Offset: 0x0007B3D4
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

	// Token: 0x06000F19 RID: 3865 RVA: 0x0007D208 File Offset: 0x0007B408
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hypno");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x0007D22C File Offset: 0x0007B42C
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

	// Token: 0x06000F1B RID: 3867 RVA: 0x0007D324 File Offset: 0x0007B524
	private void Update()
	{
	}

	// Token: 0x06000F1C RID: 3868 RVA: 0x0007D326 File Offset: 0x0007B526
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001370 RID: 4976
	public Shader SCShader;

	// Token: 0x04001371 RID: 4977
	private float TimeX = 1f;

	// Token: 0x04001372 RID: 4978
	private Material SCMaterial;

	// Token: 0x04001373 RID: 4979
	[Range(0f, 1f)]
	public float Speed = 1f;

	// Token: 0x04001374 RID: 4980
	[Range(-2f, 2f)]
	public float Red;

	// Token: 0x04001375 RID: 4981
	[Range(-2f, 2f)]
	public float Green = 1f;

	// Token: 0x04001376 RID: 4982
	[Range(-2f, 2f)]
	public float Blue = 1f;
}
