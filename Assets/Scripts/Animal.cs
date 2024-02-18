using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }

    // Constructor
    public Animal(string name, int age, string species)
    {
        Name = name;
        Age = age;
        Species = species;
    }

    // Method to make the animal make a sound
    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a sound.");
    }

    // Method to display information about the animal
    public virtual void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Species: {Species}");
    }
}


