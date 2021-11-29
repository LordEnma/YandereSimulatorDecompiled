using System;

// Token: 0x020003F5 RID: 1013
[Serializable]
public class EventSaveData
{
	// Token: 0x06001BE1 RID: 7137 RVA: 0x0014317B File Offset: 0x0014137B
	public static EventSaveData ReadFromGlobals()
	{
		return new EventSaveData
		{
			befriendConversation = EventGlobals.BefriendConversation,
			event1 = EventGlobals.Event1,
			event2 = EventGlobals.Event2,
			kidnapConversation = EventGlobals.KidnapConversation,
			livingRoom = EventGlobals.LivingRoom
		};
	}

	// Token: 0x06001BE2 RID: 7138 RVA: 0x001431B9 File Offset: 0x001413B9
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x040030C9 RID: 12489
	public bool befriendConversation;

	// Token: 0x040030CA RID: 12490
	public bool event1;

	// Token: 0x040030CB RID: 12491
	public bool event2;

	// Token: 0x040030CC RID: 12492
	public bool kidnapConversation;

	// Token: 0x040030CD RID: 12493
	public bool livingRoom;
}
