using System;
using UnityEngine;

// Token: 0x02000159 RID: 345
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Spliter")]
public class CameraFilterPack_Broken_Spliter : MonoBehaviour
{
	// Token: 0x1700025D RID: 605
	// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x00073951 File Offset: 0x00071B51
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

	// Token: 0x06000CD4 RID: 3284 RVA: 0x00073985 File Offset: 0x00071B85
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Broken_Spliter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CD5 RID: 3285 RVA: 0x000739A8 File Offset: 0x00071BA8
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
			this.material.SetFloat("PosX", this._PosX);
			this.material.SetFloat("PosY", this._PosY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x00073A8A File Offset: 0x00071C8A
	private void Update()
	{
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x00073A8C File Offset: 0x00071C8C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001122 RID: 4386
	public Shader SCShader;

	// Token: 0x04001123 RID: 4387
	private float TimeX = 1f;

	// Token: 0x04001124 RID: 4388
	private Material SCMaterial;

	// Token: 0x04001125 RID: 4389
	[Range(0f, 1f)]
	private float __Speed = 1f;

	// Token: 0x04001126 RID: 4390
	[Range(0f, 1f)]
	public float _PosX = 0.5f;

	// Token: 0x04001127 RID: 4391
	[Range(0f, 1f)]
	public float _PosY = 0.5f;
}
