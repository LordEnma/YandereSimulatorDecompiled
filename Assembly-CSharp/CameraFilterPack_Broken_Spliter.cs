using System;
using UnityEngine;

// Token: 0x02000158 RID: 344
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Spliter")]
public class CameraFilterPack_Broken_Spliter : MonoBehaviour
{
	// Token: 0x1700025D RID: 605
	// (get) Token: 0x06000CCF RID: 3279 RVA: 0x000734F5 File Offset: 0x000716F5
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

	// Token: 0x06000CD0 RID: 3280 RVA: 0x00073529 File Offset: 0x00071729
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Broken_Spliter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x0007354C File Offset: 0x0007174C
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

	// Token: 0x06000CD2 RID: 3282 RVA: 0x0007362E File Offset: 0x0007182E
	private void Update()
	{
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x00073630 File Offset: 0x00071830
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
	private float __Speed = 1f;

	// Token: 0x0400111E RID: 4382
	[Range(0f, 1f)]
	public float _PosX = 0.5f;

	// Token: 0x0400111F RID: 4383
	[Range(0f, 1f)]
	public float _PosY = 0.5f;
}
