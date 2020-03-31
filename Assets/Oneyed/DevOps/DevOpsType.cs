using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OneEyed.Attributes;

namespace OneEyed.DevOps
{
    [Flags]
    public enum DevOpsType
    {
        Editor = (1 << 0),
        DevelopmentBuild = (1 << 1),
        ReleaseBuild = (1 << 2)
    }
}
