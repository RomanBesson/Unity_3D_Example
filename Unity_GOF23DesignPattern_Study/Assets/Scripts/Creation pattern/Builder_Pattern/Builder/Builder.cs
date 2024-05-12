using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Builder {

    public abstract void BuildAudios();
    public abstract void BuildEffects();
    public abstract void BuildBloodBar();
    public abstract GameObject GetResult();
}
