using System;
using UnityEngine;

// Token: 0x02000158 RID: 344
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Simple")]
public class CameraFilterPack_Broken_Simple : MonoBehaviour
{
	// Token: 0x1700025C RID: 604
	// (get) Token: 0x06000CCD RID: 3277 RVA: 0x0007377A File Offset: 0x0007197A
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

	// Token: 0x06000CCE RID: 3278 RVA: 0x000737AE File Offset: 0x000719AE
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Broken_Simple");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CCF RID: 3279 RVA: 0x000737D0 File Offset: 0x000719D0
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

	// Token: 0x06000CD0 RID: 3280 RVA: 0x000738DE File Offset: 0x00071ADE
	private void Update()
	{
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x000738E0 File Offset: 0x00071AE0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400111A RID: 4378
	public Shader SCShader;

	// Token: 0x0400111B RID: 4379
	private float TimeX = 1f;

	// Token: 0x0400111C RID: 4380
	private Material SCMaterial;

	// Token: 0x0400111D RID: 4381
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x0400111E RID: 4382
	[Range(0f, 1f)]
	public float _Broke1 = 1f;

	// Token: 0x0400111F RID: 4383
	[Range(0f, 1f)]
	public float _Broke2 = 1f;

	// Token: 0x04001120 RID: 4384
	[Range(0f, 1f)]
	public float _PosX = 0.5f;

	// Token: 0x04001121 RID: 4385
	[Range(0f, 1f)]
	public float _PosY = 0.5f;
}
