using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A5 RID: 1189
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F52 RID: 8018 RVA: 0x001B7520 File Offset: 0x001B5720
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F53 RID: 8019 RVA: 0x001B7534 File Offset: 0x001B5734
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F54 RID: 8020 RVA: 0x001B7594 File Offset: 0x001B5794
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F55 RID: 8021 RVA: 0x001B75D0 File Offset: 0x001B57D0
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F56 RID: 8022 RVA: 0x001B75D4 File Offset: 0x001B57D4
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

	// Token: 0x06001F57 RID: 8023 RVA: 0x001B7638 File Offset: 0x001B5838
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

	// Token: 0x0400414C RID: 16716
	[SerializeField]
	private List<T> elements;

	// Token: 0x0400414D RID: 16717
	private const string XML_Element = "Element";
}
