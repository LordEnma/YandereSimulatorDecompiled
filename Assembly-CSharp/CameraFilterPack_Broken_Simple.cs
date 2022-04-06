using System;
using UnityEngine;

// Token: 0x02000158 RID: 344
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Simple")]
public class CameraFilterPack_Broken_Simple : MonoBehaviour
{
	// Token: 0x1700025C RID: 604
	// (get) Token: 0x06000CCF RID: 3279 RVA: 0x00073D3E File Offset: 0x00071F3E
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

	// Token: 0x06000CD0 RID: 3280 RVA: 0x00073D72 File Offset: 0x00071F72
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Broken_Simple");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x00073D94 File Offset: 0x00071F94
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
			this.material.SetFloat("Broke1", this._Broke1);
			this.material.SetFloat("Broke2", this._Broke2);
			this.material.SetFloat("PosX", this._PosX);
			this.material.SetFloat("PosY", this._PosY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x00073EA2 File Offset: 0x000720A2
	private void Update()
	{
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x00073EA4 File Offset: 0x000720A4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400112A RID: 4394
	public Shader SCShader;

	// Token: 0x0400112B RID: 4395
	private float TimeX = 1f;

	// Token: 0x0400112C RID: 4396
	private Material SCMaterial;

	// Token: 0x0400112D RID: 4397
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x0400112E RID: 4398
	[Range(0f, 1f)]
	public float _Broke1 = 1f;

	// Token: 0x0400112F RID: 4399
	[Range(0f, 1f)]
	public float _Broke2 = 1f;

	// Token: 0x04001130 RID: 4400
	[Range(0f, 1f)]
	public float _PosX = 0.5f;

	// Token: 0x04001131 RID: 4401
	[Range(0f, 1f)]
	public float _PosY = 0.5f;
}
