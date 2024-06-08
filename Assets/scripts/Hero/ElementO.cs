using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
/*被动1：剧烈燃烧，每次攻击消耗自身当前生命，大幅增加攻速
被动2：燃烧，每次攻击为攻击附着每秒扣血buff，可叠层
技能1；超氧形态，给自己加攻击力攻速buff，类似棘刺、
技能2：氧化，氧化一个目标，降低防御。*/
public class ElementO : Hero
{
    public override void AttackTarget(Hero target)
    {
        base.AttackTarget(target);

    }
}
