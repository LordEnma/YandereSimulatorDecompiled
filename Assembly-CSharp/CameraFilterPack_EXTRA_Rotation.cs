using System;
using UnityEngine;

// Token: 0x0200019E RID: 414
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/EXTRA/Rotation")]
public class CameraFilterPack_EXTRA_Rotation : MonoBehaviour
{
	// Token: 0x170002A2 RID: 674
	// (get) Token: 0x06000E72 RID: 3698 RVA: 0x0007A269 File Offset: 0x00078469
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

	// Token: 0x06000E73 RID: 3699 RVA: 0x0007A29D File Offset: 0x0007849D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/EXTRA_Rotation");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E74 RID: 3700 RVA: 0x0007A2C0 File Offset: 0x000784C0
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

	// Token: 0x06000E75 RID: 3701 RVA: 0x0007A3B9 File Offset: 0x000785B9
	private void Update()
	{
	}

	// Token: 0x06000E76 RID: 3702 RVA: 0x0007A3BB File Offset: 0x000785BB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012C3 RID: 4803
	public Shader SCShader;

	// Token: 0x040012C4 RID: 4804
	private float TimeX = 1f;

	// Token: 0x040012C5 RID: 4805
	private Material SCMaterial;

	// Token: 0x040012C6 RID: 4806
	[Range(-360f, 360f)]
	public float Rotation;

	// Token: 0x040012C7 RID: 4807
	[Range(-1f, 2f)]
	public float PositionX = 0.5f;

	// Token: 0x040012C8 RID: 4808
	[Range(-1f, 2f)]
	public float PositionY = 0.5f;

	// Token: 0x040012C9 RID: 4809
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
