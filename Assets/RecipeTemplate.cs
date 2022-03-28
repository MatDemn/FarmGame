using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New recipe", menuName = "Recipe")]
public class RecipeTemplate : ScriptableObject
{
    public InvSlotItem ingredient;
    public InvSlotItem result;
}
