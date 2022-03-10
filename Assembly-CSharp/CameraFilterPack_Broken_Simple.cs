using System;
using UnityEngine;

// Token: 0x02000158 RID: 344
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Simple")]
public class CameraFilterPack_Broken_Simple : MonoBehaviour
{
	// Token: 0x1700025C RID: 604
	// (get) Token: 0x06000CCD RID: 3277 RVA: 0x000738C2 File Offset: 0x00071AC2
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

	// Token: 0x06000CCE RID: 3278 RVA: 0x000738F6 File Offset: 0x00071AF6
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Broken_Simple");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CCF RID: 3279 RVA: 0x00073918 File Offset: 0x00071B18
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

	// Token: 0x06000CD0 RID: 3280 RVA: 0x00073A26 File Offset: 0x00071C26
	private void Update()
	{
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x00073A28 File Offset: 0x00071C28
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001123 RID: 4387
	public Shader SCShader;

	// Token: 0x04001124 RID: 4388
	private float TimeX = 1f;

	// Token: 0x04001125 RID: 4389
	private Material SCMaterial;

	// Token: 0x04001126 RID: 4390
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x04001127 RID: 4391
	[Range(0f, 1f)]
	public float _Broke1 = 1f;

	// Token: 0x04001128 RID: 4392
	[Range(0f, 1f)]
	public float _Broke2 = 1f;

	// Token: 0x04001129 RID: 4393
	[Range(0f, 1f)]
	public float _PosX = 0.5f;

	// Token: 0x0400112A RID: 4394
	[Range(0f, 1f)]
	public float _PosY = 0.5f;
}
