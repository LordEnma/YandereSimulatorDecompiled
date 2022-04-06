using System;
using UnityEngine;

// Token: 0x02000119 RID: 281
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood_Hit")]
public class CameraFilterPack_AAA_Blood_Hit : MonoBehaviour
{
	// Token: 0x1700021D RID: 541
	// (get) Token: 0x06000B16 RID: 2838 RVA: 0x0006B238 File Offset: 0x00069438
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

	// Token: 0x06000B17 RID: 2839 RVA: 0x0006B26C File Offset: 0x0006946C
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

	// Token: 0x06000B18 RID: 2840 RVA: 0x0006B2A4 File Offset: 0x000694A4
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

	// Token: 0x06000B19 RID: 2841 RVA: 0x0006B4FF File Offset: 0x000696FF
	private void Update()
	{
	}

	// Token: 0x06000B1A RID: 2842 RVA: 0x0006B501 File Offset: 0x00069701
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F07 RID: 3847
	public Shader SCShader;

	// Token: 0x04000F08 RID: 3848
	private float TimeX = 1f;

	// Token: 0x04000F09 RID: 3849
	[Range(0f, 1f)]
	public float Hit_Left = 1f;

	// Token: 0x04000F0A RID: 3850
	[Range(0f, 1f)]
	public float Hit_Up;

	// Token: 0x04000F0B RID: 3851
	[Range(0f, 1f)]
	public float Hit_Right;

	// Token: 0x04000F0C RID: 3852
	[Range(0f, 1f)]
	public float Hit_Down;

	// Token: 0x04000F0D RID: 3853
	[Range(0f, 1f)]
	public float Blood_Hit_Left;

	// Token: 0x04000F0E RID: 3854
	[Range(0f, 1f)]
	public float Blood_Hit_Up;

	// Token: 0x04000F0F RID: 3855
	[Range(0f, 1f)]
	public float Blood_Hit_Right;

	// Token: 0x04000F10 RID: 3856
	[Range(0f, 1f)]
	public float Blood_Hit_Down;

	// Token: 0x04000F11 RID: 3857
	[Range(0f, 1f)]
	public float Hit_Full;

	// Token: 0x04000F12 RID: 3858
	[Range(0f, 1f)]
	public float Blood_Hit_Full_1;

	// Token: 0x04000F13 RID: 3859
	[Range(0f, 1f)]
	public float Blood_Hit_Full_2;

	// Token: 0x04000F14 RID: 3860
	[Range(0f, 1f)]
	public float Blood_Hit_Full_3;

	// Token: 0x04000F15 RID: 3861
	[Range(0f, 1f)]
	public float LightReflect = 0.5f;

	// Token: 0x04000F16 RID: 3862
	private Material SCMaterial;

	// Token: 0x04000F17 RID: 3863
	private Texture2D Texture2;
}
