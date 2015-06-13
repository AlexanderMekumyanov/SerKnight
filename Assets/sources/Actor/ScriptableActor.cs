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

    public void ReceiveScriptFlag(ScriptParameter scriptParameter)
    {
        ScriptFlag = true;
        ScriptCommand = scriptParameter.ScriptCommand;
        ArrayOfParameter = scriptParameter.ArrayOfParameter;

        MethodInfo methodInfo = this.GetType().GetMethod(ScriptCommand);
        methodInfo.Invoke(this, ArrayOfParameter);
    }
}