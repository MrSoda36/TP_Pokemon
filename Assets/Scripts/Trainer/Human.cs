using System.Collections.Generic;
using UnityEngine;

public abstract class Human
{
    public string humanName { get; protected set; }
    protected List<Pokemon> pokemonTeam;

    public void SetPokemonTeam(List<Pokemon> pokemons) {
        pokemonTeam = pokemons;
        for (int i = 0; i < pokemonTeam.Count; i++) {
            pokemonTeam[i].OnKO += Notify;
            pokemonTeam[i].SetOriginalTrainer(this);
        }
    }

    public List<Pokemon> GetPokemonTeam() {
        return pokemonTeam;
    }

    public void LaunchPokemon(Pokemon pokemon) {
        Debug.Log(humanName + " choisi " + pokemon.pkmnName);
        pokemon.GoInBattle();
    }

    void Notify(Pokemon pokemon) {
        Debug.Log("Le " + pokemon.pkmnName + " de " + humanName + " n'est plus en etat de se battre.");
        for (int i = 0; i < pokemonTeam.Count; i++) {
            if (!pokemonTeam[i].isKO) {
                LaunchPokemon(pokemonTeam[i]);
            }
        }
    }
}
