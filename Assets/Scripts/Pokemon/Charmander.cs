using UnityEngine;

public class Charmander : Pokemon
{
    public Charmander() {
        pkmnName = "Salamèche";
        maxHp = 100;
        currentHp = maxHp;
        atk = 60;
        def = 40;
        spd = 60;
        type = PokemonType.Fire;
        isKO = false;
        isInPokeball = true;
    }

    public override void AtkSpecial(Pokemon target) {
        Flammeche(target);
    }

    public void Flammeche(Pokemon target) {
        if (target == null) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'a pas de cible valide");
            return;
        }
        if (target.originalTrainer == this.originalTrainer) {
            Debug.Log("Le Pokémon ne peut pas se viser soi-même");
        }
        if (isInPokeball) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " est dans sa pokéball");
            return;
        }
        if (isKO) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'est plus en etat de se battre.");
            return;
        }
        Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " lance Flammèche");
        target.TakeDamage(atk, PokemonType.Fire);
    }
}
