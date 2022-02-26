using System;
using UnityEngine;

// Token: 0x020001B9 RID: 441
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hypno")]
public class CameraFilterPack_FX_Hypno : MonoBehaviour
{
	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06000F16 RID: 3862 RVA: 0x0007CC10 File Offset: 0x0007AE10
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

	// Token: 0x06000F17 RID: 3863 RVA: 0x0007CC44 File Offset: 0x0007AE44
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hypno");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F18 RID: 3864 RVA: 0x0007CC68 File Offset: 0x0007AE68
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

	// Token: 0x06000F19 RID: 3865 RVA: 0x0007CD60 File Offset: 0x0007AF60
	private void Update()
	{
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x0007CD62 File Offset: 0x0007AF62
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001360 RID: 4960
	public Shader SCShader;

	// Token: 0x04001361 RID: 4961
	private float TimeX = 1f;

	// Token: 0x04001362 RID: 4962
	private Material SCMaterial;

	// Token: 0x04001363 RID: 4963
	[Range(0f, 1f)]
	public float Speed = 1f;

	// Token: 0x04001364 RID: 4964
	[Range(-2f, 2f)]
	public float Red;

	// Token: 0x04001365 RID: 4965
	[Range(-2f, 2f)]
	public float Green = 1f;

	// Token: 0x04001366 RID: 4966
	[Range(-2f, 2f)]
	public float Blue = 1f;
}
