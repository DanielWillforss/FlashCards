using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class ValidateInput
{
    private static List<int> usedIndex = new List<int>();
    private static List<int> unusedIndex = new List<int>();
    private static int largestUsed = 0;

    public static int? ValidateUnusedIndex(string input)
    {
        int valueInput = ValidatePosInt(input) ?? 0;
        if(valueInput == 0 || usedIndex.Contains(valueInput))
        {
            return null;
        }
        else
        {
            usedIndex.Add(valueInput);
            if(valueInput > largestUsed)
            {
                for(int i = largestUsed + 1; i < valueInput; i++)
                {
                    unusedIndex.Add(i);
                }
                largestUsed = valueInput;
            }
            else if(valueInput < largestUsed)
            {
                unusedIndex.Remove(valueInput);
            }
            return valueInput;
        }
    }

    public static bool RemoveIndex(int index)
    {
        bool removed = usedIndex.Remove(index);
        if(removed)
        {
            unusedIndex.Add(index);
        }
        return removed;
    }

    public static int GetAndUseNewUnusedIndex()
    {
        int newIndex;
        if(unusedIndex.Count > 0)
        {
            newIndex = unusedIndex[0];
            unusedIndex.Remove(newIndex);
            usedIndex.Add(newIndex);
        }
        else
        {
            newIndex = largestUsed + 1;
            largestUsed++;
            usedIndex.Add(newIndex);
        }
        return newIndex;
    }

    public static int? ValidatePosInt(string input)
    {
        int? validatedInt = ValidateInt(input);
        
        if(validatedInt > 0)
        {
            return validatedInt;
        }
        return null;
    }

    public static int? ValidateInt(string input)
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
        return validatedInt;
    }

    public static string ValidateGeneralString(string input)
    {
        if (input == null || input == "" || input.Contains("*"))
        {
            return null;
        }
        return input;
    }

    public static bool? ValidateBoolean(string input)
    {
        int valueInput = ValidateInt(input) ?? -1;
        if(valueInput == 0)
        {
            return false;
        }
        else if(valueInput == 1)
        {
            return true;
        }
        else
        {
            return null;
        }
    }
}
