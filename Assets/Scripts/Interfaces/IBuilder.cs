using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public interface IBuilder<T>
{
    public abstract T Build();
}
