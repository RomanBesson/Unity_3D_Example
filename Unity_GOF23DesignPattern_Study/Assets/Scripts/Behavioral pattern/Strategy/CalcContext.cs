using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcContext {

    private Calc calc;

    public CalcContext(Calc calc)
    {
        this.calc = calc;
    }

    public int Operation(int numA, int numB)
    {
        return calc.Operation(numA, numB);
    }
}
