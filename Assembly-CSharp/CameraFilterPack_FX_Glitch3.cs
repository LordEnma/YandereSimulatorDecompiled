using System;
using UnityEngine;

// Token: 0x020001B5 RID: 437
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch3")]
public class CameraFilterPack_FX_Glitch3 : MonoBehaviour
{
	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x06000EFE RID: 3838 RVA: 0x0007C86C File Offset: 0x0007AA6C
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

	// Token: 0x06000EFF RID: 3839 RVA: 0x0007C8A0 File Offset: 0x0007AAA0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x0007C8C4 File Offset: 0x0007AAC4
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
			this.material.SetFloat("_Glitch", this._Glitch);
			this.material.SetFloat("_Noise", this._Noise);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x0007C990 File Offset: 0x0007AB90
	private void Update()
	{
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x0007C992 File Offset: 0x0007AB92
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
	public float _Glitch = 1f;

	// Token: 0x0400135C RID: 4956
	[Range(0f, 1f)]
	public float _Noise = 1f;
}
