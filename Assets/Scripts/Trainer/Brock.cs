using System.Collections.Generic;
using UnityEngine;

public class Brock : Human
{
    public Brock() {
        humanName = "Pierre";
    }
    
    public new void SetPokemonTeam(List<Pokemon> pokemons) {
        Debug.Log("Pierre ne peut pas avoir de pokémons");
        return;
    }

    public new List<Pokemon> GetPokemonTeam() {
        Debug.Log("Pierre ne peut pas avoir de pokémons");
        return null;
    }

    public new void LaunchPokemon(Pokemon pokemon) {
        Debug.Log("Pierre ne peut pas avoir de pokémons");
        return;
    }

    public void CookForPokemon(List<Pokemon> ashPokemon, List<Pokemon> mistyPokemon) {
        for (int i = 0; i < ashPokemon.Count; i++) {
            ashPokemon[i].ReceiveHeal(20);
            if (!ashPokemon[i].isKO) {
                Debug.Log("Pierre soigne 20 PV pour " + ashPokemon[i].pkmnName + " de Sasha. Il a " + ashPokemon[i].currentHp + " PV");
                break;
            }
        }
        for (int i = 0; i < mistyPokemon.Count; i++) {
            mistyPokemon[i].ReceiveHeal(20);
            if (!mistyPokemon[i].isKO) {
                Debug.Log("Pierre soigne 20 PV pour " + mistyPokemon[i].pkmnName + " d'Ondine. Il a " + mistyPokemon[i].currentHp + " PV");
                break;
            }  
        }
    }

    public void FullHeal(Pokemon pokemon) {
        pokemon.ReceiveHeal(pokemon.maxHp);
        if (!pokemon.isKO) {
            Debug.Log("Pierre soigne tous les PV de " + pokemon.pkmnName + " de " + pokemon.originalTrainer.humanName + " !");
        }
    }
}
