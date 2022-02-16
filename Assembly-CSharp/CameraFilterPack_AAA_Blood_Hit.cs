using System;
using UnityEngine;

// Token: 0x02000119 RID: 281
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood_Hit")]
public class CameraFilterPack_AAA_Blood_Hit : MonoBehaviour
{
	// Token: 0x1700021D RID: 541
	// (get) Token: 0x06000B14 RID: 2836 RVA: 0x0006AB60 File Offset: 0x00068D60
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

	// Token: 0x06000B15 RID: 2837 RVA: 0x0006AB94 File Offset: 0x00068D94
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_AAA_Blood_Hit1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_Blood_Hit");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B16 RID: 2838 RVA: 0x0006ABCC File Offset: 0x00068DCC
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
			this.material.SetFloat("_Value", this.LightReflect);
			this.material.SetFloat("_Value2", Mathf.Clamp(this.Hit_Left, 0f, 1f));
			this.material.SetFloat("_Value3", Mathf.Clamp(this.Hit_Up, 0f, 1f));
			this.material.SetFloat("_Value4", Mathf.Clamp(this.Hit_Right, 0f, 1f));
			this.material.SetFloat("_Value5", Mathf.Clamp(this.Hit_Down, 0f, 1f));
			this.material.SetFloat("_Value6", Mathf.Clamp(this.Blood_Hit_Left, 0f, 1f));
			this.material.SetFloat("_Value7", Mathf.Clamp(this.Blood_Hit_Up, 0f, 1f));
			this.material.SetFloat("_Value8", Mathf.Clamp(this.Blood_Hit_Right, 0f, 1f));
			this.material.SetFloat("_Value9", Mathf.Clamp(this.Blood_Hit_Down, 0f, 1f));
			this.material.SetFloat("_Value10", Mathf.Clamp(this.Hit_Full, 0f, 1f));
			this.material.SetFloat("_Value11", Mathf.Clamp(this.Blood_Hit_Full_1, 0f, 1f));
			this.material.SetFloat("_Value12", Mathf.Clamp(this.Blood_Hit_Full_2, 0f, 1f));
			this.material.SetFloat("_Value13", Mathf.Clamp(this.Blood_Hit_Full_3, 0f, 1f));
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B17 RID: 2839 RVA: 0x0006AE27 File Offset: 0x00069027
	private void Update()
	{
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x0006AE29 File Offset: 0x00069029
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EF7 RID: 3831
	public Shader SCShader;

	// Token: 0x04000EF8 RID: 3832
	private float TimeX = 1f;

	// Token: 0x04000EF9 RID: 3833
	[Range(0f, 1f)]
	public float Hit_Left = 1f;

	// Token: 0x04000EFA RID: 3834
	[Range(0f, 1f)]
	public float Hit_Up;

	// Token: 0x04000EFB RID: 3835
	[Range(0f, 1f)]
	public float Hit_Right;

	// Token: 0x04000EFC RID: 3836
	[Range(0f, 1f)]
	public float Hit_Down;

	// Token: 0x04000EFD RID: 3837
	[Range(0f, 1f)]
	public float Blood_Hit_Left;

	// Token: 0x04000EFE RID: 3838
	[Range(0f, 1f)]
	public float Blood_Hit_Up;

	// Token: 0x04000EFF RID: 3839
	[Range(0f, 1f)]
	public float Blood_Hit_Right;

	// Token: 0x04000F00 RID: 3840
	[Range(0f, 1f)]
	public float Blood_Hit_Down;

	// Token: 0x04000F01 RID: 3841
	[Range(0f, 1f)]
	public float Hit_Full;

	// Token: 0x04000F02 RID: 3842
	[Range(0f, 1f)]
	public float Blood_Hit_Full_1;

	// Token: 0x04000F03 RID: 3843
	[Range(0f, 1f)]
	public float Blood_Hit_Full_2;

	// Token: 0x04000F04 RID: 3844
	[Range(0f, 1f)]
	public float Blood_Hit_Full_3;

	// Token: 0x04000F05 RID: 3845
	[Range(0f, 1f)]
	public float LightReflect = 0.5f;

	// Token: 0x04000F06 RID: 3846
	private Material SCMaterial;

	// Token: 0x04000F07 RID: 3847
	private Texture2D Texture2;
}
