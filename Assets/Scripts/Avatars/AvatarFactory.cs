using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public static class AvatarFactory
{
    public static MobAvatar CreateMob(Type entityType, Transform parent = null)
    {
        var modelPrefab = Global.GetPrefabForEntity(entityType);
        var model = GameObject.Instantiate<GameObject>(modelPrefab);
        var avatar = model.AddComponent<MobAvatar>();
        model.AddComponent<NavMeshAgent>();
        avatar.Entity = Activator.CreateInstance(entityType) as BaseEntity;
        avatar.transform.position = parent.position;

        return avatar;
    }

    public static CharacterAvatar CreateCharacter(Character character, Transform parent = null) 
    {
        var modelPrefab = Global.GetPrefabForEntity(typeof(Character));
        var model = GameObject.Instantiate<GameObject>(modelPrefab);
        var avatar = model.GetComponent<CharacterAvatar>();
        avatar.Entity = character;
        avatar.transform.position = parent.position;

        return avatar;
    }
}

