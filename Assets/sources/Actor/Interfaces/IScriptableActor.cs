using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface IScriptableActor
{
    bool     ScriptFlag{get; set;}
    string   ScriptCommand{get; set;}
    string[] ArrayOfParameter{get; set;}
    Dictionary<string, bool> states { get; set; }

    void ReceiveScriptFlag(ScriptParameter scriptParameter);
    bool GetCurrState(string name);
    void SetCurrState(string name, bool value);
}
