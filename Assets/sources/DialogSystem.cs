using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Serialization;

public class DialogSystem
{
    static DialogSystem dialogSystem;

    private XmlDocument text;

    public DialogSystem ()
    {
        text = new XmlDocument();
        text.Load("Assets\\resources\\files\\text.xml");
    }

    public static DialogSystem GetDialogSystem()
    {
        if (dialogSystem == null)
        {
            dialogSystem = new DialogSystem();
            return dialogSystem;
        }
        else
        {
            return dialogSystem;
        }
    }

    public string GetDialogById(string id)
    {
        XmlNode node = text.SelectSingleNode(id);
        return node.InnerText;
    }
}
