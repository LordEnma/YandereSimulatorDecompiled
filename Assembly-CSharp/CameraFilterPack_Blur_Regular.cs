using System;
using UnityEngine;

// Token: 0x02000151 RID: 337
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Regular")]
public class CameraFilterPack_Blur_Regular : MonoBehaviour
{
	// Token: 0x17000256 RID: 598
	// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x0007279B File Offset: 0x0007099B
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

	// Token: 0x06000CA6 RID: 3238 RVA: 0x000727CF File Offset: 0x000709CF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Regular");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x000727F0 File Offset: 0x000709F0
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

	// Token: 0x06000CA8 RID: 3240 RVA: 0x000728C2 File Offset: 0x00070AC2
	private void Update()
	{
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x000728C4 File Offset: 0x00070AC4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010E9 RID: 4329
	public Shader SCShader;

	// Token: 0x040010EA RID: 4330
	private float TimeX = 1f;

	// Token: 0x040010EB RID: 4331
	private Material SCMaterial;

	// Token: 0x040010EC RID: 4332
	[Range(1f, 16f)]
	public int Level = 4;

	// Token: 0x040010ED RID: 4333
	public Vector2 Distance = new Vector2(30f, 0f);
}
