using UnityEngine;

public class DokiScript : MonoBehaviour
{
	public YandereShoeLockerScript ShoeLocker;

	public MusicCreditScript Credits;

	public YandereScript Yandere;

	public PromptScript OtherPrompt;

	public PromptScript Prompt;

	public GameObject TransformEffect;

	public Texture DokiTexture;

	public Texture[] DokiSocks;

	public Texture[] DokiHair;

	public string[] DokiName;

	public int ID;

	private void Update()
	{
		if (!Yandere.Egg)
		{
			if (OtherPrompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Hide();
				Prompt.enabled = false;
				base.enabled = false;
			}
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Yandere.PantyAttacher.newRenderer.enabled = false;
				Prompt.Circle[0].fillAmount = 1f;
				Object.Instantiate(TransformEffect, Yandere.Hips.position, Quaternion.identity);
				Yandere.MyRenderer.sharedMesh = Yandere.Uniforms[4];
				Yandere.MyRenderer.materials[0].mainTexture = DokiTexture;
				Yandere.MyRenderer.materials[1].mainTexture = DokiTexture;
				ID++;
				if (ID > 4)
				{
					ID = 1;
				}
				Credits.SongLabel.text = DokiName[ID] + " from Doki Doki Literature Club";
				Credits.BandLabel.text = "by Team Salvato";
				Credits.Sprite.enabled = true;
				Credits.Slide = true;
				Credits.Timer = 0f;
				if (ID == 1)
				{
					Yandere.MyRenderer.materials[0].SetTexture("_OverlayTex", DokiSocks[0]);
					Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", DokiSocks[0]);
				}
				else
				{
					Yandere.MyRenderer.materials[0].SetTexture("_OverlayTex", DokiSocks[1]);
					Yandere.MyRenderer.materials[1].SetTexture("_OverlayTex", DokiSocks[1]);
				}
				Debug.Log("Activating shadows on Yandere-chan.");
				Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
				Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
				Yandere.MyRenderer.materials[2].mainTexture = DokiHair[ID];
				Yandere.Hairstyle = 136 + ID;
				Yandere.UpdateHair();
				ShoeLocker.enabled = false;
			}
		}
		else
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}
}
