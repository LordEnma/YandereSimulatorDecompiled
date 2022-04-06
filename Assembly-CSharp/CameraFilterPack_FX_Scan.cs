using System;
using UnityEngine;

// Token: 0x020001BE RID: 446
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Scan")]
public class CameraFilterPack_FX_Scan : MonoBehaviour
{
	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x06000F36 RID: 3894 RVA: 0x0007D81C File Offset: 0x0007BA1C
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

	// Token: 0x06000F37 RID: 3895 RVA: 0x0007D850 File Offset: 0x0007BA50
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Scan");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F38 RID: 3896 RVA: 0x0007D874 File Offset: 0x0007BA74
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Speed);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F39 RID: 3897 RVA: 0x0007D96C File Offset: 0x0007BB6C
	private void Update()
	{
	}

	// Token: 0x06000F3A RID: 3898 RVA: 0x0007D96E File Offset: 0x0007BB6E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001385 RID: 4997
	public Shader SCShader;

	// Token: 0x04001386 RID: 4998
	private float TimeX = 1f;

	// Token: 0x04001387 RID: 4999
	private Material SCMaterial;

	// Token: 0x04001388 RID: 5000
	[Range(0.001f, 0.1f)]
	public float Size = 0.025f;

	// Token: 0x04001389 RID: 5001
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x0400138A RID: 5002
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x0400138B RID: 5003
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
