using System;
using UnityEngine;

// Token: 0x020001BE RID: 446
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Scan")]
public class CameraFilterPack_FX_Scan : MonoBehaviour
{
	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x06000F33 RID: 3891 RVA: 0x0007CFF4 File Offset: 0x0007B1F4
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

	// Token: 0x06000F34 RID: 3892 RVA: 0x0007D028 File Offset: 0x0007B228
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Scan");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F35 RID: 3893 RVA: 0x0007D04C File Offset: 0x0007B24C
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

	// Token: 0x06000F36 RID: 3894 RVA: 0x0007D144 File Offset: 0x0007B344
	private void Update()
	{
	}

	// Token: 0x06000F37 RID: 3895 RVA: 0x0007D146 File Offset: 0x0007B346
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001372 RID: 4978
	public Shader SCShader;

	// Token: 0x04001373 RID: 4979
	private float TimeX = 1f;

	// Token: 0x04001374 RID: 4980
	private Material SCMaterial;

	// Token: 0x04001375 RID: 4981
	[Range(0.001f, 0.1f)]
	public float Size = 0.025f;

	// Token: 0x04001376 RID: 4982
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001377 RID: 4983
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001378 RID: 4984
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
