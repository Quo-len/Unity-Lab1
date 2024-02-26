using UnityEngine;
using System.Collections;

namespace MemberHiding
{
    public class Orc : Enemy
    {
        //This hides the Enemy version.
        new public void Yell()
        {
            Debug.Log("Orc version of the Yell() method");
        }
    }
}