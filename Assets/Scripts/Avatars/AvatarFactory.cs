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
        var agent = model.AddComponent<NavMeshAgent>();
        agent.isStopped = true;
        agent.enabled = false;
        var meshObstacle = model.AddComponent<NavMeshObstacle>();
        meshObstacle.carving = true;
        meshObstacle.carveOnlyStationary = false;
        var rigidBody = model.AddComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        model.AddComponent<AudioSource>();
        avatar.Entity = Activator.CreateInstance(entityType) as BaseEntity;
        avatar.Entity.Die += avatar.EntityDie;
        avatar.transform.position = parent.position;

        return avatar;
    }

    public static CharacterAvatar CreateCharacter(Character character, Transform parent = null) 
    {
        var modelPrefab = Global.GetPrefabForEntity(typeof(Character));
        var model = GameObject.Instantiate<GameObject>(modelPrefab);
        var avatar = model.GetComponent<CharacterAvatar>();
        model.AddComponent<AudioSource>();
        avatar.Entity = character;
        avatar.Entity.Die += avatar.EntityDie;
        avatar.transform.position = parent.position;

        return avatar;
    }
}

