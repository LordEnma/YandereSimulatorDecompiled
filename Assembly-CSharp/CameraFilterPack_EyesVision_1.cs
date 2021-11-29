using System;
using UnityEngine;

// Token: 0x020001A5 RID: 421
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Eyes 1")]
public class CameraFilterPack_EyesVision_1 : MonoBehaviour
{
	// Token: 0x170002AA RID: 682
	// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x0007AB60 File Offset: 0x00078D60
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

	// Token: 0x06000EA1 RID: 3745 RVA: 0x0007AB94 File Offset: 0x00078D94
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

	// Token: 0x06000EA2 RID: 3746 RVA: 0x0007ABCC File Offset: 0x00078DCC
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

	// Token: 0x06000EA3 RID: 3747 RVA: 0x0007ACAD File Offset: 0x00078EAD
	private void Update()
	{
	}

	// Token: 0x06000EA4 RID: 3748 RVA: 0x0007ACAF File Offset: 0x00078EAF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012E6 RID: 4838
	public Shader SCShader;

	// Token: 0x040012E7 RID: 4839
	private float TimeX = 1f;

	// Token: 0x040012E8 RID: 4840
	[Range(1f, 32f)]
	public float _EyeWave = 15f;

	// Token: 0x040012E9 RID: 4841
	[Range(0f, 10f)]
	public float _EyeSpeed = 1f;

	// Token: 0x040012EA RID: 4842
	[Range(0f, 8f)]
	public float _EyeMove = 2f;

	// Token: 0x040012EB RID: 4843
	[Range(0f, 1f)]
	public float _EyeBlink = 1f;

	// Token: 0x040012EC RID: 4844
	private Material SCMaterial;

	// Token: 0x040012ED RID: 4845
	private Texture2D Texture2;
}
