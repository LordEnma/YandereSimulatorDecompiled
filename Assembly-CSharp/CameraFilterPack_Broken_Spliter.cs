using System;
using UnityEngine;

// Token: 0x02000159 RID: 345
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Spliter")]
public class CameraFilterPack_Broken_Spliter : MonoBehaviour
{
	// Token: 0x1700025D RID: 605
	// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x00073F15 File Offset: 0x00072115
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

	// Token: 0x06000CD6 RID: 3286 RVA: 0x00073F49 File Offset: 0x00072149
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Broken_Spliter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x00073F6C File Offset: 0x0007216C
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

	// Token: 0x06000CD8 RID: 3288 RVA: 0x0007404E File Offset: 0x0007224E
	private void Update()
	{
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x00074050 File Offset: 0x00072250
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001132 RID: 4402
	public Shader SCShader;

	// Token: 0x04001133 RID: 4403
	private float TimeX = 1f;

	// Token: 0x04001134 RID: 4404
	private Material SCMaterial;

	// Token: 0x04001135 RID: 4405
	[Range(0f, 1f)]
	private float __Speed = 1f;

	// Token: 0x04001136 RID: 4406
	[Range(0f, 1f)]
	public float _PosX = 0.5f;

	// Token: 0x04001137 RID: 4407
	[Range(0f, 1f)]
	public float _PosY = 0.5f;
}
