using System;
using UnityEngine;

// Token: 0x020001B5 RID: 437
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch3")]
public class CameraFilterPack_FX_Glitch3 : MonoBehaviour
{
	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x06000F00 RID: 3840 RVA: 0x0007CCE8 File Offset: 0x0007AEE8
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

	// Token: 0x06000F01 RID: 3841 RVA: 0x0007CD1C File Offset: 0x0007AF1C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x0007CD40 File Offset: 0x0007AF40
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

	// Token: 0x06000F03 RID: 3843 RVA: 0x0007CE0C File Offset: 0x0007B00C
	private void Update()
	{
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x0007CE0E File Offset: 0x0007B00E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400135F RID: 4959
	public Shader SCShader;

	// Token: 0x04001360 RID: 4960
	private float TimeX = 1f;

	// Token: 0x04001361 RID: 4961
	private Material SCMaterial;

	// Token: 0x04001362 RID: 4962
	[Range(0f, 1f)]
	public float _Glitch = 1f;

	// Token: 0x04001363 RID: 4963
	[Range(0f, 1f)]
	public float _Noise = 1f;
}
