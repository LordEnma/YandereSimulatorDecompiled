using System;
using UnityEngine;

// Token: 0x02000152 RID: 338
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Regular")]
public class CameraFilterPack_Blur_Regular : MonoBehaviour
{
	// Token: 0x17000256 RID: 598
	// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00072D3F File Offset: 0x00070F3F
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

	// Token: 0x06000CAA RID: 3242 RVA: 0x00072D73 File Offset: 0x00070F73
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Regular");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CAB RID: 3243 RVA: 0x00072D94 File Offset: 0x00070F94
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
			this.material.SetFloat("_Level", (float)this.Level);
			this.material.SetVector("_Distance", this.Distance);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CAC RID: 3244 RVA: 0x00072E66 File Offset: 0x00071066
	private void Update()
	{
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x00072E68 File Offset: 0x00071068
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010FA RID: 4346
	public Shader SCShader;

	// Token: 0x040010FB RID: 4347
	private float TimeX = 1f;

	// Token: 0x040010FC RID: 4348
	private Material SCMaterial;

	// Token: 0x040010FD RID: 4349
	[Range(1f, 16f)]
	public int Level = 4;

	// Token: 0x040010FE RID: 4350
	public Vector2 Distance = new Vector2(30f, 0f);
}
