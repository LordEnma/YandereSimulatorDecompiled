using System;
using UnityEngine;

// Token: 0x020001B5 RID: 437
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch3")]
public class CameraFilterPack_FX_Glitch3 : MonoBehaviour
{
	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x06000EFE RID: 3838 RVA: 0x0007C724 File Offset: 0x0007A924
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

	// Token: 0x06000EFF RID: 3839 RVA: 0x0007C758 File Offset: 0x0007A958
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x0007C77C File Offset: 0x0007A97C
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

	// Token: 0x06000F01 RID: 3841 RVA: 0x0007C848 File Offset: 0x0007AA48
	private void Update()
	{
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x0007C84A File Offset: 0x0007AA4A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400134F RID: 4943
	public Shader SCShader;

	// Token: 0x04001350 RID: 4944
	private float TimeX = 1f;

	// Token: 0x04001351 RID: 4945
	private Material SCMaterial;

	// Token: 0x04001352 RID: 4946
	[Range(0f, 1f)]
	public float _Glitch = 1f;

	// Token: 0x04001353 RID: 4947
	[Range(0f, 1f)]
	public float _Noise = 1f;
}
