using System;
using UnityEngine;

// Token: 0x02000152 RID: 338
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Regular")]
public class CameraFilterPack_Blur_Regular : MonoBehaviour
{
	// Token: 0x17000256 RID: 598
	// (get) Token: 0x06000CAB RID: 3243 RVA: 0x000731BB File Offset: 0x000713BB
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

	// Token: 0x06000CAC RID: 3244 RVA: 0x000731EF File Offset: 0x000713EF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Regular");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x00073210 File Offset: 0x00071410
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

	// Token: 0x06000CAE RID: 3246 RVA: 0x000732E2 File Offset: 0x000714E2
	private void Update()
	{
	}

	// Token: 0x06000CAF RID: 3247 RVA: 0x000732E4 File Offset: 0x000714E4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001101 RID: 4353
	public Shader SCShader;

	// Token: 0x04001102 RID: 4354
	private float TimeX = 1f;

	// Token: 0x04001103 RID: 4355
	private Material SCMaterial;

	// Token: 0x04001104 RID: 4356
	[Range(1f, 16f)]
	public int Level = 4;

	// Token: 0x04001105 RID: 4357
	public Vector2 Distance = new Vector2(30f, 0f);
}
