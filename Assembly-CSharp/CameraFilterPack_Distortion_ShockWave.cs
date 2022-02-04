using System;
using UnityEngine;

// Token: 0x02000180 RID: 384
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/ShockWave")]
public class CameraFilterPack_Distortion_ShockWave : MonoBehaviour
{
	// Token: 0x17000284 RID: 644
	// (get) Token: 0x06000DBE RID: 3518 RVA: 0x000773C5 File Offset: 0x000755C5
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

	// Token: 0x06000DBF RID: 3519 RVA: 0x000773F9 File Offset: 0x000755F9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_ShockWave");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x0007741C File Offset: 0x0007561C
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
			this.material.SetFloat("_Value", this.PosX);
			this.material.SetFloat("_Value2", this.PosY);
			this.material.SetFloat("_Value3", this.Speed);
			this.material.SetFloat("_Value4", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DC1 RID: 3521 RVA: 0x00077514 File Offset: 0x00075714
	private void Update()
	{
	}

	// Token: 0x06000DC2 RID: 3522 RVA: 0x00077516 File Offset: 0x00075716
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011FC RID: 4604
	public Shader SCShader;

	// Token: 0x040011FD RID: 4605
	private float TimeX = 1f;

	// Token: 0x040011FE RID: 4606
	private Material SCMaterial;

	// Token: 0x040011FF RID: 4607
	[Range(-1.5f, 1.5f)]
	public float PosX = 0.5f;

	// Token: 0x04001200 RID: 4608
	[Range(-1.5f, 1.5f)]
	public float PosY = 0.5f;

	// Token: 0x04001201 RID: 4609
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001202 RID: 4610
	[Range(0f, 10f)]
	private float Size = 1f;
}
