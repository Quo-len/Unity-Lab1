using UnityEngine;
using System.Collections;

namespace MemberHiding
{
    public class Enemy : Humanoid
    {
        //This hides the Humanoid version.
        new public void Yell()
        {
            Debug.Log("Enemy version of the Yell() method");
        }
    }
}