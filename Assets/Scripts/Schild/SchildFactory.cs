using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchildFactory {

    public ISchild GetSchild(Utility.SchildTypes schildType,GameObject schildObj)
    {

        switch (schildType)
        {
            case Utility.SchildTypes.InstantSchild:
                InstantSchild instantSchild = schildObj.GetComponent<InstantSchild>();
             
                return  instantSchild;

            case Utility.SchildTypes.PowerSchild:
                return new PowerSchild();

            default:
                return new InstantSchild();
        }
    }

}
