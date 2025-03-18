using UnityEngine;

public class ControllerTestScript : MonoBehaviour
{
	public UISprite[] Button;

	private void Update()
	{
		Button[0].alpha = (Input.GetButton(InputNames.Xbox_A) ? 1f : 0.5f);
		Button[1].alpha = (Input.GetButton(InputNames.Xbox_B) ? 1f : 0.5f);
		Button[2].alpha = (Input.GetButton(InputNames.Xbox_X) ? 1f : 0.5f);
		Button[3].alpha = (Input.GetButton(InputNames.Xbox_Y) ? 1f : 0.5f);
		Button[4].alpha = (Input.GetButton(InputNames.Xbox_Start) ? 1f : 0.5f);
		Button[5].alpha = (Input.GetButton(InputNames.Xbox_Back) ? 1f : 0.5f);
		Button[6].alpha = (Input.GetButton(InputNames.Xbox_LS) ? 1f : 0.5f);
		Button[7].alpha = (Input.GetButton(InputNames.Xbox_RS) ? 1f : 0.5f);
		Button[8].alpha = (Input.GetButton(InputNames.Xbox_LB) ? 1f : 0.5f);
		Button[9].alpha = (Input.GetButton(InputNames.Xbox_RB) ? 1f : 0.5f);
		Button[10].alpha = ((Input.GetAxis(InputNames.Xbox_LT) > 0.5f) ? 1f : 0.5f);
		Button[11].alpha = ((Input.GetAxis(InputNames.Xbox_RT) > 0.5f) ? 1f : 0.5f);
		Button[12].alpha = ((Input.GetAxis(InputNames.Xbox_DpadX) > 0.5f) ? 1f : 0.5f);
		Button[13].alpha = ((Input.GetAxis(InputNames.Xbox_DpadY) > 0.5f) ? 1f : 0.5f);
		Button[14].alpha = ((Input.GetAxis("Horizontal") > 0.5f) ? 1f : 0.5f);
		Button[15].alpha = ((Input.GetAxis("Vertical") > 0.5f) ? 1f : 0.5f);
		Button[16].alpha = ((Input.GetAxis(InputNames.Xbox_JoyX) > 0.5f) ? 1f : 0.5f);
		Button[17].alpha = ((Input.GetAxis(InputNames.Xbox_JoyY) > 0.5f) ? 1f : 0.5f);
	}
}
