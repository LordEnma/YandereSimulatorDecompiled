using System;
using UnityEngine;

// Token: 0x020001C1 RID: 449
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/ZebraColor")]
public class CameraFilterPack_FX_ZebraColor : MonoBehaviour
{
	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x06000F46 RID: 3910 RVA: 0x0007D8AF File Offset: 0x0007BAAF
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

	// Token: 0x06000F47 RID: 3911 RVA: 0x0007D8E3 File Offset: 0x0007BAE3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_ZebraColor");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F48 RID: 3912 RVA: 0x0007D904 File Offset: 0x0007BB04
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F49 RID: 3913 RVA: 0x0007D9BA File Offset: 0x0007BBBA
	private void Update()
	{
	}

	// Token: 0x06000F4A RID: 3914 RVA: 0x0007D9BC File Offset: 0x0007BBBC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001392 RID: 5010
	public Shader SCShader;

	// Token: 0x04001393 RID: 5011
	private float TimeX = 1f;

	// Token: 0x04001394 RID: 5012
	private Material SCMaterial;

	// Token: 0x04001395 RID: 5013
	[Range(1f, 10f)]
	public float Value = 3f;
}
