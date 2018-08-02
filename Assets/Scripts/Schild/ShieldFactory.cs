using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFactory {

    public ISchild GetSchild(Utility.ShieldType schildType,GameObject schildObj)
    {

        switch (schildType)
        {
            case Utility.ShieldType.InstantSchild:
                InstantSchild instantSchild = schildObj.GetComponent<InstantSchild>();
             
                return  instantSchild;

            case Utility.ShieldType.PowerSchild:
                return new PowerSchild();

            default:
                return new InstantSchild();
        }
    }

}
