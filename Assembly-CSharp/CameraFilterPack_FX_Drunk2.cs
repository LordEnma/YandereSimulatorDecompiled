using System;
using UnityEngine;

// Token: 0x020001B0 RID: 432
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk2")]
public class CameraFilterPack_FX_Drunk2 : MonoBehaviour
{
	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x0007C5E5 File Offset: 0x0007A7E5
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

	// Token: 0x06000EE3 RID: 3811 RVA: 0x0007C619 File Offset: 0x0007A819
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Drunk2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x0007C63C File Offset: 0x0007A83C
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EE5 RID: 3813 RVA: 0x0007C734 File Offset: 0x0007A934
	private void Update()
	{
	}

	// Token: 0x06000EE6 RID: 3814 RVA: 0x0007C736 File Offset: 0x0007A936
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001346 RID: 4934
	public Shader SCShader;

	// Token: 0x04001347 RID: 4935
	private float TimeX = 1f;

	// Token: 0x04001348 RID: 4936
	private Material SCMaterial;

	// Token: 0x04001349 RID: 4937
	[Range(0f, 10f)]
	private float Value = 1f;

	// Token: 0x0400134A RID: 4938
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x0400134B RID: 4939
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x0400134C RID: 4940
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
