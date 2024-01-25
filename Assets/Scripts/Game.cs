using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Pokemons
    private string[] pokemonsNames = new string[] { "charmander", "squirtle", "bulbasaur" };

    // Humans
    private Ash ash;
    private Misty misty;
    private Brock brock;

    // Setup
    [SerializeField] private int terrain;

    void Start()
    {
        SetupGame(terrain);

        ash.LaunchPokemon(ash.GetPokemonTeam()[0]);
        misty.LaunchPokemon(misty.GetPokemonTeam()[0]);

        ash.GetPokemonTeam()[0].Charge(misty.GetPokemonTeam()[0]);
        misty.GetPokemonTeam()[0].Charge(ash.GetPokemonTeam()[0]);

        ash.GetPokemonTeam()[0].AtkSpecial(misty.GetPokemonTeam()[0]);
        misty.GetPokemonTeam()[0].AtkSpecial(ash.GetPokemonTeam()[0]);

        brock.FullHeal(ash.GetPokemonTeam()[0]);
        misty.GetPokemonTeam()[1].Charge(ash.GetPokemonTeam()[0]);

        ash.GetPokemonTeam()[0].AtkSpecial(misty.GetPokemonTeam()[0]);
        brock.FullHeal(misty.GetPokemonTeam()[0]);
    }

    void SetupGame(int terrain) {
        // Set seeds
        Random.InitState(terrain);

        // Create humans
        ash = new Ash();
        misty = new Misty();
        brock = new Brock();

        // Give pokemons to humans
        List<Pokemon> ashPokemons = new List<Pokemon>();
        for (int i = 0; i < 2; i++) {
            string newPkmnName = pokemonsNames[Random.Range(0,2)];
            switch (newPkmnName) {
                case "charmander":
                    ashPokemons.Add(new Charmander());
                    break;
                case "squirtle":
                    ashPokemons.Add(new Squirtle());
                    break;
                case "bulbasaur":
                    ashPokemons.Add(new Bulbasaur());
                    break;
            }
        }
        ash.SetPokemonTeam(ashPokemons);

        Debug.Log(ash.humanName + " a " + ash.GetPokemonTeam().Count + " pokémons");
        Debug.Log(ash.humanName + " a " + ash.GetPokemonTeam()[0].pkmnName + " et " + ash.GetPokemonTeam()[1].pkmnName);

        List<Pokemon> mistyPokemons = new List<Pokemon>();
        for (int i = 0; i < 2; i++) {
            string newPkmnName = pokemonsNames[Random.Range(0, 2)];
            switch (newPkmnName) {
                case "charmander":
                    mistyPokemons.Add(new Charmander());
                    break;
                case "squirtle":
                    mistyPokemons.Add(new Squirtle());
                    break;
                case "bulbasaur":
                    mistyPokemons.Add(new Bulbasaur());
                    break;
            }
        }
        misty.SetPokemonTeam(mistyPokemons);

        Debug.Log(misty.humanName + " a " + misty.GetPokemonTeam().Count + " pokémons");
        Debug.Log(misty.humanName + " a " + misty.GetPokemonTeam()[0].pkmnName + " et " + misty.GetPokemonTeam()[1].pkmnName);

    }
}
