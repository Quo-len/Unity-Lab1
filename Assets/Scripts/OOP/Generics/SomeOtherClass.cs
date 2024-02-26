using UnityEngine;
using System.Collections;

namespace Generics
{
    public class SomeOtherClass : MonoBehaviour
    {
        void Start()
        {
            SomeClass myClass = new SomeClass();

            //In order to use this method you must
            //tell the method what type to replace
            //'T' with.
            myClass.GenericMethod<int>(5);
        }
    }
}