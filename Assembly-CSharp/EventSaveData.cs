using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C38 RID: 7224 RVA: 0x0014AA13 File Offset: 0x00148C13
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

	// Token: 0x06001C39 RID: 7225 RVA: 0x0014AA51 File Offset: 0x00148C51
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x040031C2 RID: 12738
	public bool befriendConversation;

	// Token: 0x040031C3 RID: 12739
	public bool event1;

	// Token: 0x040031C4 RID: 12740
	public bool event2;

	// Token: 0x040031C5 RID: 12741
	public bool kidnapConversation;

	// Token: 0x040031C6 RID: 12742
	public bool livingRoom;
}
