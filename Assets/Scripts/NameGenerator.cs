using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{

    private static string[] first = new string[]
    {
        "Idiotic",
        "Stupid",
        "Dumb",
        "Gamer",
    };

    private static string[] last = new string[]
    {
        "Dog",
        "Cat",
        "Owl",
        "Bird",
        "Giraffe",
        "Eel",
        "Chair",
        "Couch",
    };

    public static string GenerateName()
    {
        string firstName = first[Random.Range(0, first.Length - 1)];
        string lastname = last[Random.Range(0, last.Length - 1)];

        return firstName + lastname;
    }

}
