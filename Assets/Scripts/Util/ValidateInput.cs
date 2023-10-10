using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValidateInput
{
    public static int? ValidatePosInt(string input)
    {
        int validatedInt = 0;
        try
        {
            validatedInt = Int32.Parse(input);
        }
        catch (FormatException)
        {
            return null;
        }

        if(validatedInt > 0)
        {
            return validatedInt;
        }
        return null;
    }

    public static string ValidateGeneralString(string input)
    {
        if (input == null || input == "" || input.Contains("*"))
        {
            return null;
        }
        return input;
    }
}
