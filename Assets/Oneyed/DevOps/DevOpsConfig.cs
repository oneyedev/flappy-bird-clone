using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OneEyed.Attributes;

namespace OneEyed.DevOps
{

    [Serializable]
    public class DevOpsBool : DevOpsConfig<bool>
    {
        public DevOpsBool()
        {
            editor = true;
            developmentBuild = true;
            releaseBuild = false;
        }
    }
    [Serializable] public class DevOpsString : DevOpsConfig<string> { }
    [Serializable] public class DevOpsFloat : DevOpsConfig<float> { }
    [Serializable] public class DevOpsInt : DevOpsConfig<int> { }

    public class DevOpsConfig<T>
    {
        public T editor;
        public T developmentBuild;
        public T releaseBuild;

        public static DevOpsType GetCurrentType()
        {
            if (Application.isEditor)
            {
                return DevOpsType.Editor;
            }
            else
            {
                if (Debug.isDebugBuild)
                {
                    return DevOpsType.DevelopmentBuild;
                }
                else
                {
                    return DevOpsType.ReleaseBuild;
                }
            }
        }

        public T Current
        {
            get => GetConfig(GetCurrentType());
        }

        public T GetConfig(DevOpsType type)
        {
            if (type == DevOpsType.Editor)
            {
                return editor;
            }
            else if (type == DevOpsType.DevelopmentBuild)
            {
                return developmentBuild;
            }
            else if (type == DevOpsType.ReleaseBuild)
            {
                return releaseBuild;
            }
            return editor;
        }
    }
}
