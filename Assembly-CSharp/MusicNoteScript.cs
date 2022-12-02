using UnityEngine;

public class MusicNoteScript : MonoBehaviour
{
	public MusicMinigameScript MusicMinigame;

	public InputManagerScript InputManager;

	public GameObject Ripple;

	public GameObject Perfect;

	public GameObject Wrong;

	public GameObject Early;

	public GameObject Late;

	public GameObject Miss;

	public GameObject Rating;

	public string XboxDirection;

	public string Direction;

	public string Tapped;

	public bool GaveInput;

	public bool Proceed;

	public float Speed;

	public int ID;

	private void Update()
	{
		base.transform.localPosition += new Vector3(Speed * Time.deltaTime * -1f, 0f, 0f);
		if (!MusicMinigame.KeyDown)
		{
			GaveInput = false;
			if (InputManager.TappedUp)
			{
				GaveInput = true;
				Tapped = "up";
			}
			else if (InputManager.TappedDown)
			{
				GaveInput = true;
				Tapped = "down";
			}
			else if (InputManager.TappedRight)
			{
				GaveInput = true;
				Tapped = "right";
			}
			else if (InputManager.TappedLeft)
			{
				GaveInput = true;
				Tapped = "left";
			}
			if (Input.GetKeyDown(Direction) || (GaveInput && Tapped == Direction))
			{
				if (MusicMinigame.CurrentNote == ID)
				{
					if (base.transform.localPosition.x > -0.6f && base.transform.localPosition.x < -0.4f)
					{
						Rating = Object.Instantiate(Perfect, base.transform.position, Quaternion.identity);
						Proceed = true;
						MusicMinigame.Health += 1f;
						MusicMinigame.CringeTimer = 0f;
						MusicMinigame.UpdateHealthBar();
					}
					else if (base.transform.localPosition.x > -0.4f && base.transform.localPosition.x < -0.2f)
					{
						Rating = Object.Instantiate(Early, base.transform.position, Quaternion.identity);
						MusicMinigame.CringeTimer = 0f;
						Proceed = true;
					}
					else if (base.transform.localPosition.x > -0.8f && base.transform.localPosition.x < -0.4f)
					{
						Rating = Object.Instantiate(Late, base.transform.position, Quaternion.identity);
						MusicMinigame.CringeTimer = 0f;
						Proceed = true;
					}
				}
			}
			else if (Input.anyKeyDown && base.transform.localPosition.x > -0.8f && base.transform.localPosition.x < -0.2f && !MusicMinigame.GameOver)
			{
				Rating = Object.Instantiate(Wrong, base.transform.position, Quaternion.identity);
				Proceed = true;
				MusicMinigame.Cringe();
				if (!MusicMinigame.LockHealth)
				{
					MusicMinigame.Health -= 10f;
				}
				MusicMinigame.UpdateHealthBar();
			}
		}
		if (Proceed)
		{
			GameObject obj = Object.Instantiate(Ripple, base.transform.position, Quaternion.identity);
			obj.transform.parent = base.transform.parent;
			obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			Rating.transform.parent = base.transform.parent;
			Rating.transform.localPosition = new Vector3(-0.5f, 0.25f, 0f);
			Rating.transform.localScale = new Vector3(0.3f, 0.15f, 0.15f);
			MusicMinigame.CurrentNote++;
			MusicMinigame.KeyDown = true;
			Object.Destroy(base.gameObject);
		}
		else if (base.transform.localPosition.x < -0.65f && MusicMinigame.CurrentNote == ID)
		{
			MusicMinigame.CurrentNote++;
		}
		if (base.transform.localPosition.x < -0.94f && !MusicMinigame.GameOver)
		{
			Rating = Object.Instantiate(Miss, base.transform.position, Quaternion.identity);
			Rating.transform.parent = base.transform.parent;
			Rating.transform.localPosition = new Vector3(-0.94f, 0.25f, 0f);
			Rating.transform.localScale = new Vector3(0.3f, 0.15f, 0.15f);
			Object.Destroy(base.gameObject);
			MusicMinigame.Cringe();
			if (!MusicMinigame.LockHealth)
			{
				MusicMinigame.Health -= 10f;
			}
			MusicMinigame.UpdateHealthBar();
		}
	}
}
