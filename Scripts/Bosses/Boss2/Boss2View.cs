using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2View : CharacterAnimator
{
    public void Idle()
    {
        ChangeAnimation("Idle");
    }

    public void Attack1()
    {
        ChangeAnimation("Attack1");
    }
}
