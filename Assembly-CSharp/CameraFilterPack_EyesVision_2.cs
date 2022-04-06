using System;
using UnityEngine;

// Token: 0x020001A7 RID: 423
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Eyes 2")]
public class CameraFilterPack_EyesVision_2 : MonoBehaviour
{
	// Token: 0x170002AB RID: 683
	// (get) Token: 0x06000EAC RID: 3756 RVA: 0x0007B728 File Offset: 0x00079928
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

	// Token: 0x06000EAD RID: 3757 RVA: 0x0007B75C File Offset: 0x0007995C
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_eyes_vision_2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/EyesVision_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EAE RID: 3758 RVA: 0x0007B794 File Offset: 0x00079994
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

	// Token: 0x06000EAF RID: 3759 RVA: 0x0007B875 File Offset: 0x00079A75
	private void Update()
	{
	}

	// Token: 0x06000EB0 RID: 3760 RVA: 0x0007B877 File Offset: 0x00079A77
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001306 RID: 4870
	public Shader SCShader;

	// Token: 0x04001307 RID: 4871
	private float TimeX = 1f;

	// Token: 0x04001308 RID: 4872
	[Range(1f, 32f)]
	public float _EyeWave = 15f;

	// Token: 0x04001309 RID: 4873
	[Range(0f, 10f)]
	public float _EyeSpeed = 1f;

	// Token: 0x0400130A RID: 4874
	[Range(0f, 8f)]
	public float _EyeMove = 2f;

	// Token: 0x0400130B RID: 4875
	[Range(0f, 1f)]
	public float _EyeBlink = 1f;

	// Token: 0x0400130C RID: 4876
	private Material SCMaterial;

	// Token: 0x0400130D RID: 4877
	private Texture2D Texture2;
}
