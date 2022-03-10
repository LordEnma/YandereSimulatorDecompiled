using System;
using UnityEngine;

// Token: 0x0200017C RID: 380
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Half_Sphere")]
public class CameraFilterPack_Distortion_Half_Sphere : MonoBehaviour
{
	// Token: 0x17000280 RID: 640
	// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x000771F0 File Offset: 0x000753F0
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

	// Token: 0x06000DA8 RID: 3496 RVA: 0x00077224 File Offset: 0x00075424
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Half_Sphere");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x00077248 File Offset: 0x00075448
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
			this.material.SetFloat("_SphereSize", this.SphereSize);
			this.material.SetFloat("_SpherePositionX", this.SpherePositionX);
			this.material.SetFloat("_SpherePositionY", this.SpherePositionY);
			this.material.SetFloat("_Strength", this.Strength);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x00077339 File Offset: 0x00075539
	private void Update()
	{
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x0007733B File Offset: 0x0007553B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011F3 RID: 4595
	public Shader SCShader;

	// Token: 0x040011F4 RID: 4596
	private float TimeX = 1f;

	// Token: 0x040011F5 RID: 4597
	[Range(1f, 6f)]
	private Material SCMaterial;

	// Token: 0x040011F6 RID: 4598
	public float SphereSize = 2.5f;

	// Token: 0x040011F7 RID: 4599
	[Range(-1f, 1f)]
	public float SpherePositionX;

	// Token: 0x040011F8 RID: 4600
	[Range(-1f, 1f)]
	public float SpherePositionY;

	// Token: 0x040011F9 RID: 4601
	[Range(1f, 10f)]
	public float Strength = 5f;
}
