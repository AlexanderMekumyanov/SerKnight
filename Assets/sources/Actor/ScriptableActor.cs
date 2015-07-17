using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public struct ScriptParameter
{
    public string ScriptCommand;
    public string[] ArrayOfParameter;
}

public abstract class ScriptableActor : MonoBehaviour, IScriptableActor
{
    public bool ScriptFlag { get; set; }
    public string ScriptCommand { get; set; }
    public string[] ArrayOfParameter { get; set; }
    public Dictionary<string, bool> states { get; set; }

    public void ReceiveScriptFlag(ScriptParameter scriptParameter)
    {
        ScriptFlag = true;
        ScriptCommand = scriptParameter.ScriptCommand;
        ArrayOfParameter = scriptParameter.ArrayOfParameter;

        MethodInfo methodInfo = this.GetType().GetMethod(ScriptCommand);
        methodInfo.Invoke(this, ArrayOfParameter);
    }

    public bool GetCurrState(string name)
    {
        bool isHave = false;
        if (states.TryGetValue(name, out isHave))
        {
            return states[name];
        }
        else
        {
            states.Add(name, false);
            return false;
        }
    }

    public void SetCurrState(string name, bool value)
    {
        bool isHave = false;
        if (states.TryGetValue(name, out isHave))
        {
            states[name] = value;
        }
        else
        {
            states.Add(name, false);
            states[name] = value;
        }
    }
}