using System;

// Token: 0x020003FA RID: 1018
[Serializable]
public class EventSaveData
{
	// Token: 0x06001BFE RID: 7166 RVA: 0x00146293 File Offset: 0x00144493
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

	// Token: 0x06001BFF RID: 7167 RVA: 0x001462D1 File Offset: 0x001444D1
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x04003115 RID: 12565
	public bool befriendConversation;

	// Token: 0x04003116 RID: 12566
	public bool event1;

	// Token: 0x04003117 RID: 12567
	public bool event2;

	// Token: 0x04003118 RID: 12568
	public bool kidnapConversation;

	// Token: 0x04003119 RID: 12569
	public bool livingRoom;
}
