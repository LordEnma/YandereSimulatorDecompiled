using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200038D RID: 909
public class OsanaWarningScript : MonoBehaviour
{
	// Token: 0x06001A5C RID: 6748 RVA: 0x00118A70 File Offset: 0x00116C70
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		this.Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = this.Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 11.2f;
		this.Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = this.Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		this.Profile.bloom.settings = settings3;
	}

	// Token: 0x06001A5D RID: 6749 RVA: 0x00118BA4 File Offset: 0x00116DA4
	private void Update()
	{
		if (this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
		}
		this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
		if (this.Alpha == 0f)
		{
			if (Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				return;
			}
		}
		else if (this.Alpha == 1f)
		{
			SceneManager.LoadScene("CalendarScene");
		}
	}

	// Token: 0x06001A5E RID: 6750 RVA: 0x00118C50 File Offset: 0x00116E50
	private void LateUpdate()
	{
		this.RightHand.localEulerAngles += new Vector3(UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f));
	}

	// Token: 0x04002B48 RID: 11080
	public PostProcessingProfile Profile;

	// Token: 0x04002B49 RID: 11081
	public Transform RightHand;

	// Token: 0x04002B4A RID: 11082
	public UISprite Darkness;

	// Token: 0x04002B4B RID: 11083
	public float Alpha = 1f;

	// Token: 0x04002B4C RID: 11084
	public bool FadeOut;
}
