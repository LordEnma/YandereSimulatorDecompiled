using System;
using UnityEngine;

// Token: 0x0200011D RID: 285
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/WaterDrop")]
public class CameraFilterPack_AAA_WaterDrop : MonoBehaviour
{
	// Token: 0x17000221 RID: 545
	// (get) Token: 0x06000B2E RID: 2862 RVA: 0x0006BD5C File Offset: 0x00069F5C
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

	// Token: 0x06000B2F RID: 2863 RVA: 0x0006BD90 File Offset: 0x00069F90
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

	// Token: 0x06000B30 RID: 2864 RVA: 0x0006BDC8 File Offset: 0x00069FC8
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

	// Token: 0x06000B31 RID: 2865 RVA: 0x0006BEA9 File Offset: 0x0006A0A9
	private void Update()
	{
	}

	// Token: 0x06000B32 RID: 2866 RVA: 0x0006BEAB File Offset: 0x0006A0AB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F3F RID: 3903
	public Shader SCShader;

	// Token: 0x04000F40 RID: 3904
	private float TimeX = 1f;

	// Token: 0x04000F41 RID: 3905
	[Range(8f, 64f)]
	public float Distortion = 8f;

	// Token: 0x04000F42 RID: 3906
	[Range(0f, 7f)]
	public float SizeX = 1f;

	// Token: 0x04000F43 RID: 3907
	[Range(0f, 7f)]
	public float SizeY = 0.5f;

	// Token: 0x04000F44 RID: 3908
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04000F45 RID: 3909
	private Material SCMaterial;

	// Token: 0x04000F46 RID: 3910
	private Texture2D Texture2;
}
