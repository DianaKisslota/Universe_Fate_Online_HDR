using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    protected EntityAvatar _avatar;

    public void BindAvatar(EntityAvatar avatar)
    {
        _avatar = avatar;
    }
}
