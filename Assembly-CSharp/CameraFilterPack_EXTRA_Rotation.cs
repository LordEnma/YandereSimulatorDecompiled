using System;
using UnityEngine;

// Token: 0x0200019D RID: 413
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/EXTRA/Rotation")]
public class CameraFilterPack_EXTRA_Rotation : MonoBehaviour
{
	// Token: 0x170002A2 RID: 674
	// (get) Token: 0x06000E6F RID: 3695 RVA: 0x0007A071 File Offset: 0x00078271
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

	// Token: 0x06000E70 RID: 3696 RVA: 0x0007A0A5 File Offset: 0x000782A5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/EXTRA_Rotation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E71 RID: 3697 RVA: 0x0007A0C8 File Offset: 0x000782C8
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
			this.material.SetFloat("_Value", -this.Rotation);
			this.material.SetFloat("_Value2", this.PositionX);
			this.material.SetFloat("_Value3", this.PositionY);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E72 RID: 3698 RVA: 0x0007A1C1 File Offset: 0x000783C1
	private void Update()
	{
	}

	// Token: 0x06000E73 RID: 3699 RVA: 0x0007A1C3 File Offset: 0x000783C3
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012BE RID: 4798
	public Shader SCShader;

	// Token: 0x040012BF RID: 4799
	private float TimeX = 1f;

	// Token: 0x040012C0 RID: 4800
	private Material SCMaterial;

	// Token: 0x040012C1 RID: 4801
	[Range(-360f, 360f)]
	public float Rotation;

	// Token: 0x040012C2 RID: 4802
	[Range(-1f, 2f)]
	public float PositionX = 0.5f;

	// Token: 0x040012C3 RID: 4803
	[Range(-1f, 2f)]
	public float PositionY = 0.5f;

	// Token: 0x040012C4 RID: 4804
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
