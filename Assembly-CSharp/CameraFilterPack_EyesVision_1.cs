using System;
using UnityEngine;

// Token: 0x020001A6 RID: 422
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Eyes 1")]
public class CameraFilterPack_EyesVision_1 : MonoBehaviour
{
	// Token: 0x170002AA RID: 682
	// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x0007AD58 File Offset: 0x00078F58
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

	// Token: 0x06000EA4 RID: 3748 RVA: 0x0007AD8C File Offset: 0x00078F8C
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_eyes_vision_1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/EyesVision_1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EA5 RID: 3749 RVA: 0x0007ADC4 File Offset: 0x00078FC4
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
			this.material.SetFloat("_Value", this._EyeWave);
			this.material.SetFloat("_Value2", this._EyeSpeed);
			this.material.SetFloat("_Value3", this._EyeMove);
			this.material.SetFloat("_Value4", this._EyeBlink);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EA6 RID: 3750 RVA: 0x0007AEA5 File Offset: 0x000790A5
	private void Update()
	{
	}

	// Token: 0x06000EA7 RID: 3751 RVA: 0x0007AEA7 File Offset: 0x000790A7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012EB RID: 4843
	public Shader SCShader;

	// Token: 0x040012EC RID: 4844
	private float TimeX = 1f;

	// Token: 0x040012ED RID: 4845
	[Range(1f, 32f)]
	public float _EyeWave = 15f;

	// Token: 0x040012EE RID: 4846
	[Range(0f, 10f)]
	public float _EyeSpeed = 1f;

	// Token: 0x040012EF RID: 4847
	[Range(0f, 8f)]
	public float _EyeMove = 2f;

	// Token: 0x040012F0 RID: 4848
	[Range(0f, 1f)]
	public float _EyeBlink = 1f;

	// Token: 0x040012F1 RID: 4849
	private Material SCMaterial;

	// Token: 0x040012F2 RID: 4850
	private Texture2D Texture2;
}
