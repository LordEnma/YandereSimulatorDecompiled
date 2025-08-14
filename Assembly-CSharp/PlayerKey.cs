using UnityEngine;

public class PlayerKey : MonoBehaviour
{
	private Animator anim;

	private int Attack = 1;

	private bool jump;

	private float speed;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		speed = Input.GetAxis("Vertical");
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (!anim.GetBool("Hands"))
			{
				anim.SetBool("Hands", value: true);
			}
			else
			{
				anim.SetBool("Hands", value: false);
			}
		}
		if (Input.GetMouseButtonDown(0))
		{
			anim.SetBool("Attack_Btn", value: true);
		}
		if (Input.GetMouseButtonUp(0))
		{
			anim.SetBool("Attack_Btn", value: false);
		}
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Attack++;
			if (Attack > 5)
			{
				Attack = 1;
			}
			anim.SetInteger("Attack", Attack);
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			anim.SetBool("Talk_1", value: true);
		}
		if (Input.GetKeyUp(KeyCode.K))
		{
			anim.SetBool("Talk_1", value: false);
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			anim.SetBool("Talk_2", value: true);
		}
		if (Input.GetKeyUp(KeyCode.L))
		{
			anim.SetBool("Talk_2", value: false);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			anim.SetBool("PushLeftHand", value: true);
		}
		if (Input.GetKeyUp(KeyCode.F))
		{
			anim.SetBool("PushLeftHand", value: false);
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			anim.SetBool("PushRightHand", value: true);
		}
		if (Input.GetKeyUp(KeyCode.G))
		{
			anim.SetBool("PushRightHand", value: false);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			anim.SetBool("PushAllHands", value: true);
		}
		if (Input.GetKeyUp(KeyCode.H))
		{
			anim.SetBool("PushAllHands", value: false);
		}
		if (Input.GetKeyDown(KeyCode.U))
		{
			anim.SetBool("ComeHere_Left", value: true);
		}
		if (Input.GetKeyUp(KeyCode.U))
		{
			anim.SetBool("ComeHere_Left", value: false);
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			anim.SetBool("ComeHere_Right", value: true);
		}
		if (Input.GetKeyUp(KeyCode.I))
		{
			anim.SetBool("ComeHere_Right", value: false);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Jump", value: true);
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			anim.SetBool("Jump", value: false);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (!anim.GetBool("Defense_Left"))
			{
				anim.SetBool("Defense_Left", value: true);
			}
			else
			{
				anim.SetBool("Defense_Left", value: false);
			}
		}
		if (Input.GetKeyDown(KeyCode.T))
		{
			if (!anim.GetBool("Defense_Right"))
			{
				anim.SetBool("Defense_Right", value: true);
			}
			else
			{
				anim.SetBool("Defense_Right", value: false);
			}
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			if (!anim.GetBool("Defense_All"))
			{
				anim.SetBool("Defense_All", value: true);
			}
			else
			{
				anim.SetBool("Defense_All", value: false);
			}
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			anim.SetBool("Heart", value: true);
		}
		if (Input.GetKeyUp(KeyCode.Z))
		{
			anim.SetBool("Heart", value: false);
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			anim.SetBool("NoNoNo", value: true);
		}
		if (Input.GetKeyUp(KeyCode.X))
		{
			anim.SetBool("NoNoNo", value: false);
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			anim.SetBool("Hello_1", value: true);
		}
		if (Input.GetKeyUp(KeyCode.C))
		{
			anim.SetBool("Hello_1", value: false);
		}
		if (Input.GetKeyDown(KeyCode.V))
		{
			anim.SetBool("Hello_2", value: true);
		}
		if (Input.GetKeyUp(KeyCode.V))
		{
			anim.SetBool("Hello_2", value: false);
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			anim.SetBool("Show_Finger", value: true);
		}
		if (Input.GetKeyUp(KeyCode.M))
		{
			anim.SetBool("Show_Finger", value: false);
		}
		if (Input.GetKeyDown(KeyCode.N))
		{
			anim.SetBool("IdleImproved", value: true);
		}
		if (Input.GetKeyUp(KeyCode.N))
		{
			anim.SetBool("IdleImproved", value: false);
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			if (!anim.GetBool("Swim"))
			{
				anim.SetBool("Swim", value: true);
			}
			else
			{
				anim.SetBool("Swim", value: false);
			}
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			if (!anim.GetBool("ZeroGravity1"))
			{
				anim.SetBool("ZeroGravity1", value: true);
			}
			else
			{
				anim.SetBool("ZeroGravity1", value: false);
			}
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (!anim.GetBool("ZeroGravity2"))
			{
				anim.SetBool("ZeroGravity2", value: true);
			}
			else
			{
				anim.SetBool("ZeroGravity2", value: false);
			}
		}
	}

	private void FixedUpdate()
	{
		anim.SetFloat("Speed", speed);
	}
}
