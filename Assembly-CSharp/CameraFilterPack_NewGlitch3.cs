using System;
using UnityEngine;

// Token: 0x020001E6 RID: 486
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch3")]
public class CameraFilterPack_NewGlitch3 : MonoBehaviour
{
	// Token: 0x170002EA RID: 746
	// (get) Token: 0x06001042 RID: 4162 RVA: 0x00082CD5 File Offset: 0x00080ED5
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

	// Token: 0x06001043 RID: 4163 RVA: 0x00082D09 File Offset: 0x00080F09
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001044 RID: 4164 RVA: 0x00082D2C File Offset: 0x00080F2C
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
			this.material.SetFloat("_Speed", this.__Speed);
			this.material.SetFloat("RedFade", this._RedFade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001045 RID: 4165 RVA: 0x00082DF8 File Offset: 0x00080FF8
	private void Update()
	{
	}

	// Token: 0x06001046 RID: 4166 RVA: 0x00082DFA File Offset: 0x00080FFA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014C2 RID: 5314
	public Shader SCShader;

	// Token: 0x040014C3 RID: 5315
	private float TimeX = 1f;

	// Token: 0x040014C4 RID: 5316
	private Material SCMaterial;

	// Token: 0x040014C5 RID: 5317
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014C6 RID: 5318
	[Range(0f, 1f)]
	public float _RedFade = 1f;
}
