using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class Squirtle : Pokemon
{
    public Squirtle() {
        pkmnName = "Carapuce";
        maxHp = 100;
        currentHp = maxHp;
        atk = 50;
        def = 60;
        spd = 50;
        type = PokemonType.Water;
        isKO = false;
        isInPokeball = true;
    }

    public override void AtkSpecial(Pokemon target) {
        WaterGun(target);
    }

    public void WaterGun(Pokemon target) {
        if (target == null) {
            Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " n'a pas de cible valide");
            return;
        }
        if (target.originalTrainer.Equals(this.originalTrainer)) {
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
        Debug.Log("Le " + pkmnName + " de " + originalTrainer.humanName + " lance Pistolet à O");
        target.TakeDamage(atk * 0.9f, PokemonType.Water);
    }
}
