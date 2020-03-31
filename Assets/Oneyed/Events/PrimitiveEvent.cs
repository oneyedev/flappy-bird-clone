using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace OneEyed.Events
{
    public enum Dimension { On2D, On3D };
    [Serializable]
    public class OnBoolEvent : UnityEvent<bool> { }

    [Serializable]
    public class OnIntEvent : UnityEvent<int> { }

    [Serializable]
    public class OnFloatEvent : UnityEvent<float> { }

    [Serializable]
    public class OnStringEvent : UnityEvent<string> { }

    [Serializable]
    public class OnVector3Event : UnityEvent<Vector3> { }

    [Serializable]
    public class OnQuaternionEvent : UnityEvent<Quaternion> { }

    [Serializable]
    public class OnCollisionEvent : UnityEvent<Collision> { }
    [Serializable]
    public class OnCollision2DEvent : UnityEvent<Collision2D> { }
    [Serializable]
    public class OnControllerCollisionHitEvent : UnityEvent<ControllerColliderHit> { }

    [Serializable]
    public class OnColliderEvent : UnityEvent<Collider> { }
    [Serializable]
    public class OnCollider2DEvent : UnityEvent<Collider2D> { }

    [Serializable]
    public class OnGameObjectEvent : UnityEvent<GameObject> { }

    [Serializable]
    public class OnSpriteEvent : UnityEvent<Sprite> { }

    [Serializable]
    public class OnPointerEvent : UnityEvent<PointerEventData> { }
    [Serializable]
    public class OnObjectEvent : UnityEvent<object> { }
    [Serializable]
    public class OnKeyCodeEvent : UnityEvent<KeyCode> { }
}

