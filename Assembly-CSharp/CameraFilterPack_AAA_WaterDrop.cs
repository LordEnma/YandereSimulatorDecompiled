using System;
using UnityEngine;

// Token: 0x0200011D RID: 285
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/WaterDrop")]
public class CameraFilterPack_AAA_WaterDrop : MonoBehaviour
{
	// Token: 0x17000221 RID: 545
	// (get) Token: 0x06000B2C RID: 2860 RVA: 0x0006B8E0 File Offset: 0x00069AE0
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

	// Token: 0x06000B2D RID: 2861 RVA: 0x0006B914 File Offset: 0x00069B14
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_WaterDrop") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_WaterDrop");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B2E RID: 2862 RVA: 0x0006B94C File Offset: 0x00069B4C
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_SizeX", this.SizeX);
			this.material.SetFloat("_SizeY", this.SizeY);
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B2F RID: 2863 RVA: 0x0006BA2D File Offset: 0x00069C2D
	private void Update()
	{
	}

	// Token: 0x06000B30 RID: 2864 RVA: 0x0006BA2F File Offset: 0x00069C2F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F38 RID: 3896
	public Shader SCShader;

	// Token: 0x04000F39 RID: 3897
	private float TimeX = 1f;

	// Token: 0x04000F3A RID: 3898
	[Range(8f, 64f)]
	public float Distortion = 8f;

	// Token: 0x04000F3B RID: 3899
	[Range(0f, 7f)]
	public float SizeX = 1f;

	// Token: 0x04000F3C RID: 3900
	[Range(0f, 7f)]
	public float SizeY = 0.5f;

	// Token: 0x04000F3D RID: 3901
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04000F3E RID: 3902
	private Material SCMaterial;

	// Token: 0x04000F3F RID: 3903
	private Texture2D Texture2;
}
