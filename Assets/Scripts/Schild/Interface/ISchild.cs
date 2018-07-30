using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISchild {

    void ActivateSchild();
    void DeactivateSchild();
    void DamageSchild(int amount);
    void HitBySchild(int amount);
    void ShieldSetUp();
}
