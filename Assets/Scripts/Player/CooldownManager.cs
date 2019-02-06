using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    #region Singleton

    public static CooldownManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        if (instance != this) Destroy(this);
    }

    #endregion

    public void SetCooldown(Skill skill)
    {
        StartCoroutine(Cooldown(skill));
    }

    public IEnumerator Cooldown(Skill skill)
    {
        yield return new WaitForSeconds(skill.cooldown);

        FinishCooldown(skill);
    }

    public void FinishCooldown(Skill skill)
    {
        skill.available = true;
    }
}
