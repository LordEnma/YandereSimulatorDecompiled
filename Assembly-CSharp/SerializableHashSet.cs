using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A4 RID: 1188
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F45 RID: 8005 RVA: 0x001B628C File Offset: 0x001B448C
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x001B62A0 File Offset: 0x001B44A0
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F47 RID: 8007 RVA: 0x001B6300 File Offset: 0x001B4500
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F48 RID: 8008 RVA: 0x001B633C File Offset: 0x001B453C
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F49 RID: 8009 RVA: 0x001B6340 File Offset: 0x001B4540
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001F4A RID: 8010 RVA: 0x001B63A4 File Offset: 0x001B45A4
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004115 RID: 16661
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004116 RID: 16662
	private const string XML_Element = "Element";
}
