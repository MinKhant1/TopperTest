﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGarbage : MonoBehaviour
{

    private void Update()
    {
        Destroy(gameObject, 2);
    }

}
