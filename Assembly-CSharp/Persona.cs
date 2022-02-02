using System;
using UnityEngine;

// Token: 0x020002AF RID: 687
[Serializable]
public class Persona
{
	// Token: 0x06001442 RID: 5186 RVA: 0x000C564A File Offset: 0x000C384A
	public Persona(PersonaType type)
	{
		this.type = type;
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x06001443 RID: 5187 RVA: 0x000C5659 File Offset: 0x000C3859
	public PersonaType Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04001F1B RID: 7963
	[SerializeField]
	private PersonaType type;

	// Token: 0x04001F1C RID: 7964
	public static readonly PersonaTypeAndStringDictionary PersonaNames = new PersonaTypeAndStringDictionary
	{
		{
			PersonaType.None,
			"None"
		},
		{
			PersonaType.Loner,
			"Loner"
		},
		{
			PersonaType.TeachersPet,
			"Teacher's Pet"
		},
		{
			PersonaType.Heroic,
			"Heroic"
		},
		{
			PersonaType.Coward,
			"Coward"
		},
		{
			PersonaType.Evil,
			"Evil"
		},
		{
			PersonaType.SocialButterfly,
			"Social Butterfly"
		},
		{
			PersonaType.Lovestruck,
			"Lovestruck"
		},
		{
			PersonaType.Dangerous,
			"Dangerous"
		},
		{
			PersonaType.Strict,
			"Strict"
		},
		{
			PersonaType.PhoneAddict,
			"Phone Addict"
		},
		{
			PersonaType.Fragile,
			"Fragile"
		},
		{
			PersonaType.Spiteful,
			"Spiteful"
		},
		{
			PersonaType.Sleuth,
			"Sleuth"
		},
		{
			PersonaType.Vengeful,
			"Vengeful"
		},
		{
			PersonaType.Protective,
			"Protective"
		},
		{
			PersonaType.Violent,
			"Violent"
		},
		{
			PersonaType.LandlineUser,
			"Snitch"
		},
		{
			PersonaType.Nemesis,
			"?????"
		}
	};
}
