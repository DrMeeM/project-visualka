using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal struct ChildData
{
    public ILayoutIgnorer Ignorer;
    public RectTransform Transform;
    public Vector2 Position;
    public Vector2 Size;

    public bool IsIgnored => Ignorer?.ignoreLayout ?? false;
}
